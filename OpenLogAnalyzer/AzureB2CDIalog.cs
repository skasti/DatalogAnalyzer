using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OpenLogAnalyzer.Extensions;
using OpenLogger.Analysis.Vehicle;

namespace OpenLogAnalyzer
{
    public partial class AzureB2CDIalog : Form
    {
        private AuthenticationResult AuthResult { get; set; }
        public AzureB2CDIalog()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            AuthenticationResult authResult = null;
            IEnumerable<IAccount> accounts = await Program.PublicClientApp.GetAccountsAsync();
            try
            {
                authResult = await Program.PublicClientApp.AcquireTokenInteractive(Program.Scopes)
                    .WithAccount(GetUserByPolicy(accounts, Program.PolicySignUpSignIn))
                    .WithPrompt(Prompt.SelectAccount)
                    .WithAuthority(Program.Authority)
                    .WithParentActivityOrWindow(this).ExecuteAsync();
            }
            catch (MsalServiceException ex)
            {
                try
                {
                    if (ex.Message.Contains("AADB2C90118"))
                    {
                        authResult = await Program.PublicClientApp.AcquireTokenInteractive(Program.Scopes)
                            .WithAccount(GetUserByPolicy(accounts, Program.PolicySignUpSignIn))
                            .WithPrompt(Prompt.SelectAccount)
                            .WithAuthority(Program.AuthorityResetPassword)
                            .WithParentActivityOrWindow(this).ExecuteAsync();
                    }
                    else
                    {
                        ResultText.Text = $"Error Acquiring Token:{Environment.NewLine}{ex}";
                    }
                }
                catch (Exception)
                {
                }
            }
            catch (Exception ex)
            {
                ResultText.Text = $"Users:{string.Join(",", accounts.Select(u => u.Username))}{Environment.NewLine}Error Acquiring Token:{Environment.NewLine}{ex}";
            }

            if (authResult != null)
            {
                //ResultText.Text = await GetHttpContentWithToken(App.ApiEndpoint, authResult.AccessToken);
                DisplayBasicTokenInfo(authResult);
                TestToken(authResult);

                AuthResult = authResult;
            }
        }

        private void AzureB2CDIalog_Load(object sender, EventArgs e)
        {

        }

        private void DisplayBasicTokenInfo(AuthenticationResult authResult)
        {
            TokenInfoText.Text = "";
            if (authResult != null)
            {
                TokenInfoText.Text += $"Name: {authResult.Account.Username}" + Environment.NewLine;
                TokenInfoText.Text += $"Token Expires: {authResult.ExpiresOn.ToLocalTime()}" + Environment.NewLine;
                TokenInfoText.Text += $"Access Token: {authResult.AccessToken}" + Environment.NewLine;
                TokenInfoText.Text += $"Id Token: {authResult.IdToken}" + Environment.NewLine;
                TokenInfoText.Text += $"Tenant Id: {authResult.TenantId}" + Environment.NewLine;
            }
        }

        private async void TestToken(AuthenticationResult authResult)
        {
            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

            // Call Web API again.
            var response = await httpClient.GetAsync("https://analyzerapi.azurewebsites.net/api/values");

            ResultText.Text += response.ToString();

            var content = await response.Content.ReadAsStringAsync();
            var contentObject = JsonConvert.DeserializeObject(content);
            ResultText.Text += $"\n\n{JsonConvert.SerializeObject(contentObject, Formatting.Indented)}";
        }

        private IAccount GetUserByPolicy(IEnumerable<IAccount> accounts, string policy)
        {
            foreach (var account in accounts)
            {
                string accountIdentifier = account.HomeAccountId.ObjectId.Split('.')[0];
                if (accountIdentifier.EndsWith(policy.ToLower())) return account;
            }

            return null;
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            if (AuthResult == null)
            {
                ResultText.Text += "\nNot logged in";
                return;
            }

            TestToken(AuthResult);
        }

        private async void test2Button_Click(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthResult.AccessToken);

            var url = $"https://analyzerapi.azurewebsites.net/api/values/{secretId.Text}";
            // Call Web API again.
            var response = await httpClient.GetAsync(url);

            ResultText.Text += response.ToString();

            var content = await response.Content.ReadAsStringAsync();
            ResultText.Text += $"\n\n{url}\n{content}";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            serializerSettings.TypeNameHandling = TypeNameHandling.Auto;

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthResult.AccessToken);

            var url = $"https://analyzerapi.azurewebsites.net/api/vehicles";
            var response = await httpClient.GetAsync(url);

            ResultText.Text += response.ToString();

            var vehicles = await response.Content.DeserializeJson<List<Vehicle>>();

            foreach (var vehicle in vehicles)
            {
                ResultText.Text += $"\nVehicle in Azure: {vehicle.Name} - {vehicle.Id}";
            }

            ResultText.Text += $"\n\n";

            var localNames = VehicleRepository.GetNames();

            var onlyLocals = localNames.Where(l => vehicles.All(v => v.Name != l)).Select(VehicleRepository.Get);
            
            foreach (var localVehicle in onlyLocals)
            {
                localVehicle.Id = Guid.NewGuid();

                var json = JsonConvert.SerializeObject(localVehicle, Formatting.Indented, serializerSettings);

                var v = JsonConvert.DeserializeObject<Vehicle>(json, serializerSettings);
                ResultText.Text += $"\nUploading Vehicle: {v.Name}";

                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var postResponse = await httpClient.PostAsync(url, content);

                if (postResponse.IsSuccessStatusCode)
                {
                    var newLocalVehicle = await postResponse.Content.DeserializeJson<Vehicle>();
                    VehicleRepository.Save(newLocalVehicle);

                    ResultText.Text += $"\nUploaded Vehicle: {newLocalVehicle.Name} - {newLocalVehicle.Id}";
                }
                else
                {
                    ResultText.Text += $"\nVehicle Upload Failed: {localVehicle.Name} - {postResponse.StatusCode}: {postResponse.ReasonPhrase}\n{await postResponse.Content.ReadAsStringAsync()}";
                    break;
                }
            }

            //ResultText.Text += $"\n\n{url}\n{content}";
        }
    }
}

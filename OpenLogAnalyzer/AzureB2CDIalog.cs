using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Identity.Client;

namespace OpenLogAnalyzer
{
    public partial class AzureB2CDIalog : Form
    {
        public AzureB2CDIalog()
        {
            InitializeComponent();
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

        private async void loginButton_Click(object sender, EventArgs e)
        {
            //AuthenticationResult authResult = null;
            //IEnumerable<IAccount> accounts = await Program.PublicClientApp.GetAccountsAsync();
            //try
            //{
            //    authResult = await Program.PublicClientApp.AcquireTokenAsync(Program.ApiScopes, GetUserByPolicy(accounts, Program.PolicySignUpSignIn), Prompt.SelectAccount, string.Empty, null, Program.Authority);
            //    DisplayBasicTokenInfo(authResult);
            //    UpdateSignInState(true);
            //}
            //catch (MsalServiceException ex)
            //{
            //    try
            //    {
            //        if (ex.Message.Contains("AADB2C90118"))
            //        {
            //            authResult = await Program.PublicClientApp.AcquireTokenAsync(Program.ApiScopes, GetUserByPolicy(accounts, Program.PolicySignUpSignIn), UIBehavior.SelectAccount, string.Empty, null, Program.AuthorityResetPassword);
            //        }
            //        else
            //        {
            //            ResultText.Text = $"Error Acquiring Token:{Environment.NewLine}{ex}";
            //        }
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ResultText.Text = $"Users:{string.Join(",", accounts.Select(u => u.Username))}{Environment.NewLine}Error Acquiring Token:{Environment.NewLine}{ex}";
            //}
        }
    }
}

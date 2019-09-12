using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Identity.Client;

namespace OpenLogAnalyzer
{
    static class Program
    {
        public static AuthenticationResult AuthResult { get; set; }
        private static string TenantName = "openlogger";
        private static string Tenant = "openlogger.onmicrosoft.com";
        private static string ClientId = "90821ce6-739a-4db4-9ba6-6a544253f406";
        public static string PolicySignUpSignIn = "B2C_1_SignUpIn";
        public static string PolicyEditProfile = "B2C_1_EditPolicy";
        public static string PolicyResetPassword = "B2C_1_PssReset";

        public static string[] Scopes = { "https://openlogger.onmicrosoft.com/analyzerapi/user_impersonation openid offline_access" };

        private static string BaseAuthority = "https://{tenantName}.b2clogin.com/tfp/{tenant}/{policy}/oauth2/v2.0/authorize";
        public static string Authority = BaseAuthority.Replace("{tenantName}", TenantName).Replace("{tenant}", Tenant).Replace("{policy}", PolicySignUpSignIn);
        public static string AuthorityEditProfile = BaseAuthority.Replace("{tenantName}", TenantName).Replace("{tenant}", Tenant).Replace("{policy}", PolicyEditProfile);
        public static string AuthorityResetPassword = BaseAuthority.Replace("{tenantName}", TenantName).Replace("{tenant}", Tenant).Replace("{policy}", PolicyResetPassword);

        public static IPublicClientApplication PublicClientApp { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PublicClientApp = PublicClientApplicationBuilder.Create(ClientId)
                .WithB2CAuthority(Authority)
                .Build();

            TokenCacheHelper.Bind(PublicClientApp.UserTokenCache);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static IAccount GetUserByPolicy(IEnumerable<IAccount> accounts, string policy)
        {
            foreach (var account in accounts)
            {
                string accountIdentifier = account.HomeAccountId.ObjectId.Split('.')[0];
                if (accountIdentifier.EndsWith(policy.ToLower())) return account;
            }

            return null;
        }
    }
}

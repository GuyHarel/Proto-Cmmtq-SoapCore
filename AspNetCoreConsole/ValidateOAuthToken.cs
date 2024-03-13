using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Protocols; 
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace AspNetCoreConsole
{
    public static class ValidateOAuthToken
    {
        public static void VAlidate()
        {
            var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IlhSdmtvOFA3QTNVYVdTblU3Yk05blQwTWpoQSIsImtpZCI6IlhSdmtvOFA3QTNVYVdTblU3Yk05blQwTWpoQSJ9.eyJhdWQiOiJhcGk6Ly84NDRkNDMxMC00MWUxLTRlMTEtODlmZS0wOGYzOTY4NDZhMjEiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC8xYTViYjI1Ny01Y2RjLTQzNGQtYjRjYy0yMGU0MjE4YjM2MzkvIiwiaWF0IjoxNzEwMzMwODc3LCJuYmYiOjE3MTAzMzA4NzcsImV4cCI6MTcxMDMzNDc3NywiYWlvIjoiRTJOZ1lPaVdhdmhrRWEzcXA3V1I4MHdVTjRzR0FBPT0iLCJhcHBpZCI6IjMwYzk1ZGZkLTZkMTAtNDFkYi1iNzFmLWI0MzE4NGVkNGUyNCIsImFwcGlkYWNyIjoiMSIsImlkcCI6Imh0dHBzOi8vc3RzLndpbmRvd3MubmV0LzFhNWJiMjU3LTVjZGMtNDM0ZC1iNGNjLTIwZTQyMThiMzYzOS8iLCJvaWQiOiI1ZWE3ZmQxYi1mM2ZiLTRiNDEtYTg5My1lZTdhNDA3OGIxNmUiLCJyaCI6IjAuQVRjQVY3SmJHdHhjVFVPMHpDRGtJWXMyT1JCRFRZVGhRUkZPaWY0STg1YUVhaUgxQUFBLiIsInJvbGVzIjpbIlJvdXRlQXBpIl0sInN1YiI6IjVlYTdmZDFiLWYzZmItNGI0MS1hODkzLWVlN2E0MDc4YjE2ZSIsInRpZCI6IjFhNWJiMjU3LTVjZGMtNDM0ZC1iNGNjLTIwZTQyMThiMzYzOSIsInV0aSI6ImwxZi1TUFZKN0V1VldaNjdGbnBQQUEiLCJ2ZXIiOiIxLjAifQ.Ci4pM5nPtG9isSxSFUKdxsfHr2HB15hWlJZyZA6J4qLmeCC4roPKuqsa9iZEyOtan-za-zDwcznuMsV2XTzCv50PV00JGCzv5JSxnEe9VLTpAYlsXo5IGo2a4-arPZLlxW9-HDvFw4GgB3nYu8UBSKdLFkviroGf0VIhSeOxp1udjbNNGP8O5idbUVOf9GnPyKzXjBDKHWOuazIasw0zb84BBZF9eYDMMYEL05H4lYN8hAD8bsOXUrYRyuZILwIDjZshEehMazVKoQcFXRvgSCdLlyfEzGZYmN5zhUWL4JspsNT2dF_Zp_oidckKTR2srkyrdA0Pb1jWUc8dyB5GgQ";
            var tenant_id = "1a5bb257-5cdc-434d-b4cc-20e4218b3639";
            var audience = "api://844d4310-41e1-4e11-89fe-08f396846a21/RouteApi"; // (obtenu dans IntraID/gh-ad-client.../Api autorisé/ clique sur RouteApi )
            var issuer  = $"https://sts.windows.net/{tenant_id}/";
            var secret = "h4s8Q~9Msr5KtwwG8B~zuy7vms.z3yOk.HXwycq_"; // dans gh-ad-client-NetCoreWebApi/certificat et secret
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
            var stsDiscoveryEndpoint = String.Format(CultureInfo.InvariantCulture, "https://login.microsoftonline.com/{0}/.well-known/openid-configuration", tenant_id);
            var configManager = new ConfigurationManager<OpenIdConnectConfiguration>(stsDiscoveryEndpoint, new OpenIdConnectConfigurationRetriever());
            var config = configManager.GetConfigurationAsync().Result;







        }
    }
}

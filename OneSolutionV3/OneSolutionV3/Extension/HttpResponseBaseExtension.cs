using System.Web;
using System.Web.Security;
using System.Security.Principal;
using Newtonsoft.Json;

namespace OneSolutionV3.Common.Extension
{
    public static class HttpResponseBaseExtension
    {
        public static int SetAuthCookie<T>(this HttpResponseBase responseBase, string name, bool rememberMe, T userData)
        {
            var cookie = FormsAuthentication.GetAuthCookie(name, rememberMe);
            var ticket = FormsAuthentication.Decrypt(cookie.Value);

            var stringified = Newtonsoft.Json.JsonConvert.SerializeObject(userData);
            var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, stringified, ticket.CookiePath);
            var encryptedTicket = FormsAuthentication.Encrypt(newTicket);

            cookie.Value = encryptedTicket;
            responseBase.Cookies.Add(cookie);
            
            return encryptedTicket.Length;
        }

        public static T GetAuthCookie<T>(IIdentity identity)
        {
            var userData = ((FormsIdentity)identity).Ticket.UserData;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(userData);
        }
    }
}

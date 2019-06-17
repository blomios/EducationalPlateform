using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using LO54_Projet.Models;
using LO54_Projet.Tools;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using LO54_Projet.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace LO54_Projet.Models
{
    // Vous pouvez ajouter des données d'utilisateur pour l'utilisateur en ajoutant d'autres propriétés à votre classe d'utilisateur. Pour en savoir plus, visitez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Role { get; set; }
        
        public List<UserSharedUV> UserSharedUVs { get; set; }
        public List<User_Quizz> QuizzTaken { get; set; }

        public ApplicationUser() : base()
        {
            Nom = "";
            Prenom = "";
            CustomRoles cr = new CustomRoles();
            Role = cr.getProf();
            
        }

        public ApplicationUser(string nom, string prenom) : base()
        {
            Nom = nom;
            Prenom = prenom;
            Role = CustomRoles.roles.Etud.ToString();
        }

        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            // Notez que l'authenticationType doit correspondre à celui défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter des revendications utilisateur personnalisées ici
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }

        public bool HasAccessToUV(int uvId)
        {
            return UserSharedUVs.Exists(u => u.UVId == uvId);
        }

        public bool TookQuizz(int idQuizz)
        {
            return QuizzTaken.Exists(q => q.QuizzId == idQuizz);
        }
    }

    
}

#region Modules d'aide
namespace LO54_Projet
{
    public static class IdentityHelper
    {
        // Utilisés pour XSRF lors de la liaison de logins externes
        public const string XsrfKey = "XsrfId";

        public const string ProviderNameKey = "providerName";
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request.QueryString[ProviderNameKey];
        }

        public const string CodeKey = "code";
        public static string GetCodeFromRequest(HttpRequest request)
        {
            return request.QueryString[CodeKey];
        }

        public const string UserIdKey = "userId";
        public static string GetUserIdFromRequest(HttpRequest request)
        {
            return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
        }

        public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
        {
            var absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
        {
            var absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
    }
}
#endregion

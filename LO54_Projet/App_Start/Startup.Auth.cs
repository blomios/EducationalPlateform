using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Google;
using Owin;
using LO54_Projet.Models;
using LO54_Projet.Repository;

namespace LO54_Projet
{
    public partial class Startup {

        // Pour plus d'informations sur la configuration de l'authentification, visitez https://go.microsoft.com/fwlink/?LinkId=301883
        public void ConfigureAuth(IAppBuilder app)
        {
            //Configurer le contexte de base de données, le gestionnaire des utilisateurs et le gestionnaire des connexions pour utiliser une instance unique par demande
            app.CreatePerOwinContext(IdentityDb.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Laisser l'application utiliser un cookie pour stocker les informations de l'utilisateur connecté
            // et d'utiliser un cookie pour stocker temporairement des informations sur une connexion utilisateur avec un fournisseur de connextion tiers
            // Configurer le cookie d'inscription
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            // Utilisez un cookie pour stocker temporairement des informations sur une connexion utilisateur avec un fournisseur de connexion tiers
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Permet à l'application de stocker temporairement les informations utilisateur lors de la vérification du second facteur dans le processus d'authentification à 2 facteurs.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Permet à l'application de mémoriser le second facteur de la vérification, un numéro de téléphone ou un e-mail par exemple.
            // Lorsque vous sélectionnez cette option, votre seconde étape de vérification lors du processus de connexion est mémorisée sur le poste à partir duquel vous vous êtes connecté.
            // Ceci est similaire à l'option RememberMe lors de la connexion.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Décommenter les lignes suivantes pour activer la connexion avec des fournisseurs de connexion tiers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}

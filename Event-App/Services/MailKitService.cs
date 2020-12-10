using Event_App.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util;
using Google.Apis.Util.Store;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading;
using System.Threading.Tasks;

namespace Event_App.Services
{
    public class MailKitService
    {
        public async Task SendEmail(Person person, string email)
        {
            await EmailContestantAsync(person, email);
        }

        /// <summary>
        /// Utilizes MailKit and Google APIs to send an email
        /// </summary>
        /// <param name="person">User's Email</param>
        /// <returns></returns>
        private async Task EmailContestantAsync(Person person, string email)
        {
            const string GMailAccount = "throwmeawaybreakingben@gmail.com";

            var clientSecrets = new ClientSecrets
            {
                ClientId = Services.AuthKeys.Google_OAuth,
                ClientSecret = Services.AuthKeys.Google_Client,
            };

            var codeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                DataStore = new FileDataStore("CredentialCacheFolder", false),
                Scopes = new[] { "https://mail.google.com/" },
                ClientSecrets = clientSecrets
            });

            // Note: For a web app, you'll want to use AuthorizationCodeWebApp instead.
            var codeReceiver = new LocalServerCodeReceiver();
            var authCode = new AuthorizationCodeInstalledApp(codeFlow, codeReceiver);

            var credential = await authCode.AuthorizeAsync(GMailAccount, CancellationToken.None);

            if (credential.Token.IsExpired(SystemClock.Default))
                await credential.RefreshTokenAsync(CancellationToken.None);

            var oauth2 = new SaslMechanismOAuth2(credential.UserId, credential.Token.AccessToken);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Happnin", "Confirmation@Happnin.com"));
            message.To.Add(new MailboxAddress($"{email}", email));
            message.Subject = "Please Confirm";

            message.Body = new TextPart("plain")
            {
                Text = "this email confirms that you are registered for this event!" 
                       //somekind of confirm button here
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);

                // use the OAuth2.0 access token obtained above

                client.Authenticate(oauth2);

                client.Send(message);
                client.Disconnect(true);
            }
        }


    }
}

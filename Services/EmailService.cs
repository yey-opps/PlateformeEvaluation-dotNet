using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Services
{
    public interface IEmailService
    {
        Task EnvoyerEmailValidationAsync(string destinataire, string nomCandidat, string lienTest);
        Task EnvoyerEmailEntretienAsync(string destinataire, string nomCandidat, DateTime dateEntretien, string typeEntretien, string lieu);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task EnvoyerEmailValidationAsync(string destinataire, string nomCandidat, string lienTest)
        {
            var smtpHost = _configuration["Email:SmtpHost"];
            var smtpPort = int.Parse(_configuration["Email:SmtpPort"]);
            var smtpUser = _configuration["Email:SmtpUser"];
            var smtpPassword = _configuration["Email:SmtpPassword"];
            var fromEmail = _configuration["Email:FromEmail"];
            var fromName = _configuration["Email:FromName"];

            var message = new MailMessage
            {
                From = new MailAddress(fromEmail, fromName),
                Subject = "? Votre candidature a été validée - HireDesk",
                Body = $@"
                    <!DOCTYPE html>
                    <html>
                    <head>
                        <meta charset=""UTF-8"">
                    </head>
                    <body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333;'>
                        <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #e5e7eb; border-radius: 10px;'>
                            <h2 style='color: #10b981;'>?? Félicitations {nomCandidat} !</h2>
                            <p>Votre CV a été validé par notre équipe RH.</p>
                            <p>Vous êtes maintenant éligible pour passer nos tests d'évaluation.</p>
                            
                            <div style='background: #f0f9ff; padding: 15px; border-radius: 8px; margin: 20px 0;'>
                                <p style='margin: 0; font-weight: 600;'>?? Prochaine étape :</p>
                                <p style='margin: 10px 0 0 0;'>Connectez-vous pour passer vos évaluations :</p>
                                <a href='{lienTest}' style='display: inline-block; margin-top: 15px; padding: 12px 24px; background: #10b981; color: white; text-decoration: none; border-radius: 8px; font-weight: 600;'>
                                    Accéder aux tests
                                </a>
                            </div>

                            <p style='color: #6b7280; font-size: 14px; margin-top: 20px;'>
                                Bonne chance ! ??<br>
                                L'équipe HireDesk
                            </p>
                        </div>
                    </body>
                    </html>
                ",
                IsBodyHtml = true,
                SubjectEncoding = Encoding.UTF8,
                BodyEncoding = Encoding.UTF8
            };

            message.To.Add(destinataire);

            using var smtpClient = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(smtpUser, smtpPassword),
                EnableSsl = true
            };

            await smtpClient.SendMailAsync(message);
        }

        public async Task EnvoyerEmailEntretienAsync(string destinataire, string nomCandidat, DateTime dateEntretien, string typeEntretien, string lieu)
        {
            var smtpHost = _configuration["Email:SmtpHost"];
            var smtpPort = int.Parse(_configuration["Email:SmtpPort"]);
            var smtpUser = _configuration["Email:SmtpUser"];
            var smtpPassword = _configuration["Email:SmtpPassword"];
            var fromEmail = _configuration["Email:FromEmail"];
            var fromName = _configuration["Email:FromName"];

            var message = new MailMessage
            {
                From = new MailAddress(fromEmail, fromName),
                Subject = "?? Votre entretien a été programmé - HireDesk",
                Body = $@"
                    <!DOCTYPE html>
                    <html>
                    <head>
                        <meta charset=""UTF-8"">
                    </head>
                    <body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333;'>
                        <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #e5e7eb; border-radius: 10px;'>
                            <h2 style='color: #3b82f6;'>Félicitations {nomCandidat} !</h2>
                            <p>Nous sommes ravis de vous informer qu'un entretien a été programmé avec notre équipe.</p>
                            
                            <div style='background: #dbeafe; padding: 20px; border-radius: 8px; margin: 20px 0;'>
                                <h3 style='margin-top: 0; color: #1e40af;'>Détails de l'entretien</h3>
                                <p style='margin: 8px 0;'><strong>?? Date et heure :</strong> {dateEntretien:dd/MM/yyyy à HH:mm}</p>
                                <p style='margin: 8px 0;'><strong>?? Type d'entretien :</strong> {typeEntretien}</p>
                                <p style='margin: 8px 0;'><strong>?? Lieu :</strong> {lieu}</p>
                            </div>

                            <div style='background: #f0f9ff; padding: 15px; border-radius: 8px; margin: 20px 0;'>
                                <p style='margin: 0; font-weight: 600; color: #1e40af;'>?? Conseils pour l'entretien :</p>
                                <ul style='margin: 10px 0; padding-left: 20px; color: #374151;'>
                                    <li>Préparez vos réponses sur vos expériences professionnelles</li>
                                    <li>Renseignez-vous sur notre entreprise</li>
                                    <li>Préparez des questions à nous poser</li>
                                    <li>Soyez à l'heure (ou connecté 5 minutes avant si visio)</li>
                                </ul>
                            </div>

                            <p style='color: #6b7280; font-size: 14px; margin-top: 20px;'>
                                Nous avons hâte de vous rencontrer !<br>
                                L'équipe HireDesk
                            </p>
                        </div>
                    </body>
                    </html>
                ",
                IsBodyHtml = true,
                SubjectEncoding = Encoding.UTF8,
                BodyEncoding = Encoding.UTF8
            };

            message.To.Add(destinataire);

            using var smtpClient = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(smtpUser, smtpPassword),
                EnableSsl = true
            };

            await smtpClient.SendMailAsync(message);
        }
    }
}
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Instagram.Service.NotificationAPI.Utils {

    public class SmtpClientService {
        public static void SendMail(string title, string to, string subject, string body) {
            try {
                // Specify the SMTP server details
                string smtpHost = "smtp.gmail.com"; // Replace with your SMTP server
                int smtpPort = 587; // Replace with your SMTP port

                // Create the SmtpClient object
                using (SmtpClient client = new SmtpClient(smtpHost, smtpPort)) {
                    // Provide your email and password for authentication
                    string username = "randomhubonline@gmail.com"; // Your email address
                    string password = "cqnuyrvexehsggww"; // Your email password

                    client.Credentials = new NetworkCredential(username, password);
                    client.EnableSsl = true; // Enable SSL for secure communication

                    // Log the SMTP server details
                    Console.WriteLine($"Connecting to SMTP server: {smtpHost}:{smtpPort}");

                    // Create the MailMessage object
                    MailAddress sendFrom = new MailAddress(username, title, Encoding.UTF8); // Ensure the 'From' address matches the authenticated email
                    MailAddress sendTo = new(to);
                    MailMessage message = new MailMessage {
                        From = sendFrom,
                        Subject = subject,
                        Body = body + Environment.NewLine + new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' }),
                        BodyEncoding = Encoding.UTF8,
                        SubjectEncoding = Encoding.UTF8,
                        IsBodyHtml = true // Set to true if the body contains HTML content
                    };
                    message.To.Add(sendTo);
                }
            } catch (SmtpException ex) {
                // Handle SMTP-related exceptions
                Console.WriteLine($"SMTP Exception: {ex.Message}");
            } catch (Exception ex) {
                // Handle general exceptions
                Console.WriteLine($"General Exception: {ex.Message}");
            }
        }
    }
}

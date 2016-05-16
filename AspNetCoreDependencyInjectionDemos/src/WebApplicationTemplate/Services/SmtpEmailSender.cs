using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApplicationTemplate.Services
{
	public class SmtpEmailSender : IEmailSender
	{
		public Task SendEmailAsync(string email, string subject, string message)
		{
			var smtpClient = new SmtpClient();
			smtpClient.Host = "mx.havit.cz";
			return smtpClient.SendMailAsync("no-reply@havit.cz", email, subject, message);
		}
	}
}
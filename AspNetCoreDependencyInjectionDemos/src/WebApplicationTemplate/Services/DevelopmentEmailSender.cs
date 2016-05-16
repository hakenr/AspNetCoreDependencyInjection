using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTemplate.Services
{
	public class DevelopmentEmailSender : IEmailSender
	{
		public Task SendEmailAsync(string email, string subject, string message)
		{
			Debug.WriteLine($"EMAIL:: To: {email}, Subject: {subject}, Message: {message}");

			return Task.FromResult(0);
		}
	}
}
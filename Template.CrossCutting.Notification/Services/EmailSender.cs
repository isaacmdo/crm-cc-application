using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.CrossCutting.Notification.Interfaces;
using Template.CrossCutting.Notification.ViewModels;

namespace Template.CrossCutting.Notification.Services
{
    public class EmailSender : IEmailSender
	{
		private readonly EmailConfiguration _emailConfig;

		public EmailSender(EmailConfiguration emailConfig)
		{
			_emailConfig = emailConfig;
		}

		private string GetMessage(string code)
		{
			return code switch
			{
				"ACCOUNT-CREATED" => "Bem-vindo {0} <br/><br/> Sua conta foi criada com sucesso.<br/>" +
                "Por favor, ative-o no link abaixo: {1}<br/><br/><b>Template</b> <br/> ",
				"FORGOT-PASSWORD" => "Olá {0} <br/><br/> O código para alterar a senha é: <b>{1}</ b><br/><br/><b>Template</b> <br/> ",
				"PASSWORD-CHANGED" => "Olá {0} <br/><br/> Sua senha foi alterada com sucesso.<br/><br/><b> Template </b> <br/> ",
				_ => "",
			};
		}

		public void SendEmail(EmailViewModel message, IEnumerable<string> parameters)
		{
			var emailMessage = CreateEmailMessage(message, parameters);

			Send(emailMessage);
		}

		public async Task SendEmailAsync(EmailViewModel message, IEnumerable<string> parameters)
		{
			var mailMessage = CreateEmailMessage(message, parameters);

			await SendAsync(mailMessage);
		}

		private MimeMessage CreateEmailMessage(EmailViewModel message, IEnumerable<string> parameters)
		{
			var emailMessage = new MimeMessage();
			emailMessage.From.Add(new MailboxAddress("Template", _emailConfig.From));
			emailMessage.To.AddRange(message.Recipients);
			emailMessage.Subject = message.Subject;

			string bodyFormatted = string.Format(GetMessage(message.Code), parameters.Select(x => x.ToString()).ToArray());

			var bodyBuilder = new BodyBuilder { HtmlBody = bodyFormatted };

			emailMessage.Body = bodyBuilder.ToMessageBody();
			return emailMessage;
		}

		private void Send(MimeMessage mailMessage)
		{
			using var client = new SmtpClient();
			try
			{
				client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
				client.AuthenticationMechanisms.Remove("XOAUTH2");
				client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

				client.Send(mailMessage);
			}
			catch (Exception ex)
			{

			}
			finally
			{
				client.Disconnect(true);
				client.Dispose();
			}
		}

		private async Task SendAsync(MimeMessage mailMessage)
		{
			using var client = new SmtpClient();
			try
			{
				await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.StartTls);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
				await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

				await client.SendAsync(mailMessage);
			}
			catch (Exception ex)
			{

			}
			finally
			{
				await client.DisconnectAsync(true);
				client.Dispose();
			}
		}
	}
}

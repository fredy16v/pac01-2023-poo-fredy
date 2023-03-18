using Portafolio.Interfaces;
using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Servicios
{
	public class ServicioEmailSendGrid : IServicioEmail
	{
		private readonly IConfiguration configuration;

		public ServicioEmailSendGrid(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public async Task Enviar(ContactoViewModel contactoViewModel)
		{
			var apikey = configuration.GetValue<string>("SENDGRID_APY_KEY");
			var email = configuration.GetValue<string>("SENDGRID_FROM");
			var nombre = configuration.GetValue<string>("SENDGRID_NOMBRE");

			var cliente = new SendGridClient(apikey);
			var from = new EmailAddress(email, nombre);
			var subject = $"El cliente{contactoViewModel.Email} quiere contactarte.";
			var to = new EmailAddress(email, nombre);
			var mensajeTextoPlano = contactoViewModel.Mensaje;
			var contenidoHtml = $@"De: {contactoViewModel.Nombre}
			Email: {contactoViewModel.Email}
			Mensaje: {contactoViewModel.Mensaje}";

			var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, mensajeTextoPlano, contenidoHtml);
			var respuesta = await cliente.SendEmailAsync(singleEmail);
		}
	}
}

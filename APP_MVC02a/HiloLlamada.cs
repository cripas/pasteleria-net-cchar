using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using Twilio;
using APP_MVC02a.Models;

namespace APP_MVC02a.hilos
{
    public class HiloLlamada
    {

        pedido ped;
        public HiloLlamada(pedido ped)
        {
            this.ped = ped;
        }

        public void lanzar()
        {
            try
            {
                // Find your Account Sid and Auth Token at twilio.com/user/account 
                string AccountSid = "AC5ee97f763eb14e6754a03570fcd1b269";
                string AuthToken = "3fec4bfd5ff5cd6379df62ac78a0e460";
                var twilio = new TwilioRestClient(AccountSid, AuthToken);

                string url = "http://tiendapasteleria.esy.es/texttospeechc.php?Message%5B0%5D=";
                url += "Estimado " + ped.contacto_nom + " " + ped.contacto_ape + " este es un mensaje de la pasteleria San Elias. Le Notificamos que su pedido numero " + ped.idpedido + " esta " + ped.estado.descrip + " .Que tenga un buen dia";
                url = url.Replace(" ", "%20");

                // Build the parameters 
                var options = new CallOptions();
                options.Url = url;
                options.To = "+51" + "979085281";
                options.From = "+12019890396";


                var call = twilio.InitiateOutboundCall(options);
                Console.WriteLine(call.Sid);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
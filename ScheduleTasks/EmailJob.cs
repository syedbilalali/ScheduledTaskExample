using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using Quartz;
using System.Threading.Tasks;

namespace ScheduledTaskExample.ScheduleTasks
{
    public class EmailJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            System.Diagnostics.Debug.WriteLine("On Executing the Mail --->");
            using (var message = new MailMessage("syedbilalali.dev@gmail.com", "praveen@younggeeks.in"))
            {
                message.Subject = "Test";
                message.Body = "Test at " + DateTime.Now;
                using (SmtpClient client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("syedbilalali.dev@gmail.com", "syedbilal999")
                })
               
                    client.Send(message);
                
            }
            System.Diagnostics.Debug.WriteLine("On Sent the Mail --->");
        }
    }
}
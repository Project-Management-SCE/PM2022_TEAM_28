using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebHoly.Data;
using WebHoly.Models;
using WebHoly.Service;

namespace WebHoly.Jobs
{
    [DisallowConcurrentExecution]
    public class PaymentJob : IJob
    {
        private readonly ILogger<PaymentJob> _logger;
        private readonly ApplicationDbContext _context;
        public IEmailSender _emailSender { get; }

        public PaymentJob(ILogger<PaymentJob> logger , ApplicationDbContext context, IEmailSender emailSender)
        {
            _logger = logger;
            _context = context;
            _emailSender = emailSender;

        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("PaymentJob Start");
            DateTime dateTime = DateTime.Now;
            var sub = _context.HolySubscription.Include(x => x.Payment).ToList();
            var payments = _context.Payment.ToList();
            foreach(var item in sub.SelectMany(x => x.Payment).OrderBy(x => x.PaymentDate))
            {
                if (item.PaymentDate.AddMonths(months: 1) < dateTime)
                {
                    var holyPayment = new Payment
                    {
                        Aproved = true,
                        HolySubscriptionId = item.HolySubscriptionId,
                        ReceptionNumber = RecipteNumber(),
                        PaymentDate = DateTime.Now,
                        Price = 199,
                    };
                    _context.Payment.Add(holyPayment);

                    _context.SaveChanges();
                    var user = _context.Users.Where(x => x.Id == sub.FirstOrDefault().UserId).FirstOrDefault();
                    string body = "<html> <body dir='rtl'>" +

                " <h2> שלום " + sub.FirstOrDefault().FirstName + " WebHoly</h2>" +
                "<span> הסכום ששולם : " + holyPayment.Price + "  בתאריך : " + holyPayment.PaymentDate + "</span> " +
                "<strong> מספר קבלה :" + holyPayment.ReceptionNumber + "</strong>" +
                "</body></html>";
                    var message = new Message(new string[] { user.Email }, "קבלה WebHoly ", body);
                    _emailSender.SendEmail(message);
                }
            }


            _logger.LogInformation("PaymentJob End");

            return Task.CompletedTask;
        }

        public int RecipteNumber()
        {
            var payment = _context.Payment.OrderBy(x => x.PaymentDate).Select(x => x.ReceptionNumber).FirstOrDefault();
            return payment + 1;
        }
    }
}
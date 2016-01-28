using Feedbapp.Entities;
using System;
using System.Threading.Tasks;

namespace Feedbapp.ViewModels
{
    public class RequestViewModel : BaseReqOffViewModel
    {
        public RequestViewModel() : base()
        {
            buttonText = "Solicitar Feedback";
            PageTitle = "Solicitar Feedback";
            comments = "Me gustaría pedirte feedback!";
        }

        public override string getSentText()
        {
            if (this.SelectedRecipient != null)
            {
                return "Se le ha enviado una solicitud a " + this.SelectedRecipient.firstName + " " + this.SelectedRecipient.lastName + " para agendar una instancia de feedback. Recibirás una notificación por mail.";
            }
            return string.Empty;
        }

        internal override async Task<bool> Send()
        {
            int sId = SelectedIndexSender;
            int rId = SelectedIndexRecipient;
            string comm = Comments;
            Requested r = new Requested() { senderId = this.SelectedSender.userId, recipientId = this.SelectedRecipient.userId, sender = null, recipient = null, comments = comm, isComplete = false, date = DateTime.Now };
            int ret = await model.SendRequest(r);
            return ret == 1;
        }
    }
}
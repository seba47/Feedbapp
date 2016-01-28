using Feedbapp.Entities;
using Feedbapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedbapp.ViewModels
{
    public class OfferViewModel : BaseReqOffViewModel
    {
        public OfferViewModel() : base()
        {
            buttonText = "Ofrecer Feedback";
            PageTitle = "Ofrecer Feedback";
            comments = "Me gustaría ofrecerte feedback!";
        }

        internal override async Task<bool> Send()
        {
            string comm = this.Comments;
            //User selected = this.UsersList[this.SelectedIndex];
            Services.RemoteRepository_Offered req = new Services.RemoteRepository_Offered();
            Offered o = new Offered() { senderId = this.SelectedSender.userId, recipientId = this.SelectedRecipient.userId, sender = null, recipient = null, comments = comm, isComplete = false, date = DateTime.Now };
            int ret = await model.SendOffer(o);
            return ret == 1;
        }

        public override string getSentText()
        {
            if (this.SelectedRecipient != null)
            {
                return "Se le ha enviado una ofrecimiento de feedback a " + SelectedRecipient.firstName + " " + SelectedRecipient.lastName + ". Recibirás una notificación por mail.";
            }
            return string.Empty;
        }
    }
}
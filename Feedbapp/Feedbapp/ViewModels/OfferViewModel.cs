﻿using Feedbapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.Entities;


namespace Feedbapp.ViewModels
{
    public class OfferViewModel : BaseReqOffViewModel
    {
        public OfferViewModel():base()
        {
            this.buttonText="Ofrecer Feedback";
            this.PageTitle = "Ofrecer Feedback";
            this.comments = "Me gustaría ofrecerte feedback!";
        }

        internal override async Task<bool> Send()
        {
            int senderId = this.SelectedIndexSender;
            int recipientId = this.SelectedIndexRecipient;
            string comm = this.Comments;
            //User selected = this.UsersList[this.SelectedIndex];
            Services.RemoteRepository_Offered req = new Services.RemoteRepository_Offered();
            Offered r = new Offered() { sender = this.SelectedSender, recipient = this.SelectedRecipient, comments = comm, isComplete = false, date = DateTime.Now };
            int ret = await req.Add(r);
            return ret == 1;
        }

        public override string getSentText()
        {
            if (this.SelectedRecipient != null)
            {
                return "Se le ha enviado una ofrecimiento de feedback a " + this.SelectedRecipient.firstName + " " + this.SelectedRecipient.lastName + ". Recibirás una notificación por mail.";
            }
            return string.Empty;
        }
    }
}

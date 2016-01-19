﻿using Feedbapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.Entities;

namespace Feedbapp.ViewModels
{
    public class RequestViewModel: BaseReqOffViewModel
    {      
        public RequestViewModel():base()
        {
            this.buttonText = "Solicitar Feedback";
            this.PageTitle = "Solicitar Feedback";
            this.comments = "Me gustaría pedirte feedback!";
        }

        internal override async Task<bool> Send()
        {
            int senderId = this.SelectedIndexSender;
            int recipientId = this.SelectedIndexRecipient;
            string comm = this.Comments;
            //User selected = this.UsersList[this.SelectedIndex];
            Services.RemoteRepository_Requested req = new Services.RemoteRepository_Requested();
            Requested r = new Requested() { sender = this.SelectedSender, recipient = this.SelectedRecipient, comments = comm, isComplete = false, date= DateTime.Now};
            int ret = await req.Add(r);
            return ret == 1;

        }
    }
}

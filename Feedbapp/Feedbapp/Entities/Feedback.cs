using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedbapp.Entities
{
    public abstract class Feedback
    {
        private int senderId { get; set; }
        private int recipientId { get; set; }
        private DateTime date { get; set; }
        private string comments { get; set; }
        private bool accepted { get; set; }
        private bool isComplete { get; set; }
    }
}

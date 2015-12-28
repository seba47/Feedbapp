using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedbapp.Entities
{
    public abstract class Feedback
    {
        private int feedbackId { get; set; }
        private User sender { get; set; }
        private User recipient { get; set; }
        private DateTime date { get; set; }
        private string comments { get; set; }
        private bool accepted { get; set; }
        private bool isComplete { get; set; }
    }
}

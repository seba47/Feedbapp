using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedbapp.Entities
{
    public abstract class Feedback: TEntity
    {
        public int feedbackId { get; set; }
        public User sender { get; set; }
        public User recipient { get; set; }
        public int? senderId { get; set; }
        public int? recipientId { get; set; }
        public DateTime date { get; set; }
        public string comments { get; set; }
        public bool accepted { get; set; }
        public bool isComplete { get; set; }
    }
}

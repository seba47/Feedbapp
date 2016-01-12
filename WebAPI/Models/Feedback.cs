using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Feedback
    {
        [Key]
        public int feedbackId { get; set; }

        [ForeignKey("senderId")]
        public virtual User sender { get; set; }

        [ForeignKey("recipientId")]
        public virtual User recipient { get; set; }
        public int? senderId { get; set; }
        public int? recipientId { get; set; }
        public DateTime date { get; set; }
        public string comments { get; set; }
        public bool accepted { get; set; }
        public bool isComplete { get; set; }
    }
}

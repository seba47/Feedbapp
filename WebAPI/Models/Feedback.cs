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
        
        public virtual User sender { get; set; }
        
        public virtual User recipient { get; set; }

        public DateTime date { get; set; }
        public string comments { get; set; }
        public bool accepted { get; set; }
        public bool isComplete { get; set; }        
    }
}

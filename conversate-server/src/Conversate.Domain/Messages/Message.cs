using Conversate.Domain.ApplicationUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversate.Domain.Messages
{
    public class Message
    {
        public int Id { get; set; } 

        [Required]
        public string SenderUserId { get; set; } 

        [Required]
        public string Content { get; set; } 

        [Required]
        public DateTime SentAt { get; set; } 

        public string RecipientUserId { get; set; } 

        [ForeignKey("SenderUserId")]
        public virtual ApplicationUser Sender { get; set; } 

        [ForeignKey("RecipientUserId")]
        public virtual ApplicationUser Recipient { get; set; } 
    }
}

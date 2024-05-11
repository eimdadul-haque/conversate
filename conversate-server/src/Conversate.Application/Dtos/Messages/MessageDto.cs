using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversate.Application.Dtos.Messages
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string SenderUserId { get; set; }
        public string Content { get; set; }
        public DateTime? SentAt { get; set; }
        public Guid RecipientUserId { get; set; }
        //public virtual ApplicationUser Sender { get; set; }
        //public virtual ApplicationUser Recipient { get; set; }
    }
}

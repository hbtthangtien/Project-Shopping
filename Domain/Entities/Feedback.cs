using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Feedback
    {
        public int FeedbackId { get; set; }

        public virtual string? AccountId { get; set; }

        public virtual int? ProductId {  get; set; }

        public DateTime? FeedbackDate { get; set; }

        public string? FeedbackDescribe { get; set; }

        public bool IsFeedback {  get; set; }

        //public int FeedbackStatus { get; set; }

        public virtual Account? Account { get; set; }

        public virtual Product? Product { get; set;}

        public virtual ICollection<ImageFeedback> ImageFeedbacks { get; set; } = new List<ImageFeedback>();
    }
}

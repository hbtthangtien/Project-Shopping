using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ImageFeedback
    {
        public int ImageFeedbackId { get; set; }

        public string? ImageFeedbackUrl { get; set; }

        public int? FeedbackId { get; set; }

        public virtual Feedback? Feedback {  get; set; }
    }
}

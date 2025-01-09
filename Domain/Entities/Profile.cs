using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Profile
    {
        public int ProfileId { get; set; }

        public string? Fullname { get; set; }

        public string? Address { get; set; }

        public Gender? Gender { get; set; }

        public string? AvatarProfile {  get; set; }

        public string? PhoneNumber { get; set; }

        public string? IdentityCard { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public virtual string? AccountId { get; set; }

        public virtual Account? Account { get; set; }
    }
}

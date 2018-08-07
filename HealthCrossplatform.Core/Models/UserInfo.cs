using System;
namespace HealthCrossplatform.Core.Models
{
    public class UserInfo
    {
        public string Id { get; set; }
        public string DOB { get; set; }
        public int Gender { get; set; }

        public float Height { get; set; }
        public float InitialWeight { get; set; }
        public float InitialWaist { get; set; }

        public string Lifestyle { get; set; }
        public string HealthReason { get; set; }
        public string Habit { get; set; }
        public string Goal { get; set; }
    }
}

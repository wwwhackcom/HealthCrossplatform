using System;
namespace HealthCrossplatform.Core.Models
{
    public class UserInfo
    {
        //basic information
        public string Id { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }

        //health information
        public float Height { get; set; }
        public float InitialWeight { get; set; }
        public float InitialWaist { get; set; }

        //extra interests information
        public string Lifestyle { get; set; }
        public string HealthReason { get; set; }
        public string Habit { get; set; }
        public string Goal { get; set; }
    }
}

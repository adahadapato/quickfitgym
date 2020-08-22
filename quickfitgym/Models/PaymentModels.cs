using System;
namespace quickfitgym.Models
{
    public class Payment
    {
        public string Username { get; set; }
        public int Planid { get; set; }
    }

    public class PayementPlan
    {
        public int PlanId { get; set; }
        public string Plan { get; set; }
        public double StartAmount { get; set; }
        public double Amount { get; set; }
        public int Duration { get; set; }
    }
}

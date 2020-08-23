using System;
namespace quickfitgym.Models
{
    public class Payment
    {
        public string UserName { get; set; }
        public int Planid { get; set; }
        public string Status { get; set; }
        public double Amount { get; set; }
    }

    public class PaymentPlan
    {
        public int PlanId { get; set; }
        public string Plan { get; set; }
        public double StartAmount { get; set; }
        public double Amount { get; set; }
        public int Duration { get; set; }
    }
}

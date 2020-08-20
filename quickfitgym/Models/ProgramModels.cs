using System;
using System.Collections.Generic;

namespace quickfitgym.Models
{
    public class ProgramSchedule
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public string DayOfWeek { get; set; }
        public string StartTime { get; set; }
        public string StopTime { get; set; }
    }

    public class Program
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProgramSchedule> ProgramSchedules { get; set; }
    }
}

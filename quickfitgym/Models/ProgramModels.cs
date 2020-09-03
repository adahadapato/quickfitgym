using System;
using System.Collections.Generic;

namespace quickfitgym.Models
{
    public class ProgramTime
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public string DayOfWeek { get; set; }
        public string StartTime { get; set; }
        public string StopTime { get; set; }
    }

   

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
        public List<ProgramTime> ProgramSchedules { get; set; }
    }

    public class AddProgramResult
    {
        public string Message { get; set; }
        public int ProgramId { get; set; }
    }

    public class JoinProgram
    {
        public string UserId { get; set; }
        public int ScheduleId { get; set; }
    }
}

namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //This is used to display workouts on the calendar. DO NOT CHANGE OR WILL BREAK!!!!
    public partial class Event
    {
        public int id { get; set; }

        public string title { get; set; }
        
        public Boolean allDay { get; set; }

        public DateTime start { get; set; }

        public DateTime? end { get; set; }

        public string url { get; set; }

        public string className { get; set; }

        public Boolean editable { get; set; }

        public Boolean startEditable { get; set; }

        public Boolean durationEditable { get; set; }

        public string color { get; set; }

        public string backgroundColor { get; set; }

        public string borderColor { get; set; }

        public string textColor { get; set; }

        public string description { get; set; }

        public string extra { get; set; }
        
    }
}

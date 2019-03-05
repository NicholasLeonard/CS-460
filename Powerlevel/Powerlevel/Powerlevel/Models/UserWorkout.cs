namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserWorkout")]
    public partial class UserWorkout
    {
        [Key]
        public int UWId { get; set; }

        public int UsernameId { get; set; }

        public int UserCurrentPlan { get; set; }

        public virtual PlanWorkout PlanWorkout { get; set; }

        public virtual User User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Powerlevel.Models.ViewModels
{
    public class WorkoutVM
    {
        //this is the id of the active workout for a user
        public int UWId { get; set; }

        //this is the current exercise in the current workout that the user is doing
        public virtual Exercise CurrentExercise { get; set; }
    }
}
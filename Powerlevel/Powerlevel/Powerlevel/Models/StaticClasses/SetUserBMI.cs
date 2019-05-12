using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Powerlevel.Models.StaticClasses
{
    public static class SetUserBMI
    {
        public static void SetBMI(User currentUser, toasterContext dbAccess)
        {
            //calculate user BMI on submit
            //BMI Formula: ( (lbs * 703) / inch^2 )
            //convert inch to decimal, then to inches
            double tempHeight = (double)((currentUser.HeightFeet * 12) + (currentUser.HeightInch / 10));
            currentUser.BMI = Math.Round((double)((currentUser.Weight * 703) / Math.Pow(tempHeight, 2.00)), 2); //round to 2 decimal places
            dbAccess.SaveChanges();
        }
    }
}
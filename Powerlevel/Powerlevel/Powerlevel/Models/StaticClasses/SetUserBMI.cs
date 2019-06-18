using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitsNet.Units;
using UnitsNet;

namespace Powerlevel.Models.StaticClasses
{
    public static class SetUserBMI
    {
        public static void SetBMI(User currentUser, toasterContext dbAccess)
        {
            //calculate user BMI on submit
            //BMI Formula: mass kg / height ^2 m
            
            // gets the weight and height of the user to be used in the formula using UnitsNet library
            Mass Weight = Mass.FromPounds((QuantityValue)currentUser.Weight).ToUnit(MassUnit.Kilogram);
            Length Height = Length.FromInches((QuantityValue)(currentUser.HeightFeet * 12 + currentUser.HeightInch)).ToUnit(LengthUnit.Meter);

            //Performs BMI calculation
            currentUser.BMI = Math.Round(Weight.Kilograms/Math.Pow(Height.Meters, 2), 2);

            dbAccess.SaveChanges();
        }
    }
}
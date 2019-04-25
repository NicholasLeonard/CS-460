using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Powerlevel.Infastructure;
using Powerlevel.Models;
using System.Data.Entity;

namespace Powerlevel.Infastructure
{
    public class ToasterRepository : IToasterRepository
    {
        private toasterContext db = new toasterContext();

        
        public IQueryable<WorkoutEvent> WorkoutEvents
        {
            get
            {
                return  db.WorkoutEvents;
            }
        }

        public void Update(object tableObject)
        {
            db.Entry(tableObject).State = EntityState.Modified;
            db.SaveChanges();
        }

        public WorkoutEvent Find(int id)
        {
            return db.WorkoutEvents.Find(id);
        }
        

       public void Dispose()
        {
            db.Dispose();
        }
    }
}
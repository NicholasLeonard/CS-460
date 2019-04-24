using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Powerlevel.Models;
using System.Data.Entity;

namespace Powerlevel.Infastructure
{
     public interface IToasterRepository
    {
          
        IDbSet<WorkoutEvent> WorkoutEvents { get; }
        void Dispose();
        void Update(object tableObject);

        
    }
}

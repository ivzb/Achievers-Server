using Mine360.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine360.Data.Models
{
    public class PlanedMaintenanceJobList : BaseModel<int>
    {
        private ICollection<PlanedMaintenanceJob> jobs;

        public PlanedMaintenanceJobList()
        {
            this.jobs = new HashSet<PlanedMaintenanceJob>();
        }

        public virtual ICollection<PlanedMaintenanceJob> Jobs
        {
            get
            {
                return this.jobs;
            }
            set
            {
                this.jobs = value;
            }
        }
    }
}

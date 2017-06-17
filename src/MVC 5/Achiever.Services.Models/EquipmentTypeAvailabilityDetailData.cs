using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine360.Services.Models
{
    public class EquipmentTypeAvailabilityDetailData
    {
        public DateTime PeriodStartDate { get; set; }

        public double AvailabilityPercentage { get; set; }

        public double? MovingAveragePercentage { get; set; }
        public int TypeId { get; set; }
    }
}

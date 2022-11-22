using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Model
{
    public class AddEngergyConsumptionDto
    {
        public string UserId { get; set; }
        public string DeviceId { get; set; }
        public string EnergyConsumption { get; set; }

    }
}

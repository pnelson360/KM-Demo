using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KM_Demo.Models
{
    internal class Models
    {
    }
    public class MilestonesSource
    {
        public string MilestoneName { get; set; }
        public string AssignedUser { get;set; }
        public MilestonesSource(string milestoneName, string assignedUser)
        {
            MilestoneName = milestoneName;
            AssignedUser = assignedUser;
        }
    }
}

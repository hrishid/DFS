using System;
using System.Collections.Generic;
using System.Text;

namespace DFS.Services.Models
{
    public class DepartmentModel
    {
        public int departmentId { get; set; }
        public string departmentName { get; set; }
        public int clientLocationId { get; set; }
        public int dynamicFlowId { get; set; }
    }
}

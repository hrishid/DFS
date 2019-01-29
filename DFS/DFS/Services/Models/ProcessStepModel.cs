using System;
using System.Collections.Generic;
using System.Text;

namespace DFS.Services.Models
{
    public class ProcessStepModel
    {

        public int processId { get; set; }
        public string processName { get; set; }
        public int clientLocationId { get; set; }
        public int departmentId { get; set; }
        public int dynamicFlowId { get; set; }

    }
}

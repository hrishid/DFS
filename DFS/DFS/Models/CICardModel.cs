using System;
using System.Collections.Generic;
using System.Text;

namespace DFS.Models
{
    public class CICardModel
    {
        public string cardTitle { get; set; }
        public string businessValue { get; set; }
       // public int costReduction { get; set; }
        public string description { get; set; }
        public int bucketId { get; set; }
        public int clientLocationId { get; set; }
        public int dynamicFlowId { get; set; }
        public int departmentId { get; set; }
        public int? processId { get; set; }
        public int auditUserId { get; set; }
        public int clientId { get; set; }
        public string descriptionImage { get; set; }
    }
}

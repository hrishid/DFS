using System;
using System.Collections.Generic;
using System.Text;

namespace DFS.Services.Models
{
    public class Bucket
    {
        public int bucketId { get; set; }
        public string bucketName { get; set; }
    }

    public class ClientLocation
    {
        public int clientLocationId { get; set; }
        public string clientLocationName { get; set; }
        public int clientId { get; set; }
    }

    public class Department
    {
        public int departmentId { get; set; }
        public string departmentName { get; set; }
        public int clientLocationId { get; set; }
        public int dynamicFlowId { get; set; }
    }

    public class Process
    {
        public int processId { get; set; }
        public string processName { get; set; }
        public int clientLocationId { get; set; }
        public int departmentId { get; set; }
        public int dynamicFlowId { get; set; }
    }

    public class ValueStream
    {
        public int dynamicFlowId { get; set; }
        public string dynamicFlowName { get; set; }
        public int clientLocationId { get; set; }
    }

    public class CiCardStatus
    {
        public int cardStatusId { get; set; }
        public int assigneeId { get; set; }
        public int reviewerId { get; set; }
        public int statusId { get; set; }
        public string status { get; set; }
    }

    public class CardModel
    {
        public int cardId { get; set; }
        public string cardNo { get; set; }
        public string cardTitle { get; set; }
        public string businessValue { get; set; }
        public double? costReduction { get; set; }
        public string description { get; set; }
        public Bucket bucket { get; set; }
        public ClientLocation clientLocation { get; set; }
        public Department department { get; set; }
        public Process process { get; set; }
        public ValueStream valueStream { get; set; }
        public CiCardStatus ciCardStatus { get; set; }
        public int auditUserId { get; set; }
        public string actions { get; set; }
        public string remarks { get; set; }
        public DateTime? dueDate { get; set; }
        public DateTime? completionDate { get; set; }
        public DateTime createdOn { get; set; }
        public string imageUrl { get; set; }
        public int? signedOffUserId { get; set; }
        public int? updatedBy { get; set; }
        public DateTime? updatedOn { get; set; }
        public int clientId { get; set; }
        public object riskReduction { get; set; }
        public string solutionImageUrl { get; set; }
        public bool benchmarkWorthy { get; set; }
        public object reviewedDate { get; set; }
    }
    
}

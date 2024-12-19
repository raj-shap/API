using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Logs
    {
        [Key]
        public int LogId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string LogLevel { get; set; }// INFO, DEBUG, WARN, ERROR, FATAL).
        public string Message { get; set; }
        public string? ExceptinDetails {get;set;}
        public string Category { get; set; } // specific module, controller, or service
        public int? UserId { get; set; }
        public Guid? RequestId { get; set; }
        public string? IPAddress { get; set; }
        public string? SessionId { get; set; }
        public Guid? CorrelationId { get; set; }
        public string? MachineName { get; set; }
        public string? ModuleName { get; set; } // specific module or component in you application where the log origineted.
        public string? Environment {  get; set; }
        public double? ExecutionTime { get; set; }
        public long? MemmoryUsage { get; set; }
        public string? CustomData { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public string? DeletedFlag { get; set; } // Indicates if log entry was soft-deleted.
    }
}

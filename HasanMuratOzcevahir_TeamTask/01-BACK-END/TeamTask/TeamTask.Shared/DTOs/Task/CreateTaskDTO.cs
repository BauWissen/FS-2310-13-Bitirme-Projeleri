using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TeamTask.Shared.Types;

namespace TeamTask.Shared.DTOs.Task
{
    public class CreateTaskDTO
    {
        public int WorkSpaceId { get; set; }
        [JsonPropertyName("TaskName")]
        public string Title { get; set; }
        public TaskPriorityType Priority { get; set; }
        public DateTime EndDate { get; set; }
    }
}

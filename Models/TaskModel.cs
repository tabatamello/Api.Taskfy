using Api.Taskfy.Models.ModelBase;

namespace Api.Taskfy.Models
{
    public class TaskModel : BaseModel
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsCompleted { get; set; } = false;
    }
}

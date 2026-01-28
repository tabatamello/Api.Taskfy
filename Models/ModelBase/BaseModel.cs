namespace Api.Taskfy.Models.ModelBase
{
    public class BaseModel
    {
        public long Id { get; set; }
        public DateTimeOffset DateCreate { get; set; }
        public DateTimeOffset DateChange { get; set; }
    }
}

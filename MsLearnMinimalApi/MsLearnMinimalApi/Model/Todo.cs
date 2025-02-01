namespace MsLearnMinimalApi.Model
{
    public record TodoDto(string Id, string Name, bool IsComplete);
    public record TodoRequest(TodoDto TodoDto);

    public class Todo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}

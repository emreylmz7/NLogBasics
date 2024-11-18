namespace NLogBasics.Models;

public sealed class Log
{
    public int Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Level { get; set; }
    public string Logger { get; set; }
    public string Message { get; set; }
    public string Exception { get; set; }
}

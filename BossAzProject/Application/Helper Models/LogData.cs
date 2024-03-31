namespace BossAz.Application.HelperModels;

public class LogData
{
    public string Text { get; set; } 
    public DateTime Date { get; set; }


    public LogData(string text)
    {
        Text = text;
        Date = DateTime.Now; 
    }

}


namespace BossAz.Application.Models;

public class Notification
{
	public Guid Id { get; init; }
	public DateTime SendDate { get; init; }
	public string Message { get; set; }

	public Notification(string message)
	{
		Id = Guid.NewGuid();
		SendDate = DateTime.Now;

		Message = message;
	}

	public void Show()
	{
		Console.WriteLine(@$"
				Notification ID : {Id.ToString()}
					Send Date : {SendDate}
			Message : {Message}
	-----------------------------------------------------------------------------
			");
	}

	public override string ToString()
	=> @$"
				Notification ID : {Id.ToString()}
					Send Date : {SendDate}
			Message : {Message}
	-----------------------------------------------------------------------------
			";

}

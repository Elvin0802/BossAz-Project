
using BossAz.Application;
using BossAz.Application.HelperModels;

namespace BossAz;

public class Program
{
	static void Main(string[] args)
	{
		try
		{
			App app = new();

			JsonOperations.ProccessLog(new LogData("App Started"));

			app.StartApp();
		}
		catch (Exception ex)
		{
			JsonOperations.ProccessLog(new LogData("Error Happened"));
			Console.WriteLine($"\n\n\t\tError in Program.Main --> App.StartApp\n\n\t{ex.Message}\n\n\n");
		}
		finally
		{
			Console.WriteLine("\n\n\n");
			App.Pause();
			Console.WriteLine("\n\n\n");
		}
	}
}


using Newtonsoft.Json;

namespace BossAz.Application.HelperModels;

public static class JsonOperations
{
	private static string FolderPath { get; } = "..\\..\\..\\Json Database\\";

	public static void WriteToFile<T>(List<T> lst, string fileName)
	{
		var opt = new JsonSerializerSettings { Formatting = Formatting.Indented };

		File.WriteAllText($"{FolderPath}{fileName}", JsonConvert.SerializeObject(lst, opt));
	}
	public static void ReadFromFile<T>(out List<T> lst, string fileName)
	{
		var data = File.ReadAllText($"{FolderPath}{fileName}");

		lst = JsonConvert.DeserializeObject<List<T>>(data);
	}

	public static void ProccessLog(LogData ld)
	{
		var opt = new JsonSerializerSettings { Formatting = Formatting.Indented };

		File.AppendAllText($"{FolderPath}log.json", JsonConvert.SerializeObject(ld, opt));
	}
}
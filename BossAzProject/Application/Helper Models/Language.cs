
namespace BossAz.Application.HelperModels;

public class Language
{
	public string language { get; set; }
	public string Level { get; set; }

	public Language(string language, string level)
	{
		this.language = language;
		Level = level;
	}

	public static Language? GetLanguage(string language)
	{
		int optionLang = 0;

		List<string> levels = new() { "A1", "A2", "B1", "B2", "C1", "C2" };

		Language? L = null;

		while (true)
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine("\n\n\n\t\t\tSelect your level.\n");
			Console.ForegroundColor = ConsoleColor.White;

			App.ShowMenu(in levels, optionLang);

			if (!(App.KeyCheck(ref optionLang, 0, levels.Count-1))) continue;

			L = new Language(language, levels[optionLang]);

			return L;
		}
	}

	public override string ToString()
	{
		return $"{language} - {Level}";
	}
}


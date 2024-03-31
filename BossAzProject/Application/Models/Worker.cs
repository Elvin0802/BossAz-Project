
using BossAz.Application.Interfaces;

namespace BossAz.Application.Models;
public class Worker : Person, IShowing
{
	public CV Cv { get; set; }

	public Worker(string name, string surname, string city, string phone, DateOnly birthDate,
					CV cv, bool gender, string email, string password)
					: base(name, surname, city, phone, birthDate, gender, email, password)
	{
		Cv = cv;
	}

	public override string ToString()
	{
		return $"Id : {Id} / Name : {Name} / Surname : {Surname} / Gender : {(Gender ? "Male" : "Female")} / " +
				$"City : {City} / Phone : {Phone} / Birth Date : {BirthDate.ToString()} / " +
				$"Email : {Email}\n--- Cv ---\n{Cv?.ToString()}\n";
	}

	public void Show(bool showPassword)
	{
		Console.WriteLine(@$"

					Id : {Id}

				Name : {Name}  |  Surname : {Surname}

			Gender : {(Gender ? "Male" : "Female")}  | City : {City}  |   Birth Date : {BirthDate.ToString()}

		Phone : {Phone}  |  Email : {Email}  {(showPassword ? $"  |  {Password}" : "")}

		------------  CV  ------------

				{(Cv == null ? "There is No Cv" : Cv?.ToString())}


--------------------------------------------------------------------------------------------------------------------
				");
	}

	public void Show()
	{
		Show(false);
	}

	public void ShortShow(bool increaseViewCount = false)
	{
		Console.WriteLine(@$"
				Id : {Id} 
			Name : {Name}   |  Age : {2024 - BirthDate.Year}
		Email : {Email}  |  Phone : {Phone}
---------------------------------------------------------------------------
		");

	}
}

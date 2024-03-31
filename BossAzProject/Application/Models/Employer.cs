
namespace BossAz.Application.Models;

public class Employer : Person
{
	public List<Vacancie> Vacancies { get; set; }

	public Employer(string name, string surname, string city, string phone,
			DateOnly age, bool gender, string email, string password)
			: base(name, surname, city, phone, age, gender, email, password)
	{
		Vacancies = new();
	}


	public override string ToString()
	{
		return $"Id : {Id} / Name : {Name} / City : {City} / Phone : {Phone} /  Email : {Email}";
	}

	public void Show(bool showPassword)
	{
		Console.WriteLine(@$"
	
						Id : {Id}
	
					Name : {Name}  |  Surname : {Surname}
	
				Gender : {(Gender ? "Male" : "Female")}  | City : {City}  |   Birth Date : {BirthDate.ToString()}
	
			Phone : {Phone}  |  Email : {Email}  {(showPassword ? $" |  Password : {Password}" : "")}
	

--------------------------------------------------------------------------------------------------------------------
				");
	}

	public bool AddVacancie(Vacancie v)
	{
		try
		{
			Vacancies.Add(v);
			return true;
		}
		catch { return false; }
	}

	public Vacancie? GetVacancie(string Id)
	{
		return Vacancies.Find(v => v.VacancieId.ToString() == Id);
	}

	public bool DeleteVacancie(string vacancieId)
	{
		return Vacancies.Remove(Vacancies.Find(v => v.VacancieId.ToString() == vacancieId));
	}
	public bool ConfirmVacancie(string vacancieId)
	{
		var va = Vacancies.Find(v => v.VacancieId.ToString() == vacancieId);

		if (va is null)
			return false;
		else
			return va.ConfirmVacancie();
	}
	public void ConfirmAllVacancies()
	{
		foreach (var v in Vacancies)
		{
			if (v.IsConfirmed) continue;

			_ = v.ConfirmVacancie();
		}
	}

	public bool CheckVacancieById(string Id)
	{
		return Vacancies.Any(v => v.VacancieId.ToString() == Id);
	}

	public void GetAllVacanciesIdBy(ref List<string> lst, Func<Vacancie, bool> predicate,
				bool getTimeEndedVacancie = false)
	{
		foreach (var v in Vacancies)
		{
			if (!getTimeEndedVacancie)
			{
				if (v.EndingDate < DateTime.Now)
					continue;
			}

			if (predicate(v)) lst.Add(v.VacancieId.ToString());
		}
	}
}
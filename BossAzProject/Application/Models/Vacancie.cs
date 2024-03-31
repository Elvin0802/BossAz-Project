
using BossAz.Application.Interfaces;

namespace BossAz.Application.Models;

public class Vacancie : IShowing
{
	#region Fields

	public Guid VacancieId { get; init; }
	public string CompanyName { get; set; }
	public string Position { get; set; }
	public string Location { get; set; }
	public string JobCategory { get; set; }
	public string JobType { get; set; }
	public string JobDescription { get; set; }
	public string Requirements { get; set; }
	public string Advantages { get; set; }
	public double MinSalary { get; set; }
	public double MaxSalary { get; set; }
	public DateTime ShareDate { get; set; }
	public DateTime EndingDate { get; set; }
	public string RelevantPerson { get; set; }
	public sbyte MinExpYear { get; set; }
	public sbyte MaxExpYear { get; set; }
	public string PhoneNum { get; set; }
	public string Email { get; set; }
	public sbyte MinAge { get; set; }
	public sbyte MaxAge { get; set; }
	public long ViewCount { get; set; }
	public bool IsConfirmed { get; set; }

	#endregion

	public Vacancie(string companyName, string position, string location, string jobCategory,
			string jobType, string jobDescription, string requirements, string advantages,
			double minSalary, double maxSalary, string relevantPerson, sbyte minExpYear,
			sbyte maxExpYear, string phoneNum, string email, sbyte minAge, sbyte maxAge)
	{
		VacancieId= Guid.NewGuid();
		IsConfirmed= false;
		ViewCount = 0;

		ShareDate = DateTime.MinValue;
		EndingDate = DateTime.MinValue;

		CompanyName = companyName;
		Position = position;
		Location = location;
		JobCategory = jobCategory;
		JobType = jobType;
		JobDescription = jobDescription;
		Requirements = requirements;
		Advantages = advantages;
		MinSalary = minSalary;
		MaxSalary = maxSalary;
		RelevantPerson = relevantPerson;
		MinExpYear = minExpYear;
		MaxExpYear = maxExpYear;
		PhoneNum = phoneNum;
		Email = email;
		MinAge = minAge;
		MaxAge = maxAge;
	}

	public bool ConfirmVacancie()
	{
		try
		{
			IsConfirmed = true;
			ShareDate = DateTime.Now;
			EndingDate = DateTime.Now.AddDays(30);
			return true;
		}
		catch { return false; }
	}

	public void Show(bool increaseViewCount)
	{
		this.Show();
		if (increaseViewCount) ViewCount++;
	}

	public void ShortShow(bool increaseViewCount)
	{
		Console.WriteLine(@$"
					ID : {VacancieId}
				Shirketin Adi : {CompanyName}  |  Vezife : {Position}
			Maash Araliqi : {MinSalary} - {MaxSalary}  AZN  |  Bitme Tarixi : {EndingDate.ToString()}

	---------------------------------------------------------------------------------------------------------------
		");
        if (increaseViewCount) ViewCount++;
    }

	public void Show()
	{
		Console.ForegroundColor = ConsoleColor.Cyan;
		Console.Write($@" 
		
				ID : {VacancieId}
				Shirketin Adi : {CompanyName}
				Paylashilma Tarixi : {ShareDate.ToString()}
				Bitme Tarixi : {EndingDate.ToString()}
				Vezife : {Position}
				Unvan : {Location}
				Maash Araliqi : {MinSalary} - {MaxSalary}  AZN
				Yash Araliqi : {MinAge} - {MaxAge}  yash

				Ishin Kateqoriyasi : {JobCategory}

				Ishin Tipi : {JobType}

				Namizede Telebler : {Requirements}

				Ish Tecrubesi : {MinExpYear} - {MaxExpYear}  il

				Ish Haqqinda Melumat : {JobDescription}

				Ustunlukler : {Advantages}
				Elaqedar Shexs : {RelevantPerson}
				Telefon : {PhoneNum}
				Email : {Email}
				Baxish Sayi : {ViewCount}
		");

		Console.ForegroundColor = ConsoleColor.Gray;
		Console.WriteLine("-------------------------------------------------" +
			"---------------------------------------------------------------");
	}
}

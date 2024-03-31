
using BossAz.Application.Models;

namespace BossAz.Application.HelperModels;

public static class AdditionalFunctions
{
	public static void TextAnimation(string text)
	{
		Console.Clear();
		foreach (char let in text)
		{
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.Write(let);
			Console.ForegroundColor = ConsoleColor.White;
			Thread.Sleep(30);
			if (Console.KeyAvailable)
			{
				Console.ReadKey(true); 
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.Write(text);
				Console.ForegroundColor = ConsoleColor.White;
				return;
			}
		}
	}

	public static Vacancie GetNewVacancie()
	{
		string companyName, position, location, jobCategory, jobType, jobDescription,
				requirements, advantages, relevantPerson, phoneNum, email;

		sbyte minExpYear, maxExpYear, minAge, maxAge;
		double minSalary, maxSalary;

		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the Company Name : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			companyName = Console.ReadLine();

			if (companyName != "") break;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct Company Name !\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n\n");
		}
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the worker position : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			position = Console.ReadLine();

			if (position != "") break;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct position !\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n\n");
		}
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the Job Location : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			location = Console.ReadLine();

			if (location != "") break;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct location !\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n\n");
		}
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the Job Category : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			jobCategory = Console.ReadLine();

			if (jobCategory != "") break;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct Job Category !\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n\n");
		}
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the Job Type : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			jobType = Console.ReadLine();

			if (jobType != "") break;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct Job Type !\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n\n");
		}
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the Job Description : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			jobDescription = Console.ReadLine();

			if (jobDescription != "") break;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct Job Description !\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n\n");
		}
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the Requirements : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			requirements = Console.ReadLine();

			if (requirements != "") break;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct Requirements !\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n\n");
		}
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the Advantages : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			advantages = Console.ReadLine();

			if (advantages != "") break;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct Advantages !\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n\n");
		}
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the Salary Range.");
			Console.Write("\n\n\t\t\t\tEnter the Min Salary : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			minSalary = double.Parse(Console.ReadLine());

			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the Max Salary : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			maxSalary = double.Parse(Console.ReadLine());

			if (minSalary >= 0 && maxSalary > minSalary) break;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct Salary Range !\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n\n");
		}
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the Relevant Person : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			relevantPerson = Console.ReadLine();

			if (relevantPerson != "") break;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct Relevant Person !\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n\n");
		}
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the Experience Year Range.");
			Console.Write("\n\n\t\t\t\tEnter the Min Experience Year : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			minExpYear = sbyte.Parse(Console.ReadLine());

			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the Max Experience Year : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			maxExpYear = sbyte.Parse(Console.ReadLine());

			if (minExpYear >= 0 && maxExpYear >= minExpYear) break;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct Experience Year Range !\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n\n");
		}
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the Phone Number : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			phoneNum = Console.ReadLine();

			if (phoneNum != "") break;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct Phone Number !\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n\n");
		}
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the email : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			email = Console.ReadLine();

			if (email != "") break;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct email !\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n\n");
		}
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the Age Range.");
			Console.Write("\n\n\t\t\t\tEnter the Min Age : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			minAge = sbyte.Parse(Console.ReadLine());

			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the Max Age : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			maxAge = sbyte.Parse(Console.ReadLine());

			if (minAge > 0 && maxAge >= minAge) break;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct Age Range !\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n\n");
		}

		return new Vacancie(companyName,position,location,jobCategory,jobType,jobDescription,
				requirements,advantages,minSalary,maxSalary,relevantPerson,minExpYear,
				maxExpYear,phoneNum,email,minAge,maxAge);
	}

	public static void ChangePersonData(string userKey, Person person)
	{
		List<string> DataMenu = new() { "BACK", "Change Name", "Change Surname", "Change City",
							"Change Phone Number", "Change Gender", "Change Birth Date",
							"Change Email", "Change Password" };
		int optionD = 0;

		if (person == null) { return; }

		if (userKey == "WORKER")
			DataMenu.Add("Change My CV");

		while (true)
		{
			Console.Clear();
			Console.WriteLine("\n\n\n\n");
			App.ShowMenu(in DataMenu, optionD);

			if (!(App.KeyCheck(ref optionD, 0, DataMenu.Count-1))) continue;

			if (DataMenu[optionD] == "BACK")
				break;
			else if (DataMenu[optionD] == "Change Name")
				person.Name = GetName();
			else if (DataMenu[optionD] == "Change Surname")
				person.Surname = GetSurname();
			else if (DataMenu[optionD] == "Change City")
				person.City = GetCity();
			else if (DataMenu[optionD] == "Change Phone Number")
				person.Phone = GetPhoneNumber();
			else if (DataMenu[optionD] == "Change Gender")
				person.Gender = GetGender();
			else if (DataMenu[optionD] == "Change Birth Date")
				person.BirthDate = GetBirthDate();
			else if (DataMenu[optionD] == "Change Email")
				person.Email = GetEmail();
			else if (DataMenu[optionD] == "Change Password")
				person.Password = GetPassword();
			else if (DataMenu[optionD] == "Change My CV")
			{
				Worker w1 = (Worker)person;

				w1.Cv = GetCV();
			}

			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine($"\n\n\t\t\t{DataMenu[optionD]} is Successfully Completed.\n\n");
			App.Pause();
		}
	}

	public static string GetName()
	{
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the name : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			string name = Console.ReadLine();

			if (AppRegex.CheckNSC(name)) return name;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct name !\n\t\t\t Sample : 'Abbasqulu' or 'Huseyn Ali'\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n");
		}
	}

	public static string GetSurname()
	{
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the surname : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			string surname = Console.ReadLine();

			if (AppRegex.CheckNSC(surname)) return surname;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct surname !\n\t\t\t Sample : 'Aliyev' or 'Pashayev'\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n");
		}
	}

	public static string GetCity()
	{
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the your city : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			string city = Console.ReadLine();

			if (AppRegex.CheckNSC(city)) return city;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct city name !\n\t\t\t Sample : 'Rio de Janeiro' or 'New York'\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n");
		}
	}

	public static string GetPhoneNumber()
	{
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the your phone number : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			string phone = Console.ReadLine();

			if (AppRegex.CheckPhoneNum(phone)) return phone;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct phone number !\n\t\t\t Sample : '010 211 55 99' or '099 288 41 02'\n" +
				"\t\t\t Front Codes : 010 , 050 , 051 , 055 , 070 , 077 , 099\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n");
		}
	}

	public static bool GetGender()
	{
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tSelect the your gender ( Male = 1 , Female = 0 ) : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			string gender = Console.ReadLine();

			if (gender == "1" || gender == "0") return (gender == "1" ? true : false);

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease select a correct gender type !\n\t\t\t Sample : '1' or '0'\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n");
		}
	}

	public static DateOnly GetBirthDate()
	{
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the your Birth Date\n\n");
			Console.Write("\n\t\t\t\tEnter the Year : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			int y = int.Parse(Console.ReadLine());

			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the Month : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			byte m = byte.Parse(Console.ReadLine());

			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the Day : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			byte d = byte.Parse(Console.ReadLine());

			try
			{
				if (y > 1800 && y < 2024 && m < 13 && m > 0 && d < 32 && d > 0)
					return new DateOnly(y, m, d);
				else
					throw new Exception();
			}
			catch
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine(
					"\n\n\t\t\tPlease enter a correct Birth Date !\n\t\t\t Sample : ' 1993 1 14 '\n\n");
				App.Pause();
				Console.Clear();
				Console.WriteLine("\n\n\n\n");
			}
		}
	}

	public static string GetEmail()
	{
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the your email : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			string email = Console.ReadLine();

			if (AppRegex.CheckEmail(email)) return email;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tPlease enter a correct email !\n\t\t\t Sample : 'sample@gmail.com' or 'anymail@microsoft.uk'\n\n");
			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n");
		}
	}

	public static string GetPassword()
	{
		while (true)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\t\t\tEnter the password : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			string password = Console.ReadLine();

			if (AppRegex.CheckPassword(password)) return password;

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
			"\n\n\t\t\tPlease enter a correct password !\n\t\t\t Sample : 'AnyPassword_1' or 'MyPasw@022'\n" +
			"\t\t\t Minimum char condition for password : 1 uppercase letter , 1 lowercase letter , 1 digit , 1 any symbol\n" +
			"\t\t\t Length condition for password : Minimum : 6 char , Maximum : 30 char\n\n");

			App.Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n");
		}
	}

	public static CV GetCV()
	{
		CV? cv = null;

		string specialty, school, companies, skills, linkOfLinkedIn, linkOfGitHub;
		bool isHonorsDiploma; double uniEntryMark;

		Console.Clear();

		Console.ForegroundColor = ConsoleColor.Green;
		Console.Write("\n\t\tEnter the your specialty : ");

		Console.ForegroundColor = ConsoleColor.Yellow;
		specialty = Console.ReadLine();

		Console.ForegroundColor = ConsoleColor.Green;
		Console.Write("\n\t\tEnter the your school : ");

		Console.ForegroundColor = ConsoleColor.Yellow;
		school = Console.ReadLine();

		Console.ForegroundColor = ConsoleColor.Green;
		Console.Write("\n\t\tEnter the your skills : ");

		Console.ForegroundColor = ConsoleColor.Yellow;
		skills = Console.ReadLine();

		Console.ForegroundColor = ConsoleColor.Green;
		Console.Write("\n\t\tEnter the your university entry mark : ");

		Console.ForegroundColor = ConsoleColor.Yellow;
		uniEntryMark = double.Parse(Console.ReadLine());

		Console.ForegroundColor = ConsoleColor.Green;
		Console.Write("\n\t\tEnter the your worked companies : ");

		Console.ForegroundColor = ConsoleColor.Yellow;
		companies = Console.ReadLine();

		Console.ForegroundColor = ConsoleColor.Green;
		Console.Write("\n\t\tAre you have Honors Diploma ( 1 or 0 ) : ");

		Console.ForegroundColor = ConsoleColor.Yellow;
		isHonorsDiploma = Console.ReadLine() == "1" ? true : false;

		Console.ForegroundColor = ConsoleColor.Green;
		Console.Write("\n\t\tEnter the your link of LinkedIn : ");

		Console.ForegroundColor = ConsoleColor.Yellow;
		linkOfLinkedIn = Console.ReadLine();

		Console.ForegroundColor = ConsoleColor.Green;
		Console.Write("\n\t\tEnter the your link of GitHub : ");

		Console.ForegroundColor = ConsoleColor.Yellow;
		linkOfGitHub = Console.ReadLine();

		Console.ForegroundColor = ConsoleColor.Green;
		Console.Write("\n\t\tHow many languages do you know : ");

		int say = int.Parse(Console.ReadLine());

		cv = new CV(specialty, school, uniEntryMark, skills, companies, isHonorsDiploma, linkOfGitHub, linkOfLinkedIn);

		for (int i = 0; i < say; ++i)
		{
			string lang;

			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\t\tEnter the language : ");
			lang = Console.ReadLine();

			var lg = Language.GetLanguage(lang);

			cv.AddLanguage(ref lg);
		}

		return cv;
	}

}


using System.Text.RegularExpressions;

namespace BossAz.Application.HelperModels;

public class AppRegex
{
	// Check name or surname or city with regex. Return true if correct. else false.
	public static bool CheckNSC(string nsc)
		=> Regex.IsMatch(nsc, @"^(?=[A-Z])[A-Za-z]{2,49}$");
	
	// Check email with regex. Return true if correct. else false.
	public static bool CheckEmail(string email)
		=> Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
	
	// Check password with regex. Return true if correct. else false.
	public static bool CheckPassword(string pasw)
		=> Regex.IsMatch(pasw, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?.!_@$%^&*-]).{6,31}$");

	// Check Phone Number with regex. Return true if correct. else false.
	public static bool CheckPhoneNum(string pNum)
		=> Regex.IsMatch(pNum, @"^(050|051|010|055|099|070|077)\s\d{3}\s\d{2}\s\d{2}$");
}

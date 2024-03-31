
using BossAz.Application.Interfaces;

namespace BossAz.Application.Models;

public abstract class Person : IRegisterable
{
	public Guid Id { get; init; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public string City { get; set; }
	public string Phone { get; set; }
	public DateOnly BirthDate { get; set; }
	public bool Gender { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public List<Notification> Notifications { get; set; }

	protected Person(string name, string surname, string city, string phone,
			DateOnly birthDate, bool gender, string email, string password)
	{
		Id=Guid.NewGuid();
		Notifications=new();

		Name=name;
		Surname=surname;
		City=city;
		Phone=phone;
		BirthDate=birthDate;
		Gender=gender;
		Email=email;
		Password=password;
	}

	public void AddNotification(ref Notification notification)
	{
		Notifications.Add(notification);
	}

	internal void ShowAllNotifications()
	{
		foreach (var n in Notifications)
		{
			n.Show();
			Console.Write("-------------------------------------------");
			Console.WriteLine("-----------------------------------------");
		}
	}

}

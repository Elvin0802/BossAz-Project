
using BossAz.Application.HelperModels;
using BossAz.Application.Models;

namespace BossAz.Application;

public class App
{
	Admin Admin { get; init; }

	private List<Worker> workers = new List<Worker>();
	private List<Employer> employers = new List<Employer>();

	public App() { Admin = new(); }

	public void StartApp()
	{
		try
		{       // get all data
			JsonOperations.ReadFromFile(out workers, "Workers.json");
			JsonOperations.ReadFromFile(out employers, "Employers.json");

			JsonOperations.ProccessLog(new LogData("Get datas from file"));
		}
		catch (Exception ex)
		{
			Console.WriteLine($"\n\nError in Deserialize for json.\n\n{ex.Message}\n");
			JsonOperations.ProccessLog(new LogData("Error Happend"));
			Pause();
		}

		List<string> GuestMenu = new() { "Vacancies", "Workers", "Log In", "Sign Up", "About Us", "EXIT" };
		int optionG = 0;

		while (true)
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine("\n\n\n");
			Console.Write(@"
			██████╗  ██████╗ ███████╗███████╗    █████╗ ███████╗
			██╔══██╗██╔═══██╗██╔════╝██╔════╝   ██╔══██╗╚══███╔╝
			██████╔╝██║   ██║███████╗███████╗   ███████║  ███╔╝ 
			██╔══██╗██║   ██║╚════██║╚════██║   ██╔══██║ ███╔╝  
			██████╔╝╚██████╔╝███████║███████║██╗██║  ██║███████╗
			╚═════╝  ╚═════╝ ╚══════╝╚══════╝╚═╝╚═╝  ╚═╝╚══════╝"
			); Console.WriteLine("\n\n\n");

			Console.ForegroundColor = ConsoleColor.White;
			ShowMenu(in GuestMenu, in optionG, false);

			if (!(KeyCheck(ref optionG, 0, GuestMenu.Count - 1, true))) continue;

			if (GuestMenu[optionG] == "EXIT")
			{
				JsonOperations.WriteToFile(workers, "Workers.json");
				JsonOperations.WriteToFile(employers, "Employers.json");
				JsonOperations.ProccessLog(new LogData("Datas writed to file"));
				JsonOperations.ProccessLog(new LogData("Exit from program"));
				break;
			}
			else if (GuestMenu[optionG] == "Vacancies")
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("\n\n\n");
				Console.Write(@"
                 █████╗ ██╗     ██╗         ██╗   ██╗ █████╗  ██████╗ █████╗ ███╗   ██╗ ██████╗██╗███████╗███████╗
                ██╔══██╗██║     ██║         ██║   ██║██╔══██╗██╔════╝██╔══██╗████╗  ██║██╔════╝██║██╔════╝██╔════╝
                ███████║██║     ██║         ██║   ██║███████║██║     ███████║██╔██╗ ██║██║     ██║█████╗  ███████╗
                ██╔══██║██║     ██║         ╚██╗ ██╔╝██╔══██║██║     ██╔══██║██║╚██╗██║██║     ██║██╔══╝  ╚════██║
                ██║  ██║███████╗███████╗     ╚████╔╝ ██║  ██║╚██████╗██║  ██║██║ ╚████║╚██████╗██║███████╗███████║
                ╚═╝  ╚═╝╚══════╝╚══════╝      ╚═══╝  ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝╚═╝╚══════╝╚══════╝
				"
				); Console.WriteLine("\n\n");

				foreach (var e in employers)
					ShowAllVacanciesBy(v => v.IsConfirmed, e.Vacancies, false, false, true);

				JsonOperations.ProccessLog(new LogData("Vacancies Showed"));
				Pause();
			}
			else if (GuestMenu[optionG] == "Workers")
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.Write(@"



				 _    _ _  __        __         _                 
			    / \  | | | \ \      / /__  _ __| | _____ _ __ ___ 
			   / _ \ | | |  \ \ /\ / / _ \| '__| |/ / _ \ '__/ __|
			  / ___ \| | |   \ V  V / (_) | |  |   <  __/ |  \__ \
			 /_/   \_\_|_|    \_/\_/ \___/|_|  |_|\_\___|_|  |___/
				"
				); Console.WriteLine("\n\n");

				foreach (var worker in workers)
					worker.Show();

				JsonOperations.ProccessLog(new LogData("Workers Showed"));
				Pause();
			}
			else if (GuestMenu[optionG] == "Log In")
			{
				List<string> LoginMenu = new() { "ADMIN", "EMPLOYER", "WORKER", "BACK" };
				int optionL = 0;

				while (true)
				{
					Console.Clear();
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.WriteLine("\n\n\n");
					Console.WriteLine(@"
					██╗      ██████╗  ██████╗     ██╗███╗   ██╗
					██║     ██╔═══██╗██╔════╝     ██║████╗  ██║
					██║     ██║   ██║██║  ███╗    ██║██╔██╗ ██║
					██║     ██║   ██║██║   ██║    ██║██║╚██╗██║
					███████╗╚██████╔╝╚██████╔╝    ██║██║ ╚████║
					╚══════╝ ╚═════╝  ╚═════╝     ╚═╝╚═╝  ╚═══╝
					"); Console.WriteLine("\n\n\n");

					Console.ForegroundColor = ConsoleColor.White;
					ShowMenu(in LoginMenu, optionL);

					if (!(KeyCheck(ref optionL, 0, LoginMenu.Count - 1))) continue;

					if (LoginMenu[optionL] == "BACK") break;
					else if (LoginMenu[optionL] == "ADMIN")
					{
						string email = AdditionalFunctions.GetEmail();
						string password = AdditionalFunctions.GetPassword();

						if (CheckUser("ADMIN", email, password) == false)
						{
							Console.WriteLine("\n\t\tPassword is Wrong\n\t\tPlease enter a correct password\n");
							Pause();
							continue;
						}

						AdminOperation();
						JsonOperations.ProccessLog(new LogData("Admin LogIn-ed"));
					}
					else if (LoginMenu[optionL] == "EMPLOYER" || LoginMenu[optionL] == "WORKER")
					{
						Person? p1 = LogIn(LoginMenu[optionL]);

						if (p1 == null)
						{
							Console.WriteLine("\n\n\t\t\tEmail or Password is Wrong.\n\t\t\tPlease Enter Correct Data.");
							Pause();
							continue;
						}

						if (LoginMenu[optionL] == "EMPLOYER")
						{
							Employer? e1 = (Employer)p1;

							JsonOperations.ProccessLog(new LogData("Employer LogIn-ed"));
							EmployerOperation(ref e1);
						}
						else if (LoginMenu[optionL] == "WORKER")
						{
							Worker? w1 = (Worker)p1;

							JsonOperations.ProccessLog(new LogData("Worker LogIn-ed"));
							WorkerOperation(ref w1);
						}
					}
				}
			}
			else if (GuestMenu[optionG] == "Sign Up")
			{
				List<string> SignMenu = new() { "EMPLOYER", "WORKER", "BACK" };
				int optionS = 0;

				while (true)
				{
					Console.Clear();
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.WriteLine("\n\n\n");
					Console.WriteLine(@"
                    ███████╗██╗ ██████╗ ███╗   ██╗    ██╗   ██╗██████╗ 
                    ██╔════╝██║██╔════╝ ████╗  ██║    ██║   ██║██╔══██╗
                    ███████╗██║██║  ███╗██╔██╗ ██║    ██║   ██║██████╔╝
                    ╚════██║██║██║   ██║██║╚██╗██║    ██║   ██║██╔═══╝ 
                    ███████║██║╚██████╔╝██║ ╚████║    ╚██████╔╝██║     
                    ╚══════╝╚═╝ ╚═════╝ ╚═╝  ╚═══╝     ╚═════╝ ╚═╝     
					"); Console.WriteLine("\n\n\n");

					Console.ForegroundColor = ConsoleColor.White;
					ShowMenu(in SignMenu, optionS);

					if (!(KeyCheck(ref optionS, 0, SignMenu.Count - 1))) continue;

					if (SignMenu[optionS] == "BACK")
						break;
					else if (SignMenu[optionS] == "EMPLOYER" || SignMenu[optionS] == "WORKER")
						SignUp(SignMenu[optionS]);
					JsonOperations.ProccessLog(new LogData($"{SignMenu[optionS]} LogIn-ed"));
				}
			}
			else if (GuestMenu[optionG] == "About Us")
			{
				List<string> langs = new() { "Azerbaycanca", "in English" };
				int opt = 0;

				while (true)
				{
					Console.Clear();

					Console.WriteLine("\n\n\n\n");
					ShowMenu(in langs, opt);

					if (!(KeyCheck(ref opt, 0, langs.Count - 1))) continue;

					Console.Clear();
					Console.WriteLine("\n\n\n");

					Console.ForegroundColor = ConsoleColor.White;

					if (langs[opt] == "Azerbaycanca")
						AdditionalFunctions.TextAnimation(@"
						
		İnnovasiya ile fursetin qovushdugu Boss.az-da dinamik komandamiza qoshulun! 
		Biz istedadli shexsleri arzuladiqlari karyera ile elaqelendirmeye hesr olunmush aparici ish saytiyiq. 
		Hem ish axtaranlar, hem de ishegoturenler uchun esas platforma olaraq, biz emekdashliq ve inkluziv ish muhitini inkishaf etdirmekle fexr edirik.
		Boss.az-da biz ferdlere oz potensiallarini tam shekilde chatdirmaq uchun selahiyyetlerin verilmesine inaniriq. 
		Komanda uzvu olaraq, insanlarin dolgun ish imkanlari tapmalarina komek etmekle onlarin heyatina menali tesir gostermek shansiniz olacaq. 
		Mukemmelliye sadiqliyimiz bizi daim tekmilleshmeye ve daim deyishen ish bazarina uygunlashmaga sovq edir.
		Boyumeye davam etdikce, biz oz unikal bacariqlarini ve perspektivlerini teqdim etmeye can atan ehtirasli shexsleri axtaririq. 
		İster tecrubeli peshekar olun, isterse de karyera seyahetinize yeni bashlasaniz, komandamizda sizin uchun yer var. 
		Boss.az-da bize qoshulun ve heqiqeten qeyri-adi bir sheyin bir hissesi olun!
							
							");
					else if (langs[opt] == "in English")
						AdditionalFunctions.TextAnimation(@"

		Join our dynamic team at Boss.az, where innovation meets opportunity! 
		We are a leading job site dedicated to connecting talented individuals with their dream careers. 
		As the premier platform for job seekers and employers alike, we pride ourselves on fostering a collaborative and inclusive work environment
		At Boss.az, we believe in empowering individuals to reach their full potential.
		As a team member, you'll have the chance to make a meaningful impact on people's lives by helping them find fulfilling employment opportunities.
		Our commitment to excellence drives us to constantly evolve and adapt to the ever-changing job market.
		As we continue to grow, we're seeking passionate individuals who are eager to contribute their unique skills and perspectives.
		Whether you're a seasoned professional or just starting your career journey, there's a place for you on our team. 
		Join us at Boss.az and be part of something truly extraordinary!
						
						");

					JsonOperations.ProccessLog(new LogData($"About Us Runned"));
					Pause();
					break;
				}
			}

			JsonOperations.WriteToFile(workers, "Workers.json");
			JsonOperations.WriteToFile(employers, "Employers.json");
			JsonOperations.ProccessLog(new LogData("Datas writed to file"));
		}
	}

	public void DeleteVacancie(List<Employer> empls)
	{
		JsonOperations.ProccessLog(new LogData("Delete Vacancie Function Runned."));

		List<string> DeleteMenu = new() { "BACK" };
		int optionD = 0;

		foreach (var e in empls)
		{
			foreach (var v in e.Vacancies)
				DeleteMenu.Add(v.VacancieId.ToString());
		}

		while (true)
		{
			Console.Clear();

			Console.WriteLine("\n\n\t\t\tPress ' Enter ' for delete\n\n\n");
			ShowMenu(in DeleteMenu, optionD);

			if (!(KeyCheck(ref optionD, 0, DeleteMenu.Count - 1))) continue;

			if (DeleteMenu[optionD] == "BACK") break;

			foreach (var e in empls)
			{
				if (e.CheckVacancieById(DeleteMenu[optionD]))
				{
					Console.Clear();
					e.Vacancies.Remove(e.Vacancies.Find(v => v.VacancieId.ToString() == DeleteMenu[optionD]));
					if (e.DeleteVacancie(DeleteMenu[optionD]))
						Console.WriteLine("\n\n\t\t\tVacancie Deleted.\n\n");
					else
						Console.WriteLine("\n\n\t\t\tVacancie Not Found or Not Deleted.\n\n");

					Pause();
					break;
				}
			}

			break;
		}
	}

	public void AdminOperation()
	{
		JsonOperations.ProccessLog(new LogData("Admin Function Runned."));

		List<string> AdminMenu = new() { "Confirm Vacancies", "Show Vacancies By Filter", "Delete Vacancies", "Change My Password", "Add User", "BACK" };

		int optionA = 0;

		while (true)
		{
			Console.Clear();

			Console.WriteLine("\n\n\n\n");
			ShowMenu(in AdminMenu, optionA);

			if (!(KeyCheck(ref optionA, 0, AdminMenu.Count - 1))) continue;

			if (AdminMenu[optionA] == "BACK") break;

			if (AdminMenu[optionA] == "Confirm Vacancies")
			{
				List<string> ConfirmMenu = new() { "BACK", "Confirm All Vacancies" };
				int optionC = 0;

				foreach (var e in employers)
				{
					foreach (var v in e.Vacancies)
						if (!v.IsConfirmed)
							ConfirmMenu.Add(v.VacancieId.ToString());
				}

				while (true)
				{
					Console.Clear();
					Console.WriteLine("\n\n\t\t\tPress ' Enter ' for confirm vacancie\n\n\n");
					ShowMenu(in ConfirmMenu, optionC);

					if (!(KeyCheck(ref optionC, 0, ConfirmMenu.Count - 1))) continue;

					if (ConfirmMenu[optionC] == "BACK") break;
					else if (ConfirmMenu[optionC] == "Confirm All Vacancies")
					{
						try
						{
							foreach (var e in employers)
								e.ConfirmAllVacancies();

							Console.WriteLine("\n\t\tAll Vacancies are Confirmed.\n");
						}
						catch { Console.WriteLine("\n\t\tAll Vacancies Not Confirmed. Error in Confirmation.\n"); }
						finally
						{
							Pause();
						}
					}
					else
					{
						foreach (var e in employers)
						{
							if (e.CheckVacancieById(ConfirmMenu[optionC]))
							{
								Console.Clear();

								if (e.ConfirmVacancie(ConfirmMenu[optionC]))
									Console.WriteLine("\n\n\t\t\tVacancie Confirmed.\n\n");
								else
									Console.WriteLine("\n\n\t\t\tVacancie Not Found or Not Confirmed.\n\n");
								break;
							}
						}

						Pause();
						break;
					}
				}
			}
			else if (AdminMenu[optionA] == "Show Vacancies By Filter")
			{
				ShowVacanciesBy(null, true);
			}
			else if (AdminMenu[optionA] == "Delete Vacancies")
			{
				DeleteVacancie(employers);
			}
			else if (AdminMenu[optionA] == "Add User")
			{
				List<string> EmployerMenu = new() { "Add Worker", "Add Employer", "BACK" };
				int optionAB = 0;

				while (true)
				{
					Console.Clear();

					Console.WriteLine("\n\n\n\n");
					ShowMenu(in EmployerMenu, optionAB);

					if (!(KeyCheck(ref optionAB, 0, EmployerMenu.Count - 1))) continue;

					if (EmployerMenu[optionAB] == "BACK")
						return;
					else if (EmployerMenu[optionAB] == "Add Worker")
						SignUp("WORKER");
					else if (EmployerMenu[optionAB] == "Add Employer")
						SignUp("EMPLOYER");
				}
			}
			else if (AdminMenu[optionA] == "Change My Password")
			{
				Admin.Password = AdditionalFunctions.GetPassword();

				Console.WriteLine("\n\n\t\tPassword Changed.\n");
				Pause();
			}
		}
	}

	public void EmployerOperation(ref Employer user)
	{
		JsonOperations.ProccessLog(new LogData("Employer Function Runned."));
		List<string> EmployerMenu = new() { "My Vacancies", "My Notifications", "Add New Vacancie", "Delete Vacancie",
							"Show or Change My Data", "Show All Workers", "BACK" };
		int optionE = 0;

		while (true)
		{
			Console.Clear();

			Console.WriteLine("\n\n\n\n");
			ShowMenu(in EmployerMenu, optionE);

			if (!(KeyCheck(ref optionE, 0, EmployerMenu.Count - 1))) continue;

			if (EmployerMenu[optionE] == "BACK") return;

			if (EmployerMenu[optionE] == "My Vacancies")
			{
				Console.Clear();
				Console.WriteLine("\n\n");
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.Write(@"
                ███╗   ███╗██╗   ██╗    ██╗   ██╗ █████╗  ██████╗ █████╗ ███╗   ██╗ ██████╗██╗███████╗███████╗
                ████╗ ████║╚██╗ ██╔╝    ██║   ██║██╔══██╗██╔════╝██╔══██╗████╗  ██║██╔════╝██║██╔════╝██╔════╝
                ██╔████╔██║ ╚████╔╝     ██║   ██║███████║██║     ███████║██╔██╗ ██║██║     ██║█████╗  ███████╗
                ██║╚██╔╝██║  ╚██╔╝      ╚██╗ ██╔╝██╔══██║██║     ██╔══██║██║╚██╗██║██║     ██║██╔══╝  ╚════██║
                ██║ ╚═╝ ██║   ██║        ╚████╔╝ ██║  ██║╚██████╗██║  ██║██║ ╚████║╚██████╗██║███████╗███████║
                ╚═╝     ╚═╝   ╚═╝         ╚═══╝  ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝╚═╝╚══════╝╚══════╝
				"); Console.WriteLine("\n\n");

				ShowVacanciesBy(user);
			}
			else if (EmployerMenu[optionE] == "My Notifications")
			{
				user.ShowAllNotifications();
				Pause();
			}
			else if (EmployerMenu[optionE] == "Add New Vacancie")
			{
				try
				{
					var result = user.AddVacancie(AdditionalFunctions.GetNewVacancie());

					if (result) Console.WriteLine("\n\n\t\t\tVacancie Added.\n\n");
					else Console.WriteLine("\n\n\t\t\tVacancie NOT Added.\n\n");
				}
				catch { Console.WriteLine("\n\n\t\t\tAny Error. Vacancie NOT Added.\n\n"); }
				finally { Pause(); }
			}
			else if (EmployerMenu[optionE] == "Delete Vacancie")
			{
				DeleteVacancie(new List<Employer> { user });
			}
			else if (EmployerMenu[optionE] == "Show or Change My Data")
			{
				List<string> ESCDMenu = new() { "Show My Data", "Change My Data", "BACK" };
				int optionSCD = 0;

				while (true)
				{
					Console.Clear();

					Console.WriteLine("\n\n\n\n");
					ShowMenu(in ESCDMenu, optionSCD);

					if (!(KeyCheck(ref optionSCD, 0, ESCDMenu.Count - 1))) continue;

					if (ESCDMenu[optionSCD] == "BACK")
						break;
					else if (ESCDMenu[optionSCD] == "Show My Data")
					{
						Console.ForegroundColor = ConsoleColor.Cyan;
						user.Show(true);
					}
					else if (ESCDMenu[optionSCD] == "Change My Data")
						AdditionalFunctions.ChangePersonData("EMPLOYER", user);

					Pause();
				}
			}
			else if (EmployerMenu[optionE] == "Show All Workers")
			{
				while (true)
				{
					Console.Clear();

					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine("\n\n\n\t\t\tPress ' F ' Key for Show Full Worker ( By Id )");
					Console.WriteLine("\n\t\t\tPress ' B ' Key for Go Back\n\n");

					Console.ForegroundColor = ConsoleColor.Yellow;

					foreach (var worker in workers)
						worker.ShortShow();

					var keyW = Console.ReadKey();

					if (keyW.Key == ConsoleKey.F)
					{
						List<string> sWorkers = new() { "BACK" };

						foreach (var we in workers)
							sWorkers.Add(we.Id.ToString());

						int optionRV = 0;

						while (true)
						{
							Console.Clear();

							Console.WriteLine("\n\n");
							ShowMenu(in sWorkers, optionRV);

							if (!(KeyCheck(ref optionRV, 0, sWorkers.Count - 1))) continue;

							if (sWorkers[optionRV] == "BACK") break;
							else
							{
								Worker? sW = null;

								foreach (var we in workers)
								{
									if (we.Id.ToString() == sWorkers[optionRV])
										sW = we;
								}

								if (sW == null) break;

								while (true)
								{
									Console.ForegroundColor = ConsoleColor.Blue;
									Console.WriteLine("\n\n\t\t\tPress ' Enter ' Key for Request a Worker ( By Id )\n\n");
									Console.WriteLine("\t\t\tPress ' B ' Key for Go Back\n\n");

									Console.ForegroundColor = ConsoleColor.Yellow;

									sW.Show();

									var keyVD = Console.ReadKey();

									if (keyVD.Key == ConsoleKey.Enter)
									{
										string message = $"\n\t\t{user.Name} sizi ishe goturmek uchun muraciet edib." +
												 $"\n\n\t\tIshe Goturen Haqqinda\n\t{user.ToString()}\n";

										Notification notificationW = new(message);

										foreach (var we in workers)
										{
											if (we.Id.ToString() == sWorkers[optionRV])
											{
												we.AddNotification(ref notificationW);

												Network.SendNotificationToEmail(notificationW, we.Email);
												break;
											}
										}
										Console.Clear();
										Console.ForegroundColor = ConsoleColor.Green;
										Console.WriteLine("\n\n\t\tIshchiye muraciet gonderildi.\n\n");
										Pause();
									}
									else if (keyVD.Key == ConsoleKey.B)
									{
										break;
									}
								}
							}
						}
					}
					else if (keyW.Key == ConsoleKey.B)
					{
						break;
					}
				}

				Pause();
			}
		}
	}

	public void WorkerOperation(ref Worker user)
	{
		JsonOperations.ProccessLog(new LogData("Worker Function Runned."));

		List<string> WorkerMenu = new() { "Show All Vacancies", "My Notifications", "Show or Change My Data", "BACK" };
		int optionW = 0;

		while (true)
		{
			Console.Clear();

			Console.WriteLine("\n\n\n\n");
			ShowMenu(in WorkerMenu, optionW);

			if (!(KeyCheck(ref optionW, 0, WorkerMenu.Count - 1))) continue;

			if (WorkerMenu[optionW] == "BACK") return;

			if (WorkerMenu[optionW] == "Show All Vacancies")
			{
				while (true)
				{
					Console.Clear();
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine("\n\n\n\t\t\tPress ' F ' Key for Show Full Vacancie ( By Id )");
					Console.WriteLine("\n\t\t\tPress ' B ' Key for Go Back\n");
					Console.ForegroundColor = ConsoleColor.Yellow;

					foreach (var u in employers)
						ShowAllVacanciesBy(v => v.IsConfirmed, u.Vacancies, false, true, true);

					var keyV = Console.ReadKey();

					if (keyV.Key == ConsoleKey.F)
					{
						List<string> shortVs = new() { "BACK" };

						foreach (var u in employers)
							u.GetAllVacanciesIdBy(ref shortVs, v => v.IsConfirmed);

						int optionRV = 0;

						while (true)
						{
							Console.Clear();

							Console.WriteLine("\n\n");
							ShowMenu(in shortVs, optionRV);

							if (!(KeyCheck(ref optionRV, 0, shortVs.Count - 1))) continue;

							if (shortVs[optionRV] == "BACK") break;
							else
							{
								Vacancie? sVacancie = null;

								foreach (var u in employers)
								{
									if (u.CheckVacancieById(shortVs[optionRV]))
										sVacancie = u.GetVacancie(shortVs[optionRV]);
								}

								if (sVacancie == null) break;

								while (true)
								{
									Console.ForegroundColor = ConsoleColor.Blue;
									Console.WriteLine("\n\n\n\t\t\tPress ' Enter ' Key for Request a Vacancy ( By Id )\n\n");
									Console.WriteLine("\t\t\tPress ' B ' Key for Go Back\n\n");
									Console.ForegroundColor = ConsoleColor.Yellow;

									sVacancie.Show();

									var keyVD = Console.ReadKey();

									if (keyVD.Key == ConsoleKey.Enter)
									{
										string message = $"\n\t\t{user?.Name} Sizin vakansiyaya muraciet edib." +
											 $"\n\t Vakansiyanin IDsi : {shortVs[optionRV]}" +
											 $"\n\n\t\tIshchi Haqqinda\n\t{user?.ToString()}\n";

										Notification notificationW = new(message);

										foreach (var e in employers)
										{
											if (e.CheckVacancieById(shortVs[optionRV]))
											{
												e.AddNotification(ref notificationW);

												Network.SendNotificationToEmail(notificationW, e.Email);
												break;
											}
										}
										Console.Clear();
										Console.ForegroundColor = ConsoleColor.Green;
										Console.WriteLine("\n\n\t\tVakansiyaya muraciet edildi.\n\n");
										Pause();
									}
									else if (keyVD.Key == ConsoleKey.B)
									{
										break;
									}
								}
							}
						}
					}
					else if (keyV.Key == ConsoleKey.B)
					{
						break;
					}
				}
			}
			else if (WorkerMenu[optionW] == "My Notifications")
			{
				user.ShowAllNotifications();
				Pause();
			}
			else if (WorkerMenu[optionW] == "Show or Change My Data")
			{
				List<string> SCDMenu = new() { "Show My Data", "Change My Data", "BACK" };
				int optionSCD = 0;

				while (true)
				{
					Console.Clear();

					Console.WriteLine("\n\n\n\n");
					ShowMenu(in SCDMenu, optionSCD);

					if (!(KeyCheck(ref optionSCD, 0, SCDMenu.Count - 1))) continue;

					if (SCDMenu[optionSCD] == "BACK")
						break;
					else if (SCDMenu[optionSCD] == "Show My Data")
						user.Show(true);
					else if (SCDMenu[optionSCD] == "Change My Data")
						AdditionalFunctions.ChangePersonData("WORKER", user);

					Pause();
				}
			}
		}
	}

	public void ShowVacanciesByFilter(List<Vacancie> vacancies)
	{
		List<string> FVacancieMenu = new() { "Show By Age Range", "Show By Experience Year Range",
								"Show By Salary Range", "BACK" };
		int optionVF = 0;

		while (true)
		{
			Console.Clear();
			Console.WriteLine("\n\n\n\n");
			ShowMenu(in FVacancieMenu, optionVF);

			if (!(KeyCheck(ref optionVF, 0, FVacancieMenu.Count - 1))) continue;

			if (FVacancieMenu[optionVF] == "BACK")
				return;
			else if (FVacancieMenu[optionVF] == "Show By Age Range")
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("\n\t\t\t\tEnter the Min Age : ");

				Console.ForegroundColor = ConsoleColor.Yellow;
				int minAge = int.Parse(Console.ReadLine());

				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("\n\t\t\t\tEnter the Max Age : ");

				Console.ForegroundColor = ConsoleColor.Yellow;
				int maxAge = int.Parse(Console.ReadLine());

				ShowAllVacanciesBy(v =>
				{
					if (v.MaxAge >= minAge && v.MinAge <= maxAge) return true;
					else return false;
				}, vacancies);
			}
			else if (FVacancieMenu[optionVF] == "Show By Experience Year Range")
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("\n\t\t\t\tEnter the Min Experience Year : ");

				Console.ForegroundColor = ConsoleColor.Yellow;
				int minExp = int.Parse(Console.ReadLine());

				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("\n\t\t\t\tEnter the Max Experience Year : ");

				Console.ForegroundColor = ConsoleColor.Yellow;
				int maxExp = int.Parse(Console.ReadLine());

				ShowAllVacanciesBy(v =>
				{
					if (v.MaxExpYear >= minExp && v.MinExpYear <= maxExp) return true;
					else return false;
				}, vacancies);
			}
			else if (FVacancieMenu[optionVF] == "Show By Salary Range")
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("\n\t\t\t\tEnter the Min Salary : ");

				Console.ForegroundColor = ConsoleColor.Yellow;
				double minSalary = int.Parse(Console.ReadLine());

				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("\n\t\t\t\tEnter the Max Salary : ");

				Console.ForegroundColor = ConsoleColor.Yellow;
				double maxSalary = int.Parse(Console.ReadLine());

				ShowAllVacanciesBy(v =>
				{
					if (v.MaxSalary >= minSalary && v.MinSalary <= maxSalary) return true;
					else return false;
				}, vacancies);
			}

			Pause();
		}
	}

	public void ShowVacanciesBy(in Employer employer, bool isAdminCall = false)
	{
		List<string> AVacancieMenu = new() { "Show By Filter", "Show All", "Show Time Actives", "Show Time Endeds",
								"Show Confirmeds", "Show Not Confirmeds", "BACK" };
		int optionVA = 0;

		if (!isAdminCall && employer == null) return;

		List<Vacancie>? vacancies = null;

		while (true)
		{
			Console.Clear();
			Console.WriteLine("\n\n\n\n");
			ShowMenu(in AVacancieMenu, optionVA);

			if (!(KeyCheck(ref optionVA, 0, AVacancieMenu.Count - 1))) continue;

			if (AVacancieMenu[optionVA] == "BACK") return;

			try
			{
				if (vacancies == null)
					vacancies = (isAdminCall ? (employers.SelectMany(e => e.Vacancies).ToList()) : employer.Vacancies);

				switch (AVacancieMenu[optionVA])
				{
					case "Show By Filter":
						ShowVacanciesByFilter(vacancies);
						break;
					case "Show All":
						ShowAllVacanciesBy(v => true, vacancies, true, (employer == null ? false : true));
						break;
					case "Show Confirmeds":
						ShowAllVacanciesBy(v => v.IsConfirmed, vacancies, true, (employer == null ? false : true));
						break;
					case "Show Not Confirmeds":
						ShowAllVacanciesBy(v => !v.IsConfirmed, vacancies, true, (employer == null ? false : true));
						break;
					case "Show Time Actives":
						ShowAllVacanciesBy(v => true, vacancies, (employer == null ? false : true));
						break;
					case "Show Time Endeds":
						ShowAllVacanciesBy(v => { return (v.IsConfirmed) && (v.EndingDate < DateTime.Now); },
								vacancies, true, (employer == null ? false : true));
						break;
				}
			}
			catch { Console.WriteLine("\n\n\t\tUnnamed Error in Show Vacancies.\n\n"); }
			finally { Pause(); }
		}
	}

	public void ShowAllVacanciesBy(Func<Vacancie, bool> predicate, List<Vacancie> vacancies, bool showTimeEndedVacancie = false,
									bool shortShow = false, bool increaseViewCount = false)
	{
		foreach (var v in vacancies)
		{
			if (!showTimeEndedVacancie)
				if (v.EndingDate < DateTime.Now)
					continue;

			if (predicate(v))
			{
				if (shortShow) v.ShortShow(increaseViewCount);
				else v.Show(increaseViewCount);
			}
		}
	}

	public void SignUp(string userKey)
	{
		string name, surname, city, phone, email, verifyCode, password;
		DateOnly bd; bool gender;

		Console.Clear();
		Console.WriteLine("\n\n\n");

		name = AdditionalFunctions.GetName();
		surname = AdditionalFunctions.GetSurname();
		city = AdditionalFunctions.GetCity();
		phone = AdditionalFunctions.GetPhoneNumber();
		bd = AdditionalFunctions.GetBirthDate();
		gender = AdditionalFunctions.GetGender();
		email = AdditionalFunctions.GetEmail();

		Random random = new Random();

		while (true)
		{
			var code = random.Next(1001, 9989);

			if (Network.SendCodeToEmail(code.ToString(), email))
			{
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.Write("\n\t\t\t\tVerify Code sended to your email.");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.Write("\n\n\t\tVerify Code not sended. Something went wrong. Please try again.");
			}

			Console.Write("\n\t\t\t\tIf there is any Problem , write : ' stop '");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("\n\n\t\t\t\tEnter the Verify Code or (stop) : ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			verifyCode = Console.ReadLine();

			if (verifyCode == code.ToString()) break;
			else if (verifyCode == "stop")
			{ Console.WriteLine("Proccess Stopped."); Pause(); return; }

			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(
				"\n\n\t\t\tVerify Code resended to your email.\n\t\t\tPlease enter a correct Verify Code !\n\n");
			Pause();
			Console.Clear();
			Console.WriteLine("\n\n\n\n");
		}

		password = AdditionalFunctions.GetPassword();

		if (userKey == "WORKER")
		{
			try
			{
				Console.WriteLine("\n\n\t\t\tWould you like to add a your CV ?");
				Console.Write("\n\n\t\t\tAnswer (yes / no) : ");
				string? ans = Console.ReadLine();

				CV? cv = null;

				if (ans?.ToLower() == "yes")
					cv = AdditionalFunctions.GetCV();

				Worker w = new(name, surname, city, phone, bd, cv, gender, email, password);

				workers.Add(w);

				Console.WriteLine("\n\n\t\t\tSign Up Completed Successfully.\n\n");
			}
			catch { Console.WriteLine("\n\n\t\t\tSign Up Failed.\n\n"); }

			Pause();
		}
		else if (userKey == "EMPLOYER")
		{
			try
			{
				Employer e = new(name, surname, city, phone, bd, gender, email, password);

				employers.Add(e);

				Console.WriteLine("\n\n\t\t\tSign Up Completed Successfully.\n\n");
			}
			catch { Console.WriteLine("\n\n\t\t\tSign Up Failed.\n\n"); }

			Pause();
		}
	}

	public Person? LogIn(string userKey)
	{
		string email = AdditionalFunctions.GetEmail();
		string password = AdditionalFunctions.GetPassword();

		return GetUser(userKey, email, password);
	}

	public Person? GetUser(string userKey, string email, string password)
	{
		if (userKey == "WORKER")
			return workers.Find(wr => wr.Email == email && wr.Password == password);
		else if (userKey == "EMPLOYER")
			return employers.Find(em => em.Email == email && em.Password == password);

		return null;
	}

	public bool CheckUser(string userKey, string email, string password)
	{
		if (userKey == "WORKER")
		{
			foreach (var w in workers)
				if (w.Email == email && w.Password == password)
					return true;
		}
		else if (userKey == "EMPLOYER")
		{
			foreach (var e in employers)
				if (e.Email == email && e.Password == password)
					return true;
		}
		else if (userKey == "ADMIN")
		{
			if (Admin.Email == email && Admin.Password == password)
				return true;
		}

		return false;
	}

	public static bool KeyCheck(ref int option, int min, int max, bool isReverse = false)
	{
		ConsoleKeyInfo key = Console.ReadKey(true);

		if (key.Key == ConsoleKey.Enter)
		{
			return true;
		}
		else if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W ||
			key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
		{
			if (isReverse)
			{
				option++;
				if (option > max) option = min;
			}
			else
			{
				option--;
				if (option < min) option = max;
			}
		}
		else if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S ||
			key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
		{
			if (isReverse)
			{
				option--;
				if (option < min) option = max;
			}
			else
			{
				option++;
				if (option > max) option = min;
			}
		}

		return false;
	}

	public static void Pause()
	{
		Console.ForegroundColor = ConsoleColor.DarkRed;
		Console.WriteLine("\n\n\t\t\t\tPress any Key to Continue ...");
		Console.ForegroundColor = ConsoleColor.White;
		_ = Console.ReadKey();
	}

	public static void ShowMenu(in List<string> lst, in int opt, bool isVertical = true)
	{
		int index = 0;
		foreach (var txt in lst)
		{
			if (index == opt)
				Console.ForegroundColor = ConsoleColor.DarkGreen;

			if (isVertical)
				Console.Write($"\t\t\t\t{txt}\n\n");
			else
				Console.Write($"\t {txt} | ");

			Console.ForegroundColor = ConsoleColor.White;

			index++;
		}
	}

}

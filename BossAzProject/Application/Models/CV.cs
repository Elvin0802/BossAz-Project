
using BossAz.Application.HelperModels;

namespace BossAz.Application.Models;

public class CV
{
	public string Specialty { get; set; }
	public string School { get; set; }

	private double _uem = 0.0;
	public double UniEntryMark
	{
		get { return _uem; }
		set
		{
			if (value > 0.0 && value < 701.0) _uem = value;
			else throw new Exception("Uni Entry Mark is 0 to 700.");
		}
	}

	public string Skills { get; set; }
	public string Companies { get; set; }
	public List<Language> Languages { get; set; }
	public bool IsHonorsDiploma { get; set; }
	public string LinkOfGitHub { get; set; }
	public string LinkOfLinkedIn { get; set; }

	public CV(string specialty, string school, double uniEntryMark, string skills, string companies,
				bool isHonorsDiploma, string linkOfGitHub, string linkOfLinkedIn)
	{
		Specialty=specialty;
		School=school;
		UniEntryMark=uniEntryMark;
		Skills=skills;
		Companies=companies;
		Languages=new();
		IsHonorsDiploma=isHonorsDiploma;
		LinkOfGitHub=linkOfGitHub;
		LinkOfLinkedIn=linkOfLinkedIn;
	}
	public void AddLanguage(ref Language lang)
	{ Languages.Add(lang); }

	public override string ToString()
	{
		string text = $"Specialty : {Specialty}\n\t\tSchool : {School} | Uni Entry Mark : {UniEntryMark.ToString()}\n\t\t" +
		$"Skills : {Skills}\n\t\tCompanies : {Companies} | Is Have Honors Diploma : {(IsHonorsDiploma ? "Yes" : "No")}\n\t\t" +
		$"GitHub Link : {LinkOfGitHub} | LinkedIn Link : {LinkOfLinkedIn}\n\t\tLanguages known.";

		foreach (var l in Languages)
			text += $"\t\t{l?.ToString()}\n";

		return text;
    }
}
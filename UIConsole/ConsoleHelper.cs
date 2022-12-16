// Johan Vandaele - Versie: 20220501

using Model.Repositories;
using System.Text.RegularExpressions;

namespace UIConsole;

public enum OptionMode
{
	Optional = 0,
	Mandatory = 1
}

public enum SelectionMode
{
	None = 0,
	Single = 1,
	Multiple = 2
}

public enum ReturnNullEmpty
{
	Null = 0,
	Empty = 1
}

//public enum LoginResult
//{
//	OK = 0,
//	Ongeldig = 1,
//	EersteKeer = 2,
//	Vervallen = 3,
//	Oud = 4,
//}

public partial class Program
{
	private const int LengthInputLabel = 32;
	private static bool darkMode = false;
	private static TimeSpan paswoordDuurtijd = new TimeSpan(10, 0, 0, 1);

	// -------
	// Console
	// -------
	public static void InitConsole()
	{
#pragma warning disable CA1416 // Validate platform compatibility
		Console.SetWindowSize(142, 32);
#pragma warning restore CA1416 // Validate platform compatibility

		darkMode = ((string)LeesKeuzeUitLijst("Dark Mode", new List<object> { "J", "N", "j", "n" }, OptionMode.Mandatory)!).ToUpper() == "J";
		ResetConsole();
	}

	public static void ResetConsole()
	{
		Console.BackgroundColor = darkMode ? ConsoleColor.Black : ConsoleColor.White;
		Console.ForegroundColor = darkMode ? ConsoleColor.White : ConsoleColor.Black;
		Console.Clear();
	}

	// ---------
	// DrukToets
	// ---------
	public static void DrukToets()
	{
		Console.Write("\nDruk een toets");
		Console.ReadKey();
	}

	// ----------
	// LeesString
	// ----------
	public static string? LeesString(string label, int maxLength, OptionMode optionMode = OptionMode.Optional, ReturnNullEmpty returnNullEmpty = ReturnNullEmpty.Empty)
	{
		var input = string.Empty;

		while (true)
		{
			Console.Write($"{label + (optionMode == OptionMode.Mandatory ? "* : " : " : "),LengthInputLabel}");
			input = Console.ReadLine()!;

			if (optionMode == OptionMode.Mandatory && string.IsNullOrWhiteSpace(input))
			{
				ToonFoutBoodschap("Verplichte ingave...");
				continue;
			}
			else if (input.Length > maxLength)
			{
				ToonFoutBoodschap($"De ingave is te lang (max {maxLength} tekens)...");
				continue;
			}

			break;
		}

		if (string.IsNullOrWhiteSpace(input))
		{
			if (returnNullEmpty == ReturnNullEmpty.Null) return null;
			else return String.Empty;
		}
		else
			return input;
	}

	// ---------
	// LeesDatum
	// ---------
	public static DateTime? LeesDatum(string label, DateTime MinDate, DateTime MaxDate, OptionMode optionMode = OptionMode.Optional)
	{
		var input = string.Empty;
		DateTime datumParse;
		int maxLength = 10; // DD/MM/YYYY

		while (true)
		{
			Console.Write($"{label + (optionMode == OptionMode.Mandatory ? "* : " : " : "),LengthInputLabel}");
			input = Console.ReadLine()!;

			if (optionMode == OptionMode.Mandatory && string.IsNullOrWhiteSpace(input))
			{
				ToonFoutBoodschap("Verplichte ingave...");
				continue;
			}

			if (input.Length > maxLength)
			{
				ToonFoutBoodschap($"De ingave is te lang (max {maxLength} tekens)...");
				continue;
			}

			if (!string.IsNullOrWhiteSpace(input))
			{
				if (!DateTime.TryParse(input, out datumParse))
				{
					ToonFoutBoodschap("Ongeldige Datum...");
					continue;
				}

				if (datumParse < MinDate || datumParse > MaxDate)
				{
					ToonFoutBoodschap($"De datum moet liggen tussen {MinDate} en {MaxDate}...");
					continue;
				}
			}

			break;
		}

		if (string.IsNullOrWhiteSpace(input))
			return null;
		else
		{
			DateTime.TryParse(input, out datumParse);
			return datumParse;
		}
	}

	// -------
	// LeesInt
	// -------
	public static int? LeesInt(string label, int Min = int.MinValue, int Max = int.MaxValue, OptionMode optionMode = OptionMode.Optional)
	{
		var input = string.Empty;
		int intParse;

		while (true)
		{
			Console.Write($"{label + (optionMode == OptionMode.Mandatory ? "* : " : " : "),LengthInputLabel}");
			input = Console.ReadLine()!;

			if (optionMode == OptionMode.Mandatory && string.IsNullOrWhiteSpace(input))
			{
				ToonFoutBoodschap("Verplichte ingave...");
				continue;
			}

			if (!string.IsNullOrWhiteSpace(input))
			{
				if (!int.TryParse(input, out intParse))
				{
					ToonFoutBoodschap("Ongeldig getal...");
					continue;
				}

				if (intParse < Min || intParse > Max)
				{
					ToonFoutBoodschap($"Het getal moet liggen tussen {Min} en {Max}...");
					continue;
				}
			}

			break;
		}

		if (string.IsNullOrWhiteSpace(input))
			return null;
		else
		{
			int.TryParse(input, out intParse);
			return intParse;
		}
	}

	// -----------
	// LeesDecimal
	// -----------
	public static decimal? LeesDecimal(string label, decimal Min = decimal.MinValue, decimal Max = decimal.MaxValue, OptionMode optionMode = OptionMode.Optional)
	{
		var input = string.Empty;
		decimal decimalParse;

		while (true)
		{
			Console.Write($"{label + (optionMode == OptionMode.Mandatory ? "* : " : " : "),LengthInputLabel}");
			input = Console.ReadLine()!;

			if (optionMode == OptionMode.Mandatory && string.IsNullOrWhiteSpace(input))
			{
				ToonFoutBoodschap("Verplichte ingave...");
				continue;
			}

			if (!string.IsNullOrWhiteSpace(input))
			{
				if (!decimal.TryParse(input, out decimalParse))
				{
					ToonFoutBoodschap("Ongeldig getal...");
					continue;
				}

				if (decimalParse < Min || decimalParse > Max)
				{
					ToonFoutBoodschap($"Het getal moet liggen tussen {Min} en {Max}...");
					continue;
				}
			}

			break;
		}

		if (string.IsNullOrWhiteSpace(input))
			return null;
		else
		{
			decimal.TryParse(input, out decimalParse);
			return decimalParse;
		}
	}

	// ---------
	// LeesFloat
	// ---------
	public static float? LeesFloat(string label, float Min = float.MinValue, float Max = float.MaxValue, OptionMode optionMode = OptionMode.Optional)
	{
		var input = string.Empty;
		float floatParse;

		while (true)
		{
			Console.Write($"{label + (optionMode == OptionMode.Mandatory ? "* : " : " : "),LengthInputLabel}");
			input = Console.ReadLine()!;

			if (optionMode == OptionMode.Mandatory && string.IsNullOrWhiteSpace(input))
			{
				ToonFoutBoodschap("Verplichte ingave...");
				continue;
			}

			if (!string.IsNullOrWhiteSpace(input))
			{
				if (!float.TryParse(input, out floatParse))
				{
					ToonFoutBoodschap("Ongeldig getal...");
					continue;
				}

				if (floatParse < Min || floatParse > Max)
				{
					ToonFoutBoodschap($"Het getal moet liggen tussen {Min} en {Max}...");
					continue;
				}
			}

			break;
		}

		if (string.IsNullOrWhiteSpace(input))
			return null;
		else
		{
			float.TryParse(input, out floatParse);
			return floatParse;
		}
	}

	// --------
	// LeesBool
	// --------
	public static bool? LeesBool(string label, OptionMode optionMode = OptionMode.Optional)
	{
		bool inputReturn = false;
		int maxLength = 1;

		while (true)
		{
			Console.Write($"{label + " Y/N" + (optionMode == OptionMode.Mandatory ? "* : " : " : "),LengthInputLabel}");
			var input = Console.ReadLine()!.ToUpper();

			if (optionMode == OptionMode.Mandatory && string.IsNullOrWhiteSpace(input))
			{
				ToonFoutBoodschap("Verplichte ingave...");
				continue;
			}

			if (input.Length > maxLength)
			{
				ToonFoutBoodschap($"De ingave is te lang (max {maxLength} tekens)...");
				continue;
			}

			if (!(input == "Y" || input == "N"))
			{
				ToonFoutBoodschap("Ongeldige keuze (Y/N)...");
				continue;
			}

			if (input == "Y") inputReturn = true;

			break;
		}

		return inputReturn;
	}

	// ---------
	// LeesLijst
	// ---------
	public static List<object> LeesLijst(string titel, IEnumerable<object> l, List<string> displayValues, SelectionMode selectionMode = SelectionMode.None, OptionMode optionMode = OptionMode.Optional)
	{
		var lijst = l;

		ToonTitel($"{titel}{(selectionMode == SelectionMode.Multiple ? " (gescheiden door een comma)" : string.Empty)}", optionMode);

		List<object> gekozenObjecten = new List<object>();

		while (true)
		{
			string seqKeuzes;
			int intKeuze;
			int seq = 0;

			displayValues.ForEach(i => Console.WriteLine($"{(selectionMode == SelectionMode.None ? string.Empty : string.Format("{0:0000}\t", ++seq))}{i}"));

			// Multiple selection
			if (selectionMode == SelectionMode.Multiple)
			{
				seqKeuzes = LeesString("Geef de volgnummers uit de lijst", 1000, OptionMode.Optional)!;

				if (optionMode == OptionMode.Mandatory && string.IsNullOrWhiteSpace(seqKeuzes))
				{
					ToonFoutBoodschap("De keuze is verplicht.");
					continue;
				}

				if (optionMode == OptionMode.Optional && string.IsNullOrWhiteSpace(seqKeuzes)) break;

				string[] keuzes = seqKeuzes.Split(',');

				var okLijst = true;
				gekozenObjecten.Clear();

				// Validate
				foreach (var keuze in keuzes)
				{
					if (int.TryParse(keuze, out intKeuze))
					{
						if (intKeuze > 0 & intKeuze <= seq)
							gekozenObjecten.Add(lijst.ElementAt(intKeuze - 1));
						else
						{
							ToonFoutBoodschap($"Ongeldige keuze.  Keuze tussen 1 en {seq}.  Probeer opnieuw...");
							okLijst = false;
							break;
						}
					}
					else
					{
						ToonFoutBoodschap("De lijst mag enkel cijfers bevatten...");
						okLijst = false;
						break;
					}
				}

				if (okLijst) break;
			}

			// Single Selection
			if (selectionMode == SelectionMode.Single)
			{
				int? leesInt = LeesInt("Geef het volgnummer uit de lijst", 1, seq, OptionMode.Optional);
				intKeuze = leesInt == null ? 0 : (int)leesInt;

				if (intKeuze == 0 && optionMode == OptionMode.Mandatory)
				{
					ToonFoutBoodschap("De keuze is verplicht.");
					continue;
				}

				if (intKeuze > 0) gekozenObjecten.Add(lijst.ElementAt((int)intKeuze - 1));
				break;
			}

			// No Selection (display only)
			if (selectionMode == SelectionMode.None) break;
		}

		Console.WriteLine();

		return gekozenObjecten;
	}

	// -----------------
	// LeesKeuzeUitLijst
	// -----------------
	public static object? LeesKeuzeUitLijst(string label, List<object> keuzeLijst, OptionMode optionMode = OptionMode.Optional)
	{
		var input = string.Empty;
		var keuzes = " (" + string.Join(", ", keuzeLijst) + ")";

		while (true)
		{
			Console.Write($"{label + keuzes + (optionMode == OptionMode.Mandatory ? "* : " : " : "),LengthInputLabel}");
			input = Console.ReadLine()!;

			if (optionMode == OptionMode.Mandatory && string.IsNullOrWhiteSpace(input))
			{
				ToonFoutBoodschap("Verplichte ingave...");
				continue;
			}
			else if (!keuzeLijst.Contains(input))
			{
				ToonFoutBoodschap("Verkeerde keuze...");
				continue;
			}

			break;
		}

		if (!string.IsNullOrWhiteSpace(input))
			return keuzeLijst.ElementAt(keuzeLijst.IndexOf(input));
		else
			return null;
	}

	// ---------
	// LeesRegEx
	// ---------
	public static string LeesRegex(string label, Regex regex, OptionMode optionMode = OptionMode.Optional)
	{
		var input = string.Empty;

		while (true)
		{
			Console.Write($"{label + (optionMode == OptionMode.Mandatory ? "* : " : " : "),LengthInputLabel}");
			input = Console.ReadLine()!;

			if (optionMode == OptionMode.Mandatory && string.IsNullOrWhiteSpace(input))
			{
				ToonFoutBoodschap("Verplichte ingave...");
				continue;
			}
			else if (optionMode == OptionMode.Mandatory && !regex.Match(input).Success)
			{
				ToonFoutBoodschap("Verkeerd formaat...");
				continue;
			}

			break;
		}

		return input;
	}

	// ------------------
	// LeesTelefoonnummer
	// ------------------
	public static string LeesTelefoonNummer(string label = "Telefoonnummer", OptionMode optionMode = OptionMode.Optional)
		=> LeesRegex(label, new Regex(@"^((\+|00(\s|\s?\-\s?)?)32(\s|\s?\-\s?)?(\(0\)[\-\s]?)?|0)[1-9]((\s|\s?\-\s?)?[0-9])((\s|\s?-\s?)?[0-9])((\s|\s?-\s?)?[0-9])\s?[0-9]\s?[0-9]\s?[0-9]\s?[0-9]\s?[0-9]$"), optionMode);

	// --------------
	// LeesEmailAdres
	// --------------
	public static string LeesEmailAdres(string label = "Emailadres", OptionMode optionMode = OptionMode.Optional)
		=> LeesRegex(label, new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"), optionMode);

	// --------------
	// LeesWebsiteUrl
	// --------------
	public static string LeesWebsiteUrl(string label = "Website", OptionMode optionMode = OptionMode.Optional)
		=> LeesRegex(label, new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*"), optionMode);

	// ------------
	// LeesPaswoord
	// ------------
	public static string LeesPaswoord(string label, int minlengte = 8, int maxLengte = 64, OptionMode optionMode = OptionMode.Optional)
	{
		var paswoord = "";

		while (true)
		{
			paswoord = LeesString(label, maxLengte, optionMode)!;

			if ((optionMode == OptionMode.Mandatory) || (optionMode == OptionMode.Optional && paswoord.Length > 0))
			{
				// Minimum eight characters, one uppercase letter, one lowercase letter, one number and one special character:
				Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&_])[A-Za-z\d@$!%*?&_]{" + minlengte + "," + maxLengte + "}$");

				if (regex.IsMatch(paswoord))
					break;
				else
					ToonFoutBoodschap($"Het paswoord moet minsens 1 kleine letter, 1 hoofdletter, 1 cijfer bevatten en één speciaal teken.\nHet paswoord moet minstens {minlengte} tekens lang zijn.");
			}
			else
				break;
		}

		return paswoord;
	}

	// ---------
	// ToonTekst
	// ---------
	public static void ToonTekst(string tekst, ConsoleColor tekstkleur = ConsoleColor.Black)
	{
		if (tekstkleur == ConsoleColor.Black && darkMode) tekstkleur = ConsoleColor.White;

		var color = Console.ForegroundColor;
		Console.ForegroundColor = tekstkleur;
		Console.WriteLine(tekst);
		Console.ForegroundColor = color;
	}

	// -----------------
	// ToonFoutBoodschap
	// -----------------
	public static void ToonFoutBoodschap(string tekst) => ToonTekst(tekst, ConsoleColor.Red);

	// -----------------
	// ToonInfoBoodschap
	// -----------------
	public static void ToonInfoBoodschap(string tekst) => ToonTekst(tekst, ConsoleColor.DarkGreen);

	// ---------
	// ToonTitel
	// ---------
	public static void ToonTitel(string titel, OptionMode optionMode = OptionMode.Optional) => Console.WriteLine($"\n{titel + (optionMode == OptionMode.Mandatory ? "*" : "")}");
}

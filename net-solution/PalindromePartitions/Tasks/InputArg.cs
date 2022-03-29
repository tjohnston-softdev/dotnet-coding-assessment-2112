using System;
using System.Text.RegularExpressions;

namespace PalindromePartitions.Tasks
{
	// Functions related to input text argument.
	public class InputArg
	{
		private static readonly Regex Syntax = new Regex("^[A-Z0-9]+$", RegexOptions.IgnoreCase);
		private const int MaxLength = 100;
		
		// Read text string.
		public static string ReadInputText(string[] argArray)
        {
            string inputRes;
			
			try
			{
				// Read argument.
				inputRes = argArray[0];
			}
			catch
			{
				// Argument does not exist.
				inputRes = "";
			}
			
			return inputRes;
		}
		
		// Validate string length and characters.
		public static bool ValidateInputText(ref string inpTxt)
		{
			bool correctSyntax = Syntax.IsMatch(inpTxt);
            bool validRes = false;
			
			if (inpTxt.Length > 0 && inpTxt.Length <= MaxLength && correctSyntax)
			{
				// Valid
				validRes = true;
			}
			else if (inpTxt.Length > 0 && inpTxt.Length <= MaxLength)
			{
				// Invalid characters.
                throw new Exception("Input string must only contain alphanumeric characters.");
			}
			else if (inpTxt.Length > MaxLength)
			{
				// Too long.
                throw new Exception("Input string can only have up to 100 characters.");
			}
			else
			{
				// Empty.
                throw new Exception("Input string is missing.");
			}
			
			return validRes;
		}
		
	}
}
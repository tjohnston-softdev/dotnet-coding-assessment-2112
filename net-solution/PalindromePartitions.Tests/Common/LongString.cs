using System;

namespace PalindromePartitions.Tests.Common
{
    // Class used to write really long string for input validation.
	public class LongString
    {
		private static readonly Random RandGen = new Random();
		
		public static string Write()
		{
			string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string textRes = "";
			
			while (textRes.Length < 105)
			{
				// Adds random letter.
                int randomIndex = RandGen.Next(alphabet.Length);
				textRes += alphabet[randomIndex].ToString();
			}
			
			return textRes;
		}
		
    }
}
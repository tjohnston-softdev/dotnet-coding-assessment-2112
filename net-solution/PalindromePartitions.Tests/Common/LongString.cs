using System;

namespace PalindromePartitions.Tests.Common
{
    // Class used to write really long string for input validation.
	public class LongString
    {
		private static Random randGen = new Random();
		
		public static string Write()
		{
			string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			int randomIndex = -1;
			string textRes = "";
			
			while (textRes.Length < 105)
			{
				// Adds random letter.
				randomIndex = randGen.Next(alphabet.Length);
				textRes += alphabet[randomIndex].ToString();
			}
			
			return textRes;
		}
		
    }
}
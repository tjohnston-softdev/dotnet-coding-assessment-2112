using System;
using System.Text.RegularExpressions;
using PalindromePartitions.Classes;

namespace PalindromePartitions.Tests.Common
{
    // Class used to test Partition object contents.
	public class PartitionContents
    {
		// Valid 'Join' string syntax.
		private static Regex joinSyntax = new Regex("^[A-Z0-9]+(,[A-Z0-9]+)*", RegexOptions.IgnoreCase);
		
		
		// Checks whether the contents are valid.
		public static string Check(Partition resObj)
		{
			string joinedString = resObj.Join();
			bool correctSyntax = joinSyntax.IsMatch(joinedString);
			
			if (correctSyntax != true)
			{
				throw new Exception("Partition contains invalid characters");
			}
			
			return joinedString;
		}
		
		
		// Compares an initialized Partition object against the original string.
		public static void CompareInitializedConstructor(ref string origStr, Partition resObj)
		{
			int loopIndex = 0;
            bool compMatch = true;
			
			// Loop original strng characters.
			while (loopIndex >= 0 && loopIndex < origStr.Length && compMatch)
			{
				// Read both character and substring.
				string currentChar = origStr[loopIndex].ToString();
				string currentSubstring = resObj.GetSubstring(loopIndex);
				
				if (currentChar == currentSubstring)
				{
					// Matching partition substring.
					loopIndex += 1;
				}
				else
				{
					// Substring does not match.
					compMatch = false;
					throw new Exception("Initial split character partition does not match original string.");
				}
			}
		}
		
    }
}
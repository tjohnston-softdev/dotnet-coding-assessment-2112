using System;
using NUnit.Framework;
using System.Collections.Generic;
using PalindromePartitions.Classes;

namespace PalindromePartitions.Tests.Common
{
    // Class compares algorithm results to expected output.
	public class AlgorithmContents
    {
		
		// Main function.
		public static void CheckResults(List<string> expStrList, List<string> actStrList)
		{
			Assert.AreEqual(expStrList.Count, actStrList.Count);
			LoopComparison(expStrList, actStrList);
		}
		
		// Result comparison loop.
		private static void LoopComparison(List<string> expList, List<string> actList)
		{
			int loopIndex = 0;
			string currentActualString = "";
			bool currentUnique = false;
			bool currentExpectFound = false;
			
			bool canContinue = true;
			
			while (loopIndex >= 0 && loopIndex < actList.Count && canContinue == true)
			{
				// Validate actual output string.
				currentActualString = actList[loopIndex];
				currentUnique = CheckUnique(currentActualString, actList, loopIndex);
				currentExpectFound = FindExpected(currentActualString, expList);
				
				if (currentUnique == true && currentExpectFound == true)
				{
					// Match found.
					loopIndex = loopIndex + 1;
				}
				else if (currentUnique == true)
				{
					// Result not allowed.
					canContinue = false;
					ThrowExpectNotFound(currentActualString);
				}
				else
				{
					// Duplicate string.
					canContinue = false;
					ThrowDuplicateItem(currentActualString);
				}
			}
		}
		
		
		// Checks if a given string re-appears in the list.
		private static bool CheckUnique(string tgtString, List<string> strList, int originPoint)
		{
			int matchIndex = strList.IndexOf(tgtString, originPoint + 1);
			bool uniqueRes = true;
			
			if (matchIndex >= 0 && matchIndex > originPoint && matchIndex < strList.Count)
			{
				// Duplicate found.
				uniqueRes = true;
			}
			
			return uniqueRes;
		}
		
		// Checks if a given string is found in a list.
		private static bool FindExpected(string tgtString, List<string> strList)
		{
			int matchIndex = strList.IndexOf(tgtString);
			bool findRes = false;
			
			if (matchIndex >= 0 && matchIndex < strList.Count)
			{
				// Match found.
				findRes = true;
			}
			
			return findRes;
		}
		
		// 'Not expected result' error.
		private static void ThrowExpectNotFound(string missingItem)
		{
			string errTxt = "The partition '" + missingItem + "' is not one of the expected result items.";
			throw new Exception(errTxt);
		}
		
		
		// 'Duplicate item' error.
		private static void ThrowDuplicateItem(string dupeItem)
		{
			string errTxt = "The partition '" + dupeItem + "' appears multiple times in the result.";
			throw new Exception(errTxt);
		}
		
		
    }
}
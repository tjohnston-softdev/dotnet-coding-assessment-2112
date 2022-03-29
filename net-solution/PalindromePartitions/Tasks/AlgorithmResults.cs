using System;
using System.Collections.Generic;
using PalindromePartitions.Classes;

namespace PalindromePartitions.Tasks
{
	// Functions related to the algorithm result list.
	public class AlgorithmResults
	{
		// Max number of partitions to display.
		private const int MaxResultsDisplay = 100;
		
		
		// Initialize list of partitions using input string.
		public static List<Partition> InitializeList(ref string inpStr)
		{
			Partition charSplitObj = Partition.Initialize(ref inpStr);
			List<Partition> intlRes = new List<Partition>();
			
			intlRes.Add(charSplitObj);
			return intlRes;
		}
		
		
		// Output results to console.
		public static void OutputPartitions(List<Partition> resList)
		{
			if (resList.Count > 0)
			{
				// Call loop.
				PrintOutput(resList);
			}
			else
			{
				// Empty.
				Console.WriteLine("No partitions found");
			}
		}
		
		
		// Debug function indicates output mode based on given number. Used for unit testing.
		public static int GetOutputType(int resultCount)
        {
            int resultFlag;
			
			if (resultCount > 0 && resultCount <= MaxResultsDisplay)
			{
				// Complete.
				resultFlag = 1;
			}
			else if (resultCount > MaxResultsDisplay)
			{
				// Truncated.
				resultFlag = 0;
			}
			else
			{
				// Empty.
				resultFlag = -1;
			}
			
			return resultFlag;
		}
		
		
		// Output display loop.
		private static void PrintOutput(List<Partition> rList)
		{
            int loopCutoff = Math.Min(rList.Count, MaxResultsDisplay);

            // Header
			Console.WriteLine("");
			Console.WriteLine("---RESULTS---");
			
			// Loop writes individual partitions to console, up to 100.
			for (int loopIndex = 0; loopIndex < loopCutoff; loopIndex++)
			{
				Partition currentPartition = rList[loopIndex];
				string currentString = currentPartition.Join();
				Console.WriteLine(currentString);
			}
			
			if (rList.Count > MaxResultsDisplay)
			{
				// Truncate further results.
				TruncateResults(rList.Count);
			}
			
			// Footer.
			Console.WriteLine("---");
		}
		
		// Displays result truncate message.
		private static void TruncateResults(int totalResCount)
		{
			int truncateCount = totalResCount - MaxResultsDisplay;
            string outputString;
			
			if (truncateCount > 1)
			{
				// Multiple
				outputString = "...and " + truncateCount.ToString() + " others.";
			}
			else if (truncateCount == 1)
			{
				// One left
				outputString = "...and 1 other.";
			}
			else
			{
				// None
				outputString = "...and no others.";
			}
			
			Console.WriteLine("");
			Console.WriteLine(outputString);
		}
		
	}
}
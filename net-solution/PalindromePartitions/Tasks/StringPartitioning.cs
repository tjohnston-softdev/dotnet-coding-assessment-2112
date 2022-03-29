using System;
using System.Collections.Generic;
using PalindromePartitions.Classes;

namespace PalindromePartitions.Tasks
{
	// Partitioning algorithm.
	public class StringPartitioning
	{
		// Main function.
		public static void RunLoop(List<Partition> partitionList)
		{
            // Loop processes partitions as they are found.
			for (int loopIndex = 0; loopIndex < partitionList.Count; loopIndex++)
			{
				// Handle current partition.
				Partition currentBase = partitionList[loopIndex];
				DerivePossibilities(currentBase, partitionList);
			}
		}
		
		
		// Derives new partitions from a base object.
		private static void DerivePossibilities(Partition baseObj, List<Partition> parList)
		{
            // Outer loop merges an increasingly large number of substrings to find palindromes.
			for (int mergeCount = 1; mergeCount <= baseObj.Count; mergeCount++)
			{
				// Reset index.
				int startIndex = 0;

                // Inner loop iterates merge start points.
				while (startIndex >= 0 && startIndex < baseObj.Count)
				{
					// Merge given number of substrings.
					int endIndex = startIndex + mergeCount;
					
					// Reset current palindrome.
					string currentSubOrig = "";
					string currentSubRev = "";
					Partition currentDerived = Partition.Empty();
					bool currentAdd = false;
					bool currentExists = false;
					
					// Only merge strings if end index is in range.
					if (endIndex >= 0 && endIndex > startIndex && endIndex < baseObj.Count)
					{
						// Write palindrome strings.
						currentSubOrig = baseObj.MergeSubstrings(startIndex, endIndex);
						currentSubRev = PrepareReversedString(currentSubOrig);
					}
					
					// Checks if the current string is a palindrome.
					if (currentSubOrig.Length > 1 && currentSubOrig.ToLower() == currentSubRev)
					{
						// Create new partition.
						currentDerived = Partition.Derive(baseObj, currentSubOrig, startIndex, endIndex);
						currentAdd = true;
						currentExists = CheckPartitionExists(currentDerived, parList);
					}
					
					
					if (currentAdd && !currentExists)
					{
						// Save partition if it does not already exist.
						parList.Add(currentDerived);
					}
					
					// Continue searching.
					startIndex = startIndex + 1;
				}
			}
		}
		
		
		// Reverses given string without casing.
		private static string PrepareReversedString(string origStr)
		{
			char[] charSplit = origStr.ToCharArray();

            Array.Reverse(charSplit);
			string revRes = new string(charSplit);
			revRes = revRes.ToLower();
			
			return revRes;
		}
		
		
		// Checks if a given partition already exists based on the final string.
		private static bool CheckPartitionExists(Partition newObj, List<Partition> existingObjects)
		{
			string tgtString = newObj.Join().ToLower();
			int existIndex = 0;

            bool existRes = false;
			
			// Loop until all items checked or duplicate partition found.
			while (existIndex >= 0 && existIndex < existingObjects.Count && !existRes)
			{
				// Write string from current partition.
				Partition currentExistingItem = existingObjects[existIndex];
				string currentJoin = currentExistingItem.Join().ToLower();
				
				if (currentJoin == tgtString) existRes = true;

                existIndex++;
            }
			
			return existRes;
		}
		
	}
	
}
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
			int loopIndex = 0;
			Partition currentBase = Partition.Empty();
			
			// Loop processes partitions as they are found.
			for (loopIndex = 0; loopIndex < partitionList.Count; loopIndex = loopIndex + 1)
			{
				// Handle current partition.
				currentBase = partitionList[loopIndex];
				DerivePossibilities(currentBase, partitionList);
			}
		}
		
		
		// Derives new partitions from a base object.
		private static void DerivePossibilities(Partition baseObj, List<Partition> parList)
		{
			int mergeCount = 1;
			int startIndex = 0;
			int endIndex = -1;
			string currentSubOrig = "";
			string currentSubRev = "";
			Partition currentDerived = Partition.Empty();
			bool currentAdd = false;
			bool currentExists = false;
			
			// Outer loop merges an increasingly large number of substrings to find palindromes.
			for (mergeCount = 1; mergeCount <= baseObj.Count; mergeCount = mergeCount + 1)
			{
				// Reset index.
				startIndex = 0;
				endIndex = -1;
				
				// Inner loop iterates merge start points.
				while (startIndex >= 0 && startIndex < baseObj.Count)
				{
					// Merge given number of substrings.
					endIndex = startIndex + mergeCount;
					
					// Reset current palindrome.
					currentSubOrig = "";
					currentSubRev = "";
					currentDerived = Partition.Empty();
					currentAdd = false;
					currentExists = false;
					
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
					
					
					if (currentAdd == true && currentExists != true)
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
			string revRes = "";
			
			Array.Reverse(charSplit);
			revRes = new string(charSplit);
			revRes = revRes.ToLower();
			
			return revRes;
		}
		
		
		// Checks if a given partition already exists based on the final string.
		private static bool CheckPartitionExists(Partition newObj, List<Partition> existingObjects)
		{
			string tgtString = newObj.Join().ToLower();
			int existIndex = 0;
			Partition currentExistingItem = Partition.Empty();
			string currentJoin = "";
			
			bool existRes = false;
			
			// Loop until all items checked or duplicate partition found.
			while (existIndex >= 0 && existIndex < existingObjects.Count && existRes != true)
			{
				// Write string from current partition.
				currentExistingItem = existingObjects[existIndex];
				currentJoin = currentExistingItem.Join().ToLower();
				
				if (currentJoin == tgtString)
				{
					// Match
					existRes = true;
				}
				
				existIndex = existIndex + 1;
			}
			
			return existRes;
		}
		
	}
	
}
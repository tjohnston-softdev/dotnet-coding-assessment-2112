using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PalindromePartitions.Classes
{
	// Partition object class.
	public class Partition
	{
		// Ignore substrings that contain invalid characters when parsing.
		private static Regex invalidChars = new Regex("[^A-Z0-9]+", RegexOptions.IgnoreCase);
		
		// Wrap string list.
		private List<string> substrings = new List<string>();
		
		
		// Base constructor.
		private Partition(List<string> listVal)
		{
			substrings = listVal;
		}
		
		
		// Constructor - Partition from input string.
		public static Partition Initialize(ref string fullStr)
		{
			int loopIndex = 0;
			string currentChar = "";
			bool currentSkip = false;
			List<string> charList = new List<string>();
			
			// Loop characters in string.
			for (loopIndex = 0; loopIndex < fullStr.Length; loopIndex = loopIndex + 1)
			{
				currentChar = fullStr[loopIndex].ToString();
				currentSkip = invalidChars.IsMatch(currentChar);
				
				if (currentSkip != true)
				{
					charList.Add(currentChar);
				}
				
			}
			
			Partition objectRes = new Partition(charList);
			return objectRes;
		}
		
		
		// Constructor - Empty.
		public static Partition Empty()
		{
			List<string> listObj = new List<string>();
			Partition objectRes = new Partition(listObj);
			return objectRes;
		}
		
		
		// Constructor - Parsed from comma-separated string.
		public static Partition Parse(string fullText)
		{
			string[] splitArray = new string[0];
			
			int subIndex = 0;
			string currentSubstring = "";
			bool badFound = false;
			
			List<string> listObj = new List<string>();
			
			// Split by comma.
			splitArray = fullText.Split(",", StringSplitOptions.RemoveEmptyEntries);
			
			
			// Loop substrings.
			for (subIndex = 0; subIndex < splitArray.Length; subIndex = subIndex + 1)
			{
				// Read substring and validate characters.
				currentSubstring = splitArray[subIndex];
				badFound = invalidChars.IsMatch(currentSubstring);
				
				// Add string if valid.
				if (currentSubstring.Length > 0 && badFound != true)
				{
					listObj.Add(currentSubstring);
				}
			}
			
			Partition objectRes = new Partition(listObj);
			return objectRes;
		}
		
		
		// Constructor - Derived partition.
		public static Partition Derive(Partition origObj, string foundPalindrome, int mergeStart, int mergeEnd)
		{
			// Retrieve sub-lists of parts before and after the new palindrome.
			int suffixStart = mergeEnd + 1;
			int suffixLength = origObj.Count - suffixStart;
			List<string> prefixList = origObj.Slice(0, mergeStart);
			List<string> suffixList = origObj.Slice(suffixStart, suffixLength);
			
			// Build new partition.
			List<string> completeList = new List<string>();
			completeList.AddRange(prefixList);
			completeList.Add(foundPalindrome);
			completeList.AddRange(suffixList);
			
			Partition objectRes = new Partition(completeList);
			return objectRes;
		}
		
		
		// Create sub-list of strings.
		public List<string> Slice(int sliceStart, int sliceLength)
		{
			List<string> sliceRes = new List<string>();
			
			if (sliceLength > 0)
			{
				sliceRes = substrings.GetRange(sliceStart, sliceLength);
			}
			
			return sliceRes;
		}
		
		
		// Merge substrings from given range.
		public string MergeSubstrings(int sIndex, int eIndex)
		{
			int prepStart = sIndex;
			int prepEnd = eIndex;
			int itemCount = -1;
			List<string> chosenElements = new List<string>();
			string mergeRes = "";
			
			// Swap range index numbers if need be.
			if (sIndex > eIndex || eIndex < sIndex)
			{
				prepStart = eIndex;
				prepEnd = sIndex;
			}
			
			// Select strings and merge together.
			itemCount = (prepEnd - prepStart) + 1;
			chosenElements = substrings.GetRange(prepStart, itemCount);
			mergeRes = String.Join("", chosenElements);
			
			return mergeRes;
		}
		
		
		// Write full partition string.
		public string Join()
		{
			string joinRes = String.Join(",", substrings);
			return joinRes;
		}
		
		// Read particular substring.
		public string GetSubstring(int tgtIndex)
		{
			string subRes = "";
			
			if (tgtIndex >= 0 && tgtIndex < substrings.Count)
			{
				subRes = substrings[tgtIndex];
			}
			
			return subRes;
		}
		
		
		// Substring count property.
		public int Count
		{
			get {return substrings.Count;}
		}
	}
}
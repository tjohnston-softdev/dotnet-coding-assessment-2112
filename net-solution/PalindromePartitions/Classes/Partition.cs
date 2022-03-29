using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PalindromePartitions.Classes
{
	// Partition object class.
	public class Partition
	{
		// Ignore substrings that contain invalid characters when parsing.
		private static readonly Regex InvalidChars = new Regex("[^A-Z0-9]+", RegexOptions.IgnoreCase);
		
		// Wrap string list.
		private readonly List<string> _substrings;
		
		
		// Base constructor.
		private Partition(List<string> listVal)
		{
			_substrings = listVal;
		}
		
		
		// Constructor - Partition from input string.
		public static Partition Initialize(ref string fullStr)
		{
            List<string> charList = new List<string>();
			
			// Loop characters in string.
			for (int loopIndex = 0; loopIndex < fullStr.Length; loopIndex++)
			{
				string currentChar = fullStr[loopIndex].ToString();
				bool currentSkip = InvalidChars.IsMatch(currentChar);
				
				if (currentSkip != true) charList.Add(currentChar);

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
            string[] splitArray = fullText.Split(",", StringSplitOptions.RemoveEmptyEntries);
            List<string> listObj = new List<string>();


			// Loop substrings.
			for (int subIndex = 0; subIndex < splitArray.Length; subIndex++)
			{
				// Read substring and validate characters.
				string currentSubstring = splitArray[subIndex];
				bool badFound = InvalidChars.IsMatch(currentSubstring);
				
				// Add string if valid.
				if (currentSubstring.Length > 0 && !badFound) listObj.Add(currentSubstring);
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
            if (sliceLength > 0) sliceRes = _substrings.GetRange(sliceStart, sliceLength);
            return sliceRes;
		}
		
		
		// Merge substrings from given range.
		public string MergeSubstrings(int sIndex, int eIndex)
		{
			int prepStart = sIndex;
			int prepEnd = eIndex;

            // Swap range index numbers if need be.
			if (sIndex > eIndex || eIndex < sIndex)
			{
				prepStart = eIndex;
				prepEnd = sIndex;
			}
			
			// Select strings and merge together.
			int itemCount = (prepEnd - prepStart) + 1;
			List<string> chosenElements = _substrings.GetRange(prepStart, itemCount);
			return String.Join("", chosenElements);
        }
		
		
		// Write full partition string.
		public string Join()
		{
			return String.Join(",", _substrings);
        }
		
		// Read particular substring.
		public string GetSubstring(int tgtIndex)
		{
			string subRes = "";
            if (tgtIndex >= 0 && tgtIndex < _substrings.Count) subRes = _substrings[tgtIndex];
            return subRes;
		}
		
		
		// Substring count property.
		public int Count => _substrings.Count;
    }
}
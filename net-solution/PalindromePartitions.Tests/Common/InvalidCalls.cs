using System;
using NUnit.Framework;
using PalindromePartitions.Classes;
using PalindromePartitions.Tasks;

namespace PalindromePartitions.Tests.Common
{
    // Calls functions using invalid input in a 'try-catch' structure.
	public class InvalidCalls
    {
		
		// Input argument validation - Populated.
		public static TryCatchResult ArgumentValidationPopulated(string entryValue)
		{
			string[] givenArgs = new string[1];
			string extractedValue = "";
			bool textValid = false;
			string excMsg = "";
			
			try
			{
				givenArgs[0] = entryValue;
				extractedValue = InputArg.ReadInputText(givenArgs);
				textValid = InputArg.ValidateInputText(ref extractedValue);
				
			}
			catch (Exception flaggedError)
			{
				textValid = false;
				excMsg = flaggedError.Message;
			}
			
			TryCatchResult resultObject = new TryCatchResult(textValid, excMsg);
			return resultObject;
		}
		
		
		// Input argument validation - Empty.
		public static TryCatchResult ArgumentValidationEmpty()
		{
			string[] emptyArr = new string[0];
			string readString = "";
			bool emptyValid = false;
			string excMsg = "";
			
			try
			{
				readString = InputArg.ReadInputText(emptyArr);
				emptyValid = InputArg.ValidateInputText(ref readString);
			}
			catch (Exception flaggedError)
			{
				emptyValid = false;
				excMsg = flaggedError.Message;
			}
			
			TryCatchResult resultObject = new TryCatchResult(emptyValid, excMsg);
			return resultObject;
		}
		
		
		// Slice partition.
		public static TryCatchResult PartitionSlice(Partition entryObj, int inpStart, int inpLength)
		{
			bool sliceValid = false;
			string excMsg = "";
			
			try
			{
				entryObj.Slice(inpStart, inpLength);
				sliceValid = true;
			}
			catch (Exception flaggedError)
			{
				sliceValid = false;
				excMsg = flaggedError.Message;
			}
			
			TryCatchResult resultObject = new TryCatchResult(sliceValid, excMsg);
			return resultObject;
		}
		
		
		// Merge partition substrings.
		public static TryCatchResult PartitionMerge(Partition entryObj, int inpStart, int inpEnd)
		{
			bool mergeValid = false;
			string excMsg = "";
			
			try
			{
				entryObj.MergeSubstrings(inpStart, inpEnd);
				mergeValid = true;
			}
			catch (Exception flaggedError)
			{
				mergeValid = false;
				excMsg = flaggedError.Message;
			}
			
			TryCatchResult resultObject = new TryCatchResult(mergeValid, excMsg);
			return resultObject;
			
		}
		
		// Check if correct error caught.
		public static void CheckErrorResult(TryCatchResult resObj, string expectedError)
		{
			Assert.False(resObj.Successful);
			Assert.AreEqual(resObj.ErrorMessage, expectedError);
		}
    }
}
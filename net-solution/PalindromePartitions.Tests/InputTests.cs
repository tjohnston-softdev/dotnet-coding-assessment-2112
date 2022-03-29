using System;
using NUnit.Framework;
using PalindromePartitions.Classes;
using PalindromePartitions.Tasks;
using PalindromePartitions.Tests.Common;

namespace PalindromePartitions.Tests
{
    // Unit tests for input validation.
	[TestFixture]
	public class InputTests
    {
		// Error message strings.
		private static string emptyErrorText = "Input string is missing.";
		private static string maxLengthText = "Input string can only have up to 100 characters.";
		private static string wrongCharsText = "Input string must only contain alphanumeric characters.";

        [Test]
        public void ValidString()
        {
			string[] givenArgs = {"qu1ck8r0wnf0x"};
			string retrievedText = InputArg.ReadInputText(givenArgs);
			bool testOutcome = InputArg.ValidateInputText(ref retrievedText);
			Assert.True(testOutcome);
        }
		
		
		[Test]
		public void EmptyArguments()
		{
			TryCatchResult testOutcome = InvalidCalls.ArgumentValidationEmpty();
			InvalidCalls.CheckErrorResult(testOutcome, emptyErrorText);
		}
		
		[Test]
		public void EmptyString()
		{
			TryCatchResult testOutcome = InvalidCalls.ArgumentValidationPopulated("");
			InvalidCalls.CheckErrorResult(testOutcome, emptyErrorText);
		}
		
		[Test]
		public void StringTooLong()
		{
			string reallyLongEntry = LongString.Write();
			TryCatchResult testOutcome = InvalidCalls.ArgumentValidationPopulated(reallyLongEntry);
			InvalidCalls.CheckErrorResult(testOutcome, maxLengthText);
		}
		
		[Test]
		public void InvalidCharacters()
		{
			TryCatchResult testOutcome = InvalidCalls.ArgumentValidationPopulated("qu!ck-#rwn-f()%");
			InvalidCalls.CheckErrorResult(testOutcome, wrongCharsText);
		}
		
		[Test]
		public void InvalidSpaces()
		{
			TryCatchResult testOutcome = InvalidCalls.ArgumentValidationPopulated("This string has spaces in it");
			InvalidCalls.CheckErrorResult(testOutcome, wrongCharsText);
		}
    }
}
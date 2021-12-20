using System;
using NUnit.Framework;
using PalindromePartitions.Classes;
using PalindromePartitions.Tests.Common;

namespace PalindromePartitions.Tests
{
    // Unit test for 'try-catch' object schema.
	[TestFixture]
	public class TryCatchSchema
    {
		[Test]
		public void FunctionExists()
		{
			Type classObject = typeof(TryCatchResult);
			Type boolType = typeof(bool);
			Type strType = typeof(string);
			
			SchemaValidation.CheckProperty(classObject, "successful", boolType);
			SchemaValidation.CheckProperty(classObject, "errorMessage", strType);
		}
		
    }
}
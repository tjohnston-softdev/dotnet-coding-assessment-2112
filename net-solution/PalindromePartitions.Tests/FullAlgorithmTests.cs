using System;
using System.Collections.Generic;
using NUnit.Framework;
using PalindromePartitions.Classes;
using PalindromePartitions.Tasks;
using PalindromePartitions.Tests.Common;

namespace PalindromePartitions.Tests
{
    // Unit tests for the full partitioning algorithm.
	[TestFixture]
	public class FullAlgorithmTests
    {
		[Test]
		public void FunctionExists()
		{
			Type classObject = typeof(StringPartitioning);
			SchemaValidation.CheckMethod(classObject, "RunLoop", typeof(void), true);
		}
		
		// 'geeks' input.
		[Test]
        public void Geeks()
        {
			List<Partition> testOutcome = CallAlgorithm(AlgorithmTestData.geeksInput);
			List<string> resultStrings = new List<string>();
			
			CheckResultObject(testOutcome, 2);
			resultStrings = PartitionReduce.Loop(testOutcome);
			AlgorithmContents.CheckResults(AlgorithmTestData.geeksOutput, resultStrings);
        }
		
		// 'aab' input.
		[Test]
		public void Letters()
		{
			List<Partition> testOutcome = CallAlgorithm(AlgorithmTestData.lettersInput);
			List<string> resultStrings = new List<string>();
			
			CheckResultObject(testOutcome, 2);
			resultStrings = PartitionReduce.Loop(testOutcome);
			AlgorithmContents.CheckResults(AlgorithmTestData.lettersOutput, resultStrings);
		}
		
		// Custom input.
		[Test]
		public void Custom()
		{
			List<Partition> testOutcome = CallAlgorithm(AlgorithmTestData.customInput);
			List<string> resultStrings = new List<string>();
			
			CheckResultObject(testOutcome, 12);
			resultStrings = PartitionReduce.Loop(testOutcome);
			AlgorithmContents.CheckResults(AlgorithmTestData.customOutput, resultStrings);
		}
		
		
		// Shared function runs partitioning algorithm.
		private static List<Partition> CallAlgorithm(string algoInput)
		{
			bool inputStringValid = InputArg.ValidateInputText(ref algoInput);
			List<Partition> resultList = new List<Partition>();
			
			if (inputStringValid == true)
			{
				resultList = AlgorithmResults.InitializeList(ref algoInput);
				StringPartitioning.RunLoop(resultList);
			}
			
			return resultList;
		}
		
		// Check result object type and length.
		private static void CheckResultObject(List<Partition> resObj, int expectedCount)
		{
			Assert.IsInstanceOf(typeof(List<Partition>), resObj);
			Assert.AreEqual(resObj.Count, expectedCount);
		}
		
    }
}
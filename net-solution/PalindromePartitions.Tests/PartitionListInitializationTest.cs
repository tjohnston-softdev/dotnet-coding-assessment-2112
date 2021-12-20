using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;
using PalindromePartitions.Classes;
using PalindromePartitions.Tasks;
using PalindromePartitions.Tests.Common;

namespace PalindromePartitions.Tests
{
    // Unit tests for 'partition list initialization' function.
	[TestFixture]
	public class PartitionListInitializationTest
    {
		[Test]
		public void FunctionExists()
		{
			Type classObject = typeof(AlgorithmResults);
			SchemaValidation.CheckMethod(classObject, "InitializeList", typeof(List<Partition>), true);
		}
		
		[Test]
        public void IntlTest()
        {
			string entryString = "initialize";
			Partition singlePartitionObject = Partition.Empty();
			List<Partition> preparedList = new List<Partition>();
			Partition listPartitionObject = Partition.Empty();
			string singleObjectJoin = "";
			string listObjectJoin = "";
			
			// Create stand-alone partition object.
			singlePartitionObject = Partition.Initialize(ref entryString);
			
			// Create listed partition object.
			preparedList = AlgorithmResults.InitializeList(ref entryString);
			Assert.AreEqual(preparedList.Count, 1);
			listPartitionObject = preparedList[0];
			
			// Check if partition substring counts match.
			Assert.AreEqual(entryString.Length, singlePartitionObject.Count);
			Assert.AreEqual(entryString.Length, listPartitionObject.Count);
			
			// Check if partition objects match.
			singleObjectJoin = singlePartitionObject.Join();
			listObjectJoin = listPartitionObject.Join();
			Assert.AreEqual(singleObjectJoin, listObjectJoin);
        }
		
    }
}
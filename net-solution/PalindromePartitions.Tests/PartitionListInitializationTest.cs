using System;
using System.Collections.Generic;
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
        public void IntlTest()
        {
			string entryString = "initialize";

            // Create stand-alone partition object.
			Partition singlePartitionObject = Partition.Initialize(ref entryString);

			// Create listed partition object.
			List<Partition> preparedList = AlgorithmResults.InitializeList(ref entryString);
			Assert.AreEqual(preparedList.Count, 1);
			Partition listPartitionObject = preparedList[0];
			
			// Check if partition substring counts match.
			Assert.AreEqual(entryString.Length, singlePartitionObject.Count);
			Assert.AreEqual(entryString.Length, listPartitionObject.Count);
			
			// Check if partition objects match.
			string singleObjectJoin = singlePartitionObject.Join();
			string listObjectJoin = listPartitionObject.Join();
			Assert.AreEqual(singleObjectJoin, listObjectJoin);
        }
		
    }
}
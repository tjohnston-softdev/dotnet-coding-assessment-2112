using System;
using System.Collections.Generic;
using PalindromePartitions.Classes;

namespace PalindromePartitions.Tests.Common
{
    // Class reduces a list of partitions into the joined strings.
	public class PartitionReduce
    {
		public static List<string> Loop(List<Partition> resObj)
		{
			int loopIndex = 0;
			Partition currentPartition = Partition.Empty();
			string currentString = "";
			
			List<string> reduceRes = new List<string>();
			
			for (loopIndex = 0; loopIndex < resObj.Count; loopIndex = loopIndex + 1)
			{
				// Join partition substrings together.
				currentPartition = resObj[loopIndex];
				currentString = currentPartition.Join();
				reduceRes.Add(currentString);
			}
			
			return reduceRes;
		}
    }
}
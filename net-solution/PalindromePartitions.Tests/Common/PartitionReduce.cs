using System.Collections.Generic;
using PalindromePartitions.Classes;

namespace PalindromePartitions.Tests.Common
{
    // Class reduces a list of partitions into the joined strings.
	public class PartitionReduce
    {
		public static List<string> Loop(List<Partition> resObj)
		{
            List<string> reduceRes = new List<string>();
			
			for (int loopIndex = 0; loopIndex < resObj.Count; loopIndex++)
			{
				// Join partition substrings together.
				Partition currentPartition = resObj[loopIndex];
				string currentString = currentPartition.Join();
				reduceRes.Add(currentString);
			}
			
			return reduceRes;
		}
    }
}
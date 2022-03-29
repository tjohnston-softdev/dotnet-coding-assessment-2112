using System;
using NUnit.Framework;
using PalindromePartitions.Tasks;
using PalindromePartitions.Tests.Common;

namespace PalindromePartitions.Tests
{
    // Unit tests for result output modes.
	[TestFixture]
	public class ResultOutputTests
    {
        [Test]
        public void Complete()
        {
			int testFlag = AlgorithmResults.GetOutputType(20);
			Assert.Positive(testFlag);
        }
		
		[Test]
		public void Truncated()
		{
			int testFlag = AlgorithmResults.GetOutputType(500);
			Assert.Zero(testFlag);
		}
		
		
		[Test]
		public void Empty()
		{
			int testFlag = AlgorithmResults.GetOutputType(-1);
			Assert.Negative(testFlag);
		}
		
    }
}
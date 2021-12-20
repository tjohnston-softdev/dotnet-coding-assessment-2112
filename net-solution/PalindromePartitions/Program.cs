using System;
using System.Collections.Generic;
using PalindromePartitions.Classes;
using PalindromePartitions.Tasks;

namespace PalindromePartitions
{
    // PalindromePartitions - Main script file.
	class Program
    {
        static void Main(string[] args)
        {
			string enteredText = "";
			bool inputValid = false;
			List<Partition> resultList = new List<Partition>();
			
			try
			{
				// Read and validate input text.
				enteredText = InputArg.ReadInputText(args);
				inputValid = InputArg.ValidateInputText(ref enteredText);
				
				if (inputValid == true)
				{
					// Perform algorithm.
					resultList = AlgorithmResults.InitializeList(ref enteredText);
					StringPartitioning.RunLoop(resultList);
					
					// Display results to console.
					AlgorithmResults.OutputPartitions(resultList);
				}
				
			}
			catch(Exception flaggedError)
			{
				// Display error message.
				Console.WriteLine("ERROR: " + flaggedError.Message);
			}
        }
    }
}

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
            try
			{
				// Read and validate input text.
				string enteredText = InputArg.ReadInputText(args);
				bool inputValid = InputArg.ValidateInputText(ref enteredText);
				
				if (inputValid)
				{
					// Perform algorithm.
                    List<Partition>  resultList = AlgorithmResults.InitializeList(ref enteredText);
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

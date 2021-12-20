// Palindrome Partition Mockup - Main file.

const inputArg = require("./src/input-arg");
const initializePartitions = require("./src/initialize-partitions");
const mergeParts = require("./src/merge-parts");
runMockup();


function runMockup()
{
	var enteredString = "";
	var partitionArray = [];
	
	var partitionIndex = 0;
	var currentBase = null;
	
	// Read and validate input string.
	enteredString = inputArg.getString(process.argv);
	inputArg.validateLength(enteredString.length);
	inputArg.validateChars(enteredString);
	
	// Initialize partition array.
	partitionArray = initializePartitions(enteredString);
	
	
	// Loop processes partitions as they are discovered.
	for (partitionIndex = 0; partitionIndex < partitionArray.length; partitionIndex = partitionIndex + 1)
	{
		currentBase = partitionArray[partitionIndex];
		outputResult(currentBase);
		mergeParts(currentBase, partitionArray);
	}
}


// Output result to console.
function outputResult(baseObj)
{
	var compStr = baseObj.join(",");
	console.log(compStr);
}
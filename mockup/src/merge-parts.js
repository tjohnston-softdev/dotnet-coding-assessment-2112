// Palindrome partitioning algorithm.


// Main function.
function loopPartMerging(baseObj, resultArray)
{
	var mergeCount = 1;
	
	var startIndex = -1;
	var endIndex = -1;
	var currentSubPart = [];
	var currentStringOrig = "";
	var currentStringRev = "";
	var currentPrefix = null;
	var currentMerge = null;
	var currentSuffix = null;
	var currentDerived = null;
	
	
	// Outer loop merges substrings in an increasingly large range.
	for (mergeCount = 1; mergeCount < baseObj.length; mergeCount = mergeCount + 1)
	{
		startIndex = 0;
		endIndex = -1;
		currentSubPart = [];
		currentStringOrig = "";
		currentStringRev = "";
		currentPrefix = null;
		currentMerge = null;
		currentSuffix = null;
		currentDerived = null;
		
		
		// Inner loop iterates merge range start points.
		while (startIndex >= 0 && startIndex < baseObj.length)
		{
			// Decide end point.
			endIndex = startIndex + (mergeCount + 1);
			
			// Reset current iteration.
			currentSubPart = [];
			currentStringOrig = "";
			currentStringRev = "";
			currentPrefix = null;
			currentMerge = null;
			currentSuffix = null;
			currentDerived = null;
			
			// Checks if end index is within range.
			if (endIndex >= 0 && endIndex > startIndex && endIndex < baseObj.length)
			{
				// Read current string.
				currentSubPart = baseObj.slice(startIndex, endIndex);
				currentStringOrig = currentSubPart.join("");
				currentStringRev = reverseString(currentStringOrig);
			}
			
			// Checks if the current string is a palindrome.
			if (currentStringOrig.length > 1 && currentStringRev.toLowerCase() === currentStringOrig.toLowerCase())
			{
				// Create new partition using found palindrome.
				currentPrefix = baseObj.slice(0, startIndex);
				currentMerge = [currentStringOrig];
				currentSuffix = baseObj.slice(endIndex);
				currentDerived = currentPrefix.concat(currentMerge, currentSuffix);
				
				resultArray.push(currentDerived);
			}
			
			// Continue searching.
			startIndex = startIndex + 1;
		}
	}
	
}

// Reverse given string.
function reverseString(origStr)
{
	var splitChars = origStr.split("");
	var stringRes = "";
	
	splitChars.reverse();
	stringRes = splitChars.join("");
	
	return stringRes;
}


module.exports = loopPartMerging;
// Create base partition.
function initializePartitionArray(inpStr)
{
	// Split input string by character.
	var splitChars = inpStr.split("");
	var intlRes = [splitChars];
	return intlRes;
}


module.exports = initializePartitionArray;
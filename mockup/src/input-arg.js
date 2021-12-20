// Input argument functions.


// Read string.
function getInputString(argArray)
{
	var arrayExists = Array.isArray(argArray);
	var argElement = null;
	var givenType = "";
	
	var stringRes = "";
	
	if (arrayExists === true && argArray.length > 2)
	{
		// Read command line argument.
		argElement = argArray[2];
		givenType = typeof argElement;
	}
	
	if (givenType === "string" && argElement.length > 0)
	{
		// Use value.
		stringRes = argElement;
	}
	
	return stringRes;
}


// Validate input string length.
function validateStringLength(inpLength)
{
	var maxLength = 100;
	var lengthValid = false;
	
	if (inpLength >= 0 && inpLength <= maxLength)
	{
		// Valid.
		lengthValid = true;
	}
	else if (inpLength > maxLength)
	{
		// Too long.
		throw new Error("Input string is too long.");
	}
	else
	{
		// Empty.
		throw new Error("Input string cannot be empty.");
	}
}


// Checks if input string is alphanumeric.
function validateStringCharacters(inpStr)
{
	var correctSyntax = /^[A-Z0-9]+$/gi;
	var matchFlag = inpStr.search(correctSyntax);
	
	if (matchFlag !== 0)
	{
		throw new Error("String must only contain alphanumeric characters.");
	}
}



module.exports =
{
	getString: getInputString,
	validateLength: validateStringLength,
	validateChars: validateStringCharacters
};
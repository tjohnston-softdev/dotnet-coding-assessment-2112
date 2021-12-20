namespace PalindromePartitions.Classes
{
	// Result object for 'try-catch' attempt - Unit tests only.
	public class TryCatchResult
	{
		// Private properties.
		private bool pSuccessful = false;
		private string pErrorMessage = "";
		
		
		// Constructor.
		public TryCatchResult(bool successVal, string msgVal)
		{
			pSuccessful = successVal;
			pErrorMessage = msgVal;
		}
		
		// Successful.
		public bool successful
		{
			get {return pSuccessful;}
		}
		
		// Error message string.
		public string errorMessage
		{
			get {return pErrorMessage;}
		}
	}
}
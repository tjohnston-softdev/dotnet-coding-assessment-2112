namespace PalindromePartitions.Classes
{
	// Result object for 'try-catch' attempt - Unit tests only.
	public class TryCatchResult
	{
		// Private properties.
		private bool _successful;
        private string _errorMessage;
		
		
		// Constructor.
		public TryCatchResult(bool successVal, string msgVal)
		{
            _successful = successVal;
            _errorMessage = msgVal;
		}
		
		// Successful property.
		public bool Successful => _successful;

        // Error message string property.
		public string ErrorMessage => _errorMessage;
    }
}
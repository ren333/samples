namespace CaliburnSampleApp.Main
{
    /// <summary>
    /// Data Model to store values for the Main View Model.
    /// </summary>
    public class MainDataModel
    {
        /// <summary>
        /// Stored message. 
        /// </summary>
        private string _message = "";
        
        /// <summary>
        /// Get/Set stored message.
        /// </summary>
        public string Message
        {
            get { return _message.Trim(); }
            set { _message = string.IsNullOrWhiteSpace(value) ? "" : value.Trim(); }
        }
    }
}

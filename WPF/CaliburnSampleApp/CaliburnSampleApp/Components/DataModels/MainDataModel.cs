namespace CaliburnSampleApp.Components
{
    /// <summary>
    /// Data Model to store values for the Main View Model.
    /// </summary>
    public class MainDataModel
    {
        #region Fields
        /// <summary>
        /// Stored message. 
        /// </summary>
        private string _message = "";
        #endregion

        #region Properties
        /// <summary>
        /// Get/Set stored message.
        /// </summary>
        public string Message
        {
            get => _message.Trim();
            set => _message = string.IsNullOrWhiteSpace(value) ? "" : value.Trim();
        }
        #endregion
    }
}

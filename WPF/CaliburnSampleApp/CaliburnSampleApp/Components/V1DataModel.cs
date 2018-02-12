namespace CaliburnSampleApp.Components
{
    public class V1DataModel
    {
        public int Id { get; set; }

        private string _description = "";
        public string Description
        {
            get { return _description.Trim(); }
            set { _description = (string.IsNullOrWhiteSpace(value)) ? "" : value.Trim(); }
        }

        public bool Hidden { get; set; }
    }
}

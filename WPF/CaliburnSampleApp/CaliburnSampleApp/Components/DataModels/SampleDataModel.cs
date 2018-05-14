namespace CaliburnSampleApp.Components.DataModels
{
    public class SampleDataModel
    {
        #region Properties

        public int Id
        {
            get => RandomData.Id;
            set => RandomData.Id = value;
        }
        public RandomData RandomData { get; set; }

        public string Description
        {
            get => RandomData.Name.Trim();
            set => RandomData.Name = string.IsNullOrWhiteSpace(value) ? "" : value.Trim();
        }

        public bool IsEnabled { get; set; }
        #endregion

        public SampleDataModel()
        {
            IsEnabled = true;
        }
    }
}

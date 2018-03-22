namespace CaliburnSampleApp.Components
{
    public class V1DataModel
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

        public V1DataModel()
        {
            IsEnabled = true;
        }
    }
}

using System;

namespace CaliburnSampleApp.Components
{
    public class V1DataModel
    {
        public int Id { get; set; }
        public RandomData RandomData { get; set; }

        public string Description
        {
            get { return RandomData.Name.Trim(); }
            set { RandomData.Name = string.IsNullOrWhiteSpace(value) ? "" : value.Trim(); }
        }

        public bool Hidden { get; set; }
    }
}

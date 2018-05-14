namespace CaliburnSampleApp.Components.ViewModels
{
    public class TemplateExamplesViewModel
    {
        public TemplatedDataGridViewModel TemplatedDataGridViewModel { get; }

        public TemplateExamplesViewModel(TemplatedDataGridViewModel templatedDataGridViewModel)
        {
            TemplatedDataGridViewModel = templatedDataGridViewModel;
        }
    }
}

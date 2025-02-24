namespace EventAggregator.Interfaces
{
    public interface IEventAggregator
    {
        #region Methods
        void Publish<TEvent>(TEvent eventToPublish);
        void Subscribe(object subscriber);
        #endregion
    }
}

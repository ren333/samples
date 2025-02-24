using EventAggregator.Interfaces;

namespace EventAggregator
{
    public class EventAggregator : IEventAggregator
    {
        #region Properties
        private readonly List<WeakReference> _subscribers = [];
        #endregion

        #region Methods
        public void Publish<TEvent>(TEvent eventToPublish)
        {
            foreach (var weakSubscriber in _subscribers.ToList())
            {
                if (weakSubscriber.Target is IHandle<TEvent> subscriber)
                {
                    subscriber.Handle(eventToPublish);
                }
                else if (!weakSubscriber.IsAlive)
                {
                    _subscribers.Remove(weakSubscriber);
                }
            }
        }

        public void Subscribe(object subscriber)
        {
            _subscribers.Add(new WeakReference(subscriber));
        }
        #endregion
    }

}

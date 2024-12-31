namespace ObserverPattern2
{
    /*
     使用委托和事件实现观察者模式
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            var subject = new Subject();
            var observer = new Observer(subject);

            subject.State = "New State"; // 这将触发通知

            observer.Detach(); // 取消订阅
            subject.State = "Another State"; // 这不会触发通知
        }
    }

    public class Subject
    {
        // 定义一个事件
        public event EventHandler StateChanged;

        private string _state;
        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                NotifyObservers();
            }
        }

        // 通知所有观察者
        protected virtual void NotifyObservers()
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Observer
    {
        private readonly Subject _subject;

        public Observer(Subject subject)
        {
            _subject = subject;
            _subject.StateChanged += OnStateChanged;
        }

        private void OnStateChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Observer: Subject state has changed!");
        }

        public void Detach()
        {
            _subject.StateChanged -= OnStateChanged;
        }
    }

    public class UpdateEventArgs : EventArgs
    {
        public string Message { get; set; }
        public UpdateEventArgs(string message)
        {
            Message = message;
        }
    }
}

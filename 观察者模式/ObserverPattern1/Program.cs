namespace ObserverPattern1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ISubject subject = new ConcreteSubject();
            IObserver observer1 = new ConcreteObserver();
            IObserver observer2 = new ConcreteObserver();

            subject.RegisterObserver(observer1);
            subject.RegisterObserver(observer2);

            subject.ChangeState(); // 通知所有观察者

            subject.UnregisterObserver(observer1);

            subject.ChangeState(); // 只通知剩余的观察者
        }
    }
    /*
     观察者模式（Observer Pattern）是一种行为设计模式，它定义了对象之间的一对多依赖关系，当一个对象的状态发生改变时，所有依赖于它的对象都会得到通知并自动更新。
        这种模式在很多场景中都非常有用，比如事件处理、状态监控等。
     */
    /// <summary>
    /// 定义观察者接口
    /// </summary>
    public interface IObserver
    {
        void Update();
    }
    /// <summary>
    /// 定义被观察者接口
    /// </summary>
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void UnregisterObserver(IObserver observer);
        void NotifyObservers();
        void ChangeState();
    }
    /// <summary>
    /// 实现具体的观察者类
    /// </summary>
    public class ConcreteObserver : IObserver
    {
        /// <summary>
        /// 当接收到更新通知时，执行相应的操作
        /// </summary>
        public void Update()
        {
            Console.WriteLine("ConcreteObserver received update.");
        }
    }
    /// <summary>
    /// 实现具体的被观察者类
    /// 负责管理观察者列表并通知它们
    /// 
    /// </summary>
    public class ConcreteSubject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void UnregisterObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update();
            }
        }

        public void ChangeState()
        {
            // 改变状态的逻辑
            Console.WriteLine("ConcreteSubject state changed.");
            NotifyObservers();
        }
    }
}

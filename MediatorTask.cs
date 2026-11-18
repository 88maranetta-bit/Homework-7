using System;

namespace ConsoleApp3
{
    public class MediatorTask
    {
        abstract class Mediator { public abstract void Send(string message, Colleague colleague); }
        class ConcreteMediator : Mediator
        {
            public ConcreteColleague1 Colleague1 { get; set; }
            public ConcreteColleague2 Colleague2 { get; set; }
            public ConcreteColleague3 Colleague3 { get; set; }

            public override void Send(string message, Colleague colleague)
            {
                if (colleague == Colleague1)
                {
                    Colleague2?.Notify(message);
                    Colleague3?.Notify(message);
                }
                else if (colleague == Colleague2)
                {
                    Colleague1?.Notify(message);
                    Colleague3?.Notify(message);
                }
                else if (colleague == Colleague3)
                {
                    Colleague1?.Notify(message);
                    Colleague2?.Notify(message);
                }
            }
        }

        abstract class Colleague
        {
            protected Mediator mediator;
            public Colleague(Mediator mediator) { this.mediator = mediator; }
        }

        class ConcreteColleague1 : Colleague
        {
            public ConcreteColleague1(Mediator m) : base(m) { }
            public void Send(string msg) { mediator.Send(msg, this); }
            public void Notify(string msg) { Console.WriteLine("Colleague1 gets: " + msg); }
        }

        class ConcreteColleague2 : Colleague
        {
            public ConcreteColleague2(Mediator m) : base(m) { }
            public void Send(string msg) { mediator.Send(msg, this); }
            public void Notify(string msg) { Console.WriteLine("Colleague2 gets: " + msg); }
        }

        class ConcreteColleague3 : Colleague
        {
            public ConcreteColleague3(Mediator m) : base(m) { }
            public void Send(string msg) { mediator.Send(msg, this); }
            public void Notify(string msg) { Console.WriteLine("Colleague3 gets: " + msg); }
        }

        public static void Run()
        {
            ConcreteMediator m = new ConcreteMediator();
            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);
            ConcreteColleague3 c3 = new ConcreteColleague3(m);

            m.Colleague1 = c1;
            m.Colleague2 = c2;
            m.Colleague3 = c3;

            c1.Send("Hello from C1!");
        }
    }
}

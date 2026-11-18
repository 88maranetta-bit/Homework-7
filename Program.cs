using System;
using System.Text;
using System.Collections;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=========================================");
                Console.WriteLine("         ДОМАШНЯ РОБОТА №7: ПАТЕРНИ      ");
                Console.WriteLine("=========================================\n");

                Console.WriteLine(" 0. Довідка\n");

                Console.WriteLine(" 1. Abstract Factory (Автомобілі / Mercedes)");
                Console.WriteLine(" 2. Builder (Піци / Margarita)");
                Console.WriteLine(" 3. Composite (Дерево компонентів)");
                Console.WriteLine(" 4. Decorator (Новорічна ялинка)");
                Console.WriteLine(" 5. Factory Method (Продукти / Product C)");
                Console.WriteLine(" 6. Mediator (Колеги / Чат)");
                Console.WriteLine(" 7. Prototype (Фігури / Трикутник)\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" 8. Вихід");
                Console.ResetColor();

                Console.WriteLine("\n=========================================");
                Console.Write("Оберіть номер пункту (0-8): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "0":
                        Console.WriteLine("=========================================");
                        Console.WriteLine("                ДОВІДКА                  ");
                        Console.WriteLine("=========================================");
                        Console.WriteLine(" Виконала: Мариніна Анна");
                        Console.WriteLine(" Група: К-27");
                        Console.WriteLine("=========================================");
                        break;
                    case "1":
                        Console.WriteLine("--- Виконання: Abstract Factory ---\n");
                        AbstractFactoryTask.Run();
                        break;
                    case "2":
                        Console.WriteLine("--- Виконання: Builder ---\n");
                        BuilderExample.Run();
                        break;
                    case "3":
                        Console.WriteLine("--- Виконання: Composite ---\n");
                        CompositeExampleTask.Run();
                        break;
                    case "4":
                        Console.WriteLine("--- Виконання: Decorator ---\n");
                        DecoratorExampleTask.Run();
                        break;
                    case "5":
                        Console.WriteLine("--- Виконання: Factory Method ---\n");
                        FactoryMethodTask.Run();
                        break;
                    case "6":
                        Console.WriteLine("--- Виконання: Mediator ---\n");
                        MediatorTask.Run();
                        break;
                    case "7":
                        Console.WriteLine("--- Виконання: Prototype ---\n");
                        PrototypeTask.Run();
                        break;
                    case "8":
                        exit = true;
                        Console.WriteLine("Вихід з програми.");
                        continue;
                    default:
                        Console.WriteLine("Помилка! Такого пункту немає.");
                        break;
                }

                Console.WriteLine("\n-----------------------------------------");
                Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
                Console.ReadKey();
            }
        }
    }

    // ==========================================
    // 1. ABSTRACT FACTORY
    // ==========================================
    public class AbstractFactoryTask
    {
        abstract class Car { public abstract void Info(); }
        class Ford : Car { public override void Info() { Console.WriteLine("Ford"); } }
        class Toyota : Car { public override void Info() { Console.WriteLine("Toyota"); } }
        /************************************************************/
        class Mersedes : Car { public override void Info() { Console.WriteLine("Mersedes"); } }
        /************************************************************/

        abstract class Engine { public virtual void GetPower() { } }
        class FordEngine : Engine { public override void GetPower() { Console.WriteLine("Ford Engine 4.4"); } }
        class ToyotaEngine : Engine { public override void GetPower() { Console.WriteLine("Toyota Engine 3.2"); } }
        /************************************************************/
        class MersedesEngine : Engine { public override void GetPower() { Console.WriteLine("Mersedes Engine 5.5"); } }
        /************************************************************/

        interface ICarFactory { Car CreateCar(); Engine CreateEngine(); }
        class FordFactory : ICarFactory
        {
            Car ICarFactory.CreateCar() => new Ford();
            Engine ICarFactory.CreateEngine() => new FordEngine();
        }
        class ToyotaFactory : ICarFactory
        {
            Car ICarFactory.CreateCar() => new Toyota();
            Engine ICarFactory.CreateEngine() => new ToyotaEngine();
        }
        /************************************************************/
        class MersedesFactory : ICarFactory
        {
            Car ICarFactory.CreateCar() => new Mersedes();
            Engine ICarFactory.CreateEngine() => new MersedesEngine();
        }
        /************************************************************/

        public static void Run()
        {
            ICarFactory carFactory = new ToyotaFactory();
            carFactory.CreateCar().Info();
            carFactory.CreateEngine().GetPower();

            carFactory = new FordFactory();
            carFactory.CreateCar().Info();
            carFactory.CreateEngine().GetPower();

            /************************************************************/
            carFactory = new MersedesFactory();
            carFactory.CreateCar().Info();
            carFactory.CreateEngine().GetPower();
            /************************************************************/
        }
    }

    // ==========================================
    // 2. BUILDER
    // ==========================================
    public class BuilderExample
    {
        class Pizza
        {
            string dough, sauce, topping;
            public void SetDough(string d) { dough = d; }
            public void SetSauce(string s) { sauce = s; }
            public void SetTopping(string t) { topping = t; }
            public void Info() { Console.WriteLine($"Dough: {dough}\nSauce: {sauce}\nTopping: {topping}\n"); }
        }

        abstract class PizzaBuilder
        {
            protected Pizza pizza;
            public Pizza GetPizza() { return pizza; }
            public void CreateNewPizza() { pizza = new Pizza(); }
            public abstract void BuildDough();
            public abstract void BuildSauce();
            public abstract void BuildTopping();
        }

        class HawaiianPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("cross"); }
            public override void BuildSauce() { pizza.SetSauce("mild"); }
            public override void BuildTopping() { pizza.SetTopping("ham+pineapple"); }
        }

        class SpicyPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("pan baked"); }
            public override void BuildSauce() { pizza.SetSauce("hot"); }
            public override void BuildTopping() { pizza.SetTopping("pepparoni+salami"); }
        }

        /************************************************************/
        class MargaritaPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("thin"); }
            public override void BuildSauce() { pizza.SetSauce("tomato"); }
            public override void BuildTopping() { pizza.SetTopping("mozzarella+basil"); }
        }
        /************************************************************/

        class Waiter
        {
            private PizzaBuilder pizzaBuilder;
            public void SetPizzaBuilder(PizzaBuilder pb) { pizzaBuilder = pb; }
            public Pizza GetPizza() { return pizzaBuilder.GetPizza(); }
            public void ConstructPizza()
            {
                pizzaBuilder.CreateNewPizza();
                pizzaBuilder.BuildDough();
                pizzaBuilder.BuildSauce();
                pizzaBuilder.BuildTopping();
            }
        }

        public static void Run()
        {
            Waiter waiter = new Waiter();
            PizzaBuilder hawaiian = new HawaiianPizzaBuilder();
            /************************************************************/
            PizzaBuilder margarita = new MargaritaPizzaBuilder();
            /************************************************************/

            waiter.SetPizzaBuilder(hawaiian);
            waiter.ConstructPizza();
            Console.WriteLine("Hawaiian Pizza:");
            waiter.GetPizza().Info();

            /************************************************************/
            waiter.SetPizzaBuilder(margarita);
            waiter.ConstructPizza();
            Console.WriteLine("Margarita Pizza:");
            waiter.GetPizza().Info();
            /************************************************************/
        }
    }

    // ==========================================
    // 3. COMPOSITE
    // ==========================================
    public class CompositeExampleTask
    {
        abstract class Component
        {
            protected string name;
            public Component(string name) { this.name = name; }
            public abstract void Add(Component c);
            public abstract void Remove(Component c);
            public abstract void Display(int depth);
        }

        class Composite : Component
        {
            private ArrayList children = new ArrayList();
            public Composite(string name) : base(name) { }
            public override void Add(Component c) { children.Add(c); }
            public override void Remove(Component c) { children.Remove(c); }
            public override void Display(int depth)
            {
                Console.WriteLine(new String('-', depth) + name);
                foreach (Component c in children) c.Display(depth + 2);
            }
        }

        class Leaf : Component
        {
            public Leaf(string name) : base(name) { }
            public override void Add(Component c) { Console.WriteLine("Cannot add to a leaf"); }
            public override void Remove(Component c) { Console.WriteLine("Cannot remove from a leaf"); }
            public override void Display(int depth) { Console.WriteLine(new String('-', depth) + name); }
        }

        public static void Run()
        {
            Component root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Component comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));
            root.Add(comp);

            /************************************************************/
            Component compY = new Composite("Composite Y");
            compY.Add(new Leaf("Leaf YA"));
            compY.Add(new Leaf("Leaf YB"));
            compY.Add(new Leaf("Leaf YC"));
            root.Add(compY);
            /************************************************************/

            root.Add(new Leaf("Leaf C"));
            root.Display(1);
        }
    }

    // ==========================================
    // 4. DECORATOR
    // ==========================================
    public class DecoratorExampleTask
    {
        abstract class Tree { public abstract void Display(); }
        class ChristmasTree : Tree { public override void Display() { Console.WriteLine("A regular green Christmas tree."); } }

        abstract class TreeDecorator : Tree
        {
            protected Tree tree;
            public TreeDecorator(Tree tree) { this.tree = tree; }
            public override void Display() { if (tree != null) tree.Display(); }
        }

        class OrnamentsDecorator : TreeDecorator
        {
            public string Ornaments { get; set; }
            public OrnamentsDecorator(Tree tree, string ornaments) : base(tree) { Ornaments = ornaments; }
            public override void Display() { base.Display(); Console.WriteLine($" - Decorated with toys: {Ornaments}."); }
        }

        class GarlandDecorator : TreeDecorator
        {
            public GarlandDecorator(Tree tree) : base(tree) { }
            public override void Display() { base.Display(); Console.WriteLine(" - Garland glowing brightly!"); }
        }

        public static void Run()
        {
            Tree myTree = new ChristmasTree();
            myTree.Display();

            Tree treeWithOrnaments = new OrnamentsDecorator(myTree, "red balls, pinecones, a star");
            treeWithOrnaments.Display();

            /************************************************************/
            Tree fullyDecorated = new GarlandDecorator(treeWithOrnaments);
            fullyDecorated.Display();
            /************************************************************/
        }
    }

    // ==========================================
    // 5. FACTORY METHOD
    // ==========================================
    public class FactoryMethodTask
    {
        public abstract class Creator { public abstract Product FactoryMethod(int type); }
        public class ConcreteCreator : Creator
        {
            public override Product FactoryMethod(int type)
            {
                switch (type)
                {
                    case 1: return new ConcreteProductA();
                    case 2: return new ConcreteProductB();
                    /************************************************************/
                    case 3: return new ConcreteProductC();
                    /************************************************************/
                    default: throw new ArgumentException("Invalid type.");
                }
            }
        }

        public abstract class Product { }
        public class ConcreteProductA : Product { }
        public class ConcreteProductB : Product { }
        /************************************************************/
        public class ConcreteProductC : Product { }
        /************************************************************/

        public static void Run()
        {
            Creator creator = new ConcreteCreator();
            for (int i = 1; i <= 3; i++)
            {
                var product = creator.FactoryMethod(i);
                Console.WriteLine("Where id = {0}, Created {1} ", i, product.GetType());
            }
        }
    }

    // ==========================================
    // 6. MEDIATOR
    // ==========================================
    public class MediatorTask
    {
        abstract class Mediator { public abstract void Send(string message, Colleague colleague); }
        class ConcreteMediator : Mediator
        {
            public ConcreteColleague1 Colleague1 { get; set; }
            public ConcreteColleague2 Colleague2 { get; set; }
            /************************************************************/
            public ConcreteColleague3 Colleague3 { get; set; }
            /************************************************************/

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
                /************************************************************/
                else if (colleague == Colleague3)
                {
                    Colleague1?.Notify(message);
                    Colleague2?.Notify(message);
                }
                /************************************************************/
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

        /************************************************************/
        class ConcreteColleague3 : Colleague
        {
            public ConcreteColleague3(Mediator m) : base(m) { }
            public void Send(string msg) { mediator.Send(msg, this); }
            public void Notify(string msg) { Console.WriteLine("Colleague3 gets: " + msg); }
        }
        /************************************************************/

        public static void Run()
        {
            ConcreteMediator m = new ConcreteMediator();
            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);
            /************************************************************/
            ConcreteColleague3 c3 = new ConcreteColleague3(m);
            /************************************************************/

            m.Colleague1 = c1;
            m.Colleague2 = c2;
            /************************************************************/
            m.Colleague3 = c3;
            /************************************************************/

            c1.Send("Hello from C1!");
        }
    }

    // ==========================================
    // 7. PROTOTYPE
    // ==========================================
    public class PrototypeTask
    {
        interface IFigure { IFigure Clone(); void GetInfo(); }
        class Rectangle : IFigure
        {
            int w, h;
            public Rectangle(int w, int h) { this.w = w; this.h = h; }
            public IFigure Clone() { return new Rectangle(w, h); }
            public void GetInfo() { Console.WriteLine($"Прямокутник {w}x{h}"); }
        }
        class Circle : IFigure
        {
            int r;
            public Circle(int r) { this.r = r; }
            public IFigure Clone() { return new Circle(r); }
            public void GetInfo() { Console.WriteLine($"Круг радіусом {r}"); }
        }
        /************************************************************/
        class Triangle : IFigure
        {
            int a, b, c;
            public Triangle(int a, int b, int c) { this.a = a; this.b = b; this.c = c; }
            public IFigure Clone() { return new Triangle(a, b, c); }
            public void GetInfo() { Console.WriteLine($"Трикутник зі сторонами {a}, {b}, {c}"); }
        }
        /************************************************************/

        public static void Run()
        {
            IFigure fig = new Rectangle(10, 20);
            fig.Clone().GetInfo();

            /************************************************************/
            IFigure tri = new Triangle(3, 4, 5);
            tri.Clone().GetInfo();
            /************************************************************/
        }
    }
}

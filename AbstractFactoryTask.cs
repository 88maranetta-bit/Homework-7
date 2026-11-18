using System;

namespace ConsoleApp3
{
    public class AbstractFactoryTask
    {
        abstract class Car { public abstract void Info(); }
        class Ford : Car { public override void Info() { Console.WriteLine("Ford"); } }
        class Toyota : Car { public override void Info() { Console.WriteLine("Toyota"); } }
        class Mersedes : Car { public override void Info() { Console.WriteLine("Mersedes"); } }

        abstract class Engine { public virtual void GetPower() { } }
        class FordEngine : Engine { public override void GetPower() { Console.WriteLine("Ford Engine 4.4"); } }
        class ToyotaEngine : Engine { public override void GetPower() { Console.WriteLine("Toyota Engine 3.2"); } }
        class MersedesEngine : Engine { public override void GetPower() { Console.WriteLine("Mersedes Engine 5.5"); } }

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
        class MersedesFactory : ICarFactory
        {
            Car ICarFactory.CreateCar() => new Mersedes();
            Engine ICarFactory.CreateEngine() => new MersedesEngine();
        }

        public static void Run()
        {
            ICarFactory carFactory = new ToyotaFactory();
            carFactory.CreateCar().Info();
            carFactory.CreateEngine().GetPower();

            carFactory = new FordFactory();
            carFactory.CreateCar().Info();
            carFactory.CreateEngine().GetPower();

            carFactory = new MersedesFactory();
            carFactory.CreateCar().Info();
            carFactory.CreateEngine().GetPower();
        }
    }
}

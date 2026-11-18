using System;

namespace ConsoleApp3
{
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

        class MargaritaPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("thin"); }
            public override void BuildSauce() { pizza.SetSauce("tomato"); }
            public override void BuildTopping() { pizza.SetTopping("mozzarella+basil"); }
        }

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
            PizzaBuilder margarita = new MargaritaPizzaBuilder();

            waiter.SetPizzaBuilder(hawaiian);
            waiter.ConstructPizza();
            Console.WriteLine("Hawaiian Pizza:");
            waiter.GetPizza().Info();

            waiter.SetPizzaBuilder(margarita);
            waiter.ConstructPizza();
            Console.WriteLine("Margarita Pizza:");
            waiter.GetPizza().Info();
        }
    }
}

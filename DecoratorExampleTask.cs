using System;

namespace ConsoleApp3
{
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

            Tree fullyDecorated = new GarlandDecorator(treeWithOrnaments);
            fullyDecorated.Display();
        }
    }
}

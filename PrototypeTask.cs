using System;

namespace ConsoleApp3
{
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
        class Triangle : IFigure
        {
            int a, b, c;
            public Triangle(int a, int b, int c) { this.a = a; this.b = b; this.c = c; }
            public IFigure Clone() { return new Triangle(a, b, c); }
            public void GetInfo() { Console.WriteLine($"Трикутник зі сторонами {a}, {b}, {c}"); }
        }

        public static void Run()
        {
            IFigure fig = new Rectangle(10, 20);
            fig.Clone().GetInfo();

            IFigure tri = new Triangle(3, 4, 5);
            tri.Clone().GetInfo();
        }
    }
}

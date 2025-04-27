using System.Numerics;
using System.Reflection.Metadata;
using System; 

namespace interfacePrac
{
    // Interface is a contract that defines a set of methods and properties that a class must implement.
    // It is a way to achieve abstraction and multiple inheritance in C#.
    // An interface can contain methods, properties, events, and indexers.
    // An interface cannot contain fields, constructors, destructors, or static members.

    //Abstract class is a class that cannot be instantiated and can contain abstract methods (methods without a body) and concrete methods (methods with a body).
    // An abstract class can also contain fields, constructors, destructors, and static members.
    // You will need to use ----Virtual---- methods to ----Override---- the methods in the derived class.
    public interface IShape // , <Another Interface> <Abstract Class>
    {
        public double Area(); // <Method> <Virtual> <public abstract(override) void>
    }

    public class Triangle (float baseL, float height) : IShape
    {
        private float Base { get; set; } = baseL; // <Private> <Public> <Protected> <Internal>
        private float Height { get; set; } = height; // <Private> <Public> <Protected> <Internal>
        //public Triangle (float baseL, float height)
        //{
        //    Base = baseL;
        //    Height = height;
        //}
        public double Area () => 0.5 * Height * Base; // <Public Override Void>
    }

    

    public class Circle (float radius): IShape
    {
        private float Radius { get; set; } = radius;
        private const double Pi  = 3.141592653589;
        //public Circle (float radius)
        //{
        //    Radius = radius;
        //}
        public double Area() => Pi * Radius * Radius;
    }

    public class Rectangle (float width, float height) : IShape
    {
        private float Width { get; set; } = width;
        private float Height { get; set; } = height;
        //public Rectangle (float width, float height)
        //{
        //    Width = width;
        //    Height = height;
        //}
        public double Area() => Width * Height;
    }

    public class Introduction()
    {
        public static void CircleIntro ()
        {
            Console.WriteLine ("This is a circle");
        }
        public static void RectangleIntro()
        {
            Console.WriteLine("This is a rectangle");
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            bool isChoosing = false;
            int choice = 0;
            int Redo = 0;
            string[] choices = { "Circle", "Triangle", "Rectangle" };
            while (!isChoosing)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Geometric Area Calculation Program!");
                Console.WriteLine("Please select a shape to calculate its area:\n");
                Redo = choice;
                for (int Print = 0 ; Print <= 2 && Print >= 0; Print++)
                {
                    if (Print == choice)
                    {
                        Console.WriteLine($"\u001b[34m{Print + 1}. {choices[choice]}\u001b[0m");
                    }
                    else
                    {
                        Console.WriteLine($"{Print + 1}. {choices[Print]}");
                    }
                }
                    if (choice < 0 || choice > 2)
                {
                    choice = Redo;
                    continue;
                }
                ConsoleKeyInfo ArrowKey = Console.ReadKey(true);
                if (ArrowKey.Key == ConsoleKey.UpArrow)
                {
                    if (choice == 0) continue;
                    choice--;
                    continue;
                }
                else if (ArrowKey.Key == ConsoleKey.DownArrow)
                {
                    if (choice == 2) continue;
                    choice++;
                    continue;
                }
                else if (ArrowKey.Key == ConsoleKey.Enter)
                {
                    isChoosing = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please use the arrow keys to navigate and Enter to select.");
                    Console.ReadKey();
                    continue;
                } 
            }
            Console.Clear ();
            switch (choice)
            {
                case 0:
                    Console.WriteLine("Welcome to Circle Section!\n");
                    Console.Write("Please Input The Value For Radius: ");
                    float radius = float.Parse(Console.ReadLine() ?? "0");
                    Circle c = new Circle(radius);
                    Console.WriteLine($"\nThe Area Of Your Circle is {Math.Round(c.Area(), 2)}");
                    break;

                case 1:
                    Console.WriteLine("Welcome to Triangle Section!\n");
                    Console.Write("Please Input The Value For Base: ");
                    float Base = float.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Please Input The Value For Width: ");
                    float height = float.Parse(Console.ReadLine() ?? "0");
                    Triangle t = new Triangle(Base, height);
                    Console.WriteLine($"\nThe Area Of Your Triangle is {Math.Round(t.Area(), 2)}");
                    break;

                case 2:
                    Console.WriteLine("Welcome to Rectangle Section!\n");
                    Console.Write("Please Input The Value For Width: ");
                    float width = float.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Please Input The Value For Height: ");
                    float Rheight = float.Parse(Console.ReadLine() ?? "0");
                    Rectangle r = new Rectangle(width, Rheight);
                    if (width == Rheight)
                    {
                        Console.Clear();
                        Console.WriteLine("Welcome to Square Section!\n");
                        Console.Write($"Please Input The Value For Sides: {width}");
                        Console.WriteLine($"\nThe Area Of Your Square is {Math.Round(r.Area(), 2)}");
                    }
                    else
                    {
                        Console.WriteLine($"\nThe Area Of Your Rectangle is {Math.Round(r.Area(), 2)}");
                    }
                    break;
            }
        }
    }
}
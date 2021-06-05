using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

class Program
{
    public static List<Car> myCars = new List<Car>(){
        new Car("E250", new Engine(1.8, 204, "CGI"), 2009),
        new Car("E350", new Engine(3.5, 292, "CGI"), 2009),
        new Car("A6", new Engine(2.5, 187, "FSI"), 2012),
        new Car("A6", new Engine(2.8, 220, "FSI"), 2012),
        new Car("A6", new Engine(3.0, 295, "TFSI"), 2012),
        new Car("A6", new Engine(2.0, 175, "TDI"), 2011),
        new Car("A6", new Engine(3.0, 309, "TDI"), 2011),
        new Car("S6", new Engine(4.0, 414, "TFSI"), 2012),
        new Car("S8", new Engine(4.0, 513, "TFSI"), 2012)
        };

    public static void Main(string[] args)
    {
        Exc1();
        Exc2();

    }

    public static void Exc1()
    {
        Console.WriteLine(" -- Exercise 1 -- \n" );

        var tmpProjectionNo1 = from c in myCars
                               where c.model == "A6"
                               select new
                               {
                                   engineType = c.motor.model == "TDI" ? "Diesel" : "Petrol",
                                   hppl = c.motor.horsePower / c.motor.displacement
                               };

        var tmpProjectionNo2 = from t in tmpProjectionNo1
                               group t by t.engineType into tmp
                               select new
                               {
                                   engineType = tmp.Key,
                                   hpplAvrg = tmp.Average(h => h.hppl)
                               };

        foreach ( var tmp in tmpProjectionNo2)
        {
            Console.WriteLine("Engine {0} {1}", tmp.engineType, tmp.hpplAvrg);
        }
        Console.WriteLine();
    }

    public static void Exc2()
    {
        Console.WriteLine(" -- Exercise 2 -- ");

        var file = "myCarsCollection.xml";
        var pathDirectory = Directory.GetCurrentDirectory();
        var pathFile = Path.Combine(pathDirectory, file);
        // Console.WriteLine(pathFile);
        Serialize(pathFile);
        Deserialize(pathFile);

    }

    public static void Serialize(string __path)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<Car>), new XmlRootAttribute("cars"));
        using TextWriter Writer = new StreamWriter(__path);
        ser.Serialize(Writer, myCars);

    }

    public static void Deserialize(string __path)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<Car>), new XmlRootAttribute("cars"));

        using Stream reader = new FileStream(__path, FileMode.Open);
        List<Car> tmpMyCars = (List<Car>)ser.Deserialize(reader);


        foreach(var t in tmpMyCars)
        {
            Console.WriteLine(t.model + " " + t.motor.model + " " + t.motor.horsePower + " " + t.motor.displacement + " " + t.year);
        }
    }
}


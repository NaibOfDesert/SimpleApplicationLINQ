using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

[Serializable]
[XmlRoot]
public class Engine
{
    [XmlElement]
    public double displacement;
    [XmlElement]
    public double horsePower;
    [XmlAttribute]
    // [XmlAttribute]
    public string model;

    public Engine() { }

    public Engine(double __displacement, double __horsePower, string __model)
    {
        this.displacement = __displacement;
        this.horsePower = __horsePower;
        this.model = __model;
    }
}


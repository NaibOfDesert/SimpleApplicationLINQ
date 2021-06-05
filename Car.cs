using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

[Serializable()]
[XmlType(TypeName = "car")]
public class Car
{
    [XmlElement]
    public string model;
    [XmlElement(ElementName = "engine")]
    public Engine motor;
    [XmlElement]
    public int year;

    public Car() { }

    public Car(string __model, Engine __motor, int __year)
    {
        this.model = __model;
        this.motor = __motor;
        this.year = __year;
    }
}


#nullable disable
Console.WriteLine("Hello, World!");

BadCarService badCarService = new BadCarService();
badCarService.Repair(new BadCar());


//Version 1
ICarService serviceInVersion1 = new CarService();
ICar mockObj = new MockCar(); //V1
ICarVersion2 mockObj2 = new MockCarVersion2();  

ICar produktivesObjekt = new Car();
serviceInVersion1.Save(produktivesObjekt);
serviceInVersion1.Save(mockObj);


//Version 2

ICarService2 serviceInVersion2 = new CarService();
ICarVersion2 carInVersion2 = new Car();

//OBjekte von Version 2 würden den gemeinsamen Nenner nur verwenden -> Polymorphie
//Abwärtskomatibel
serviceInVersion1.Save(mockObj2); //Hier werden

//Version 2
serviceInVersion2.Save(mockObj2);
serviceInVersion2.Lackieren(carInVersion2);

//Alte Objekte aus früheren Versionen in Zukünfigte Versionen gehen natürlich nicht
//serviceInVersion2.Lackieren(mockObj);



#region Bad Sample -> FESTE KOPPLUNG

//Programmer A -> 5 Tage 

//Storyboard -> Tag 1 - Tag 5 
public class BadCar
{
    public string Marke { get; set; }
    public string Modell { get; set; }
    public int ConstructionYear { get; set; }
}


public class BadCarVersion2 : BadCar
{
    public bool Caprio { get; set; }
}


//Werkstatt
//Programmierer B - > 3 Tage

//Storyboard -> Tag 5/6 -> Tag 8/9
public class BadCarService
{

    //Probleme entstehen hier:
    // -> Eigentlich müssen wir warten bis BadCar fertig ist ODER wir aktualisieren jedes mal, wenn BadCar eine Änderung erfährt unseren ab. -> Wechselwirkungen 
    // -> Paralleles Arbeiten ist nicht flüssig oder nicht mal garantiert. 
    // -> Untestbar 
    // -> Versionierungen sind von BadCar sind sehr eingeschränkt in Hinblick auf Abwärtskompatebilität
    public void Repair(BadCar car) // 
    {
        //repariere Auto 
    }
}

#endregion


public interface ICar
{
    public string Marke { get; set; }
    public string Modell { get; set; }
    public int ConstructionYear { get; set; }
}

public interface ICarVersion2 : ICar
{
    public bool Caprio { get; set; }
    public string Color { get; set; }
}

public interface ICarService
{
    public void Save(ICar car); //LOSE KOPPLUNG 
}

public interface ICarService2 : ICarService
{
    public void Lackieren(ICarVersion2 carVersion2);
}


//Programmerer A arbeitet unabhängig zu Programmierer B

//Programmer A -> 5 Tage 
public class Car : ICarVersion2
{
    //Extraaufwand in der Validierung
    public string Marke { get; set; }
    public string Modell { get; set; }
    public int ConstructionYear { get; set; }
    public bool Caprio { get; set; }
    public string Color { get; set; }
}


//Programmer A -> 3 Tage 
public class CarService : ICarService2
{
    public void Lackieren(ICarVersion2 carVersion2)
    {
        Console.WriteLine("Auto wird lackiert");
    }

    public void Save(ICar car)
    {
        Console.WriteLine("Auto wird gespeichert");
    }
}

public class MockCarVersion2 : ICarVersion2
{
    public string Marke { get; set; } = "VW";
    public string Modell { get; set; } = "Polo";
    public int ConstructionYear { get; set; } = 2012;
    public bool Caprio { get; set; } = true;
    public string Color { get; set; } = "silver";
}

public class MockCar : ICar
{
    public string Marke { get; set; } = "VW";
    public string Modell { get; set; } = "Polo";
    public int ConstructionYear { get; set; } = 2012;
    public bool Caprio { get; set; } = true;
    public string Color { get; set; } = "silver";
}
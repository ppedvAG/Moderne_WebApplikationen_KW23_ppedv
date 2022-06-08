// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public interface IBadVehicle
{
    void CanFly();
    void CanDrive();
    void CanSwim();

}

public class BadMultivehicle : IBadVehicle
{
    public void CanDrive()
    {
        Console.WriteLine("Kann fahren");
    }

    public void CanFly()
    {
        Console.WriteLine("Kann fliegen");
    }

    public void CanSwim()
    {
        Console.WriteLine("Kann swimmen");
    }
}


public class BadAmphibischesFahrzeug : IBadVehicle
{
    public void CanDrive()
    {
        Console.WriteLine("Kann fahren");
    }

    //Diese Methode ist quasi zuviel und wird der Logik nicht gerecht 
    public void CanFly()
    {
        throw new NotImplementedException();
    }

    public void CanSwim()
    {
        Console.WriteLine("Kann swimmen");
    }
}


//Good Code
// Referenz -> https://github.com/SharpRepository/SharpRepository/blob/develop/SharpRepository.Repository/Traits/ICanGet.cs
public interface IFly
{
    void Fly();
}

public interface IDrive
{
    void Drive();
}

public interface ISwim
{
    void Swim();
}

public class AbphimibischesFahrzeug : IDrive, ISwim
{
    public void Drive()
    {
        Console.WriteLine("Kann fahren");
    }

    public void Swim()
    {
        Console.WriteLine("Kann schwimmen");
    }
}


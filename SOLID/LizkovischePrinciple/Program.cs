// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//AntiBeispiel 
public class BadErdbeer
{
    public string GetColor()
    {
        return "red";
    }
}

public class BadKirche : BadErdbeer
{
    public string GetColor()
        => base.GetColor();
}



//Bessere Variante 

public interface IFruits
{
    string GetColor();
}

public class Erdbeer : IFruits
{
    public string GetColor()
    {
        return "Red";
    }
}

public class Kirche : IFruits
{
    public string GetColor()
    {
        return "Red";
    }
}
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

#region Anti-Beispiel
/*
 *  Problemstellung dieser Klasse:
 *   - Klassen repräsentiert einen Datensatz (Id, Name) -> Employee
 *   - InsertEmployeeToTable -> Arbeitet mit einer Datenbank zusammen -> Eigene Klasse wäre dafür von nöten
 *   - GenerateReport ist eine Ausgabe -> Eigene Klasse
 *   
 *   - Resumee -> BadEmployeeClass ist überladen und wird:
 *      - sehr komlex 
 *      - sehr viele Codezeilen
 *      - verschiedene Themen einfach in einer Klasse 
 *      - bei Erweiterung müssen wir SourceCode refaktorieren 
 */
public class BadEmployeeClass
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void InsertEmployeeToTable (BadEmployeeClass badEmployee)
    {
        //Speicher Datensatz in Tabelle
    }

    public void GenerateReport(BadEmployeeClass badEmployee)
    {
        //Erstelle ein Report
    }
}
#endregion

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class EmployeeRepository
{
    public void Insert (Employee employee)
    {
        //Speichere Datensatz
    }
}

public class Report
{
    public void Generate(Employee employee)
    {
        //Generiere Report 
    }
}





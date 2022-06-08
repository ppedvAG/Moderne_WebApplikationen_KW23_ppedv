#nullable disable
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Abstrakte Klassen - > Verwendung
PDFGenerator<Freelance> generator = new PDFGenerator<Freelance>();
generator.Generate(new Freelance());




//Beispiel 3 - Verwendung

IReport<Freelance> report = new CrystalReporterGeneratorys<Freelance>();
report.Generate(new Freelance());

ICrystalReporterGenerator<Freelance> advancedReport = new CrystalReporterGeneratorys<Freelance>();
advancedReport.Generate(new Freelance());
advancedReport.X509Cert();
advancedReport.SepcialWatermark();




public class EmployeeBase
{
    public int Id { get; set; }
    public string Name { get; set; }
}


public class Freelance : EmployeeBase
{
    public decimal SalaryPerHour { get; set; }  
}

public class Employee : EmployeeBase
{
    public int HolidayDays { get; set; }
    public decimal SalaryPerMonth { get; set; }
}

#region Anti-Beispiel
//Vorgabe CR, FR, LL und PDF werden jeweils mit Drittanbieter (Dlls) referenziert. 

//Was hat ein Report-System für Eigenschaften: 
//- Template-Pfad  
//- Ausgabe-Pfad des Reports 

//- Manche Reportsysteme verwenden Wasserzeichen (nicht bei allen) -> Ungehen mit Sonder-Features 

public class BadGenerateReport
{
    public int reportType; 
    //weitere Properties werden sicherlich folgden -> Template-Pfad oder Output-Path 

    //Methode wird ganz viele Zeilen Source-Code beinhalten
    public void GenerateReport()
    {
        
        if (reportType == 0)
        {
            //Crystal Reports
        }
        else if (reportType == 1)
        {
            //Fast Report
        }
        else if (reportType == 2)
        {
            //List&Label
        }
        else
        {
            //pdf 
        }
    }
}
#endregion 


#region Open - Part - Variante abstrakte Klasse
public abstract class ReportGenerator
{
    public virtual string OutputPath { get; set; }
    public abstract void GenerateReport(EmployeeBase employee);


    //Vorteil gegenüber Interface: Abgeleitete Klassen haben einen näheren Bezug zueinander
    public void CommonFunctionalMethod()
    {
        //Allgemeinen Methoden, die in abgeleitete Klassen verwendet werden können 
    }
}


//Close - Part 
public class CrystalReportGenerator : ReportGenerator
{
    public override void GenerateReport(EmployeeBase employee)
    {
        //Erstelle ein Crystal Report 
    }
}

#endregion

#region Open-Part Interface

//Interfaces

public interface IReportGenerator
{
    void GenerateReport(EmployeeBase employee);
}

public class ListLabelReportGenerator : IReportGenerator
{
    public void GenerateReport(EmployeeBase employee)
    {
        // Erstelle ein Report
    }
}

#endregion

#region OpenPart abstrakt + interface + erweitertes interface für spezielle Produkte 

public interface IReport<T> where T : class
{
    void Generate(T entity);
}

public abstract class AbstractReportBase<T> : IReport<T> where T : class
{
    public abstract void Generate(T entity);
}

//public class ReportBase<T> : AbstractReportBase<T> where T : class
//{
//    public override void Generate(T entity)
//    {
       
//    }
//}


//PDF hat in unserem Beispiel, die minimalste Funktion
public class PDFGenerator<T> : AbstractReportBase<T> where T : class
{
    public override void Generate(T entity)
    {
        //Erstelle ein PDF 
    }
}

//Report mit mehr Funktionalität
//Interfaces Vererbung 
public interface ICrystalReporterGenerator<T> : IReport<T> where T : class
{
    public void SepcialWatermark();

    public void X509Cert();
}

public class CrystalReporterGeneratorys<T> : AbstractReportBase<T>, ICrystalReporterGenerator<T> where T : class
{
    public override void Generate(T entity)
    {
        //Generiere ein Interface
    }

    //Erweiterung durch Vererbung von Interface -> Flexibilität 
    public void SepcialWatermark()
    {
        //Erstelle ein Wasserzeichen
    }

    public void X509Cert()
    {
        //Irgendwas mit X509 Certificate
    }
}


#endregion

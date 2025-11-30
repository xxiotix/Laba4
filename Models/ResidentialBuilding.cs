using Laba4.Models;
using System.Xml.Linq;

public class ResidentialBuilding : ConstructionProject
{
    public int AppartmentsCount { get; set; }
    public string Location { get; set; }
    public string GetLocationInfo()
    {
        return $"Локація проєкту: {Location}";
    }

    public double CalculateArea()
    {
        return AppartmentsCount * 50;
    }

    public override void ExecuteStage()
    {
        Console.WriteLine($"Виконується етап будівництва житлового будинку '{Name}'");
    }

    public override decimal CalculateBudget()
    {
        return TotalCost * 1.1m;
    }

    public override string ProjectType => "Житловий будинок";
}
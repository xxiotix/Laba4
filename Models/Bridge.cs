using Laba4.Interfaces;
using Laba4.Models;
using System.Xml.Linq;

public class Bridge : ConstructionProject, IHasLocation
{
    public double Length { get; set; }
    public string Location { get; set; }
    public string GetLocationInfo()
    {
        return $"Локація проєкту: {Location}";
    }

    public double CalculateLoad()
    {
        return Length * 1000;
    }

    public override void ExecuteStage()
    {
        Console.WriteLine($"Виконується етап будівництва мосту '{Name}'");
    }

    public override decimal CalculateBudget()
    {
        return TotalCost * 1.15m;
    }

    public override string ProjectType => "Міст";
}
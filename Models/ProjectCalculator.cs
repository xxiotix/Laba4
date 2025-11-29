using Laba4.Models;

public static class ProjectCalculator
{
    public static int TotalApartments(List<ConstructionProject> projects)
    {
        return projects.OfType<ResidentialBuilding>().Sum(house => house.AppartmentsCount);
    }

    public static decimal TotalBudget(List<ConstructionProject> projects)
    {
        return projects.Sum(p => p.CalculateBudget());
    }
}
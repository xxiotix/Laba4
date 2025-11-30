using Laba4.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Laba4.Models
{
    public class ShoppingMall : ConstructionProject, IHasLocation, IAuditable, IReportable
    {
        public int ShopsCount { get; set; }
        public double TotalArea { get; set; } // площа торгового центру

        public string Location { get; set; }

        public override void ExecuteStage()
        {
            Console.WriteLine($"Виконується етап будівництва ТЦ '{Name}'");
        }

        public override decimal CalculateBudget()
        {
            return TotalCost * 1.2m;
        }

        public override string ProjectType => "Торговий центр";

        public string GenerateReport()
        {
            return $"Звіт про торговий центр '{Name}'\n" +
                   $"Магазинів: {ShopsCount}\n" +
                   $"Площа: {TotalArea} м²\n" +
                   $"Вартість: {TotalCost}\n" +
                   $"Термін: {Deadline}\n" +
                   $"Локація: {Location}\n";
        }
    }
}

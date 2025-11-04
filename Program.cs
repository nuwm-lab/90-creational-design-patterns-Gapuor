using System;

namespace LabWork
{
    // Даний проект є шаблоном для виконання лабораторних робіт
    // з курсу "Об'єктно-орієнтоване програмування та патерни проектування"
    // Необхідно змінювати і дописувати код лише в цьому проекті
    // Відео-інструкції щодо роботи з github можна переглянути 
    // за посиланням https://www.youtube.com/@ViktorZhukovskyy/videos 
    internal static class Program
    {
        /// <summary>
        /// Entry point - demonstrates Builder pattern by creating several aircraft.
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                // Демонстрація використання патерну Builder для проєктування літаків
                var director = new AircraftDirector();

                var passengerBuilder = new PassengerPlaneBuilder();
                director.SetBuilder(passengerBuilder);

                // Побудувати регіональний пасажирський літак
                director.ConstructRegionalPassengerPlane();
                var regional = passengerBuilder.Build();
                Console.WriteLine(regional);

                // Побудувати довго-габаритний пасажирський літак
                director.ConstructLongHaulPassengerPlane();
                var longHaul = passengerBuilder.Build();
                Console.WriteLine(longHaul);

                // Побудувати вантажний літак через власний builder
                var cargoBuilder = new CargoPlaneBuilder();
                director.SetBuilder(cargoBuilder);
                director.ConstructHeavyCargoPlane();
                var cargo = cargoBuilder.Build();
                Console.WriteLine(cargo);

                Console.WriteLine("Builder demo completed.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                Environment.Exit(1);
            }
        }
    }
}

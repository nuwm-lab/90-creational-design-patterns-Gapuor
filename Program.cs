using System;

namespace LabWork;

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
            catch (ArgumentException ex)
            {
                // Argument problems indicate programming or input errors; report and exit with non-zero code.
                Console.Error.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                Console.Error.WriteLine(ex.StackTrace);
                Environment.ExitCode = 1;
                return;
            }
            catch (InvalidOperationException ex)
            {
                // Validation / state errors produced by builders or product validation.
                Console.Error.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                Console.Error.WriteLine(ex.StackTrace);
                Environment.ExitCode = 1;
                return;
            }
            // Note: we intentionally do not swallow all exceptions here. Unexpected exceptions should surface
            // so they can be observed during development and handled appropriately in production with
            // a proper logging/monitoring solution.
        }
    }

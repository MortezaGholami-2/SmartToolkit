using System.Diagnostics;
using System.Reflection;

namespace SmartAppSoftware.SmartToolkit.SmartConsoleMenu
{
    /// <summary>
    /// Represents a simple menu for Console apps.
    /// </summary>
    public class SimpleConsoleMenu
    {

        private static Assembly Application;
        //private static FileVersionInfo 
        //public static string? GetApplicationVersion()
        //{
        //    return FileVersionInfo.GetVersionInfo(Application.Location).FileVersion;
        //}

        private readonly Dictionary<string, Action> MenuItems;
        
        /// <summary>
        /// hgjjh
        /// </summary>
        /// <param name="menuItems">gjhgjh</param>
        public SimpleConsoleMenu(Assembly application, Dictionary<string, Action> menuItems)
        {
            Application = application;
            MenuItems = menuItems;

        }

        public void ShowMenu()
        {
            // Application Name
            Console.WriteLine($"{Application.FullName}");

            // Application Author
            Console.WriteLine($"{FileVersionInfo.GetVersionInfo(Application.Location).ProductName}");

            // Application Version
            Console.WriteLine($"{ FileVersionInfo.GetVersionInfo(Application.Location).FileVersion }");

            // Draw Menu Items
            for (int i = 1; i < MenuItems.Count; i++)
            {
                System.Console.WriteLine($"{i}. {MenuItems.Keys.ElementAt(i)}");
            }
            System.Console.WriteLine($"0. {MenuItems.Keys.ElementAt(0)}");

            // Select Menu Item
            string? selectedMenuItem = null;
            while (selectedMenuItem != "Exit")
            {
                int? i = null;
                do
                {
                    if (int.TryParse(System.Console.ReadLine(), out int j))
                    {
                        i = j;
                    }
                } while (i < 0 || i >= MenuItems.Count);

                selectedMenuItem = MenuItems.Keys.ElementAt((Index)i);

                System.Console.WriteLine("You Selected: " + MenuItems.Keys.ElementAt((Index)i));

                Action action = MenuItems.Values.ElementAt((Index)i) as Action;
                action();
            }
        }
    }
}
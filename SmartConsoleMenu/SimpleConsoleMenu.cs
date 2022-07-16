using System.Diagnostics;
using System.Reflection;
using SmartAppSoftware.SmartToolkit.SmartConsoleMenu.Models;
using Spectre.Console;

namespace SmartAppSoftware.SmartToolkit.SmartConsoleMenu
{
    /// <summary>
    /// Represents a simple menu for Console apps.
    /// </summary>
    public class SimpleConsoleMenu
    {

        private static Assembly? Application;
        //private static FileVersionInfo 
        //public static string? GetApplicationVersion()
        //{
        //    return FileVersionInfo.GetVersionInfo(Application.Location).FileVersion;
        //}

        private readonly Dictionary<Key, Action?> MenuItems;
        
        /// <summary>
        /// hgjjh
        /// </summary>
        /// <param name="menuItems">gjhgjh</param>
        public SimpleConsoleMenu(Assembly application, Dictionary<Key, Action?> menuItems)
        {
            Application = application;
            MenuItems = menuItems;
        }

        public void ShowMenu()
        {

            //var font = FigletFont.Load(".\\starwars.flf");
            //AnsiConsole.Write(
            //    new FigletText(font, "Stash")
            //    .Centered()
            //    .Color(Color.Green));
            //AnsiConsole.Write(
            //    new FigletText(font, "Companion")
            //    .Centered()
            //    .Color(Color.Green));


            //var panel = new Panel("[bold red]Stash Companion v1.0 Developed by: Me![/]");
            //panel.Border = BoxBorder.Heavy;
            //AnsiConsole.Write(panel);


            //Rule rule=new Rule("[red]Main Menu[/]");
            //rule.LeftAligned();
            //AnsiConsole.Write(rule);

            // Application Name
            Console.WriteLine($"{Application.FullName}");

            // Application Author
            Console.WriteLine($"{FileVersionInfo.GetVersionInfo(Application.Location).ProductName}");

            // Application Version
            Console.WriteLine($"{FileVersionInfo.GetVersionInfo(Application.Location).FileVersion}");

            // Draw Menu Items
            string? selectedMenuItem = null;
            string? parent = null;

            while (selectedMenuItem != "Exit")
            {
                List<string> items = new();

                foreach (var item in MenuItems)
                {
                    if (item.Key.ParentMenuItemName == parent)
                    {
                        items.Add(item.Key.ChildMenuItemName);
                    }
                }

                selectedMenuItem = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("What's your [green]favorite fruit[/]?")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                    .AddChoices(items));

                if(selectedMenuItem=="Back to Main Menu")
                {
                    parent = null;
                }
                else
                {
                    AnsiConsole.Write("You Selected: " + selectedMenuItem);

                    Action? action = MenuItems.FirstOrDefault(x => x.Key.ChildMenuItemName == selectedMenuItem).Value;
                    if (action != null)
                    {
                        action();
                    }
                    else
                    {
                        parent = items.FirstOrDefault(selectedMenuItem);
                    }
                }
            }
        }
    }
}
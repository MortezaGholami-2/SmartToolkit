namespace SmartAppSoftware.SmartToolkit.SmartConsoleMenu
{
    /// <summary>
    /// Represents a simple menu for Console apps.
    /// </summary>
    public class SimpleConsoleMenu
    {
        private Dictionary<string, Action> _menuItems;
        /// <summary>
        /// hgjjh
        /// </summary>
        /// <param name="menuItems">gjhgjh</param>
        public SimpleConsoleMenu(Dictionary<string, Action> menuItems)
        {
            _menuItems = menuItems;
        }

        public void ShowMenu()
        {
            // Application Name
            //System.Console.WriteLine($"{ApplicationService.Application.GetName()}");

            // Application Author

            // Application Version
            //System.Console.WriteLine("Written By dsdfsdfds");

            // Draw Menu Items
            for (int i = 1; i < _menuItems.Count; i++)
            {
                System.Console.WriteLine($"{i}. {_menuItems.Keys.ElementAt(i)}");
            }
            System.Console.WriteLine($"0. {_menuItems.Keys.ElementAt(0)}");

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
                } while (i < 0 || i >= _menuItems.Count);

                selectedMenuItem = _menuItems.Keys.ElementAt((Index)i);

                System.Console.WriteLine("You Selected: " + _menuItems.Keys.ElementAt((Index)i));

                Action action = _menuItems.Values.ElementAt((Index)i) as Action;
                action();
            }
        }
    }
}
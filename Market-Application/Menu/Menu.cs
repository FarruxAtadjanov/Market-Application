using Market_Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Market_Application.Servise 
{
    internal class Menu
    {      
        public static void Start()
        {
            Title = "Welcome!";          
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(prom);
        }
        public void RunMainMenu()
        {
            ProductRepository prRepo = new ProductRepository();
            string prompt = prom;
            string[] options = { "1. Browse all products", "2. Add product", "3. Search product", "4. Update product", "5. Exit" };

            ClientMenu mainMenu = new ClientMenu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 1:
                    prRepo.ShowProducts();
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
                case 4:
                    
                    break;
                case 5:
                    WriteLine("\nPress any key to exit...");
                    ReadKey(true);
                    Environment.Exit(0);
                    break;
                
            }
        }

        private void ADD()
        {

        }
        private void DeletE()
        {

        }
        private void SearCH()
        {

        }
        private void UpdatE()
        {

        }
        static string prom = @"
 __      __       .__                                  __          
/  \    /  \ ____ |  |   ____  ____   _____   ____   _/  |_  ____  
\   \/\/   // __ \|  | _/ ___\/  _ \ /     \_/ __ \  \   __\/  _ \ 
 \        /\  ___/|  |_\  \__(  <_> )  Y Y  \  ___/   |  | (  <_> )
  \__/\  /  \___  >____/\___  >____/|__|_|  /\___  >  |__|  \____/ 
       \/       \/          \/            \/     \/                
          _____                              .__                   
         /     \ _____     _________  _______|__| ____             
        /  \ /  \\__  \   / ___\__  \ \___   /  |/    \            
       /    Y    \/ __ \_/ /_/  > __ \_/    /|  |   |  \           
       \____|__  (____  /\___  (____  /_____ \__|___|  /           
               \/     \//_____/     \/      \/       \/            
                      
".ToString();
    }
}

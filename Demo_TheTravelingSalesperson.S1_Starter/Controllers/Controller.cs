using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TheTravelingSalesperson
{
    class Controller
    {
       private ConsoleView _consoleView;
       private Salesperson _salesperson;
       private bool _usingApplication;

        public Controller()
        {
            InitializeController();

            _salesperson = new Salesperson();

            _consoleView = new ConsoleView();

            ManageApplicationLoop();
        }

        public void DisplayAccountInfo()
        {
            _consoleView.DisplayAccountInfo(_salesperson);
        }

        public void DisplayCities()
        {
            _consoleView.DisplayCitiesTraveled(_salesperson);
        }

        public void InitializeController()
        {
            _usingApplication = true;
        }

        public void ManageApplicationLoop()
        {
            MenuOption userMenuChoice;

            _consoleView.DisplayWelcomeScreen();

            _salesperson = _consoleView.DisplaySetupAccount();

            while (_usingApplication)
            {

                userMenuChoice = _consoleView.DisplayGetUserMenuChoice();

                switch (userMenuChoice)
                {
                    case MenuOption.None:
                        break;
                    case MenuOption.Travel:
                        Travel();
                        break;
                    case MenuOption.DisplayCities:
                        DisplayCities();
                        break;
                    case MenuOption.DisplayAccountInfo:
                        DisplayAccountInfo();
                        break;
                    case MenuOption.Exit:
                        _usingApplication = false;
                        break;
                    default:
                        break;
                }
            }

            _consoleView.DisplayClosingScreen();

            Environment.Exit(1);

        }

        public void Travel()
        {
            string nextCity = _consoleView.DisplayGetNextCity();
            _salesperson.CitiesVisited.Add(nextCity);
        }
    }
}

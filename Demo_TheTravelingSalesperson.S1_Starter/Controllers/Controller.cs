using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TheTravelingSalesperson
{
    public class Controller
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
                    case MenuOption.Buy:
                        Buy();
                        break;
                    case MenuOption.Sell:
                        Sell();
                        break;
                    case MenuOption.DisplayInventory:
                        DisplayInventory();
                        break;
                    case MenuOption.DisplayCities:
                        DisplayCities();
                        break;
                    case MenuOption.DisplayAccountInfo:
                        DisplayAccountInfo();
                        break;
                    case MenuOption.SaveAccountInfo:
                        SaveAccountInfo();
                        break;
                    case MenuOption.LoadAccountInfo:
                        LoadAccountInfo();
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

        ///
        /// Buy products
        /// 
        private void Buy()
        {
            int numberOfUnits = _consoleView.DisplayGetNumberOfUnitsToBuy(_salesperson.CurrentStock);
            _salesperson.CurrentStock.AddProducts(numberOfUnits);
        }

        /// <summary>
        /// Sell Products
        /// </summary>
        private void Sell()
        {
            int numberOfUnits = _consoleView.DisplayGetNumberOfUnitsToSell(_salesperson.CurrentStock);
            _salesperson.CurrentStock.SubtractProducts(numberOfUnits);

            if (_salesperson.CurrentStock.OnBackOrder)
            {
                _consoleView.DisplayBackorderNotification(_salesperson.CurrentStock, numberOfUnits);
            }
        }

        private void DisplayInventory()
        {
            _consoleView.DisplayInventory(_salesperson.CurrentStock);
        }

        public void Travel()
        {
            string nextCity = _consoleView.DisplayGetNextCity();
            _salesperson.CitiesVisited.Add(nextCity);
        }

        private void SaveAccountInfo()
        {

        }

        private void LoadAccountInfo()
        {

        }
    }
}

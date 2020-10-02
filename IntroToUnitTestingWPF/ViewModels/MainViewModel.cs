using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WPFFormUI.Commands;

namespace WPFFormUI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Properties

        private string firstName;
        private string lastName;

        public string FirstName
        {
            get => firstName;
            set { 
                firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }

        private double firstNumber;

        public double FirstNumber
        {
            get { return firstNumber; }
            set
            {
                firstNumber = value;
                OnPropertyChanged();
            }

        }

        private double secondNumber;

        public double SecondNumber
        {
            get { return secondNumber; }
            set { 
                secondNumber = value;
                OnPropertyChanged();
            }
        }

        private string results;

        public string Results
        {
            get { return results; }
            set { 
                results = value;
                OnPropertyChanged();
            }
        }


        private PersonModel selectedPerson;

        public PersonModel SelectedPerson
        {
            get { return selectedPerson; }
            set { 
                selectedPerson = value;
                OnPropertyChanged();
            }
        }




        #endregion

        #region Commands

        public ObservableCollection<PersonModel> People { get; set; }
        public DelegateCommand<string> AddPersonCommand { get; set; }
        public DelegateCommand<string> AddCommand { get; set; }
        public DelegateCommand<string> SubstractCommand { get; set; }
        public DelegateCommand<string> MultiplyCommand { get; set; }
        public DelegateCommand<string> DivideCommand { get; set; }

        #endregion

        public MainViewModel()
        {
            init();
            RebindList();
        }

        void init()
        {
            AddPersonCommand = new DelegateCommand<string>(AddPerson);
            AddCommand = new DelegateCommand<string>(Add);
            SubstractCommand = new DelegateCommand<string>(Substract);
            MultiplyCommand = new DelegateCommand<string>(Multiply);
            DivideCommand = new DelegateCommand<string>(Divide);

        }

        private void Divide(string obj)
        {
            Results = Calculator.Divide(FirstNumber, SecondNumber).ToString();

            FirstNumber = 0;
            SecondNumber = 0;
        }

        private void Multiply(string obj)
        {
            Results = Calculator.Multiply(FirstNumber, SecondNumber).ToString();

            FirstNumber = 0;
            SecondNumber = 0;
        }

        private void Substract(string obj)
        {
            Results = Calculator.Subtract(FirstNumber, SecondNumber).ToString();

            FirstNumber = 0;
            SecondNumber = 0;
        }

        private void Add(string obj)
        {
            Results = Calculator.Add(FirstNumber, SecondNumber).ToString();

            FirstNumber = 0;
            SecondNumber = 0;
        }

        private void AddPerson(string obj)
        {
            var p = new PersonModel { FirstName = FirstName, LastName = LastName };

            DataAccess.AddNewPerson(p);

            FirstName = LastName = "";

            RebindList();

        }

        void RebindList()
        {
            People = new ObservableCollection<PersonModel>(DataAccess.GetAllPeople());

        }
    }
}

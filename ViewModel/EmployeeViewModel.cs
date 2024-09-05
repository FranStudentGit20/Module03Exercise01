using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module02Exercise01.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;


namespace Module02Exercise01.ViewModel
{
    public class EmployeeViewModel: INotifyPropertyChanged
    {
        private Employee _manager;

        private string _fullName;

        public EmployeeViewModel() 
        {

            _manager = new Employee { FirstName = "John", LastName = "Park", Position="Manager", Department="IT", IsActive=false};

            LoadEmployeeDataCommand = new Command(async () => await LoadEmployeeDataAsync());

            Employees = new ObservableCollection<Employee>
            {
                new Employee {FirstName="Sarah", LastName="Gregory", Position="Assistant", Department="IT", IsActive=true},
                new Employee {FirstName="Mike", LastName="Thompson", Position="Secretary", Department="IT", IsActive=true},
                new Employee {FirstName="Lucas", LastName="Franko",Position="Treasurer", Department="IT", IsActive=false},
            };
        }

        public ObservableCollection<Employee> Employees { get; set; }

        public ICommand LoadEmployeeDataCommand { get; }

        public string ManagerName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(ManagerName));
                }
            }
        }





        private async Task LoadEmployeeDataAsync()
        {
            await Task.Delay(1000); 
            ManagerName = $"{_manager.FirstName} {_manager.LastName} {_manager.Position} {_manager.Department} {_manager.IsActive}";

         

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

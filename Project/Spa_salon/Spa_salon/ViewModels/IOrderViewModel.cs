using IssueTracker.Commands;
using Spa_salon.Common.Enumerations;
using Spa_salon.Common.Models;
using Spa_salon.Common.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Spa_salon.ViewModels
{
    public interface IOrderViewModel : INotifyPropertyChanged
    {
        #region Properties
        OrderFilters OrderFilter { get; set; }
        string SearchString { get; set; }
        #endregion

        #region Collections
        ObservableCollection<IOrder> WorkerOrders { get; set; }
        ObservableCollection<IOrder> AllOrders { get; }
        ObservableCollection<IOrder> ActiveOrders { get; }
        #endregion

        #region Commands
        ICommand SearchOrdersCommand { get; }
        #endregion
    }

    public class OrderViewModel : ViewModelBase, IOrderViewModel
    {
        #region Constructors
        public OrderViewModel(UserViewModel user)
        {
            var orderService = new OrderService();

            if (user.Status == WorkerStatus.Worker)
            {
                WorkerOrders = new ObservableCollection<IOrder>(orderService.GetOrders(user.Specialities));
                AllOrders = WorkerOrders;
                ActiveOrders = new ObservableCollection<IOrder>(WorkerOrders.Where(x => x.IsActual == true).ToList());
            }
            else
            {
                WorkerOrders = new ObservableCollection<IOrder>(orderService.GetOrders(user.Salon.SalodId));
                AllOrders = WorkerOrders;
            }

            OrderFilter = OrderFilters.LastName;
        }
        #endregion

        #region Properties
        public ObservableCollection<IOrder> ActiveOrders
        {
            get;
        }

        private OrderFilters _orderFilter;
        public OrderFilters OrderFilter
        {
            get
            {
                return _orderFilter;
            }

            set
            {
                _orderFilter = value;
                OnPropertyChanged("OrderFilter");
            }
        }

        private ObservableCollection<IOrder> _workerOrders;
        public ObservableCollection<IOrder> WorkerOrders
        {
            get
            {
                return _workerOrders;
            }
            set
            {
                _workerOrders = value;
                OnPropertyChanged("WorkerOrders");
            }
        }

        private string _searchString;
        public string SearchString
        {
            get
            {
                return _searchString;
            }

            set
            {
                _searchString = value;
                OnPropertyChanged("SearchString");
            }
        }

        public ObservableCollection<IOrder> AllOrders
        {
            get;
        }
        #endregion

        #region Commands
        private ICommand _searchOrderCommand;
        public ICommand SearchOrdersCommand
        {
            get
            {
                if (_searchOrderCommand == null)
                {
                    _searchOrderCommand = new DelegateCommand(SearchOrdersCommand_Execute, SearchOrdersCommand_CanExecute);
                }

                return _searchOrderCommand;
            }
        }

        private bool SearchOrdersCommand_CanExecute(object o)
        {
            if(string.IsNullOrEmpty(SearchString))
            {
                WorkerOrders = AllOrders;
                return false;
            }
            return true;
        }

        private void SearchOrdersCommand_Execute(object o)
        {
            try
            {
                switch(OrderFilter)
                {
                    case OrderFilters.LastName:
                        WorkerOrders = new ObservableCollection<IOrder>(AllOrders.Where(x => x.Client.LastName == SearchString).ToList());
                        break;
                    case OrderFilters.FirstName:
                        WorkerOrders = new ObservableCollection<IOrder>(AllOrders.Where(x => x.Client.FirstName == SearchString).ToList());
                        break;
                    case OrderFilters.PhoneNumber:
                        WorkerOrders = new ObservableCollection<IOrder>(AllOrders.Where(x => x.Client.PhoneNumber.ToString() == SearchString).ToList());
                        break;
                    case OrderFilters.Date:
                        WorkerOrders = new ObservableCollection<IOrder>(AllOrders.Where(x => x.OrderDate.ToString("dd.MM.yyyy") == SearchString).ToList());
                        break;
                    case OrderFilters.Time:
                        WorkerOrders = new ObservableCollection<IOrder>(AllOrders.Where(x => x.OrderTime.ToString("hh\\:mm") == SearchString).ToList());
                        break;
                    case OrderFilters.Actuality:

                        if (string.Equals(SearchString, "Виконано"))
                        {
                            WorkerOrders = new ObservableCollection<IOrder>(AllOrders.Where(x => x.IsActual == false).ToList());
                        }
                        else if(string.Equals(SearchString, "Не виконано"))
                        {
                            WorkerOrders = new ObservableCollection<IOrder>(AllOrders.Where(x => x.IsActual == true).ToList());
                        }
                        else
                        {
                            WorkerOrders = null;
                        }
                        break;
                    case OrderFilters.TotalPrice:
                        WorkerOrders = new ObservableCollection<IOrder>(AllOrders.Where(x => x.TotalPrice.ToString() == SearchString).ToList());
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }
        #endregion
    }
}
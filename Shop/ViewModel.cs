using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using System.Data.Entity;
using Shop;
using Shop.MODEL;

namespace Shop
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        DATA.modelEntities DB = new DATA.modelEntities();



        //List<<>f__AnonymousType0<int, string, string, bool, string>>      IEnumerable<TableClient>
        //List<TableClient>

        private List<TableClient> _client;
        public List<TableClient> client
        {
            get { return _client;}
            set
            {
                _client = value;
                OnPropertyChanged("ListClient"); // уведомление View о том, что произошло изменение
            }
        }


        private ICommand _LoadDB;
        public ICommand CommandLoad => _LoadDB ?? (_LoadDB = new RelayCommand(LoadDB));    
        

        private void LoadDB(object parameter)
        {
            var table1 = from p in DB.Clients select new { p.ID, p.Name, p.Address, p.VIP, p.Orders };
            //MessageBox.Show(table1.GetType().ToString());
            //DataGrid1.ItemsSource = table1.ToList();
            //client = table1.ToList();
            //client.Add(table1.ToList());

            var table2 = from p in DB.Orders select new { p.ID, p.Description, p.ClientID };
            //DataGrid2.ItemsSource = table2.ToList();
        }
















        


        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////
        /// </summary>

        private ICommand _Texting;
        public ICommand CommandText => _Texting ?? (_Texting = new RelayCommand(mess));



        private string _text;
        public string text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged("TEXT"); // уведомление View о том, что произошло изменение
            }
        }


        private void mess(object parameter)
        {
            MessageBox.Show(text);
        }

        /// ///////////////////////////////////////////////////////////////////////////

    }
}

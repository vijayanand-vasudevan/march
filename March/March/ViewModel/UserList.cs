using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace March.ViewModel
{
    class UserList : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public class Person
        {
            public string Name { get; set; }
            public string Comments { get; set; }
            public int Age { get; set; }
        };

        private List<Person> Persons = new List<Person>();
        public IEnumerable<Person> MyCollection
        {
            get {  return (from v in Persons select v); }
        }
        private Timer _myTimer;

        void genData()
        {
            int iL = Persons.Count;
            for (int i = iL; i < iL+200; i++)
            {
                Person p = new Person();
                p.Name = "Vijay" + i.ToString();
                p.Age = i;
                p.Comments = "This is my name for " + System.DateTime.Now.Ticks.ToString();
                Persons.Add(p);
            }
            NotifyPropertyChanged("MyCollection");
        }

        public UserList()
        {
            _myTimer = new Timer(100);
            _myTimer.Elapsed += _myTimer_Elapsed;
            _myTimer.Enabled = true;
        }

        void _myTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            genData();
        }
    }
}

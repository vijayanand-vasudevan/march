using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VUtils;
using System.Reflection;
using System.Windows.Controls;

namespace March.ViewModel
{
    class MainWindowViewModel
    {
        private ICommand m_ButtonCommand;
        public ICommand ButtonCommand
        {
            get
            {
                return m_ButtonCommand;
            }
            set
            {
                m_ButtonCommand = value;
            }
        }

        public MainWindowViewModel()
        {
            ButtonCommand = new RelayCommand(new Action<object>(ShowMessage));
        }

        public void ShowMessage(object obj)
        {
            MessageBox.Show(obj.ToString());

            string assembly = "";
            string xaml = "March.Views.UserList";
            string view = "March.ViewModel.UserList";

            Assembly ta = null;
            if (string.IsNullOrEmpty(assembly))
                ta = Assembly.GetCallingAssembly();
            else
                ta = Assembly.Load(assembly);

            Type wndtp = ta.GetType(xaml);
            Window wnd = new Window();
            UserControl xs = (UserControl)Activator.CreateInstance(wndtp);
            wnd.Content = xs;
            //wnd.DataContext = xs;
            Type vwtp = ta.GetType(view);
            var vwm = Activator.CreateInstance(vwtp);
            xs.DataContext = vwm;
            xs.Height = wnd.Height;
            xs.Width = wnd.Width;
            wnd.Show();
        }
    }
}

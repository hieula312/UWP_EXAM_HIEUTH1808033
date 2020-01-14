using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWP_RETEST.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_RETEST.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListStudent : Page
    {
        private SQLiteService _service;
        public ListStudent()
        {
            this.InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
                var list = _service.GetStudentByStatus(1);
                MyList.ItemsSource = list;
        }

        private void OnChange(object sender, SelectionChangedEventArgs e)
        {
            if (Status.Text == "Deactive")
            {
                var list = _service.GetStudentByStatus(1);
                MyList.ItemsSource = list;
            }else if (Status.Text == "Active")
            {
                var list = _service.GetStudentByStatus(1);
                MyList.ItemsSource = list;
            } ;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Menu));
        }
    }
}

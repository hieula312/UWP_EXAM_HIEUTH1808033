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
using UWP_RETEST.Models;
using UWP_RETEST.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_RETEST.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddStudent : Page
    {
        private SQLiteService _service;
        public AddStudent()
        {
            this.InitializeComponent();
            _service = new SQLiteService();
        }


        private void AddStudent_Clicked(object sender, RoutedEventArgs e)
        {
            var Student = new Student()
            {
                Name = name.Text
            };
            _service.CreateNewStudent(Student);
            this.Frame.Navigate(typeof(ListStudent));
        }
    }
}

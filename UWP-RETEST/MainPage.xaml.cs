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
using SQLitePCL;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_RETEST
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            processSQLite();
        }

        public void processSQLite()
        {
            SQLiteConnection conn = new SQLiteConnection("demo.db");
            String query = @"Create table if not exist Customer (ID Integer PRIMARY KEY AUTOINCREMENT, Name varchar(200), Phone varchar(50) UNIQUE)";
            //String query = @"Insert table demo (Name, Phone) values (?,?)";
            var stt = conn.Prepare(query);
//            stt.Bind(1, "Hieu");
//            stt.Bind(2,"0362655898");
            stt.Step();

        }
    }
}

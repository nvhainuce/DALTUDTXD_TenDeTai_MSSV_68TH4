using DALTUDTXD_TenDeTai_MSSV_68TH4.Views.Pages;
using DALTUDTXD_TenDeTai_MSSV_68TH4.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DALTUDTXD_TenDeTai_MSSV_68TH4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //khởi tạo UserControl Ribbon
            UC_Ribbon uc_Ribbon = new UC_Ribbon(MainFrame);
            Panel0.Children.Add(uc_Ribbon);
            //load home page
            MainFrame.Content = new HomePage();
        }
    }
}

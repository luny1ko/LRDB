using LR_DB.View;
using LR_DB.ViewModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LR_DB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static PersonViewModel vmPerson = new PersonViewModel();

        public MainWindow()
        {
            InitializeComponent();
            // можно загрузить или инициализировать vmPerson здесь
        }

        private void Employee_OnClick(object sender, RoutedEventArgs e)
        {
            WindowEmployee wEmployee = new WindowEmployee();
            wEmployee.Show();
        }

        private void Role_OnClick(object sender, RoutedEventArgs e)
        {
            WindowRole wRole = new WindowRole();
            wRole.Show();
        }

        public static int IdRole { get; set; }
        public static int IdEmployee { get; set; }
    }
}
    

using LR_DB.View;
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
        

        public MainWindow()
        {
            InitializeComponent();
            // можно загрузить или инициализировать vmPerson здесь
        }

        private void Employee_OnClick(object sender, RoutedEventArgs e)
        {
            WindowBooks wBooks = new WindowBooks();
            wBooks.Show();
        }

        private void Role_OnClick(object sender, RoutedEventArgs e)
        {
            WindowGenres wRole = new WindowGenres();
            wRole.Show();
        }

        public static int IdRole { get; set; }
        public static int IdEmployee { get; set; }
    }
}
    

using LR_DB.Helper;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;

namespace LR_DB.View
{
    public partial class WindowGenres : Window
    {
        private BookshopDbContext db;

        public WindowGenres()
        {
            InitializeComponent();
            db = new BookshopDbContext();
            LoadGenres();
        }

        private void LoadGenres()
        {
            db.Genres.Load();
            dgGenres.ItemsSource = db.Genres.Local.ToObservableCollection();
        }
    }
}

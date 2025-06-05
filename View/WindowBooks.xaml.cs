using LR_DB.Helper;
using LR_DB.Model;
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
    public partial class WindowBooks : Window
    {
        private BookshopDbContext db;

        public WindowBooks()
        {
            InitializeComponent();
            db = new BookshopDbContext();
            LoadBooks();
        }

        private void LoadBooks()
        {
            db.Books.Include(b => b.Genre).Load();
            dgBooks.ItemsSource = db.Books.Local.ToObservableCollection();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new WindowBookEdit(db);
            if (editWindow.ShowDialog() == true)
            {
                db.Books.Add(editWindow.Book);
                db.SaveChanges();
                LoadBooks();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgBooks.SelectedItem is Book selectedBook)
            {
                var bookFromDb = db.Books.Include(b => b.Genre).FirstOrDefault(b => b.Id == selectedBook.Id);
                if (bookFromDb == null) return;

                var editWindow = new WindowBookEdit(db, bookFromDb);
                if (editWindow.ShowDialog() == true)
                {
                    
                    db.SaveChanges();
                    
                    dgBooks.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Выберите книгу для редактирования");
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgBooks.SelectedItem is Book selectedBook)
            {
                if (MessageBox.Show($"Удалить книгу: {selectedBook.Name}?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    db.Books.Remove(selectedBook);
                    db.SaveChanges();
                    LoadBooks();
                }
            }
        }
    }
}


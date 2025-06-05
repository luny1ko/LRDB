using LR_DB.Helper;
using LR_DB.Model;
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
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace LR_DB.View
{
    public partial class WindowBookEdit : Window
    {
        private BookshopDbContext db;
        public Book Book { get; private set; }
        private bool isEdit;

        public WindowBookEdit(BookshopDbContext context, Book book = null)
        {
            InitializeComponent();
            db = context;
            LoadGenres();

            if (book == null)
            {
                Book = new Book();
                isEdit = false;
            }
            else
            {
                Book = book;
                isEdit = true;

                
                Name.Text = Book.Name;
                Genre.SelectedValue = Book.Id_Genre;
                Price.Text = Book.Price.ToString();
                Count.Text = Book.Count.ToString();
            }
        }

        private void LoadGenres()
        {
            var genres = db.Genres.ToList();
            Genre.ItemsSource = genres;
            Genre.DisplayMemberPath = "Name";
            Genre.SelectedValuePath = "Id";
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name.Text))
            {
                MessageBox.Show("Введите название книги");
                return;
            }

            if (Genre.SelectedItem == null)
            {
                MessageBox.Show("Выберите жанр");
                return;
            }

            if (!int.TryParse(Price.Text, out int price))
            {
                MessageBox.Show("Введите корректную цену");
                return;
            }

            if (!int.TryParse(Count.Text, out int count))
            {
                MessageBox.Show("Введите корректное количество");
                return;
            }

            
            Book.Name = Name.Text.Trim();
            Book.Id_Genre = (int)Genre.SelectedValue;
            Book.Price = price;
            Book.Count = count;

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
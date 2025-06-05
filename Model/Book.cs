using LR_DB.Helper;
using LR_DB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LR_DB.Model
{
    [Table("book")]
    public class Book : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private int _idGenre;
        private int _price;
        private int _count;
        private Genre _genre;

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public int Id_Genre
        {
            get => _idGenre;
            set { _idGenre = value; OnPropertyChanged(); }
        }

        public int Price
        {
            get => _price;
            set { _price = value; OnPropertyChanged(); }
        }

        public int Count
        {
            get => _count;
            set { _count = value; OnPropertyChanged(); }
        }

        [ForeignKey("Id_Genre")]
        public Genre Genre
        {
            get => _genre;
            set { _genre = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}




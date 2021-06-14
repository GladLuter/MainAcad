using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork121
{
    public interface ILibraryUser
    {
        //public string FirstName { get; }
        //public string LastName { get; }
        //public int ID { get; }
        //public string Phone { get; }
        //public static int BookLimit { get; }
        ////public LibraryBook[] bookList { get; set; }

        ////public LibraryBook this[int num] { get; set; }
        ////public LibraryBook this[string Author_] { get; set; }

        public void BookAdd(Book book);
        public void BookAdd(string name, string author, string about);
        public void BookRemove(Book book);
        public void BookRemove(int bookID);
        public void BookRemove(string name);
        public string BookInfo(Book book);
        public int BooksCount();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork121
{
    public class LibraryUser : ILibraryUser
    {
        private static int IDCounter = 0;
        public LibraryUser() : this("NoNameUser", "NoLastNameUSer", null) { }
        public LibraryUser(string FirstName_, string LastName_, string Phone_) {
            FirstName = FirstName_;
            LastName = LastName_;
            Phone = Phone_;
        }
        private Book[] bookList = new Book[BookLimit];
        private int BooksCounter = 0;

        public string this[int num] { 
            get {
                if (num > BookLimit)
                    throw new IndexOutOfRangeException();
                return bookList[num].Name; 
            } 
            set {
                if (num > BookLimit)
                    throw new IndexOutOfRangeException();
                BookAdd(value); 
            } 
        }
        //public Book this[string Author_] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int ID { get; private set; } = ++IDCounter;
        public string Phone { get; private set; }
        public static int BookLimit { get; private set; } = 20; //default
        //private LibraryBook[] bookList { get; set; }

        public void BookAdd(Book book)
        {
            bookList[BooksCounter++] = (Book)book.Clone();
        }
        public void BookAdd(string name, string author = "Unknown", string about = "Unknown")
        {
            bookList[BooksCounter++] = new Book(name, author, about);
        }
        public int BooksCount()
        {
            return BooksCounter;
        }
        public string BookInfo(Book book)
        {
            return book.GetInfo();
        }
        public void BookRemove(Book book)
        {
            for (int i = BooksCounter - 1; i >= 0; i--)
            {
                if (bookList[i] == book)
                {
                    BookRemove(i);
                }
            }
        }
        public void BookRemove(string name)
        {
            for (int i = BooksCounter - 1; i >= 0; i--)
            {
                if (bookList[i] is null) continue;
                if (bookList[i].Name == name)
                {
                    BookRemove(i);
                }
            }
        }
        public void BookRemove(int bookID)
        {
            if (bookID == BooksCounter)
            {
                bookList[bookID] = null;
            } else if(BooksCounter == 0 || bookID > BooksCounter)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = bookID; i < BooksCounter - 1; i++)
            {
                bookList[i] = bookList[i + 1];
            }
            BooksCounter--;

        }

    }
}

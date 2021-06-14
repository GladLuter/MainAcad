using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaWork121
{
    public class Book: ICloneable
    {
        public Book(string name, string author, string about)
        {
            this.Name = name;
            this.Author = author;
            this.About = about;
        }
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string About { get; private set; }

        public object Clone()
        {
            return new Book(Name, Author, About);
        }

        public string GetInfo()
        {
            return @$"Book Author: {Author}
Book Name: {Name}

{About}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Services
{
    internal class DatabaseController
    {

        public static IQueryable<Book> GetAllBooks()
        {
            DataClassesDataContext dtx = new DataClassesDataContext();

            var books = from b in dtx.Books
                        select b;
            return books;
        }

        public static IQueryable<Book> GetAllBooks2()
        {
            DataClassesDataContext dtx = new DataClassesDataContext();

            var books = from b in dtx.Books
                        select new Book { Id = b.Id, Name = b.Name };
            return books;
        }

        public static void UpdateBook(int id,int year_press,string comment,
                                        string name,int pageCount,int quantity)
        {
            DataClassesDataContext dtx=new DataClassesDataContext();
            var updatedBook = dtx.Books.FirstOrDefault(b => b.Id == id);

            updatedBook.Name = name;
            updatedBook.YearPress = year_press;
            updatedBook.Comment = comment;
            updatedBook.Quantity = quantity;
            updatedBook.Pages = pageCount;
            dtx.SubmitChanges();
            
        }

        public static void InsertBook(Book book)
        {
            var dtx = new DataClassesDataContext();

            dtx.Books.InsertOnSubmit(book);

            dtx.SubmitChanges();
        }

        public static void InsertPress(Press press)
        {
            var dtx = new DataClassesDataContext();

            dtx.Presses.InsertOnSubmit(press);

            dtx.SubmitChanges();
        }

        public static void InsertThemes(Theme theme)
        {
            var dtx = new DataClassesDataContext();

            dtx.Themes.InsertOnSubmit(theme);

            dtx.SubmitChanges();
        }

        public static void InsertCategory(Category category)
        {
            var dtx = new DataClassesDataContext();
            dtx.Categories.InsertOnSubmit(category);

            dtx.SubmitChanges();
        }

        public static void InsertAuthor(Author author)
        {
            var dtx = new DataClassesDataContext();
            dtx.Authors.InsertOnSubmit(author);

            dtx.SubmitChanges();
        }

        public static void DeleteBook(int id)
        {
            var dtx = new DataClassesDataContext();
            var book = dtx.Books.FirstOrDefault(c => c.Id == id);
            dtx.Books.DeleteOnSubmit(book);

            dtx.SubmitChanges();
        }

        public static void InsertSCard(S_Card s_Card)
        {
            var dtx = new DataClassesDataContext();
            dtx.S_Cards.InsertOnSubmit(s_Card);

            dtx.SubmitChanges();
        }

    }
}

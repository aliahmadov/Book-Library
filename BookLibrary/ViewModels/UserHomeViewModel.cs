﻿using BookLibrary.Commands;
using BookLibrary.Models;
using BookLibrary.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.ViewModels
{
    internal class UserHomeViewModel
    {
        public RelayCommand ShowCommand { get; set; }
        public RelayCommand TakeCommand { get; set; }
        public RelayCommand ReturnCommand { get; set; }


        private UserBook GetUserBook(Book book)
        {
            var dtx = new DataClassesDataContext();
            var author = dtx.Authors.FirstOrDefault(d => d.Id == book.Id_Author);
            var category = dtx.Categories.FirstOrDefault(d => d.Id == book.Id_Category);
            var press = dtx.Presses.FirstOrDefault(d => d.Id == book.Id_Press);

            return new UserBook
            {
                Id = book.Id,
                Author = author.FirstName + " " + author.LastName,
                Category = category.Name,
                Press = press.Name,
                Name = book.Name,
                Comment = book.Comment,
                Pages = book.Pages,
                YearPress = book.YearPress

            };
        }

        private List<UserBook> GetUserBooks()
        {
            var dtx = new DataClassesDataContext();
            var count = dtx.Books.Count();
 
            var books=new List<UserBook>();
            for (int i = 0; i < count; i++)
            {
                books.Add(GetUserBook(dtx.Books.Skip(i).First()));
            }
            return books;
        }



        public UserHomeViewModel()
        {
            ShowCommand = new RelayCommand(c =>
            {

                var dtx = new DataClassesDataContext();
               // var books = dtx.Books.Select(d => d.Quantity > 0);

                var view = new UserShowBooksUC();
                var viewModel = new UserShowBooksViewModel();
                view.DataContext = viewModel;
                view.userDataGrid.ItemsSource = GetUserBooks();

                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(view);

            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Services
{
    public class SpecialServices
    {

        public static IQueryable<string> GetAuthors()
        {
            var dtx = new DataClassesDataContext();

            var authors = from a in dtx.Authors
                          select a.FirstName + " " + a.LastName;

            return authors;
        }

        public static IQueryable<string> GetCategories()
        {
            var dtx = new DataClassesDataContext();

            var categories = from c in dtx.Categories
                             select c.Name;

            return categories; ;
        }

        public static IQueryable<string> GetPresses()
        {
            var dtx = new DataClassesDataContext();

            var presses = from p in dtx.Presses
                          select p.Name;
            return presses;

        }

        public static IQueryable<string> GetThemes()
        {
            var dtx = new DataClassesDataContext();
            var themes = from t in dtx.Themes
                         select t.Name;

            return themes;
        }

    }
}

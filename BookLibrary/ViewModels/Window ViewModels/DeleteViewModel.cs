using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.ViewModels.Window_ViewModels
{
    internal class DeleteViewModel:BaseViewModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

    }
}

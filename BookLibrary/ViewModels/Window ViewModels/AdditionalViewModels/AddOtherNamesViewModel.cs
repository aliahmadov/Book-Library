using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.ViewModels.Window_ViewModels.AdditionalViewModels
{
    internal class AddOtherNamesViewModel:BaseViewModel
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;OnPropertyChanged();}
        }

    }
}

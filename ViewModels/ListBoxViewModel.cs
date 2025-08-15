using SELF_KBM_DESIGN.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELF_KBM_DESIGN.ViewModels
{
    class ListBoxViewModel
    {

        public List<ListBoxModel> iListBoxes { get; set; }
        public ListBoxViewModel() 
        {
        iListBoxes = new List<ListBoxModel>
            {
                new ListBoxModel { Name = "Just Text Item", Type = "text" },
                new ListBoxModel { Name = "Apple", ImagePath = "apple.png", Type = "image" },
                new ListBoxModel { Name = "Mango Card", Description = "A tropical fruit", Type = "card" },
                new ListBoxModel { Name = "Orange Card", Description = "Citrus fruit", Type = "card" }
            };
        }
        
    }
}

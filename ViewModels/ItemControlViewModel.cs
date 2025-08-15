using SELF_KBM_DESIGN.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELF_KBM_DESIGN.ViewModels
{
    class ItemControlViewModel
    {
        public ObservableCollection<ItemControlModel> ItemsTemplateSourceDataList { get; set; }

        public ItemControlViewModel()
        {
            ItemsTemplateSourceDataList = new ObservableCollection<ItemControlModel>
            {
                new ItemControlModel { Label = "Name", PropertyType = "Text" },
                new ItemControlModel { Label = "Email", PropertyType = "Email" },
                new ItemControlModel { Label = "Phone", PropertyType = "Phone" },
                new ItemControlModel { Label = "Address", PropertyType = "Text" },
                new ItemControlModel { Label = "Comments", PropertyType = "Comments" },
                new ItemControlModel { Label = "Additional Information", PropertyType = "Text" },
                new ItemControlModel { Label = "Feedback", PropertyType = "Comments" }
            };
        }

    }
}

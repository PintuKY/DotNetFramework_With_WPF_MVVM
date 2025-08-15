using SELF_KBM_DESIGN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SELF_KBM_DESIGN.Template
{
    public class MyListBoxTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Text1Template { get; set; }
        public DataTemplate ImageTemplate { get; set; }
        public DataTemplate CardTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ListBoxModel data)
            {
                return data.Type switch
                {
                    "text" => Text1Template,
                    "image" => ImageTemplate,
                    "card" => CardTemplate,
                    _ => Text1Template
                };
            }
            return base.SelectTemplate(item, container);
        }
    }
}

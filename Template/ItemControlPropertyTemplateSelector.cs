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
    class ItemControlPropertyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextTemplate { get; set; }
        public DataTemplate EmailTemplate { get; set; }
        public DataTemplate PhoneTemplate { get; set; }
        public DataTemplate CommentsTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ItemControlModel DataModel)
            {
                switch (DataModel.PropertyType)
                {
                    case "Text":
                        return TextTemplate;
                    case "Email":
                        return EmailTemplate;
                    case "Phone":
                        return PhoneTemplate;
                    case "Comments":
                        return CommentsTemplate;
                    default:
                        return base.SelectTemplate(item, container);
                }
            }
            return base.SelectTemplate(item, container);
        }

    }
}

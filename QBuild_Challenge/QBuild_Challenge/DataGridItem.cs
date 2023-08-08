using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBuild_Challenge
{
    class DataGridItem
    {
        public string ParentName { get; set; }
        public string ComponentName { get; set; }
        public string PartNumber { get; set; }
        public string Title { get; set; }
        public string Quantity { get; set; }
        public string Type { get; set; }
        public string Item { get; set;}
        public string Material { get; set; }

        public DataGridItem(Component c)
        {
            ParentName = c.parentName;
            ComponentName = c.componentName;
            PartNumber = c.partNumber;
            Title = c.title;
            Quantity = c.quantity.ToString();
            Type = c.type;
            Item = c.item;
            Material = c.material;
        }

        public DataGridItem()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mcp.Shared.ViewModels
{
    public class ProjectPartViewModel
    {
        public int ProjectPartID { get; set; }
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string PartNumber { get; set; }
        public decimal? Price { get; set; }
        public decimal MoneySpent { get; set; }
        public string Link { get; set; }
        public int Quantity { get; set; }
        public int QuantityPurchased { get; set; }
        public int QuantityInstalled { get; set; }

        public string LinkText
        {
            get
            {
                if(this.Link == null)
                {
                    return "";
                }
                else
                {
                    string text = this.Link.ToLower();
                    if (text.StartsWith("http"))
                    {
                        text = text.Substring(text.IndexOf("//") + 2);
                        if(text.Contains('/'))
                        {
                            text = text.Substring(0, text.IndexOf('/'));
                        }
                    }
                    return text;
                }
            }
        }
    
        public bool IsSelected { get; set; }
    }
}

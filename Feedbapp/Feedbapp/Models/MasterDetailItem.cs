using System;
using Xamarin.Forms;

namespace Feedbapp.Models
{
    public class MasterDetailItem
    {
        public MasterDetailItem(string name, string icon)
        {
            this.Name = name;
            this.icon = icon;
        }

        public string Name { private set; get; }

        public string icon { private set; get; }

        public override string ToString()
        {
            return Name;
        }
    }

}

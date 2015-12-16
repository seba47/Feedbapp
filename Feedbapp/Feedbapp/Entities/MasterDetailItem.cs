using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Feedbapp.Entities
{
    public class MasterDetailItem
    {
        public MasterDetailItem(string n, string icon)
        {
            this.name = n;
            this.icon = icon;
        }

        public string name { set; get; }

        public string icon { set; get; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Icon
        {
            get
            {
                return this.icon;
            }
            set
            {
                this.icon = value;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }


    public class PageTypeGroup : List<MasterDetailItem>
    {
        public string Title { get; set; }
        public string ShortName { get; set; } //will be used for jump lists
        public string Subtitle { get; set; }
        private PageTypeGroup(string title, string shortName)
        {
            Title = title;
            ShortName = shortName;            
        }

        public static IList<PageTypeGroup> All { private set; get; }

        static PageTypeGroup()
        {
            List<PageTypeGroup> Groups = new List<PageTypeGroup> {
            new PageTypeGroup ("Solicitudes Pendientes", "A"){
                new MasterDetailItem("José Perez", "profile1.png"),
                new MasterDetailItem("Ale Rodriguez", "profile1.png"),
                new MasterDetailItem("GMaria Perez", "profile2.png"),
                new MasterDetailItem("Seba Cabrera", "profile1.png")
            },
            new PageTypeGroup ("Solicitudes Aprobadas", "B"){
                new MasterDetailItem("José Perez", "profile1.png"),
                new MasterDetailItem("José Lalala", "profile1.png"),
                new MasterDetailItem("Ricardo A", "profile1.png"),
                new MasterDetailItem("José Fernandez", "profile1.png")
            }
        };
            All = Groups; //set the publicly accessible list
        }
    }


}

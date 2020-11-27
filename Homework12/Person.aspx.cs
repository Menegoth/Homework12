using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Homework12 {
    public partial class Person : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            List<person> myList = new List<person>();
            person p1 = new person("Mark", 12, 6.2);
            person p2 = new person("John", 15, 5);
            person p3 = new person("Rob", 10, 6.3);
            person p4 = new person("Rick", 17, 5.0);
            person p5 = new person("Evan", 10, 6.0);
            person p6 = new person("James", 14, 5.5);
            person p7 = new person("Jimmy", 11, 5.0);
            person p8 = new person("Carl", 12, 5.4);
            person p9 = new person("Jonathan", 9, 4.7);
            person p10 = new person("Bob", 15, 5.7);

            myList.Add(p1);
            myList.Add(p2);
            myList.Add(p3);
            myList.Add(p4);
            myList.Add(p5);
            myList.Add(p6);
            myList.Add(p7);
            myList.Add(p8);
            myList.Add(p9);
            myList.Add(p10);

            //list requirement
            //PersonGridView.DataSource = from a in myList select a;
            //PersonGridView.DataSource = from pa in myList where pa.Age <= 12 select pa;
            //PersonGridView.DataBind();

            //average height
            //count people
            int personCount = (from pa in myList
                               orderby pa.Name, pa.Height, pa.Age
                               select pa).Count();

            double averageHeight = 0;
            double sum = 0;

            foreach (var pp in myList) {
                sum += pp.Height;
            }
            averageHeight = sum / personCount;

            PersonGridView.DataSource = from pa in myList where pa.Height >= averageHeight && pa.Age <= 12 select pa;
            PersonGridView.DataBind();

        }

        public class person {

            string name;
            int age;
            double height;

            public person(string name, int age, double height) {
                this.Name = name;
                this.Age = age;
                this.Height = height;
            }

            public string Name { get => name; set => name = value; }
            public int Age { get => age; set => age = value; }
            public double Height { get => height; set => height = value; }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pz_13
{
    /// <summary>
    /// Логика взаимодействия для Change.xaml
    /// </summary>
    public partial class Change : Window
    {
        public Change(int id, string point, string date, string inc)
        {
            InitializeComponent();
            id = id;
            point = point;
            date = date;
            inc = inc;
            using (Income db = new Income())
            {
                db.Income.Remove(new Income() { id = id, point = point, date = date, inc = inc});
                db.SaveChanges();
            }
        }

        private void BTN_Click(object sender, RoutedEventArgs e)
        {
            using (Income db = new Income())
            {
                db.Income.Add(new Income() { id = id, point = point, date = date, inc = inc }); //не работает:( 
                db.SaveChanges();
            }
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pz_13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        Income db;
    
        public MainWindow()
        {
            db = new Income();
            InitializeComponent();
                dataGrid.ItemsSource = db.Income.ToList();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Income item = dataGrid.SelectedItem as Income;
            Edit edit = new Edit(item.id,item.point,item.date,item.inc);
            edit.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Income item = dataGrid.SelectedItem as Income;
           
                db.Remove(item);
                db.SaveChanges();
                dataGrid.ItemsSource = db.Income.ToList(); 
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmb_bx.SelectedIndex)
            {
                case 0:
                    dataGrid.ItemsSource = db.Income.OrderBy(w => w.id).ToList();
                    break;
                case 1:
                    dataGrid.ItemsSource = db.Income.OrderBy(w => w.point).ToList();
                    break;
                case 2:
                    dataGrid.ItemsSource = db.Income.OrderBy(w => w.date).ToList();
                    break;
                case 3:
                    dataGrid.ItemsSource = db.Income.OrderBy(w => w.inc).ToList();
                    break;
            }
            
        }

        private void groupClick(object sender, RoutedEventArgs e)
        {
            var joinQuery = db.Income.AsEnumerable().Join(db.Outcome, income => income.id, Outcome => Outcome.id,
            (p, l) => new
            {
                id = p.id,
                id_ = l.id,
                point = p.point.ToString(),
                date = l.date.ToString(),
                inc = p.inc.ToString(),
                out_ = l.out_.ToString(),
            }).ToList();
            dataGrid.ItemsSource = joinQuery;
            foreach(var item in joinQuery)
            {
                incoutAll.Text = (int.Parse(incoutAll.Text.ToString())+int.Parse(item.date)).ToString();
            }                               
        }
    }
}

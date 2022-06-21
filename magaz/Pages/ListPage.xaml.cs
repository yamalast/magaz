using magaz.DataBase;
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

namespace magaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Window
    {
        public ListPage()
        {
            InitializeComponent();
            LVProduct.ItemsSource = EFModel.init().Products.ToList();
            CbName.Items.Add("По возрастанию");
            CbName.Items.Add("По убыванию");
            CbName.SelectedIndex = 0;
            UpdateData();
        }
        private void UpdateData()
        {
            IEnumerable<Product> products = EFModel.init().Products.Where(p => p.ProductArticul.Contains(TbSearch.Text) ||
            p.ProductCategory.Contains(TbSearch.Text) || p.ProductName.Contains(TbSearch.Text));
            switch (CbName.SelectedIndex)
            {
                case 0:
                    products = products.OrderBy(p => p.ProductCost);
                    break;
                case 1:
                    products = products.OrderByDescending(p => p.ProductCost);
                    break;
            }
            LVProduct.ItemsSource = products.ToList();
        }

        private void TbTextChange(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void CbSortChange(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
    }
}

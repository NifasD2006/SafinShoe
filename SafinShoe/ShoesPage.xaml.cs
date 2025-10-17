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

namespace SafinShoe
{
    /// <summary>
    /// Логика взаимодействия для ShoesPage.xaml
    /// </summary>
    public partial class ShoesPage : Page
    {
        public ShoesPage()
        {
            InitializeComponent();
            ComboType.SelectedIndex = 0;
            var currentShoes = SafinShoeEntities.GetContext().Products.ToList();
            ShoeListView.ItemsSource = currentShoes;
            UpdateProducts();
        }


        private void UpdateProducts()
        {
            var currentShoes = SafinShoeEntities.GetContext().Products.ToList();

            if (ComboType.SelectedIndex == 2)
            {
                currentShoes = currentShoes.Where(p => (p.ProductSupplier == "Kari")).ToList();
            }
            if (ComboType.SelectedIndex == 1)
            {
                currentShoes = currentShoes.Where(p => (p.ProductSupplier == "Обувь для вас")).ToList();
            }
            if (RButtonDown.IsChecked.Value)
            {
                currentShoes = currentShoes.OrderByDescending(p => p.ProductCount).ToList();
            }

            if (RButtonUP.IsChecked.Value)
            {
                currentShoes = currentShoes.OrderBy(p => p.ProductCount).ToList();
            }


            currentShoes = currentShoes.Where(p => p.ProductUnit.ToLower().Contains(TBoxSearch.Text.ToLower()) || p.ProductSupplier.ToLower().Contains(TBoxSearch.Text.ToLower()) || p.ProductArticle.ToLower().Contains(TBoxSearch.Text.ToLower()) || p.ProductTypes.ProductTypeName.ToLower().Contains(TBoxSearch.Text.ToLower()) ||
                p.ProductCategory.ToLower().Contains(TBoxSearch.Text.ToLower()) || p.ProductDescription.ToLower().Contains(TBoxSearch.Text.ToLower()) || p.ProductManufacturer.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            currentShoes = currentShoes.Where(p => p.ProductUnit.ToLower().Contains(TBoxSearch2.Text.ToLower()) || p.ProductSupplier.ToLower().Contains(TBoxSearch.Text.ToLower()) || p.ProductArticle.ToLower().Contains(TBoxSearch2.Text.ToLower()) || p.ProductTypes.ProductTypeName.ToLower().Contains(TBoxSearch2.Text.ToLower()) ||
    p.ProductCategory.ToLower().Contains(TBoxSearch2.Text.ToLower()) || p.ProductDescription.ToLower().Contains(TBoxSearch2.Text.ToLower()) || p.ProductManufacturer.ToLower().Contains(TBoxSearch2.Text.ToLower())).ToList();


            ShoeListView.ItemsSource = currentShoes;
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void RButtonUP_Checked(object sender, RoutedEventArgs e)
        {
            UpdateProducts();
        }

        private void RButtonDown_Checked(object sender, RoutedEventArgs e)
        {
            UpdateProducts();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void TBoxSearchSecond_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProducts();
        }
    }
}

using System.Windows;
using System.Windows.Controls;

namespace RecipeManagementApp
{
    public partial class ScaleRecipeWindow : Window
    {
        public double ScaleFactor { get; set; }

        public ScaleRecipeWindow()
        {
            InitializeComponent();
        }



      private void Scale_Click(object sender, RoutedEventArgs e)
{
    ScaleFactor = double.Parse(((ComboBoxItem)cmbScaleFactor.SelectedItem).Content.ToString());
    DialogResult = true;

    
}

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

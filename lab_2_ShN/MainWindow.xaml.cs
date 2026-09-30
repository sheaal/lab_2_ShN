using lab_2_ShN.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab_2_ShN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MessageBox.Show(new BigNumber(100).ToString());
            MessageBox.Show(new BigNumber("1234567").ToString());
            MessageBox.Show(BigNumber.Zero.ToString());
        }

        private void EnemyImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void UpgradeButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
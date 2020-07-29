using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DiceRollerClicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        public GameManager gm = new GameManager();
        public GamePage()
        {
            this.InitializeComponent();
        }
        public async void Roll_Click(object sender, RoutedEventArgs e)
        {
            gm.Click();
        }
        public async void BuyGoblin_Click(object sender, RoutedEventArgs e)
        {
            gm.BuyGoblin();
        }
        public async void BuyD4_Click(object sender, RoutedEventArgs e)
        {
            gm.BuyD4();
        }
        public async void BuyD6_Click(object sender, RoutedEventArgs e)
        {
            gm.BuyD6();
        }
        public async void BuyD8_Click(object sender, RoutedEventArgs e)
        {
            gm.BuyD8();
        }
        public async void BuyD10_Click(object sender, RoutedEventArgs e)
        {
            gm.BuyD10();
        }
        public async void BuyD12_Click(object sender, RoutedEventArgs e)
        {
            gm.BuyD12();
        }
        public async void BuyD20_Click(object sender, RoutedEventArgs e)
        {
            gm.BuyD20();
        }
    }
}

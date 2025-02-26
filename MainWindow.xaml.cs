using DotNetProjectScaffold.ViewModels;
using System.Windows;

namespace DotNetProjectScaffold
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
        }
    }
}
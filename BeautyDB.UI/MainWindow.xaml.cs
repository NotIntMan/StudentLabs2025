using System.Windows;

namespace BeautyDB.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void CreateButton_Click(object sender, RoutedEventArgs e)
    {
        var reservationWindow = new ReservationEditWindow();
        reservationWindow.ShowDialog();
    }
}
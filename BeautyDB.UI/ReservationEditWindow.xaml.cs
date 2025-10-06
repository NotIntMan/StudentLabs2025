namespace BeautyDB.UI;

using System.Windows;

public partial class ReservationEditWindow : Window
{
    public ReservationEditWindow()
    {
        InitializeComponent();
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        // TODO: Implement save logic
        DialogResult = true;
        Close();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}
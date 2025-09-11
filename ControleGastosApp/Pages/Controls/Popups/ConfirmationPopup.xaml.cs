using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Maui.Views;

namespace ControleGastosApp.Pages.Controls.Popups;

public partial class ConfirmationPopup : Popup<bool>
{
    // ====== StatusBar ======
    static Color StatusBarColor => (Color)Application.Current!.Resources["OverlayPopup"];

    public static readonly BindableProperty MessageProperty =
       BindableProperty.Create(
           nameof(Message),
           typeof(string),
           typeof(ConfirmationPopup),
           default(string));

    public string Message
    {
        get => (string)GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    public static readonly BindableProperty AcceptProperty =
       BindableProperty.Create(
           nameof(Accept),
           typeof(string),
           typeof(ConfirmationPopup),
           default(string));

    public string Accept
    {
        get => (string)GetValue(AcceptProperty);
        set => SetValue(AcceptProperty, value);
    }

    public static readonly BindableProperty CancelProperty =
       BindableProperty.Create(
           nameof(Cancel),
           typeof(string),
           typeof(ConfirmationPopup),
           default(string));

    public string Cancel
    {
        get => (string)GetValue(CancelProperty);
        set => SetValue(CancelProperty, value);
    }

    public static readonly BindableProperty IconeProperty =
        BindableProperty.Create(
            nameof(Icone),
            typeof(string),
            typeof(ConfirmationPopup),
            string.Empty);

    public string Icone
    {
        get => (string)GetValue(IconeProperty);
        set => SetValue(IconeProperty, value);
    }

    public ConfirmationPopup()
	{
		InitializeComponent();

        Opened += (_, __) => ApplyBars();
        Closed += (_, __) => ApplyBars();
    }

    private static void ApplyBars() => StatusBar.SetColor(StatusBarColor);

    private async void OnCancel_Clicked(object sender, EventArgs e)
    {
        await CloseAsync(false);
    }

    private async void OnAccept_Clicked(object sender, EventArgs e)
    {
        await CloseAsync(true);
    }

    private void OnClickedClose(object sender, TappedEventArgs e)
    {
        CloseAsync(false);
    }
}
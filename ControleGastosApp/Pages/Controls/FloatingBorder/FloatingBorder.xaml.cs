namespace ControleGastosApp.Pages.Controls.FloatingBorder;

public partial class FloatingBorder : ContentView
{
	public FloatingBorder()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty HintProperty =
        BindableProperty.Create(
            nameof(Hint),
            typeof(string),
            typeof(FloatingBorder),
            string.Empty);

    public string Hint
    {
        get => (string)GetValue(HintProperty);
        set => SetValue(HintProperty, value);
    }

    public static readonly BindableProperty IconeProperty =
        BindableProperty.Create(
            nameof(Icone),
            typeof(string),
            typeof(FloatingBorder),
            string.Empty);

    public string Icone
    {
        get => (string)GetValue(IconeProperty);
        set => SetValue(IconeProperty, value);
    }

    public static readonly BindableProperty ErrorMessageProperty =
        BindableProperty.Create(
            nameof(ErrorMessage),
            typeof(string),
            typeof(FloatingBorder),
            string.Empty);

    public string ErrorMessage
    {
        get => (string)GetValue(ErrorMessageProperty);
        set => SetValue(ErrorMessageProperty, value);
    }

    public static readonly BindableProperty HasErrorProperty =
        BindableProperty.Create(
            nameof(HasError),
            typeof(bool),
            typeof(FloatingBorder),
            false);

    public bool HasError
    {
        get => (bool)GetValue(HasErrorProperty);
        set => SetValue(HasErrorProperty, value);
    }

    public static readonly BindableProperty BorderBackgroundProperty =
        BindableProperty.Create(
            nameof(BorderBackground),
            typeof(Color),
            typeof(FloatingBorder),
            Colors.White);    

    public Color BorderBackground
    {
        get => (Color)GetValue(BorderBackgroundProperty);
        set => SetValue(BorderBackgroundProperty, value);
    }

    public static readonly BindableProperty ErrorMessageColorProperty =
        BindableProperty.Create(
            nameof(ErrorMessageColor),
            typeof(Color),
            typeof(FloatingBorder),
            (Color)App.Current!.Resources["ActionRed"]);

    public Color ErrorMessageColor
    {
        get => (Color)GetValue(ErrorMessageColorProperty);
        set => SetValue(ErrorMessageColorProperty, value);
    }
}
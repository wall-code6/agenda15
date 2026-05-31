using CadastroEventosMaui.Models;

namespace CadastroEventosMaui.Pages;

public partial class ResumoEventoPage : ContentPage
{
    public ResumoEventoPage(Evento evento)
    {
        InitializeComponent();
        BindingContext = evento;
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}

using CadastroEventosMaui.Models;

namespace CadastroEventosMaui.Pages;

public partial class CadastroEventoPage : ContentPage
{
    private readonly Evento evento;

    public CadastroEventoPage()
    {
        InitializeComponent();
        evento = new Evento();
        BindingContext = evento;
    }

    private async void OnFinalizarCadastroClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(evento.NomeEvento))
        {
            await DisplayAlert("Atenção", "Informe o nome do evento.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(evento.LocalEvento))
        {
            await DisplayAlert("Atenção", "Informe o local do evento.", "OK");
            return;
        }

        if (evento.DataTermino.Date < evento.DataInicio.Date)
        {
            await DisplayAlert("Atenção", "A data de término não pode ser anterior à data de início.", "OK");
            return;
        }

        if (evento.NumeroParticipantes <= 0)
        {
            await DisplayAlert("Atenção", "Informe um número válido de participantes.", "OK");
            return;
        }

        if (evento.CustoPorParticipante < 0)
        {
            await DisplayAlert("Atenção", "O custo por participante não pode ser negativo.", "OK");
            return;
        }

        await Navigation.PushAsync(new ResumoEventoPage(evento));
    }
}

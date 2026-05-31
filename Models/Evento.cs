using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CadastroEventosMaui.Models;

public class Evento : INotifyPropertyChanged
{
    private string nomeEvento = string.Empty;
    private DateTime dataInicio = DateTime.Today;
    private DateTime dataTermino = DateTime.Today;
    private int numeroParticipantes;
    private string localEvento = string.Empty;
    private decimal custoPorParticipante;

    public string NomeEvento
    {
        get => nomeEvento;
        set
        {
            nomeEvento = value;
            OnPropertyChanged();
        }
    }

    public DateTime DataInicio
    {
        get => dataInicio;
        set
        {
            dataInicio = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Duracao));
            OnPropertyChanged(nameof(DuracaoEmDias));
            OnPropertyChanged(nameof(TextoDuracao));
        }
    }

    public DateTime DataTermino
    {
        get => dataTermino;
        set
        {
            dataTermino = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Duracao));
            OnPropertyChanged(nameof(DuracaoEmDias));
            OnPropertyChanged(nameof(TextoDuracao));
        }
    }

    public int NumeroParticipantes
    {
        get => numeroParticipantes;
        set
        {
            numeroParticipantes = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CustoTotal));
        }
    }

    public string LocalEvento
    {
        get => localEvento;
        set
        {
            localEvento = value;
            OnPropertyChanged();
        }
    }

    public decimal CustoPorParticipante
    {
        get => custoPorParticipante;
        set
        {
            custoPorParticipante = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CustoTotal));
        }
    }

    public TimeSpan Duracao
    {
        get
        {
            if (DataTermino.Date < DataInicio.Date)
                return TimeSpan.Zero;

            return DataTermino.Date - DataInicio.Date;
        }
    }

    public int DuracaoEmDias
    {
        get
        {
            if (DataTermino.Date < DataInicio.Date)
                return 0;

            return Duracao.Days + 1;
        }
    }

    public string TextoDuracao
    {
        get
        {
            if (DataTermino.Date < DataInicio.Date)
                return "Data de término inválida";

            return $"{DuracaoEmDias} dia(s)";
        }
    }

    public decimal CustoTotal => NumeroParticipantes * CustoPorParticipante;

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

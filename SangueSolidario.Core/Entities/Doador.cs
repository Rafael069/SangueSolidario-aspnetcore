using SangueSolidario.Core.Entities;
using SangueSolidario.Core.Enums;
using System;
using System.Collections.Generic;

public class Doador /*: BaseEntity*/
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Genero { get; set; }
    public double Peso { get; set; }
    public string TipoSanguineo { get; set; }
    public string FatorRh { get; set; }
    public DoadorStatusEnum Status { get;  set; }
    public Endereco Endereco { get; set; }
    public List<Doacao> Doacoes { get; set; } = new List<Doacao>();

    // Construtor sem parâmetros (padrão)
    public Doador() { }

    public Doador(int id,string nomeCompleto, string email, DateTime dataNascimento, string genero, double peso, string tipoSanguineo, string fatorRh/*, DoadorStatusEnum status/* Endereco endereco*/)
    {
        Id = id;
        NomeCompleto = nomeCompleto;
        Email = email;
        DataNascimento = dataNascimento;
        Genero = genero;
        Peso = peso;
        TipoSanguineo = tipoSanguineo;
        FatorRh = fatorRh;
        Status = DoadorStatusEnum.Ativo;
        //Endereco = endereco;
    }


    public void DeleteDoador()
    {
        if (Status == DoadorStatusEnum.Ativo)
        {
            Status = DoadorStatusEnum.Removido;
        }
    }

    public void Update(string nomeCompleto, string email, DateTime dataNascimento, string genero, double peso, string tipoSanguineo, string fatorRh/*, DoadorStatusEnum status*/)
    {
        NomeCompleto = nomeCompleto;
        Email= email;
        DataNascimento= dataNascimento;
        Genero = genero;
        Peso = peso;
        TipoSanguineo= tipoSanguineo;
        FatorRh = fatorRh;
        //Status = status;
    }

}

using SangueSolidario.Core.Entities;
using SangueSolidario.Core.Enums;
using System;
using System.Collections.Generic;

public class Doador : BaseEntity
{
    
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Genero { get; set; }
    public double Peso { get; set; }
    public string TipoSanguineo { get; set; }
    public string FatorRh { get; set; }
    public DoadorStatusEnum Status { get;  set; }
    public int IdEndereco { get; set; }
    public int IdDoacao { get; set; }
    public Endereco Endereco { get; set; }
    public List<Doacao> Doacoes { get; set; } = new List<Doacao>();

    // Construtor sem parâmetros (padrão)
    public Doador() { }

    public Doador(string nomeCompleto, string email, DateTime dataNascimento, string genero, double peso, string tipoSanguineo, string fatorRh/*, int idEndereco,int IdDoacao/*,int idEndereco, int idDoacao/*, DoadorStatusEnum status/* Endereco endereco*/)
    {
        NomeCompleto = nomeCompleto;
        Email = email;
        DataNascimento = dataNascimento;
        Genero = genero;
        Peso = peso;
        TipoSanguineo = tipoSanguineo;
        FatorRh = fatorRh;
        Status = DoadorStatusEnum.Ativo;
        //IdEndereco = idEndereco;
        //Doacoes= new List<Doacao>();
        //this.Endereco = endereco;
        //IdEndereco = idEndereco;
        //IdDoacao = idDoacao;
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

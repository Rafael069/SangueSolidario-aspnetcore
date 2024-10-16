using SangueSolidario.Core.Entities;
using System;
using System.Collections.Generic;

public class Doador
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Genero { get; set; }
    public double Peso { get; set; }
    public string TipoSanguineo { get; set; }
    public string FatorRh { get; set; }
    public Endereco Endereco { get; set; }
    public List<Doacao> Doacoes { get; set; } = new List<Doacao>();

    /
    public Doador(int id, string nomeCompleto, string email, DateTime dataNascimento, string genero, double peso, string tipoSanguineo, string fatorRh, Endereco endereco)
    {
        Id = id;
        NomeCompleto = nomeCompleto;
        Email = email;
        DataNascimento = dataNascimento;
        Genero = genero;
        Peso = peso;
        TipoSanguineo = tipoSanguineo;
        FatorRh = fatorRh;
        Endereco = endereco;
    }




}

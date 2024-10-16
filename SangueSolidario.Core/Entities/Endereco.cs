using SangueSolidario.Core.Entities;
using System;
using System.Collections.Generic;


public class Endereco
{
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string CEP { get; set; }
    public int DoadorId { get; set; }
    public Doador Doador { get; set; }

    // Construtor
    public Endereco(int id, string logradouro, string cidade, string estado, string cep, int doadorId)
    {
        Id = id;
        Logradouro = logradouro;
        Cidade = cidade;
        Estado = estado;
        CEP = cep;
        DoadorId = doadorId;
    }



}

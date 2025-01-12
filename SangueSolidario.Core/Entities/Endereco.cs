using SangueSolidario.Core.Entities;
using SangueSolidario.Core.Enums;
using System;
using System.Collections.Generic;


public class Endereco : BaseEntity
{


    // Construtor

    public Endereco() { }

    public Endereco(string logradouro, string cidade, string estado, string cep, int id_doador/*, EnderecoStatusEnum status*/)
    {

        Logradouro = logradouro;
        Cidade = cidade;
        Estado = estado;
        CEP = cep;
        IdDoador = id_doador;
        Status = EnderecoStatusEnum.Ativo;
    }


    public string Logradouro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string CEP { get; set; }
    public int IdDoador { get; set; }
    public Doador? Doador { get; set; }
    public EnderecoStatusEnum Status { get; set; }




    public void DeleteEndereco()
    {
        if (Status == EnderecoStatusEnum.Ativo)
        {
            Status = EnderecoStatusEnum.Removido;
        }
    }

    public void Update(string logradouro, string cidade, string estado, string cep)
    {
        Logradouro = logradouro;
        Cidade = cidade;
        Estado = estado;
        CEP = cep;
    }


}

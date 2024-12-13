using SangueSolidario.Core.Entities;
using SangueSolidario.Core.Enums;
using System;
using System.Collections.Generic;


public class Endereco /*: BaseEntity*/
{


    // Construtor

    public Endereco() { }

    public Endereco(int id,string logradouro, string cidade, string estado, string cep, int doadorId/*, EnderecoStatusEnum status*/)
    {
        Id = id;
        Logradouro = logradouro;
        Cidade = cidade;
        Estado = estado;
        CEP = cep;
        DoadorId = doadorId;
        Status = EnderecoStatusEnum.Ativo;
    }

    public int Id { get; set; }
    public string Logradouro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string CEP { get; set; }
    public int DoadorId { get; set; }
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

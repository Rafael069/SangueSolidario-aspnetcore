using FluentValidation;
using SangueSolidario.Application.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Validators
{
    public class NewDoadorInputModelValidator : AbstractValidator<NewDoadorInputModel>
    {
        public NewDoadorInputModelValidator()
        {
            RuleFor(x => x.Email)
                //

                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail informado não é válido.");
                //.MustAsync(async (email, cancellationToken) => await IsEmailUnique(email));
                //.WithMessage("O e-mail já está cadastrado.");

           
        }

        // Exemplo de uma validação assíncrona para verificar se o e-mail já está cadastrado
        //private async Task<bool> IsEmailUnique(string email)
        //{
        //    // Aqui você pode chamar seu serviço ou repositório para verificar se o e-mail já existe
        //    //return await _doadorRepository.EmailDisponivelAsync(email);

        //    return await Doadores.EmailDisponivelAsync(email);
        //}
    }
}

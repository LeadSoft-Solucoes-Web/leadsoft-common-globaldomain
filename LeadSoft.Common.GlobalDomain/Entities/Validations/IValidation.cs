using LeadSoft.Common.Library.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace LeadSoft.Common.GlobalDomain.Entities.Validations
{
    /// <summary>
    /// Define um contrato para validação de objetos.
    /// </summary>
    public interface IValidation
    {
        /// <summary>
        /// Realiza a validação do objeto atual e retorna os próprio objeto caso esteja válido.
        /// </summary>
        /// <remarks>
        /// O método utiliza o <see cref="Validator.TryValidateObject"/> para verificar se o objeto atende às regras de validação definidas pelas anotações de dados. 
        /// Se a validação for bem-sucedida, a lista de erros é esvaziada. Caso contrário, ela é preenchida com os erros de validação e é lançada uma Bad Request App Exception.
        /// </remarks>
        /// <returns>
        /// Próprio objeto, caso seja válido.
        /// </returns>
        /// <example>
        /// object obj = new().Validate();
        /// </example>
        /// <exception cref="BadRequestAppException">Erros de validação nas propriedades.</exception>
        dynamic Validate();

        /// <summary>
        /// Realiza a validação do objeto atual e retorna os resultados da validação.
        /// </summary>
        /// <param name="oValidationResults">Uma lista de <see cref="ValidationResult"/> que será preenchida com os resultados da validação.</param>
        /// <returns>
        /// Retorna <see langword="true"/> se o objeto for válido, ou <see langword="false"/> se houver erros de validação.
        /// </returns>
        /// <example>
        ///  if (object.IsValid(out var errors))
        ///     return object;
        ///  else
        ///     throw new BadRequestAppExeption(errors);
        /// </example>
        bool IsValid(out IList<ValidationResult> oValidationResults);
    }
}
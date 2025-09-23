using LeadSoft.Common.Library.Exceptions;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadSoft.Common.GlobalDomain.Entities.Validations
{
    /// <summary>
    /// Classe abstrata base que implementa o comportamento de validação para objetos. 
    /// Esta classe implementa também a interface <see cref="IValidation"/> para fornecer um mecanismo padrão de validação.
    /// </summary>
    public abstract class AsValid : IValidation
    {
        /// <summary>
        /// Represents a collection of validation results for an operation or object.
        /// </summary>
        /// <remarks>
        /// This property holds the results of validation checks, where each result provides
        /// details about  a specific validation error or success. If no validation has been performed or no results are
        /// available, the value will be <see langword="null"/>.
        /// </remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue(null)]
        [NotMapped]
        public IList<Validation>? ValidationResults { get; private set; } = null;

        /// <summary>
        /// Gets a value indicating whether the current state is valid.
        /// </summary>
        public bool IsInvalid { get => ValidationResults is not null && ValidationResults.Count > 0; }

        /// <summary>
        /// Realiza a validação do objeto atual e retorna os próprio objeto com suas devidas validações.
        /// </summary>
        /// <remarks>
        /// O método utiliza o <see cref="Validator.TryValidateObject"/> para verificar se o objeto atende às regras de validação definidas pelas anotações de dados. 
        /// Se a validação for bem-sucedida, a lista de erros é esvaziada. Caso contrário, ela é preenchida com os erros de validação e o objeto é retornado, sem exceptions.
        /// </remarks>
        /// <returns>
        /// Próprio objeto, caso seja válido.
        /// </returns>
        /// <example>
        /// object obj = new().Validate();
        /// </example>
        public dynamic Validate()
        {
            ValidationResults = [];

            ValidationContext context = new(this);

            IList<ValidationResult> validationResults = [];

            if (Validator.TryValidateObject(this, context, validationResults, true))
            {
                ValidationResults.Clear();
                ValidationResults = null;
            }
            else
                ValidationResults = Validation.From(validationResults);

            return this;
        }

        /// <summary>
        /// Realiza a validação restritiva do objeto atual e retorna os próprio objeto apenas caso esteja válido.
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
        public dynamic StrictValidate()
        {
            ValidationResults = [];

            ValidationContext context = new(this);

            IList<ValidationResult> validationResults = [];

            if (Validator.TryValidateObject(this, context, validationResults, true))
            {
                ValidationResults.Clear();
                ValidationResults = null;
                return this;
            }
            else
                throw new BadRequestAppException(validationResults);
        }

        /// <summary>
        /// Realiza a validação do objeto atual utilizando as anotações de dados aplicadas em suas propriedades.
        /// </summary>
        /// <param name="oValidationResults">Lista que será preenchida com os resultados da validação, caso existam erros.</param>
        /// <returns>
        /// Retorna <see langword="true"/> se a validação for bem-sucedida, ou <see langword="false"/> se houver erros de validação.
        /// </returns>
        /// <remarks>
        /// O método utiliza o <see cref="Validator.TryValidateObject"/> para verificar se o objeto atende às regras de validação definidas pelas anotações de dados. 
        /// Se a validação for bem-sucedida, a lista <paramref name="oValidationResults"/> é esvaziada. Caso contrário, ela é preenchida com os erros de validação.
        /// </remarks>
        /// <example>
        ///  if (object.IsValid(out var errors))
        ///     return object;
        ///  else
        ///     throw new BadRequestAppExeption(errors);
        /// </example>
        public bool IsValid(out IList<ValidationResult> oValidationResults)
        {
            ValidationResults = [];
            oValidationResults = [];

            ValidationContext context = new(this);

            IList<ValidationResult> validationResults = [];

            if (Validator.TryValidateObject(this, context, oValidationResults, true))
            {
                oValidationResults.Clear();
                ValidationResults.Clear();
                ValidationResults = null;
                return true;
            }
            else
            {
                ValidationResults = Validation.From(oValidationResults);
                return false;
            }
        }
    }
}

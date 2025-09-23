using System.ComponentModel.DataAnnotations;

namespace LeadSoft.Common.GlobalDomain.Entities.Validations
{
    /// <summary>
    /// Representa uma versão simplificada da classe <see cref="ValidationResult"/> do DataAnnotations, 
    /// utilizada para resultados de validação de objetos ou propriedades.
    /// </summary>
    /// <remarks>
    /// Esta classe é especialmente útil quando se deseja uma versão mais enxuta e leve do ValidationResult original, 
    /// mantendo apenas as informações essenciais como nomes dos membros e mensagens de erro.
    /// </remarks>
    public class Validation
    {
        /// <summary>
        /// Obtém a coleção dos nomes dos membros (propriedades ou campos) afetados pelo resultado da validação.
        /// </summary>
        /// <remarks>
        /// A coleção retornada pode estar vazia, mas nunca será nula.
        /// </remarks>
        /// <example>
        /// Exemplo de uso:
        /// <code>
        /// var resultado = new ValidationResult("Nome obrigatório", new[] {"Nome"});
        /// Validation validacao = resultado;
        /// foreach(var nomeMembro in validacao.MemberNames)
        /// {
        ///     Console.WriteLine(nomeMembro); // imprime "Nome"
        /// }
        /// </code>
        /// </example>
        public IEnumerable<string> MemberNames { get; private set; } = [];

        /// <summary>
        /// Obtém a mensagem de erro associada a este resultado de validação.
        /// </summary>
        /// <remarks>
        /// Pode retornar uma string nula ou vazia caso não exista uma mensagem específica.
        /// </remarks>
        /// <example>
        /// Exemplo de uso:
        /// <code>
        /// var validacao = new ValidationResult("Idade deve ser maior que 18");
        /// Validation resultado = validacao;
        /// Console.WriteLine(resultado.ErrorMessage); // imprime "Idade deve ser maior que 18"
        /// </code>
        /// </example>
        public string? ErrorMessage { get; private set; } = string.Empty;

        /// <summary>
        /// Permite a conversão implícita de um objeto ValidationResult para Validation.
        /// </summary>
        /// <param name="validationResult">Objeto ValidationResult original.</param>
        /// <remarks>
        /// Retorna nulo caso o parâmetro fornecido seja nulo.
        /// </remarks>
        public static implicit operator Validation(ValidationResult validationResult)
        {
            if (validationResult is null)
                return null;

            return new()
            {
                MemberNames = validationResult.MemberNames,
                ErrorMessage = validationResult.ErrorMessage,
            };
        }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Validation"/>.
        /// </summary>
        public Validation()
        {
        }

        /// <summary>
        /// Converte uma lista de objetos ValidationResult em uma lista de objetos Validation.
        /// </summary>
        /// <param name="validationResults">Lista contendo os objetos ValidationResult a serem convertidos.</param>
        /// <returns>Uma lista contendo objetos Validation convertidos.</returns>
        /// <example>
        /// Exemplo de conversão de uma lista:
        /// <code>
        /// IList&lt;ValidationResult&gt; resultadosOriginais = [
        ///     new ValidationResult("Campo obrigatório", new[] { "Nome" }),
        ///     new ValidationResult("Formato inválido", new[] { "Email" })
        /// ];
        /// IList&lt;Validation&gt; validacoes = Validation.From(resultadosOriginais);
        /// foreach(var validacao in validacoes)
        /// {
        ///     Console.WriteLine(validacao.ErrorMessage);
        /// }
        /// </code>
        /// </example>
        public static IList<Validation> From(IList<ValidationResult> validationResults)
            => [.. validationResults.Select(vr => (Validation)vr)];

        /// <summary>
        /// Converte um objeto ValidationResult individual em Validation.
        /// </summary>
        /// <param name="validationResults">O objeto ValidationResult que será convertido.</param>
        /// <returns>Um novo objeto Validation convertido.</returns>
        /// <example>
        /// Exemplo de conversão de um único objeto:
        /// <code>
        /// var resultadoOriginal = new ValidationResult("Senha obrigatória", new[] {"Senha"});
        /// Validation validacao = Validation.ToValidation(resultadoOriginal);
        /// Console.WriteLine(validacao.ErrorMessage); // imprime "Senha obrigatória"
        /// </code>
        /// </example>
        public static Validation ToValidation(ValidationResult validationResults)
            => validationResults;
    }

}

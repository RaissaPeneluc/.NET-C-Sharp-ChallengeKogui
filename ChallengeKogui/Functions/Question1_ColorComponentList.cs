/* Questão 1:
 * Essa classe tem a função de instanciar a lista de 
 * itens com os nomes das cores e os seus componentes
 * associados. */

using ChallengeKogui.Models;

namespace ChallengeKogui.Functions
{
    // Essa classe é responsável por criar uma lista de cores e seus componentes associados.
    public class Question1_ColorComponentList
    {
        // Função estática que retorna uma lista de objetos Question1_ColorKey.
        public static List<Question1_ColorKey> GetColorComponentList()
        {
            // Cria e retorna uma nova lista de Question1_ColorKey, que contém cores e componentes.
            return new List<Question1_ColorKey>
            {

                new Question1_ColorKey("", "MagentaFuchsia", "(vazio)"),
                new Question1_ColorKey("", "White", "para"),
                new Question1_ColorKey("", "Blue", "Pares"),
                new Question1_ColorKey("", "Green", "alterar"),
                new Question1_ColorKey("", "Black", "#"),
                new Question1_ColorKey("", "WebOrange", "e"),
                new Question1_ColorKey("", "Yellow", "impares"),
                new Question1_ColorKey("", "Red", "' '"),
                new Question1_ColorKey("", "Coconut", "Busca"),
                new Question1_ColorKey("", "CyanAqua", "primos"),
            };
        }
    }
}

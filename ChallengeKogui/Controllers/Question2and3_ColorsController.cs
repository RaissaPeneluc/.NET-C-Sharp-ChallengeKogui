/* Questão 2 (Generate-Phrase) e 3 (Generate-Figure):
 * Esta classe é um controlador para gerenciar os itens,
 * permitindo obter os nomes das cores usando a The Color
 * API e também gerando a imagem da matrizno console baseada
 * na dica encontrada. */

using ChallengeKogui.Functions;
using ChallengeKogui.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChallengeKogui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Question2and3_ColorsController : ControllerBase
    {
        // Esse são os valores HEX fornecidos pelo desafio que serão utilizados para buscar os nomes das cores.
        private static readonly string[] hexCodes = { "#0000FF", "#00FF00", "#FFFFFF", "#FF0000", "#FFA500", "#FFFF00", "#000000" };

        // Instância do gerador de figuras.
        private readonly Question3_MatrixFigureGenerator _figureGenerator;

        // Construtor do controlador que inicializa o gerador de figuras.
        public Question2and3_ColorsController()
        {
            _figureGenerator = new Question3_MatrixFigureGenerator();
        }

        // Endpoint com a função de obter os nomes das cores via API e comparar com a lista.
        [HttpGet("Generate-Phrase")]
        public async Task<ActionResult> GeneratePhraseFromColors()
        {
            // Obtém a lista de cores e componentes do Models.
            List<Question1_ColorKey> items = Question1_ColorComponentList.GetColorComponentList();
            List<string> phraseComponents = new List<string>(); // Lista para armazenar os componentes da frase.

            // Itera pelos códigos HEX.
            for (int i = 0; i < hexCodes.Length; i++)
            {
                string colorName = await GetColorNameAsync(hexCodes[i]); // Obtém o nome da cor usando o código HEX.

                var matchedItem = items.Find(item => item.Color.ToLower() == colorName.ToLower()); // Encontra o componente correspondente na lista de itens.

                // Vai adicionar o componente à frase, se ele tiver um valor correspondente na lista.
                if (matchedItem != null)
                {
                    phraseComponents.Add(matchedItem.Component); 
                }
            }

            // Forma a frase completa com os componentes encontrados.
            string resultPhrase = string.Join(" ", phraseComponents);

            // Usando o método Ok para retornar o resultado.
            return Ok(new { Phrase = resultPhrase });
        }

        // Método com a função de auxiliar para buscar o nome da cor na API The Color API.
        private async Task<string> GetColorNameAsync(string hexCode)
        {
            // Cria uma nova instância de HttpClient.   
            using (HttpClient client = new HttpClient())
            {
                // Requisição para obter o nome da cor a partir do código HEX.
                var response = await client.GetStringAsync($"https://www.thecolorapi.com/id?hex={hexCode.Trim('#')}");
                dynamic jsonResponse = JsonConvert.DeserializeObject(response); // Desserializa a resposta JSON.
                return jsonResponse.name.value; // Retorna o nome da cor.
            }
        }

        // Endpoint com função específico de gerar a figura a partir da matriz.
        [HttpGet("Generate-Figure")]
        public ActionResult GenerateFigure()
        {
            string figure = _figureGenerator.GenerateFigure(); // Gera a figura usando o gerador.
            return Ok(figure); // Retorna a figura gerada como resultado.
        }
    }
}

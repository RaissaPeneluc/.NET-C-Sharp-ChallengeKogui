/* Questão 1:
 * Esta classe tem a função de conter as 
 * propriedades do objeto ColorKey (ChaveCor). */

namespace ChallengeKogui.Models
{
    // Clase que contém todas a propriedades do objeto ColorKey..
    public class Question1_ColorKey
    {
        public string HEX { get; set; }
        public string Color { get; set; }
        public string Component { get; set; }

        // Construtor da classe que inicializa as propriedades com os valores fornecidos.
        public Question1_ColorKey(string hex, string color, string component)
        {
            HEX = hex;
            Color = color;
            Component = component;
        }
    }

}

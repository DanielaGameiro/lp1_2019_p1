using System;

namespace WolfAndSheep
{
    /// <summary>
    /// Esta classe contém o método Menu e imprime as regras/instruções do jogo
    /// </summary>
    public class MenuInicial
    {
        /// <summary>
        /// Breve explicação do jogo, como se joga e input para iniciar
        /// </summary>
        public void Menu()
        {
            // Texto exibido no ecrã
            Console.WriteLine("\nEsta' a jogar Wolf And Sheep!\n\n" + "W&S e'" +
            " um PvP de dois jogadores, um dos jogadores controla quatro" + 
            " ovelhas e o outro controla um lobo." +
            " Este jogo e' jogado por turnos num tabuleiro 8x8.\n\n" + 
            "Ao iniciar o jogo, o jogador que controla as ovelhas vai" + 
            " escolher um lado do tabuleiro para as posicionar e em seguida" + 
            " o outro jogador ira' escolher o lado oposto para" +
            " posicionar o seu lobo.\n\n" + "O objetivo das ovelhas e'" + 
            " bloquear o lobo entre as paredes ou entre elas mesmas," + 
            " deixando o lobo no meio, impedindo-o de se mover." + 
            " Entretanto, o objetivo do lobo e' chegar a uma das posicoes" + 
            " originais das ovelhas. Deste modo, quem for o primeiro a" + 
            " cumprir o seu objetivo ganha o jogo e o mesmo acaba!\n\n\n" + 
            " Movimentacao das OVELHAS:\n" + 
            " \n- So' podem andar na diagonal e para a frente;" +
            " \n- Pode mover UMA ovelha para UM quadrado preto vazio" + 
            " por turno.\n\n" + 
            " Movimentacao do LOBO:\n" +
            " \n- E' o primeiro a jogar!" +
            " \n- Pode andar na diagonal em qualquer direcao;" +
            " \n- Pode se mover para UM quadrado preto vazio por turno;\n\n");

            // Input do utilizador para iniciar o jogo
            Console.WriteLine("Pressiona uma tecla + ENTER" +  
            " para comecar a jogar!");
            Console.Read();
        }
    }
}
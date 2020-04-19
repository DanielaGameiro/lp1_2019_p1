using System;

namespace WolfAndSheep
{
    /// <summary>
    /// Esta classe contém o método Main onde vai fazer loop do jogo
    /// </summary>
    class Program

    {
        /// <summary>
        /// Inicializar o jogo
        /// </summary>
        private static void Main()
        {
            // Criar um Menu Inicial e chamar a função Menu
            MenuInicial menuInicial = new MenuInicial();
            menuInicial.Menu();

            // Criar e renderizar um tabuleiro 8x8
            Tabuleiro tabuleiroNovo = new Tabuleiro (8,8);
            Render(tabuleiroNovo);

            Wolf player1 = new Wolf();
            player1.Start(OvelhaDir);

            while(!(player1.Loose() || player2.Loose()))
            {
                player1.Move();
                player2.Move();
            }
        }

        /// <summary>
        /// Renderizar o tabuleiro completo
        /// </summary>
        /// <param name="tabuleiroNovo">Tabuleiro completo</param>
        private static void Render(Tabuleiro tabuleiroNovo)
        {
            // Parte de cima do tabuleiro
            Console.WriteLine("__________________________________________\n" +
            "__________________________________________");

            // Loop da largura do tabuleiro
            for (int x = 0; x < tabuleiroNovo.X; x++)
            {
                // Loop da altura do tabuleiro
                for (int y = 0; y < tabuleiroNovo.Y; y++)
                {
                    // Separadores entre os quadrados do tabuleiro
                    Console.Write("||");

                    // Exibe os espaços vazios e os X's no tabuleiro
                    Console.Write($" {tabuleiroNovo[x, y]} ");
                }
                // Lado direito do tabuleiro
                Console.Write("||\n");
            }
            // Parte de baixo do tabuleiro
            Console.WriteLine("__________________________________________\n" +
            "__________________________________________");
        }
    }
}

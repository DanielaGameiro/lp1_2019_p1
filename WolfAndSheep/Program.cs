﻿using System;

namespace WolfAndSheep
{
    /// <summary>
    /// Esta classe contém o método Main onde vai fazer loop do jogo
    /// </summary>
    class Program

    {
        private static int OvelhaDir;
        private static bool check = false;
        private static int escolhaO;

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

            Console.WriteLine("Onde quer por as ovelhas?\n"
                + "1 = cima , 2 = direita\n"
                + "3 = baixo, 4 = esquerda");
            ///Pede ao jogador a posição onde quer as ovelhas e espera input
            /// válido
            while (!int.TryParse(Console.ReadLine(), out OvelhaDir) ||
                OvelhaDir < 1 || OvelhaDir > 4);

            ///Põe as ovelhas no tabuleiro
            Ovelhas[] ovelhas = PoeOvelhas(tabuleiroNovo, OvelhaDir);

            /// <summary>
            /// Cria o objeto da classe Wolf que vai representar o jogador que
            /// controla o lobo e a sua situação
            /// </summary>
            Wolf player1 = new Wolf();

            /// Pede ao jogador a posição inicial em que deseja colocar o lobo
            /// e se válida coloca-o. Faz uso da posição inicial das ovelhas
            player1.Start(OvelhaDir, tabuleiroNovo);
            Render(tabuleiroNovo);

            /// <summary>
            /// Ciclo de jogo até que um jogador perca
            /// </summary>
            while(!(player1.Loose(ovelhas) || ovelhas_Loose(OvelhaDir, player1)))
            {
                player1.Move(ovelhas, tabuleiroNovo);
                Render(tabuleiroNovo);
                if (ovelhas_Loose(OvelhaDir, player1)) break;
                check = false;

                ///Loop enquanto uma ovelha não for movida com sucesso
                while(check == false)
                {

                    Console.WriteLine("Player2");
                    Console.WriteLine("Que ovelha queres mexer?\n"
                    + "1 , 2 , 3 , 4");

                    ///Espera o input da ovelha que o jogador que mover até
                    /// válido
                    while (!int.TryParse(Console.ReadLine(), out escolhaO) ||
                    escolhaO < 1 || escolhaO > 4) ;

                    Console.WriteLine("Player2");
                    Console.WriteLine("Para onde queres mexer a ovelha?\n"
                     + "1 - Cima-esquerda  2 - Cima-Direita\n"
                     + "3 - Baixo-esquerda 4 - Baixo-Direira");

                    ///Move a ovelha e diz-nos se foi sucedido ou não
                    check = ovelhas[escolhaO-1].OvelhaM(tabuleiroNovo, OvelhaDir
                    ,escolhaO-1);
                    ///Se a ovelha não for movida com sucesso check vem como
                    ///falso
                    if (check == false){
                        Console.WriteLine("Nao podes mexer a ovelha para ai");
                    }
                }
                Render(tabuleiroNovo);
                if (player1.Loose(ovelhas)) break;
            }
            if (player1.Loose(ovelhas))
            {
                Console.WriteLine("As ovelhas venceram");
            }

            else
            {
                Console.WriteLine("O lobo venceu");
            }
        }

        /// <summary>
        /// Põe as ovelhas no tabuleiro
        /// </summary>
        /// <param name="tabuleiroNovo">Board atual</param>
        /// <param name="OvelhaDir">Posição onde as ovelhas começaram</param>
         private static Ovelhas[] PoeOvelhas(Tabuleiro tabuleiroNovo,
         int OvelhaDir){

            Ovelhas[] ovelhas = new Ovelhas[4];

            ///x = Altura do tabuleiro ou linha
            int x;
            ///y = Largura do tabuleiro ou colunas
            int y;

            ///Atribui um número a ovelha a ser criada
            int i = 0;

            /// Dependendo da posição inicial das ovelhas cria as ovelahs na sua
            /// posição correta
            if (OvelhaDir==1)
            {
                x = 0;
                for (y = 0 ; y < tabuleiroNovo.Y; y++)
                {

                    if (tabuleiroNovo[x, y] == ' ')
                    {

                        ovelhas[i] = new Ovelhas(x, y);

                        i++;
                    }
                }

            }
            else if (OvelhaDir==3){
                x = 7;
                for (y = 0 ; y < tabuleiroNovo.Y; y++)
                {
                    if (tabuleiroNovo[x, y] == ' ')
                    {

                        ovelhas[i] = new Ovelhas(x, y);

                        i++;
                    }

                }
            }
            else if(OvelhaDir==2)
            {
                y = 7;
                for (x = 0 ; x < tabuleiroNovo.X; x++)
                {
                if (tabuleiroNovo[x, y] == ' ')
                {

                    ovelhas[i] = new Ovelhas(x, y);

                    i++;
                }
             }

             }
             else
             {
                y= 0;
                for (x = 0 ; x < tabuleiroNovo.X; x++)
                {
                    if (tabuleiroNovo[x, y] == ' ')
                    {

                        ovelhas[i] = new Ovelhas(x, y);

                        i++;
                    }
                }
             }
            ///Atualiza visualmente o tabuleiro com
            ///o número de cada ovelha no tabuleiro
            tabuleiroNovo[ovelhas[0].OvelhaX, ovelhas[0].OvelhaY] = '1';
            tabuleiroNovo[ovelhas[1].OvelhaX, ovelhas[1].OvelhaY] = '2';
            tabuleiroNovo[ovelhas[2].OvelhaX, ovelhas[2].OvelhaY] = '3';
            tabuleiroNovo[ovelhas[3].OvelhaX, ovelhas[3].OvelhaY] = '4';

            ///Mostra o tabuleiro atual ao jogador
            Render(tabuleiroNovo);

            return ovelhas;
        }

        /// <summary>
        /// Se o lobo chegar a uma das posições iniciais das ovelhas o jogador
        /// que as controla perde
        /// </summary>
        /// <param name="OvelhaDir"></param>
        /// <param name="player1">Objeto que representa o jogador que
        /// controla o lobo e através do qual se obtém a sua posição</param>
        /// <returns>Retorna True se o lobo vencer</returns>
         private static bool ovelhas_Loose(int OvelhaDir, Wolf player1)
        {
            int [] posição = player1.getPos();
            if (OvelhaDir == 1 && posição[1] == 1)
            {
                return true;
            }
            else if (OvelhaDir == 2 && posição[0] == 8)
            {
                return true;
            }
            else if (OvelhaDir == 3 && posição[1] == 8)
            {
                return true;
            }
            else if (OvelhaDir == 4 && posição[0] == 1)
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Renderizar o tabuleiro completo
        /// </summary>
        /// <param name="tabuleiroNovo">Tabuleiro completo</param>
        private static void Render(Tabuleiro tabuleiroNovo)
        {
            // Parte de cima do tabuleiro
            Console.WriteLine("__________________________________________\n" +
            "____1____2____3____4____5____6____7____8__");

            // Loop da largura do tabuleiro
            for (int x = 0; x < tabuleiroNovo.X; x++)
            {
                Console.Write(x + 1);
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

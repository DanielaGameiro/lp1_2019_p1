﻿using System;
using System.Linq;

namespace WolfAndSheep
{
   public class Wolf
    {
        /// <summary>
        /// Declara variaveis
        /// </summary>
        private int[] Pos;
        private int[] next_pos;
        private char[] separador;
        private string[]  snext;
        static bool invalida;

        /// <summary>
        /// Constructor que da valor inicial
        /// </summary>
        public Wolf()
        {
            Pos = new int[2];
            next_pos = new int[2];
            separador =  new[] {' ',',', '.', ':', '/'};
        }

        /// <summary>
        /// Método que pede ao jogador a posição inicial em que deseja colocar
        /// o lobo e se valida coloca-o
        /// </summary>
        /// <param name="O">Posição inicial das ovelhas</param>
        public void Start(int O, Tabuleiro tabuleiroNovo)
        {
            while (true)
            {
                invalida = false;
                Console.WriteLine("Player1 \n" + "Onde deseja comecar o jogo?"
                + " Escrever coordenadas da posicao, por exemplo: 1,2");
                /// Função que verifica se as coordenadas são validas
                Valid_move();

                /// <summary>
                /// Verifica se as coordenadas pertencem aos lugares iniciais
                /// disponíveis no lado oposto ao das ovelhas
                /// </summary>
                if (O == 1 && next_pos[1] == 8 && (next_pos[0] == 1 ||
                next_pos[0] == 3 || next_pos[0] == 5 || next_pos[0] == 7)){}

                else if (O == 2 && next_pos[0] == 1 && (next_pos[1] == 2 ||
                next_pos[1] == 4 || next_pos[1] == 6 || next_pos[1] == 8)){}

                else if (O == 3 && next_pos[1] == 1 && (next_pos[0] == 8 ||
                next_pos[0] == 6 || next_pos[0] == 4 || next_pos[0] == 2)){}

                else if (O == 4 && next_pos[0] == 8 && (next_pos[1] == 1 ||
                next_pos[1] == 3 || next_pos[1] == 5 || next_pos[1] == 7)){}

                /// <summary>
                /// Caso não pertença da mensagem de erro e repete o ciclo
                /// </summary>
                else
                {
                    Console.WriteLine("Posição inva'lida");
                    invalida = true;
                }

                ///Se as coordenadas estiverem corretas guarda-se a posição,
                /// mostra-se-a no tabuleiro e sai-se do método
                if (invalida == false)
                {
                    Pos = next_pos.ToArray();
                    tabuleiroNovo[(Pos[1]-1), (Pos[0]-1)] = 'L';
                    return;
                }
            }
        }

        /// <summary>
        /// Método principal que move o lobo
        /// </summary>
        /// <param name="ovelhas">Objeto da classe Ovelhas que representa o
        /// oponente do lobo e as posições das suas ovelhas</param>
        /// <param name="tabuleiroNovo">Tabuleiro do jogo</param>
        public void Move(Ovelhas[] ovelhas, Tabuleiro tabuleiroNovo)
        {
            ///Ciclo até posição valida
            while(true)
            {

                // Variavel que determina se o ciclo continua
                invalida = false;
                Console.WriteLine("Para onde deseja mover o lobo?");
                //Método que testa se a posição recebida tem formato valido
                //e se não, repete até que tenha
                Valid_move();

                //Testa se a posição esta ao alcance do jogador
                if ((Math.Abs(next_pos[0] - Pos[0]) == 1) &&
                (Math.Abs(next_pos[1] - Pos[1]) == 1))
                {
                    //Se sim testa se a posição ja esta ocupada
                    for (int k = 0; k < 4; k++)
                    {
                        if ((ovelhas[k].OvelhaY == (next_pos[0] - 1)) &&
                        (ovelhas[k].OvelhaX == (next_pos[1] - 1)))
                        {
                            Console.WriteLine("Posicao ocupada");
                            Console.WriteLine("Por favor escreva uma posicao"+
                            " vaga");
                            //Se a posição estiver ocupada a variavel
                            //faz o ciclo repetir
                            invalida = true;
                        }
                    }
                    //Se a posição não estiver ocupada a posição é guardada, o
                    //lobo desloca-se para la e o movimento é terminado
                    if (invalida == false)
                    {
                        Console.WriteLine($"Nova posicao: {next_pos[0]},"+
                        $"{next_pos[1]}");
                        tabuleiroNovo[(Pos[1]-1), (Pos[0]-1)] = ' ';
                        Pos = next_pos.ToArray();
                        tabuleiroNovo[(Pos[1]-1), (Pos[0]-1)] = 'L';
                        return;
                    }
                }
                //Se a posição não estiver ao alcance do jogador
                //da mensagem de erro e o ciclo é repetido
                else
                {
                    Console.WriteLine("Posicao fora de alcance");
                }
            }
        }

        public int[] getPos()
        {
            return Pos;
        }

        public bool Loose(Ovelhas[] ovelhas)
        {
            /// <summary>
            /// Variavel que determina os lugares bloqueados à volta do lobo
            /// </summary>
            int counter = 0;

            /// <summary>
            /// Quando o lobo se encontra numa das extremidades 2 movimentos
            /// tornam-se impossíveis
            /// </summary>
            if (Pos[0] == 1 || Pos[0] == 8) counter += 2;
            if (Pos[1] == 1 || Pos[1] == 8) counter += 2;

            /// <summary>
            /// Exceção para quando o lobo esta num canto do tabuleiro
            /// </summary>
            if (counter == 4) counter = 3;

            // Verifica se existem ovelhas a bloquear o jogador
            for (int k = 0; k < 4; k++)
            {
                if ((Math.Abs(ovelhas[k].OvelhaY - (Pos[0] - 1)) == 1) &&
                (Math.Abs(ovelhas[k].OvelhaX - (Pos[1] - 1)) == 1))
                {
                    counter += 1;
                }
            }

            /// <summary>
            /// O lobo perde
            /// </summary>
            if (counter == 4) return true;
            /// <summary>
            /// O lobo não perde
            /// </summary>
            else return false;
        }
        /// <summary>
        /// Método que testa se a posição recebida tem formato valido
        /// e se não, repete até que tenha
        /// </summary>
        public void Valid_move()
        {
            /// <summary>
            /// Recebe um input e prepara a conversão para coordenadas
            /// </summary>>
            /// <returns>String sem tudo o que atrapalharia na conversão
            /// do input para coordenadas</returns>
            snext = Console.ReadLine().Split(separador,
            StringSplitOptions.RemoveEmptyEntries);

            //Ciclo que repete até o input corresponder a coordenadas validas
            while(true)
            {
                //Se as coordenadas tiverem mais que 2 dimensões, repete ciclo
                if (snext.Length != 2)
                {
                    Console.WriteLine("Por favor escreva 2 coordenadas");
                    Console.WriteLine("Para onde deseja mover o lobo?");
                }

                else
                {
                    //Para cada dimensão das coordenadas, tenta converte-la
                    //num inteiro que pertença as dimensões do tabuleiro
                    for (int i = 0; i < 2; i++)
                    {
                        if (!int.TryParse(snext[i], out next_pos[i]))
                        {
                            Console.WriteLine("Input invalido");
                            Console.WriteLine("Para onde deseja mover o lobo?");
                            break;
                        }
                        else if(next_pos[i] < 1 || next_pos[i] > 8)
                        {
                            Console.WriteLine("Posicao invalida");
                            Console.WriteLine("Por favor escolha uma posicao"+
                            "dentro do tabuleiro");
                            break;
                        }
                        else
                        {
                            //Se tiver sucesso nas 2 dimensões termina o ciclo
                            if (i == 1) return;
                        }
                    }
                }
                //Se não tiver sucesso pede um novo input e repete o ciclo
                snext = Console.ReadLine().Split(separador,
                StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}

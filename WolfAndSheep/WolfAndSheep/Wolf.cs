using System;
using System.Linq;

namespace WolfAndSheep
{
   public class Wolf
    {
        private int[] Pos;
        private int[] next_pos;
        private char[] separador;
        private string[]  snext;

        public Wolf()
        {
            Pos = new int[2];
            next_pos = new int[2];
            separador =  new[] {' ',',', '.', ':', '/'};
        }


        public static void Start(int O)
        {
            while (true)
            {
                Console.WriteLine("Player1 \n" + "Onde deseja começar o jogo?");
                Valid_move();

                if (O == 1 && next_pos[1] == 8 && (next_pos[0] == 1 ||
                next_pos[0] == 3 || next_pos[0] == 5 || next_pos[0] == 7)){}

                else if (O == 2 && next_pos[0] == 1 && (next_pos[1] == 2 ||
                next_pos[1] == 4 || next_pos[1] == 6 || next_pos[1] == 8)){}

                else if (O == 3 && next_pos[1] == 1 && (next_pos[0] == 8 ||
                next_pos[0] == 6 || next_pos[0] == 4 || next_pos[0] == 2)){}

                else if (O == 4 && next_pos[0] == 8 && (next_pos[1] == 1 ||
                next_pos[1] == 3 || next_pos[1] == 5 || next_pos[1] == 7)){}

                else
                {
                    Console.WriteLine("Posição inválida");
                }

                Pos = next_pos.ToArray();
                tabuleiroNovo[(Pos[0]-1), (Pos[1]-1)] = 'L';
                return;
            }
        }

        public static void Move(Ovelhas ovelhas, Tabuleiro tabuleiroNovo)
        {
            while(true)
            {
                bool ocupada = false;
                Console.WriteLine("Para onde deseja mover o lobo?");
                Valid_move();

                if (next_pos[0] - Pos[0] == 1 &&
                next_pos[1] - Pos[1] == 1)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (ovelhas[k].OvelhaX == next_pos[0] &&
                        ovelhas[k].OvelhaY == next_pos[1])
                        {
                            Console.WriteLine("Posição ocupada");
                            ocupada = true;
                        }
                    }

                    if (ocupada == false)
                    {
                        Console.WriteLine($"Nova posição: {next_pos[0]},"+
                        $"{next_pos[1]}");
                        tabuleiroNovo[(Pos[0]-1), (Pos[1]-1)] = 'X';
                        Pos = next_pos.ToArray();
                        tabuleiroNovo[(Pos[0]-1), (Pos[1]-1)] = 'L';
                        return;
                    }
                }

                else
                {
                    Console.WriteLine("Posição fora de alcance");
                }
            }
        }

        public static void Loose(Ovelhas ovelhas)
        {
            /// <summary>
            /// Variável que determina os lugares bloqueados à volta do lobo
            /// </summary>
            int counter = 0;

            /// <summary>
            /// Quando o lobo se encontra numa das extremidades 2 movimentos
            /// tornam-se impossíveis
            /// </summary>
            if (Pos[0] == 1 || Pos[0] == 8) counter += 2;
            if (Pos[1] == 1 || Pos[1] == 8) counter += 2;

            /// <summary>
            /// Exceção para quando o lobo está num canto do tabuleiro
            /// </summary>
            if (counter == 4) counter = 3;

            for (int k = 0; k < 4; k++)
            {
                if (Abs(ovelhas[k].OvelhaX - (Pos[0] - 1)) == 1 &&
                Abs(ovelhas[k].OvelhaY - (Pos[1] - 1)) == 1)
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
        public static void Valid_move()
        {
            snext = Console.ReadLine().Split(separador,
            StringSplitOptions.RemoveEmptyEntries);

            while(true)
            {
                if (snext.Length > 2)
                {
                    Console.WriteLine("Demasiadas indicações");
                    Console.WriteLine("Para onde deseja mover o lobo?");
                }

                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (!int.TryParse(snext[i], out next_pos[i]))
                        {
                            Console.WriteLine("Input inválido");
                            Console.WriteLine("Para onde deseja mover o lobo?");
                            break;
                        }
                        else if(next_pos[i] < 1 || next_pos[i] > 8)
                        {
                            Console.WriteLine("Posição inválida");
                            Console.WriteLine("Por favor escolha uma posição"+
                            "dentro do tabuleiro");
                            break;
                        }
                        else
                        {
                            if (i == 1) return;
                        }
                    }
                }
                snext = Console.ReadLine().Split(separador,
                StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}

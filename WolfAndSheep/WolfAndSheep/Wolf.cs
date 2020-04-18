using System;

namespace WolfAndSheep
{
   public class Wolf
    {
        // Declarar variáveis
        private int[] next_pos;
        string[] separador;
        string[] snext;


        // Wolf pos
        public Wolf(int s)
        {
            Pos = Start();
        }

        public int[] Pos {get;}

        public static Array[] Start()
        {
            Console.WriteLine("Player1 \n" + "Onde deseja começar o jogo?");
            
        }

        public static void Move()
        {
            Console.WriteLine("Para onde deseja mover o lobo?");
            next_pos = Valid_move()

            if (next_pos[0] - Wolf.pos[0] == 1 &&
            next_pos[1] - Wolf.pos[1] == 1)
            {
                if (|Sheep.pos[n,0] - Wolf.pos[n,0]| == 1 &&
                |Sheep.pos[n,1] - Wolf.pos[n,1]| == 1)
                {
                    wolf.cant = [Sheep.pos[n,0], Sheep.pos[n,1]]
                }
            }
            else{
                Console.WriteLine("Posição Inválida");
            }


            // Largura
            for (int x = 0; x < DimX; x++)
            {
                // Altura
                for (int y = 0; y < DimY; y++)
                {
                    // Verificar se a posição está num quadrado "não-jogável"
                    if (((x + y)
                    {
                        if (sheep[x,y] == true)
                        {
                            tabuleiro[x, y] = 'S';
                        }
                        else if (Wolf[x,y] == true)
                        {
                            tabuleiro[x, y] = 'W';
                        }
                        else
                        {
                            // Se sim, meter um X nesse quadrado
                            Wolf[x, y] = false;
                        }

                    }

                    // Se a posição está num quadrado "jogável", deixar esse
                    // espaço vazio
                    else
                    {
                        tabuleiro[x, y] = ' ';
                    }
                }
            }
        }
        public static Array[] Valid_move()
        {
            separador =  {",",".", ":", "/"};
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
                    for(i = 0; i < 2; i++)
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
                            if (i == 1) return next_pos;
                        }
                    }
                }
                snext = Console.ReadLine().Split(separador,
                StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}

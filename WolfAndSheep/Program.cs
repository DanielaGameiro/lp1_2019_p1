using System;

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

            while (!int.TryParse(Console.ReadLine(), out OvelhaDir) ||
                OvelhaDir < 1 || OvelhaDir > 4);

            Ovelhas[] ovelhas = PoeOvelhas(tabuleiroNovo, OvelhaDir);

            while(true){
                check = false;

                Console.WriteLine("Que ovelha queres mexer?\n"
                    + "1 , 2 , 3 , 4");



                while (!int.TryParse(Console.ReadLine(), out escolhaO) ||
                    escolhaO < 1 || escolhaO > 4) ;

                while(check == false)
                {
                    
                    Console.WriteLine("Para onde queres mexer a ovelha?\n"
                     + "1 - Cima-esquerda  2 - Cima-Direita\n"
                     + "3 - Baixo-esquerda 4 - Baixo-Direira");

                    check = ovelhas[escolhaO-1].OvelhaM(tabuleiroNovo, OvelhaDir
                    ,escolhaO-1);
                    if (check == false){
                        Console.WriteLine("Nao podes mexer a ovelha para ai");

                    } 
                }



                Render(tabuleiroNovo);
            }  
        }

        private static Ovelhas[] PoeOvelhas(Tabuleiro tabuleiroNovo,
         int OvelhaDir){

            Ovelhas[] ovelhas = new Ovelhas[4];

            int x = OvelhaDir == 1 || OvelhaDir == 4 ? 0 :
                tabuleiroNovo.Y - 1;
            
            int i = 0;

            for (int y = 0 ; y < tabuleiroNovo.Y; y++)
            {

                if(OvelhaDir == 1 || OvelhaDir == 3)
                {

                    if (tabuleiroNovo[x, y] == ' ')
                    {
                        ovelhas[i] = new Ovelhas(x, y);

                        i++;
                    }
                }
                else {

                    if (tabuleiroNovo[y, x] == ' ')
                    {
                        ovelhas[i] = new Ovelhas(y, x);

                        i++;

                    }
                }
            }
            
            
                tabuleiroNovo[ovelhas[0].OvelhaX, ovelhas[0].OvelhaY] = '1';
                tabuleiroNovo[ovelhas[1].OvelhaX, ovelhas[1].OvelhaY] = '2';
                tabuleiroNovo[ovelhas[2].OvelhaX, ovelhas[2].OvelhaY] = '3';
                tabuleiroNovo[ovelhas[3].OvelhaX, ovelhas[3].OvelhaY] = '4';
            
            Render(tabuleiroNovo);
            return ovelhas;
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

using System;
namespace WolfAndSheep
{
    /// <summary>
    ///  Guarda a posiçao das ovelhas e trata do seu movimento no tabuleiro
    /// </summary>
    public class Ovelhas
    {

        /// int que guarda o movimento decidido pelo jogador
        int escolha;
        
        public int OvelhaX { get; set; }

        public int OvelhaY { get; set; }

        /// <summary>
        /// Construtor de ovelhas
        /// </summary>
        /// <param name="linha">Pos Y da ovelha</param>
        /// <param name="coluna">Pos X da ovelha</param>
        public Ovelhas(int linha = 0, int coluna = 0)
        {
          
            OvelhaX = linha;

          
            OvelhaY = coluna;
        }
        /// <summary>
        /// Funçao que  trata do movimento das ovelhas
        /// </summary>
        /// <param name="tabuleironovo">Board atualizado</param>
        /// <param name="OvelhaDir">Local onde as ovelhas começaram</param>
        /// <param name="escolhaO">Ovelha escolhida para se movimentar</param>
        /// <returns></returns>
        public bool OvelhaM(Tabuleiro tabuleironovo, int OvelhaDir,
         int escolhaO)
        {
        
            /// bool que vê se o movimento foi feito
            bool check = true;

    
            /// Pede input ao utlizador até receber um válido
            while(!int.TryParse(Console.ReadLine(), out escolha) ||
            escolha < 1 || escolha > 4) ;


            /// Volta a por o espaço onde estava a ovelha a branco
            tabuleironovo[OvelhaX,OvelhaY] = ' ';


            /// Checka se o movimento do jogador e válido e se for move a ovelha
            /// e da return true, se nao for válido sai e dá return false
            if (escolha == 1 && (OvelhaDir == 2 || OvelhaDir == 3))
            {
                /// Vê se o movimento e válido em cordenadas do tabuleiro     
                if (OvelhaX > 0 && OvelhaY > 0
                    && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '1'
                    && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '2' 
                    && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '3' 
                    && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '4'
                    && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != 'L')
                {

                    /// Mexe a ovelha ao aumentar ou diminuir 
                    /// os seus valores de x e y
                    OvelhaX -= 1;
                    OvelhaY -= 1;
                    
                    
                }

                else
                {
                    
                    check = false;

                }
            }

            else if (escolha == 2 && (OvelhaDir == 3 || OvelhaDir == 4))
            {
               if (OvelhaX > 0 && OvelhaY < 7 
                && tabuleironovo[OvelhaX - 1 , OvelhaY + 1 ] != '1'
                && tabuleironovo[OvelhaX - 1 , OvelhaY + 1] != '2' 
                && tabuleironovo[OvelhaX - 1 , OvelhaY + 1] != '3' 
                && tabuleironovo[OvelhaX - 1 , OvelhaY + 1] != '4' 
               && tabuleironovo[OvelhaX - 1, OvelhaY + 1] != 'L')
               {
                    OvelhaX -= 1;
                    OvelhaY += 1;
                    
                    
               }
               else
               {
                  
                    check = false;
               }
            }

            else if (escolha == 3 && (OvelhaDir == 1 || OvelhaDir == 2))
            {
                if (OvelhaX < 7 && OvelhaY > 0
                && tabuleironovo[OvelhaX + 1 , OvelhaY - 1] != '1'
                && tabuleironovo[OvelhaX + 1 , OvelhaY - 1] != '2' 
                && tabuleironovo[OvelhaX + 1 , OvelhaY - 1] != '3' 
                && tabuleironovo[OvelhaX + 1 , OvelhaY - 1] != '4'
                && tabuleironovo[OvelhaX + 1 , OvelhaY - 1] != 'L')
               {
                    OvelhaX += 1;
                    OvelhaY -= 1;
                    
                    
               }
               else
               {
                   
                    check = false;
               }
            }


            else if (escolha == 4 && (OvelhaDir == 1 || OvelhaDir == 4))
            {
                if (OvelhaX < 7 && OvelhaY < 7 
                && tabuleironovo[OvelhaX + 1 , OvelhaY + 1] != '1'
                && tabuleironovo[OvelhaX + 1 , OvelhaY + 1] != '2' 
                && tabuleironovo[OvelhaX + 1 , OvelhaY + 1] != '3' 
                && tabuleironovo[OvelhaX + 1 , OvelhaY + 1] != '4'
                && tabuleironovo[OvelhaX + 1, OvelhaY + 1] != 'L')
               {
                    OvelhaX += 1;
                    OvelhaY += 1;
                    
                    
                    
               }
               else
               {
                    check = false;
               }
            }

            else{
                check = false;
            }
            /// Vê qual foi a ovelha movida e atualiza-a no tabuleiro
            if (escolhaO == 0)
            {
                tabuleironovo[OvelhaX, OvelhaY] = '1';
            }else if(escolhaO == 1)
            {
                tabuleironovo[OvelhaX, OvelhaY] = '2';
            }
            else if(escolhaO == 2)
            {
                tabuleironovo[OvelhaX, OvelhaY] = '3';
            }else
            {
                tabuleironovo[OvelhaX, OvelhaY] = '4';
            }
                if (check == false){
                    return false;
                }
                return true;
            }
        }     
    }

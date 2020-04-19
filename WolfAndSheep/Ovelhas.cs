using System;
namespace WolfAndSheep
{
    public class Ovelhas
    {
        int escolha;
        
        public int OvelhaX { get; set; }

        public int OvelhaY { get; set; }


        public Ovelhas(int linha = 0, int coluna = 0)
        {
          
            OvelhaX = linha;

          
            OvelhaY = coluna;
        }

        public bool OvelhaM(Tabuleiro tabuleironovo, int OvelhaDir,
         int escolhaO)
        {
            bool check = true;
            Console.WriteLine("{0} is out total ", OvelhaDir);
            Console.WriteLine("{0} is out total ", escolhaO);
            Console.WriteLine("{0} is out total ", OvelhaX);
            Console.WriteLine("{0} is out total ", OvelhaY);

            while(!int.TryParse(Console.ReadLine(), out escolha) ||
            escolha < 1 || escolha > 4) ;

            tabuleironovo[OvelhaX,OvelhaY] = ' ';

            if (escolha == 1 && (OvelhaDir == 2 || OvelhaDir == 3))
            {
                if (OvelhaX > 0 && OvelhaY > 0
                    && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '1'
                    && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '2' 
                    && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '3' 
                    && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '4'
                    && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != 'L')
                {
                    Console.WriteLine("ROla");
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
                && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '1'
                && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '2' 
                && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '3' 
                && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '4' 
               && tabuleironovo[OvelhaX - 1, OvelhaY + 1] != 'L')
               {
                   Console.WriteLine("ROla");
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
                && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '1'
                && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '2' 
                && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '3' 
                && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '4'
                && tabuleironovo[OvelhaX + 1 , OvelhaY - 1] != 'L')
               {
                   Console.WriteLine("ROla");
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
                && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '1'
                && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '2' 
                && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '3' 
                && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '4'
                && tabuleironovo[OvelhaX + 1, OvelhaY + 1] != 'L')
               {
                   Console.WriteLine("ROla");
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

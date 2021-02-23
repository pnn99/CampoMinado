using System;

namespace CampoMinado
{
    class Campo
    {
        char[,] Tab;
        char[,] TmpTab;
        int Size;
        bool IsGame = false;
        int NumBombs = 0;

        public int Tabuleiro(int s, int b)
        {
            Size = s;
            NumBombs = b;
            Tab = new char[Size, Size];
            TmpTab = new char[Size, Size];

            return 0;
        }

        public void Start()
        {
            Clear();
            for (int i = 0; i < NumBombs; i++)
            {
                SetRandom('B');    
            }
            SetRandom('S');
            IsGame = true;
        }

        void PrintTab()
        {
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    Console.Write("["+ Tab[i, j] +"]");
                }
                Console.WriteLine();
            }
        }

        void MirrorTab()
        {
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    Console.Write("["+ TmpTab[i, j] +"]");
                }
                Console.WriteLine();
            }
        }

        void Clear()
        {
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    Tab[i, j] = 'O';
                    TmpTab[i, j] = 'X';
                }
            }
        }

        void SetRandom(char c)
        {
            Random gerador = new Random();
            int x, y = 0;

            do
            {
                x = gerador.Next(Size);
                y = gerador.Next(Size);

            } while (Tab[x, y] != 'O');

            Tab[x, y] = c;
        }

        public void Update()
        {
            while (IsGame)
            {
                MirrorTab();
                Console.WriteLine("Insira uma posição em x");
                int x = int.Parse(Console.ReadLine());

                Console.WriteLine("Insira uma posição em y");
                int y = int.Parse(Console.ReadLine());

                Check(x, y);
            }
        }

        public void Check(int x, int y)
        {
            if (Tab[x, y] == 'B')
            {
                gameOver();
                IsGame = false;
            }else if(Tab[x, y] == 'S')
            {
                YouWin();
                IsGame = false;
            }
            TmpTab[x, y] = Tab[x, y];
        }

        void gameOver()
        {
            Console.WriteLine("GAME OVER");
            PrintTab();
        }

        void YouWin()
        {
            Console.WriteLine("Você venceu!!!");
            PrintTab();
        }

    }
}
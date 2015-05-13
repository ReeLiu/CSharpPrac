using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightTour
{

    public class Knight
    {
        // Member variables
        static int rows;
        static int cols;
        // Direction
        int[,] direction = { {-2, 1}, {-1, 2}, {1, 2}, {2, 1}, 
                           {2, -1}, {1, -2}, {-1, -2}, {-1, -1}};
        // Tour sequence, array value represents the visting order of each position
        int[,] chessboard;
        // Current posiition
        int[] curPos = { 0, 0 };
        // Result
        int result = 0;

        // Member functions
        public Knight(int m, int n)
        {
            rows = m;
            cols = n;
            chessboard = new int[rows, cols];
        }
        public void Print()
        {
            System.Console.WriteLine("Knight's tour on {0}*{1} chessboard: ", rows, cols);
            System.Console.WriteLine();
            for (int l = 0; l < rows; l++)
            {
                for (int i = 0; i < cols; i++)
                {
                    System.Console.Write("{0}\t", chessboard[l, i]);
                }
                System.Console.WriteLine();
            }
        }

        public void DFS(int step)
        {
            try
            {
                chessboard[curPos[0], curPos[1]] = step;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("x: {0}, y: {1}", curPos[0], curPos[1]);
            }

            if (step == rows * cols)
            {
                result += 1;
                return;
            }

            // Recursion
            var tmpx = curPos[0];
            var tmpy = curPos[1];


            for (int i = 0; i < 8; i++)
            {
                var next_x = curPos[0] + direction[i, 0];
                var next_y = curPos[1] + direction[i, 1];

                if (next_x >= rows || next_x < 0 || next_y < 0 || next_y >= cols)
                {
                    continue;
                }

                else if (chessboard[next_x, next_y] != 0)
                {
                    continue;
                }

                curPos[0] = next_x;
                curPos[1] = next_y;
                step += 1;

                DFS(step);

                if (result > 0)
                    return;
                step -= 1;
                chessboard[curPos[0], curPos[1]] = 0;
                curPos[0] = tmpx;
                curPos[1] = tmpy;
            }

            return;
        }

        public void Tour()
        {
            DFS(1);
            Print();
        }
    }

    class KnightTest
    {
        static void Main(string[] args)
        {
            Knight k1 = new Knight(7, 7);
            k1.Tour();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Board
    {
        /// <summary>
        /// Sudoku board logic's methods and applications.
        /// </summary>

        internal struct EntryPoint
        {
            public int x, y;
            public EntryPoint(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        #region SetBoard

        public uint[][][] Createboard()
        {
            uint[][][] newboard = new uint[9][][];
            for (int i = 0; i < 9; i++)
            {
                newboard[i] = new uint[9][];
                for (int j = 0; j < 9; j++)
                    newboard[i][j] = new uint[10];
            }
            return newboard;
        }

        public uint[][][] FillRandom()
        {
            int d = 0;
            uint[][][] board = Createboard();
            Random ran = new Random();
            int i = ran.Next(0, 8);
            int j = ran.Next(0, 8);
            uint num = (uint)ran.Next(1, 9);
            while (d < 11)
            {
                if (Checkvalid(num, board, i, j) == true && board[i][j][0] == 0)
                {
                    board[i][j][0] = num;
                    d++;
                }
                else
                {
                    i = ran.Next(0, 8);
                    j = ran.Next(0, 8);
                    num = (uint)ran.Next(1, 9);
                }
            }
            return board;
        }

        #endregion

        #region Logic

        public bool Solvable(uint[][][] board)
        {
            //Check if there are at least 17 hints in the sudoku
            int d = 0;
            bool solvable = false;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j][0] != 0)
                    {
                        d++;
                    }
                }
            }
            if (d >= 17)
            {
                solvable = true;
            }
            return solvable;
        }

        public int Checkzone(int row, int column)
        {
            int zone = 0;
            if (row == 0 || row == 1 || row == 2)
            {
                switch (column)
                {
                    case 0:
                    case 1:
                    case 2:
                        zone = 1;
                        break;
                    case 3:
                    case 4:
                    case 5:
                        zone = 2;
                        break;
                    case 6:
                    case 7:
                    case 8:
                        zone = 3;
                        break;
                }                   
            }
            else if (row == 3 || row == 4|| row == 5)
            {
                switch (column)
                {
                    case 0:
                    case 1:
                    case 2:
                        zone = 4;
                        break;
                    case 3:
                    case 4:
                    case 5:
                        zone = 5;
                        break;
                    case 6:
                    case 7:
                    case 8:
                        zone = 6;
                        break;
                }
            }
            else if (row == 6 || row == 7 || row == 8)
            {
                switch (column)
                {
                    case 0:
                    case 1:
                    case 2:
                        zone = 7;
                        break;
                    case 3:
                    case 4:
                    case 5:
                        zone = 8;
                        break;
                    case 6:
                    case 7:
                    case 8:
                        zone = 9;
                        break;
                }
            }
            return zone;
        }

        public bool Checkvalid(uint number, uint[][][] board, int row, int column)
        {
            bool valid = true;
            int zone = Checkzone(row, column);
            for (int i = 0; i < 9; i++)
            {
                if (i != column)
                {
                    if (board[row][i][0] == number)
                    {
                        valid = false;
                        break;
                    }
                }
                if (i != row)
                {
                    if (board[i][column][0] == number)
                    {
                        valid = false;
                        break;
                    }
                }
                for (int j = 0; j < 9; j++)
                {
                    if (zone == Checkzone(i, j))
                    {
                        if (i != row && j != column)
                        {
                            if (number == board[i][j][0])
                            {
                                {
                                    valid = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return valid;
        }

        public void Evalutevalidvalue(uint[][][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j][0] == 0)
                    {                     
                        for (uint k = 1; k < 10; k++)
                        {
                            if (Checkvalid(k, board, i, j) == true)
                            {
                                board[i][j][k] = k;
                            }
                        }
                    }                  
                }
            }
        }

        public void Onlyvalue(uint[][][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j][0] == 0)
                    {
                        int d = 0;
                        uint fill = 0;
                        for (int k = 1; k < 10; k++)
                        {
                            if (board[i][j][k] != 0)
                            {
                                d++;
                                fill = board[i][j][k];
                            }
                        }
                        if (d == 1)
                        {
                            board[i][j][0] = fill;
                        }
                    }
                }
            }
        }

        public void Zonededuction(uint[][][] board)
        {
            for (int zone = 1; zone < 10; zone++)
            {
                for (uint k = 0; k < 9; k++)
                {
                    int d = 0;
                    int row = 0, column = 0;
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            if (Checkzone(i, j) == zone)
                            {
                                if (board[i][j][0] == 0)
                                {                                    
                                    if (Checkvalid(k, board, i, j) == true)
                                    {
                                        d++;
                                        row = i;
                                        column = j;
                                    }                                      
                                }
                            }
                        }
                    }
                    if (d == 1)
                    {
                        board[row][column][0] = k;
                    }
                }              
            }
        }

        public void Evaluatesquare(int i, int j, uint[][][] board)
        {
            for (uint k = 1; k < 10; k++)
            {
                board[i][j][k] = 0;
                if (Checkvalid(k, board, i, j) == true)
                {
                    board[i][j][k] = k;
                }
            }
        }

        public bool Checkvalidboard(uint[][][] board)
        {
            int error = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Checkvalid(board[i][j][0], board, i, j) == false)
                    {
                        error++;
                        break;
                    }
                }
            }
            if (error == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CompareBoard(uint[][][] board1, uint[][][] board2)
        {
            bool same = true;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j< 9; j++)
                {
                    if (board1[i][j][0] != board2[i][j][0])
                    {
                        same = false;
                        i = 9;
                        break;
                    }                     
                }
            }
            return same;
        }

        public void Substitudearray(uint[][][] board, uint[][][] board1)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i][j][0] = board1[i][j][0];
                }
            }
        }

        private void LogicApply(uint[][][] board)
        {
            Zonededuction(board);
            Evalutevalidvalue(board);
            Onlyvalue(board);             
        }

        public uint[][][] Backtracking(uint[][][] board)
        {
            LogicApply(board);

            uint[][][] solvingboard = new uint[9][][];
            for (int a = 0; a < 9; a++)
            {
                solvingboard[a] = new uint[9][];
                for (int b = 0; b < 9; b++)
                    solvingboard[a][b] = new uint[10];
            }
            Substitudearray(solvingboard, board);
            int i = 0; int j = 0; bool back = false; bool solved = false;
            while (i < 9)
            {
                if (board[i][j][0] == 0)
                {
                    back = false;
                    solvingboard[i][j][0] = 0;
                    int k = 1; int d = 0;
                    while (k < 10)
                    {
                        if (board[i][j][k] != 0 && Checkvalid(board[i][j][k], solvingboard, i, j))
                        {
                            solvingboard[i][j][0] = board[i][j][k];
                            board[i][j][k] = 0;
                            d++;
                            j++;
                            if (j == 9)
                            {
                                j = 0;
                                i++;
                                if (i == 9)
                                {
                                    solved = true;
                                }
                            }
                            break;
                        }
                        else
                        {
                            k++;
                        }
                    }
                    if (d == 0)
                    {
                        back = true;
                        Evaluatesquare(i, j, board);
                        j--;
                        if (j == -1)
                        {
                            j = 8;
                            i--;
                            if (i == -1)
                            {
                                i = 9;
                            }
                        }
                    }
                }
                else
                {
                    if (back == true)
                    {
                        j--;
                        if (j == -1)
                        {
                            j = 8;
                            i--;
                            if (i == -1)
                            {
                                i = 9;
                            }
                        }
                    }
                    else
                    {
                        j++;
                        if (j == 9)
                        {
                            j = 0;
                            i++;
                            if (i == 9)
                            {
                                solved = true;
                            }
                        }
                    }
                }
            }
            if (Checkvalidboard(solvingboard) == false)
            {
                solved = false;
            }
            if (solved == true)
            {
                return solvingboard;
            }
            else
            {
                uint[][][] blankboard = Createboard();
                return blankboard;
            }          
        }

        public int CountRow(int row, uint[][][] board)
        {
            int d = 0;
            for (int i = 0; i < 9; i++)
            {
                if (i == row)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (board[i][j][0] != 0)
                        {
                            d++;
                        }
                    }
                }
            }
            return d;
        }

        public int CountColumn(int col, uint[][][] board)
        {
            int d = 0;
            for (int j = 0; j < 9; j++)
            {
                if (j == col)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (board[i][j][0] != 0)
                        {
                            d++;
                        }
                    }
                }
            }
            return d;
        }

        public int CountBoard(uint[][][] board)
        {
            int d = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j][0] != 0)
                    {
                        d++;
                    }
                }
            }
            return d;
        }

        public void SubRow(int row1, int row2, uint[][][] board)
        {
            uint sub = 0;
            for (int i = 0; i < 9; i++)
            {
                sub = board[row1][i][0];
                board[row1][i][0] = board[row2][i][0];
                board[row2][i][0] = sub;
            }
        }

        public void SubCol(int col1, int col2, uint[][][] board)
        {
            uint sub = 0;
            for (int i = 0; i < 9; i++)
            {
                sub = board[i][col1][0];
                board[i][col1][0] = board[i][col2][0];
                board[i][col2][0] = sub;
            }
        }

        public void Propagation(byte choice, uint[][][] board)
        {
            switch (choice)
            {
                case 1:
                    SubCol(0, 2, board);
                    SubCol(6, 8, board);                    
                    break;
                case 3:
                    SubCol(0, 2, board);
                    SubRow(6, 8, board);
                    break;
                case 5:
                    SubRow(0, 2, board);
                    SubRow(6, 8, board);
                    break;
                case 7:
                    SubCol(6, 8, board);
                    SubRow(0, 2, board);
                    break;
                case 9:
                    SubCol(0, 2, board);
                    SubRow(0, 2, board);
                    break;
                case 2:
                    SubCol(6, 8, board);
                    SubRow(6, 8, board);
                    break;
                case 4:
                case 6:
                case 8:
                    SubCol(0, 2, board);
                    SubCol(6, 8, board);  
                    SubRow(0, 2, board);
                    SubRow(6, 8, board);
                    break;
            }
        }

        public void BlockSwap(byte block1, byte block2, uint[][][] board)
        {
            switch (block1)
            {
                case 1:
                    SubCol(0, 3, board);
                    SubCol(1, 4, board);
                    SubCol(2, 5, board);
                    break;
                case 2:
                    SubCol(6, 3, board);
                    SubCol(7, 4, board);
                    SubCol(8, 5, board);
                    break;
                case 3:
                    SubCol(6, 0, board);
                    SubCol(7, 1, board);
                    SubCol(8, 2, board);
                    break;
            }
            switch (block2)
            {
                case 1:
                    SubRow(0, 3, board);
                    SubRow(1, 4, board);
                    SubRow(2, 5, board);
                    break;
                case 2:
                    SubRow(6, 3, board);
                    SubRow(7, 4, board);
                    SubRow(8, 5, board);
                    break;
                case 3:
                    SubRow(6, 0, board);
                    SubRow(7, 1, board);
                    SubRow(8, 2, board);
                    break;
            }
        }
        #endregion

        #region TestUnique

        public enum Ret { Unique, NotUnique, NoSolution };

        // Is there one and only one solution?
        public Ret TestUniqueness(uint[][][] board)
        {
            // Find untouched location with most information
            int xp = 0;
            int yp = 0;
            byte[] Mp = null;
            int cMp = 10;

            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    // Is this spot unused?
                    if (board[y][x][0] == 0)
                    {
                        // Set M of possible solutions
                        byte[] M = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                        // Remove used numbers in the vertical direction
                        for (int a = 0; a < 9; a++)
                            M[board[a][x][0]] = 0;

                        // Remove used numbers in the horizontal direction
                        for (int b = 0; b < 9; b++)
                            M[board[y][b][0]] = 0;

                        // Remove used numbers in the sub square.
                        int squareIndex = m_subSquare[y, x];
                        for (int c = 0; c < 9; c++)
                        {
                            EntryPoint p = m_subIndex[squareIndex, c];
                            M[board[p.x][p.y][0]] = 0;
                        }

                        int cM = 0;
                        // Calculate cardinality of M
                        for (int d = 1; d < 10; d++)
                            cM += M[d] == 0 ? 0 : 1;

                        // Is there more information in this spot than in the best yet?
                        if (cM < cMp)
                        {
                            cMp = cM;
                            Mp = M;
                            xp = x;
                            yp = y;
                        }
                    }
                }
            }

            // Finished?
            if (cMp == 10)
                return Ret.Unique;

            // Couldn't find a solution?
            if (cMp == 0)
                return Ret.NoSolution;

            // Try elements
            int success = 0;
            for (int i = 1; i < 10; i++)
            {
                if (Mp[i] != 0)
                {
                    board[yp][xp][0] = Mp[i];

                    switch (TestUniqueness(board))
                    {
                        case Ret.Unique:
                            success++;
                            break;

                        case Ret.NotUnique:
                            return Ret.NotUnique;

                        case Ret.NoSolution:
                            break;
                    }

                    // More than one solution found?
                    if (success > 1)
                        return Ret.NotUnique;
                }
            }

            // Restore to original state.
            board[yp][xp][0] = 0;

            switch (success)
            {
                case 0:
                    return Ret.NoSolution;

                case 1:
                    return Ret.Unique;

                default:
                    // Won't happen.
                    return Ret.NotUnique;
            }
        }

        // Maps sub square index to m_sudoku
        private readonly EntryPoint[,] m_subIndex =
            new EntryPoint[,]
			{
				{ new EntryPoint(0,0),new EntryPoint(0,1),new EntryPoint(0,2),new EntryPoint(1,0),new EntryPoint(1,1),new EntryPoint(1,2),new EntryPoint(2,0),new EntryPoint(2,1),new EntryPoint(2,2)},
				{ new EntryPoint(0,3),new EntryPoint(0,4),new EntryPoint(0,5),new EntryPoint(1,3),new EntryPoint(1,4),new EntryPoint(1,5),new EntryPoint(2,3),new EntryPoint(2,4),new EntryPoint(2,5)},
				{ new EntryPoint(0,6),new EntryPoint(0,7),new EntryPoint(0,8),new EntryPoint(1,6),new EntryPoint(1,7),new EntryPoint(1,8),new EntryPoint(2,6),new EntryPoint(2,7),new EntryPoint(2,8)},
				{ new EntryPoint(3,0),new EntryPoint(3,1),new EntryPoint(3,2),new EntryPoint(4,0),new EntryPoint(4,1),new EntryPoint(4,2),new EntryPoint(5,0),new EntryPoint(5,1),new EntryPoint(5,2)},
				{ new EntryPoint(3,3),new EntryPoint(3,4),new EntryPoint(3,5),new EntryPoint(4,3),new EntryPoint(4,4),new EntryPoint(4,5),new EntryPoint(5,3),new EntryPoint(5,4),new EntryPoint(5,5)},
				{ new EntryPoint(3,6),new EntryPoint(3,7),new EntryPoint(3,8),new EntryPoint(4,6),new EntryPoint(4,7),new EntryPoint(4,8),new EntryPoint(5,6),new EntryPoint(5,7),new EntryPoint(5,8)},
				{ new EntryPoint(6,0),new EntryPoint(6,1),new EntryPoint(6,2),new EntryPoint(7,0),new EntryPoint(7,1),new EntryPoint(7,2),new EntryPoint(8,0),new EntryPoint(8,1),new EntryPoint(8,2)},
				{ new EntryPoint(6,3),new EntryPoint(6,4),new EntryPoint(6,5),new EntryPoint(7,3),new EntryPoint(7,4),new EntryPoint(7,5),new EntryPoint(8,3),new EntryPoint(8,4),new EntryPoint(8,5)},
				{ new EntryPoint(6,6),new EntryPoint(6,7),new EntryPoint(6,8),new EntryPoint(7,6),new EntryPoint(7,7),new EntryPoint(7,8),new EntryPoint(8,6),new EntryPoint(8,7),new EntryPoint(8,8)}
		};

        // Maps sub square to index
        private readonly byte[,] m_subSquare =
            new byte[,]
			{
				{0,0,0,1,1,1,2,2,2},
				{0,0,0,1,1,1,2,2,2},
				{0,0,0,1,1,1,2,2,2},
				{3,3,3,4,4,4,5,5,5},
				{3,3,3,4,4,4,5,5,5},
				{3,3,3,4,4,4,5,5,5},
				{6,6,6,7,7,7,8,8,8},
				{6,6,6,7,7,7,8,8,8},
				{6,6,6,7,7,7,8,8,8}
		};

        #endregion

        #region Apllication

        public static bool solvable = true;

        public uint[][][] Solve(uint[][][] board)
        {
            if (Solvable(board) == false)
            {
                solvable = false;
                return Createboard();
            }
            else
            {
                solvable = true;
                return Backtracking(board);
            }
        }

        public uint[][][] DigCells(uint[][][] board)
        {
            int i = 0; int j = 0; int d = 1; int attemp = 0;
            uint[][][] digging = Createboard();
            Substitudearray(digging, board);
            while (CountBoard(digging) > 17 && attemp < 1000)
            {
                while (i < 9)
                {
                    if (CountRow(i, digging) >= d && CountColumn(j, digging) >= d)
                    {
                        uint[][][] testboard = Createboard();
                        Substitudearray(testboard, digging);
                        testboard[i][j][0] = 0;
                        if (TestUniqueness(testboard) == Ret.Unique)
                        {
                            digging[i][j][0] = 0;
                        }
                        if (i == 0 || i == 2 || i == 4 || i == 6 || i == 8)
                        {
                            j++;
                            if (j == 9)
                            {
                                j = 8;
                                i++;
                            }
                        }
                        else
                        {
                            j--;
                            if (j == -1)
                            {
                                j = 0;
                                i++;
                            }
                        }
                    }
                    else
                    {
                        if (CountRow(i, digging) < d)
                        {
                            i++;
                            if (i == 2 || i == 4 || i == 6 || i == 8)
                            {
                                j = 0;
                            }
                            else
                            {
                                j = 8;
                            }
                        }
                        if (CountColumn(j, digging) < d)
                        {
                            if (i == 0 || i == 2 || i == 4 || i == 6 || i == 8)
                            {
                                j++;
                                if (j == 9)
                                {
                                    j = 8;
                                    i++;
                                }
                            }
                            else
                            {
                                j--;
                                if (j == -1)
                                {
                                    j = 0;
                                    i++;
                                }
                            }
                        }
                    }
                }
                attemp++;
            }          
            return digging;
        }

        public uint[][][] Generate()
        {
            uint[][][] sudoku = FillRandom();
            uint[][][] sudokuset = Backtracking(sudoku);
            sudoku = DigCells(sudokuset);
            Random ran = new Random();
            byte choice = (byte)ran.Next(1, 9);
            Propagation(choice, sudoku);
            byte block1 = (byte)ran.Next(1, 3);
            byte block2 = (byte)ran.Next(1, 3);
            BlockSwap(block1, block2, sudoku);
            return sudoku;
        }

        #endregion
    }
}

namespace OXGame
{
    class Program
    {
        static void Main(string[] args)
        {
            OXGameEngine game = new OXGameEngine();
            game.PlayGame();
        }
    }
    class OXGameEngine
    {
        private char[,] board;  // 用二維整列創建棋盤
        private char currentPlayer;  // 當前玩家的符號

        public OXGameEngine()
        {
            board = new char[3, 3];  // 初始化3x3的空棋盤
            currentPlayer = 'X';  // X先下
            InitializeBoard();
        }

        // 初始化棋盤' '
        private void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }

        // 打印當前棋盤狀態
        private void PrintBoard()
        {
            //Console.Clear();  //清空控制臺
            Console.WriteLine("Current Board:");
            Console.WriteLine("   0   1   2");
            for (int row = 0; row < 3; row++)
            {
                Console.Write(row + " ");
                for (int col = 0; col < 3; col++)
                {
                    // 根據棋盤内容輸出相應的内容
                    if (board[row, col] == ' ')
                        Console.Write("   ");
                    else
                        Console.Write($" {board[row, col]} ");

                    // 輸出垂直分隔綫
                    if (col < 2)
                        Console.Write("|");
                }
                Console.WriteLine();

                // 輸出水平分隔綫
                if (row < 2)
                    Console.WriteLine("  ---+---+---");
            }
            Console.WriteLine();
        }

        // 開始游戲
        public void PlayGame()
        {
            while (true)
            {
                PrintBoard();
                Console.WriteLine($"Player {currentPlayer}'s turn");
                Console.WriteLine("Enter row and column (e.g. 0 1):");

                try
                {
                    string[] input = Console.ReadLine().Split();
                    int row = int.Parse(input[0]);
                    int col = int.Parse(input[1]);

                    if (row < 0 || row > 2 || col < 0 || col > 2 || board[row, col] != ' ')
                    {
                        Console.WriteLine("Invalid move! Try again.");
                        continue;
                    }

                    board[row, col] = currentPlayer;

                    if (IsWin())
                    {
                        PrintBoard();
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        break;
                    }
                    else if (IsBoardFull())
                    {
                        PrintBoard();
                        Console.WriteLine("It's a draw!");
                        break;
                    }

                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';  // 切換玩家
                }
                catch
                {
                    Console.WriteLine("Invalid input! Please enter row and column numbers.");
                }
            }
        }

        // 檢查是否有玩家獲勝
        private bool IsWin()
        {
            // 檢查行和列
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    return true;
                if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    return true;
            }

            // 檢查對角綫
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return true;
            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return true;

            return false;
        }
        // 檢查棋盤是否已滿
        private bool IsBoardFull()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == ' ')
                        return false;
                }
            }
            return true;
        }
    }
}


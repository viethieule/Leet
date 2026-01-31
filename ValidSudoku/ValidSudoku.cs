public static class ValidSudokuProblem
{
    public static bool IsValidSudoku(char[][] board)
    {
        var rowFreqs = new int[9, 9];
        var colFreqs = new int[9, 9];
        var squareFreqs = new int[3, 3][];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                squareFreqs[i, j] = new int[9];
            }
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (!int.TryParse(board[i][j].ToString(), out var value))
                {
                    continue;
                }

                if (++rowFreqs[i, value - 1] > 1)
                {
                    return false;
                }

                if (++colFreqs[j, value - 1] > 1)
                {
                    return false;
                }

                // i = 0 1 2 -> 
                //     j = 0 1 2 -> 0
                //     j = 3 4 5 -> 1
                //     j = 6 7 8 -> 2
                // i = 3 4 5 ->
                //     j = 0 1 2 -> 3
                //     j = 3 4 5 -> 4
                //     j = 6 7 8 -> 5
                // i = 6 7 8 ->
                //     j = 0 1 2 -> 6
                //     j = 3 4 5 -> 7
                //     j = 6 7 8 -> 8

                if (++squareFreqs[i / 3, j / 3][value - 1] > 1)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
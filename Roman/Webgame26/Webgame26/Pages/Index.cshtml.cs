using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;

namespace Webgame26.Pages
{
    public class IndexModel : PageModel
    {
        private static Random _random = new Random();
        public string[] Board { get; set; }
        public bool GameOver { get; set; }
        public string GameResult { get; set; }
        //������ �������� � ������
        public void OnGet()
        {
            Console.WriteLine("�������� �������� OnGet()");

            if (HttpContext.Session.GetString("Board") == null)
            {
                Console.WriteLine("������ �� �������, ���������� ����.");
                ResetGame();
            }
            else
            {
                Console.WriteLine("������ �������, ��������� ���������.");
                LoadGameState();
            }
        }

        public IActionResult OnPost(int cell)
        {
            Console.WriteLine($"����� ������ ������: {cell}");

            //������ �������� � ������
            if (Board == null)
            {
                Console.WriteLine("Board == null, ��������� ��������� �� ������.");
                LoadGameState();
            }

            if (GameOver || Board[cell] != "")
            {
                Console.WriteLine("������: ��� ����������.");
                return Page();
            }

            // ��� ������
            Board[cell] = "X";
            SaveGameState();

            if (CheckWin("X"))
            {
                GameOver = true;
                GameResult = "�����������! �� ��������!";
                SaveGameState();
                return Page();
            }

            if (IsBoardFull())
            {
                GameOver = true;
                GameResult = "�����!";
                SaveGameState();
                return Page();
            }

            // ��� ����������
            ComputerMove();

            if (CheckWin("O"))
            {
                GameOver = true;
                GameResult = "��������� �������!";
            }
            else if (IsBoardFull())
            {
                GameOver = true;
                GameResult = "�����!";
            }

            SaveGameState();
            return Page();
        }

        public IActionResult OnPostReset()
        {
            ResetGame();
            return RedirectToPage();
        }

        private void ComputerMove()
        {
            int move;
            while (true)
            {
                move = _random.Next(0, 9);
                if (Board[move] == "")
                {
                    Board[move] = "O";
                    break;
                }
            }
        }

        private bool CheckWin(string player)
        {
            int[,] winPatterns = new int[,]
            {
                { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 },
                { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 },
                { 0, 4, 8 }, { 2, 4, 6 }
            };

            for (int i = 0; i < winPatterns.GetLength(0); i++)
            {
                if (Board[winPatterns[i, 0]] == player &&
                    Board[winPatterns[i, 1]] == player &&
                    Board[winPatterns[i, 2]] == player)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsBoardFull()
        {
            return Board.All(cell => cell != "");
        }
        //������ �������� � ������
        private void SaveGameState()
        {
            Console.WriteLine($"��������� ���������: {string.Join(",", Board)}");
            HttpContext.Session.SetString("Board", string.Join(",", Board));
            HttpContext.Session.SetString("GameOver", GameOver.ToString());
            HttpContext.Session.SetString("GameResult", GameResult);
        }

        private void LoadGameState()
        {
            Console.WriteLine("��������� ��������� �� ������...");

            string boardString = HttpContext.Session.GetString("Board");
            if (string.IsNullOrEmpty(boardString))
            {
                Console.WriteLine("������! ������ ������, ���������� ����.");
                ResetGame();
                return;
            }

            Board = boardString.Split(',');
            GameOver = bool.Parse(HttpContext.Session.GetString("GameOver"));
            GameResult = HttpContext.Session.GetString("GameResult");

            Console.WriteLine($"��������� ���������: {string.Join(",", Board)}");
        }

        private void ResetGame()
        {
            Console.WriteLine("���������� ����.");
            Board = Enumerable.Repeat("", 9).ToArray();
            GameOver = false;
            GameResult = "";
            SaveGameState();
        }
    }
}

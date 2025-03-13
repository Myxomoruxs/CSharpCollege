using System;
using System.Web.Mvc;
using FifteenGame.Business.Models;




namespace FifteenGame.Web.Controllers
{
    public class GameController : Controller
    {
        private GameLogic GetGameLogic()
        {
            if (Session["GameLogic"] == null)
            {
                Session["GameLogic"] = new GameLogic();
            }
            return (GameLogic)Session["GameLogic"];
        }

        [HttpGet]
        public ActionResult GameView()
        {
            var gameLogic = GetGameLogic();
            ViewData["Board"] = gameLogic.board;
            ViewData["Message"] = Session["Message"];
            return View();
        }

        [HttpPost]
        public JsonResult MakeMove(int row, int col)
        {
            var gameLogic = GetGameLogic();
            bool moveMade = gameLogic.MakeMove(row, col);
            string message = "";

            if (moveMade)
            {
                if (gameLogic.CheckForWin())
                {
                    message = "����� " + gameLogic.GetCurrentPlayer() + " �������!";
                    Session["GameLogic"] = new GameLogic(); // �����
                }
                else if (gameLogic.IsDraw())
                {
                    message = "�����!";
                    Session["GameLogic"] = new GameLogic(); 
                }
                else
                {
                    gameLogic.SwitchPlayer();
                    gameLogic.ComputerMove();

                    if (gameLogic.CheckForWin())
                    {
                        message = "��������� �������!";
                        Session["GameLogic"] = new GameLogic(); 
                    }
                    else if (gameLogic.IsDraw())
                    {
                        message = "�����!";
                        Session["GameLogic"] = new GameLogic(); 
                    }

                    gameLogic.SwitchPlayer();
                }
            }

            Session["Message"] = message;

            return Json(new
            {
                success = moveMade,
                board = gameLogic.board,
                message = message
            });
        }

        [HttpPost]
        public JsonResult Reset()
        {
            Session["GameLogic"] = new GameLogic();
            Session["Message"] = "";
            return Json(new { success = true });
        }
    }
}

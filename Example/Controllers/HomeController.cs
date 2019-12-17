using GameDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GameDemo.Controllers
{
    public class HomeController : Controller
    {
        readonly GameContext _context;

        public IActionResult Privacy()
        {
            return View();
        }


        // List<Game> gamesList = new List<Game>();
        

        public HomeController(GameContext context)
        {
            _context = context;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public ActionResult Index()
        {
            Result gameModel = new Result();
            // Set the initial game mode as computer versus computer
            gameModel.Player1Move = PlayerMoveChoices.computer;
            gameModel.Player2Move = PlayerMoveChoices.computer;

            gameModel.GameResult = string.Empty;

            return View(gameModel);
        }

        [HttpPost]
        /// This method is called when the Play button has been pressed
        /// The model is bound to the form so arrives hydrated from the UI
        /// The responsibility of this method is to use the GameEngine to display the winner and display this
        public ActionResult Index(Result gameModel, string submitButton)
        {
            switch (submitButton)
            {
                case "Play the game":
                    return (playAction(gameModel));
                case "Result":
                    return (resultAction(gameModel));
                default:
                    return (View(gameModel));
            }
        }

        private ActionResult playAction(Result gameModel)
        {
            Player player1 = null;
            Player player2 = null;
            string playerChoices = string.Empty;
            int winCount = _context.Results.Select(x => x.CurrentTurn).LastOrDefault();

            // Set Player1
            if (gameModel.Player1Move == PlayerMoveChoices.computer)
            {
                player1 = new ComputerPlayer();
            }
            else
            {
                player1 = new HumanPlayer();

                switch (gameModel.Player1Move)
                {
                    case PlayerMoveChoices.paper:
                        player1.Move = Move.Paper;
                        break;
                    case PlayerMoveChoices.scissors:
                        player1.Move = Move.Scissors;
                        break;
                    case PlayerMoveChoices.rock:
                        player1.Move = Move.Rock;
                        break;
                }
            }

            // Set Player2
            if (gameModel.Player2Move == PlayerMoveChoices.computer)
            {
                player2 = new ComputerPlayer();
            }
            else
            {
                player2 = new HumanPlayer();

                switch (gameModel.Player2Move)
                {
                    case PlayerMoveChoices.paper:
                        player2.Move = Move.Paper;
                        break;
                    case PlayerMoveChoices.scissors:
                        player2.Move = Move.Scissors;
                        break;
                    case PlayerMoveChoices.rock:
                        player2.Move = Move.Rock;
                        break;
                }
            }

            Game game = new Game(player1, player2);

            GameResult gameResult = game.FindWinner();

            var play1 = new Result()
            {
                PlayerName = player1.PlayerName,
                PlayerMove = player1.Move.ToString(),
                CurrentTurn = winCount + 1
            };
            var play2 = new Result()
            {
                PlayerName = player2.PlayerName,
                PlayerMove = player2.Move.ToString(),
                CurrentTurn = winCount + 1
            };

            string playerChoicesDescription = " (Plyer1 Move= " + player1.Move.ToString() + "/ Plyer1 Move= " + player2.Move.ToString() + ")";
            switch (gameResult)
            {
                case GameResult.Draw:
                    //play1.GameResult = $"{playerChoicesDescription} Draw ";
                    play1.GameResult = $"{play1.CurrentTurn}. Draw ";
                    play1.DrawCount = 1;
                    break;

                case GameResult.Player1Wins:
                    //play1.GameResult = $"{playerChoicesDescription} Player 1 won ";
                    play1.GameResult = $"{play1.CurrentTurn}. Player1: Win ";
                    play1.WinCount = 1;
                    play2.WinCount = 0;
                    break;

                case GameResult.Player2Wins:
                    //play1.GameResult = $"{playerChoicesDescription} Player 2 won ";
                    play1.GameResult = $"{play1.CurrentTurn}. Player2: Win ";
                    play1.WinCount = 0;
                    play2.WinCount = 1;
                    break;
            } 

            _context.Results.Add(play1);
            _context.Results.Add(play2);
            _context.SaveChanges();
            var data = _context.Results.Where(x => x.PlayerName == "Player1").Select(x => x.GameResult).ToList();

            gameModel.GameResult = String.Join(",", data);
            return View(gameModel);
        }

        private ActionResult resultAction(Result gameModel)
        {
            var Play1Count = _context.Results.Where(x => x.PlayerName == "Player1").Select(x => x.WinCount).ToList().Sum();
            var Play2Count = _context.Results.Where(x => x.PlayerName == "Player2").Select(x => x.WinCount).ToList().Sum();
            var rounds = _context.Results.Select(x => x.CurrentTurn).LastOrDefault();
            var draws = _context.Results.Where(x => x.PlayerName == "Player1").Select(x => x.DrawCount).ToList().Sum();

            if (Play1Count > Play2Count)
            {
                gameModel.GameResult = $"Total Rounds: {rounds}, Total Draw: {draws}, Player1= {Play1Count}, Player2= {Play2Count},Player1 won.";
            }
            else if (Play1Count < Play2Count)
            {
                gameModel.GameResult = $"Total Rounds: {rounds}, Total Draw: {draws}, Player1= {Play1Count}, Player2= {Play2Count},Player2 won.";
            }
            else
            {
                gameModel.GameResult = $"Total Rounds: {rounds}, Total Draw: {draws}, Player1= {Play1Count}, Player2= {Play2Count},Draw.";
            }
            var results = _context.Results.ToList();
            _context.Results.RemoveRange(results);
            _context.SaveChanges();

            return View(gameModel);
        }
    }
}

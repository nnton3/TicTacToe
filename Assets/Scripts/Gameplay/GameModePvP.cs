using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class GameModePvP : MonoBehaviour, IGameMode
    {
        private IPlayer _player1;
        private IPlayer _player2;
        private IPlayer _currentPlayerTurn;
        private IBoard _board;
        private IBoardView _boardView;
        private IWinConditionChecker _winChecker;

        public void Inject(IBoard board, IBoardView boardView, IWinConditionChecker winChecker)
        {
            _board = board;
            _boardView = boardView;
            _winChecker = winChecker;
        }

        private void Awake()
        {
            _player1 = new HumanPlayer(_board, _boardView);
            _player2 = new HumanPlayer(_board, _boardView);

            _player1.OnTurnEnd += EndTurnHandler;
            _player2.OnTurnEnd += EndTurnHandler;

            SelectFirst();
            StartGame();
        }

        private void SelectFirst()
        {
            var rand = new System.Random();
            var playerFirst = rand.Next(2);
            _currentPlayerTurn = (playerFirst == 0) ? _player1 : _player2;
            var playerFigure = rand.Next(2);
            if (playerFigure == 0)
            {
                _player1.SetFigure(FigureType.Cross);
                _player2.SetFigure(FigureType.Zero);
            }
            else
            {
                _player1.SetFigure(FigureType.Zero);
                _player2.SetFigure(FigureType.Cross);
            }
        }

        public void StartGame()
        {
            _currentPlayerTurn.StartTurn();
        }

        private void EndTurnHandler(object sender, Vector2Int pos)
        {
            if (_winChecker.IsWinConditionAchived(pos))
            {
                Debug.Log($"{(sender as IPlayer).FigureType} is Winner");
            }
            else
            {
                SwapTurn();
            }
        }

        private void SwapTurn()
        {
            _currentPlayerTurn = (_currentPlayerTurn == _player1) ? _player2 : _player1;
            var currentPlayerName = _currentPlayerTurn == _player1 ? "_player2" : "_player1";
            Debug.Log($"turn swap to {currentPlayerName}");
            _currentPlayerTurn.StartTurn();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SimpleGame.Business;
using SimpleGame.Models;

namespace SimpleGame.Presentation
{
    public class GameViewModel : ObservableObject
    {
        //private GameBusiness _gameBusiness;

        public Gameboard _gameboard;
        //private (Player playerOne, Player playerTwo) _currentPlayers;
        private Player _playerX;
        private Player _playerO;
        private string _messageBoxContent;

        public Gameboard Gameboard
        {
            get { return _gameboard; }
            set
            {
                _gameboard = value;
                OnPropertyChanged(nameof(Gameboard));
            }
        }

        public Player PlayerX
        {
            get { return _playerX; }
            set
            {
                _playerX = value;
                OnPropertyChanged(nameof(PlayerX));
            }
        }

        public Player PlayerO
        {
            get { return _playerO; }
            set
            {
                _playerO = value;
                OnPropertyChanged(nameof(PlayerO));
            }
        }

        public string MessageBoxContent
        {
            get { return _messageBoxContent; }
            set
            {
                _messageBoxContent = value;
                OnPropertyChanged(nameof(MessageBoxContent));
            }
        }

        public GameViewModel()
        {
            //_gameBusiness = new GameBusiness();

            InitializeGame();
        }

        private void InitializeGame()
        {
            //_currentPlayers = _gameBusiness.GetCurrentPlayers();

            _playerX = new Player();
            _playerO = new Player();

            _gameboard = new Gameboard();

            _gameboard.CurrentRoundState = Gameboard.GameboardState.PlayerXTurn;
            MessageBoxContent = "Player X's Turn Now";
        }

        public void PlayerMove(int row, int column)
        {
            if (_gameboard.GameboardPositionAvailable(new GameboardPosition(row, column)))
            {
                if (_gameboard.CurrentRoundState == Gameboard.GameboardState.PlayerXTurn)
                {
                    Gameboard.CurrentBoard[row][column] = Gameboard.PLAYER_PIECE_X;
                    OnPropertyChanged(nameof(Gameboard));
                    _gameboard.CurrentRoundState = Gameboard.GameboardState.PlayerOTurn;
                    MessageBoxContent = "Player O's Turn Now";
                }
                else
                {
                    Gameboard.CurrentBoard[row][column] = Gameboard.PLAYER_PIECE_O;
                    OnPropertyChanged(nameof(Gameboard));
                    _gameboard.CurrentRoundState = Gameboard.GameboardState.PlayerXTurn;
                    MessageBoxContent = "Player X's Turn Now";
                }
                UpdateCurrentRoundState();
            }
        }

        internal void GameCommand(string commandName)
        {
            switch (commandName)
            {
                case "NewGame":
                    _gameboard.InitializeGameboard();
                    OnPropertyChanged(nameof(Gameboard));

                    _gameboard.CurrentRoundState = Gameboard.GameboardState.PlayerXTurn;
                    break;

                case "ResetGame":
                    _gameboard.InitializeGameboard();
                    OnPropertyChanged(nameof(Gameboard));

                    _gameboard.CurrentRoundState = Gameboard.GameboardState.PlayerXTurn;
                    break;

                case "Quit":
                    
                    break;

                default:
                    
                    break;
            }
        }

        public void UpdateCurrentRoundState()
        {
            _gameboard.UpdateGameboardState();
            if (_gameboard.CurrentRoundState == Gameboard.GameboardState.CatsGame)
            {
                PlayerO.Ties++;
                PlayerX.Ties++;
                MessageBoxContent = "Cat Game";
            }
            else if (_gameboard.CurrentRoundState == Gameboard.GameboardState.PlayerXWin)
            {
                PlayerX.Wins++;
                PlayerO.Losses++;
                MessageBoxContent = "A Win for Player X!";
            }
            else if (_gameboard.CurrentRoundState == Gameboard.GameboardState.PlayerOWin)
            {
                PlayerO.Wins++;
                PlayerX.Losses++;
                MessageBoxContent = "A Win for Player O!";
            }
        }
    }
}

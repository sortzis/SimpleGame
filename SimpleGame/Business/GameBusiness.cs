using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleGame.Presentation;
using SimpleGame.Models;

//namespace SimpleGame.Business
//{
//    class GameBusiness
//    {
//        public enum GameStatus
//        {
//            QUIT
//        }

//        List<Player> _allPlayers;

//        Player _playerOne;
//        Player _playerTwo;

//        public GameBusiness()
//        {
//            InitializeGame();
//        }

//        private void InitializeGame()

//        {
            

//            _playerOne = _allPlayers.FirstOrDefault(p => p.Name == "Player X");
//            _playerTwo = _allPlayers.FirstOrDefault(p => p.Name == "Player O");
//        }

//        public (Player playerOne, Player playerTwo) GetCurrentPlayers()
//        {
//            _playerOne = _allPlayers.FirstOrDefault(p => p.Name == "Player X");
//            _playerTwo = _allPlayers.FirstOrDefault(p => p.Name == "Player O");
//            (Player playerOne, Player playerTwo) currentPlayers = (_playerOne, _playerTwo);

//            return currentPlayers;
//        }
//    }
//}

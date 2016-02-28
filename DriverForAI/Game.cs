using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DriverForAI
{
    partial class Game
    {
        private const int centerOfField = 4;
        private const int endOfField = 9;
        private int numberOfGame = 0;
        private List<bool> wayOpportunities = new List<bool>();
        private double timeLimit;
        private int numberOfWay;
        private GraphicField field;
        public bool end = false;
        public IPlayer winPlayer;
        private IPlayer player1;
        private IPlayer player2;
        public IPlayer Player1 { get { return player1; } }
        public IPlayer Player2 { get { return player2; } }
        private char lastWay;
        public char LastWay {
            get { return lastWay; }
            set { lastWay = value; }
        }

        public char[,] Field
        {
            get {return field.Field;}
            set {field.Field = value;}
        }
        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="numberOfGame"></param>
        /// <param name="player1">"X" player</param>
        /// <param name="player2">"O" player</param>
        /// <param name="timeLimit">timeLimit for game. Now it's changed to timeLimit for every player.
        /// They are assign in Program.cs</param>
        /// <param name="field">Picture of a game board.</param>
        public Game(int numberOfGame, IPlayer player1, IPlayer player2, double timeLimit, GraphicField field)
        {
            this.numberOfGame = numberOfGame;
            this.field = field;
            this.timeLimit = timeLimit;
            numberOfWay = 0;
            this.player1 = player1;
            this.player2 = player2;
            for ( int i = 0; i < endOfField + 1; i++ )
                wayOpportunities.Add(true);
        }

        public int NumberOfWay
        {
            get {return numberOfWay;}
            set {numberOfWay = value;}
        }

        public int NumberOfGame
        {
            get {return numberOfGame;}
        }
        
        /// <summary>
        /// check whether the row is full
        /// </summary>
        public List<bool> WayOpportunities
        {
            get {return wayOpportunities;}
            set {wayOpportunities = value;}
        }

        ///<summary>
        /// check whether the turn is right
        /// </summary> 
        private bool checkWay(char symbol, string way)
        {
            if ( way == null )
                return false;
            string nums = "0123456789";
            if ( (way.Length != 1) || (!nums.Contains(way[0])) )
                return false;
            if ( !WayOpportunities[int.Parse(way)] )
                return false;
            return true;
        }

        /// <summary>
        /// check whether the turn is last and the player has won. 
        /// </summary>
        /// <param name="numberOfWay">It's unnecessary var</param>
        //TODO: Delete numberOfWay
        /// <param name="symbol">the symbol that is being checked</param>
        /// <returns></returns>
        public bool checkWin(int numberOfWay, char symbol)
        {
            if ( checkTheHorizontalLine(symbol) )
                return true;
            if ( checkTheVerticalLine(symbol) )
                return true;
            if ( checkTheMainDiagonale(symbol) )
                return true;
            if ( checkTheAlternateDiagonale(symbol) )
                return true;
            return false;
        }
        /// <summary>
        /// check if there are 5 symbols in a row
        /// </summary>
        /// <param name="symbol">the symbol which is being checked</param>
        /// <returns></returns>
        private bool checkTheHorizontalLine(char symbol)
        {
            for ( int i = 0; i < endOfField; i++ ) {
                string str = "";
                for ( int j = 0; j < endOfField; j++ )
                    str += Field[i, j];
                string substr;
                if ( symbol == 'X' )
                    substr = "XXXXX";
                else
                    substr = "OOOOO";
                if ( str.Contains(substr) )
                    return true;
            }
            return false;
        }
        /// <summary>
        /// check if there are 5 symbols in a row
        /// </summary>
        /// <param name="symbol">the symbol which is being checked</param>
        /// <returns></returns>
        private bool checkTheVerticalLine(char symbol)
        {
            for ( int i = 0; i < endOfField; i++ ) {
                string str = "";
                for ( int j = 0; j < endOfField; j++ )
                    str += Field[j, i];
                string substr;
                if ( symbol == 'X' )
                    substr = "XXXXX";
                else
                    substr = "OOOOO";
                if ( str.Contains(substr) )
                    return true;
            }
                return false;
        }


        /// <summary>
        /// check if there are 5 symbols in diagonals that are located from 
        /// left-bottom to right-top corners
        /// </summary>
        /// <param name="symbol">the symbol whish is checked (X or O)</param>
        /// <returns></returns>
        //TODO: Change the digits to constants
        private bool checkTheMainDiagonale(char symbol)
        {
            string substr;
            if ( symbol == 'X' )
                substr = "XXXXX";
            else
                substr = "OOOOO";

            for (int i = 5; i >= 0; i-- ) {
                string str = "";
                for (int j = 0; i + j < 10; j++ )
                    str += Field[i + j, j];    
                if ( str.Contains(substr) )
                    return true;
            }

            for ( int i = 1; i < 5; i++ ) {
                string str = "";
                for (int j = 0; j + i < 10; j++ )
                    str += Field[j, i + j];
                if ( str.Contains(substr) )
                    return true;
            }
            return false;
        }

        /// <summary>
        /// check if there are 5 symbols in diagonals that are located from 
        /// right-bottom to left-top corners
        /// </summary>
        /// <param name="symbol">the symbol whish is checked (X or O)</param>
        /// <returns></returns>
        //TODO: Change the digits to constants
        private bool checkTheAlternateDiagonale(char symbol)
        {
            string substr;
            if ( symbol == 'X' )
                substr = "XXXXX";
            else
                substr = "OOOOO";

            for ( int i = 14; i >= 9; i-- ) {
                string str = "";
                for ( int j = i - 9; j <= 9 ; j++ )
                    str += Field[j, i - j];
                if ( str.Contains(substr) )
                    return true;
            }

            for ( int i = 8; i >= 5; i-- ) {
                string str = "";
                for ( int j = 0; i - j >= 0; j++ )
                    str += Field[j, i - j];
                if ( str.Contains(substr) )
                    return true;
            }
            return false;
        }
    }



    partial class Game
    {
        /// <summary>
        /// The logic of the turn
        /// </summary>
        /// <param name="player1">The player who does the turn</param>
        /// <param name="player2">The opposite player</param>
        public void PlayerWay(IPlayer player1, IPlayer player2)
        {
            if ( player1.Symbol == 'X' ) {
                NumberOfWay++;
                LastWay = 'X';
            } else
                LastWay = 'O';
            string wway = player1.ReadWay(NumberOfWay, player1.Symbol);
            if ( checkWay(player1.Symbol, wway)) {
                int i = int.Parse(wway);
                Field = new GraphicField(this, player1.Symbol, i).Field;
                player2.WriteWay(NumberOfWay, player1.Symbol, i, NumberOfGame);

                var pl = player1 as RandomPlayer;
                if (pl != null )
                    player1.WriteWay(NumberOfWay, player1.Symbol, i, NumberOfGame);

                if ( field.Field[endOfField, i] != '.' ) {
                    WayOpportunities[i] = false;
                }

                if ( checkWin(NumberOfWay, player1.Symbol) )
                    GameOver(player1);
                if ( checkWin(NumberOfWay, player2.Symbol) ) 
                    GameOver(player2);
                LastWay = player1.Symbol;

            } else {
                GameOver(player2);
            }
            
        }

        /// <summary>
        /// Send who is the winner
        /// </summary>
        /// <param name="winner"></param>
        public void GameOver(IPlayer winner)
        {
            end = true;
            if ( winner == player1 )
                winPlayer = player1;
            else winPlayer = player2;
        }
        /// <summary>
        /// check if the game field is full
        /// </summary>
        /// <returns></returns>
        public bool AllDraw()
        {
            int j = 0;
            foreach ( bool b in WayOpportunities )
                if ( !b ) j++;
            if ( j == endOfField + 1 )
                return true;
            return false;
        }
    }
}

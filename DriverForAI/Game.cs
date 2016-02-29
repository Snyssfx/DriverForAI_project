using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DriverForAI
{
    /*
    **************************************************************************
    * Judge for AI ("Connect Five" game).                               	 *
    *                                                                   	 *
    * This program should be used for Connect Five Competition.          	 *
    * Connect Five is the game like Connect Four; for more information see   *
    * http://www.math.spbu.ru/user/chernishev/connectfive/connectfive.html   *
    *                                                                   	 *
    * Author: Gleb Zakharov                                              	 *
    * Email: <last name><first name>i@gmail.com                         	 *
    * Year: 2015                                                        	 *
    * See the LICENSE.txt file in the project root for more information.     *
    **************************************************************************
   */
    partial class Game
    {
        private const int centerOfField = 4;
        private const int endOfField = 9;
        private int numberOfGame = 0;
        private List<bool> freeColumn = new List<bool>();
        private double timeLimit;
        private int numberOfTurn;
        private GraphicField field;
        public bool end = false;
        public IPlayer winPlayer;
        private IPlayer player1;
        private IPlayer player2;
        public IPlayer Player1 { get { return player1; } }
        public IPlayer Player2 { get { return player2; } }
        private char lastTurn;
        public char LastTurn {
            get { return lastTurn; }
            set { lastTurn = value; }
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
            numberOfTurn = 0;
            this.player1 = player1;
            this.player2 = player2;
            for ( int i = 0; i < endOfField + 1; i++ )
                freeColumn.Add(true);
        }

        public int NumberOfTurn
        {
            get {return numberOfTurn;}
            set {numberOfTurn = value;}
        }

        public int NumberOfGame
        {
            get {return numberOfGame;}
        }
        
        /// <summary>
        /// check whether the row is full
        /// </summary>
        public List<bool> FreeColumn
        {
            get {return freeColumn;}
            set {freeColumn = value;}
        }

        ///<summary>
        /// check whether the turn is right
        /// </summary> 
        private bool checkTurn(char symbol, string turn)
        {
            if ( turn == null )
                return false;
            string nums = "0123456789";
            if ( (turn.Length != 1) || (!nums.Contains(turn[0])) )
                return false;
            if ( !FreeColumn[int.Parse(turn)] )
                return false;
            return true;
        }

        /// <summary>
        /// check whether the turn is last and the player has won. 
        /// </summary>
        /// <param name="numberOfTurn">It's unnecessary var</param>
        //TODO: Delete numberOfWay
        /// <param name="symbol">the symbol that is being checked</param>
        /// <returns></returns>
        public bool checkWin(int numberOfTurn, char symbol)
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

            for (int i = centerOfField + 1; i >= 0; i-- ) {
                string str = "";
                for (int j = 0; i + j < endOfField + 1; j++ )
                    str += Field[i + j, j];    
                if ( str.Contains(substr) )
                    return true;
            }

            for ( int i = 1; i < centerOfField + 1; i++ ) {
                string str = "";
                for (int j = 0; j + i < endOfField + 1; j++ )
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

            for ( int i = endOfField + centerOfField + 1; i >= endOfField; i-- ) {
                string str = "";
                for ( int j = i - endOfField; j <= endOfField ; j++ )
                    str += Field[j, i - j];
                if ( str.Contains(substr) )
                    return true;
            }

            for ( int i = endOfField - 1; i >= centerOfField + 1; i-- ) {
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
        public void PlayerTurn(IPlayer player1, IPlayer player2)
        {
            if ( player1.Symbol == 'X' ) {
                NumberOfTurn++;
                LastTurn = 'X';
            } else
                LastTurn = 'O';
            string wway = player1.ReadTurn(NumberOfTurn, player1.Symbol);
            if ( checkTurn(player1.Symbol, wway)) {
                int i = int.Parse(wway);
                Field = new GraphicField(this, player1.Symbol, i).Field;
                player2.WriteTurn(NumberOfTurn, player1.Symbol, i, NumberOfGame);

                var pl = player1 as RandomPlayer;
                if (pl != null )
                    player1.WriteTurn(NumberOfTurn, player1.Symbol, i, NumberOfGame);

                if ( field.Field[endOfField, i] != '.' ) {
                    FreeColumn[i] = false;
                }

                if ( checkWin(NumberOfTurn, player1.Symbol) )
                    GameOver(player1);
                if ( checkWin(NumberOfTurn, player2.Symbol) ) 
                    GameOver(player2);
                LastTurn = player1.Symbol;

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
            foreach ( bool b in FreeColumn )
                if ( !b ) j++;
            if ( j == endOfField + 1 )
                return true;
            return false;
        }
    }
}

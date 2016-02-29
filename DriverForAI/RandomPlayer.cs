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
    /// <summary>
    /// Bot with a random turn's choice
    /// </summary>
    class RandomPlayer : IPlayer
    {
        private string name;
        private char symbol;
        private int numberOfWins;
        private int numberOfDraws;
        private int numberOfLoses;
        private string path;
        private List<bool> freeColumns;
        private double timeLimit;
        public RandomPlayer(string path, string name, char symbol)
        {
            this.path = path;
            this.name = name;
            Symbol = symbol;
            numberOfWins = 0;
            numberOfDraws = 0;
            numberOfLoses = 0;
        }
        public RandomPlayer(string path, string name)
        {
            this.path = path;
            this.name = name;
            numberOfWins = 0;
            numberOfDraws = 0;
            numberOfLoses = 0;
        }
        public String Name { get {return name;} }
        public Int32 NumberOfDraws
        {
            get {return numberOfDraws;}
            set {numberOfDraws = value;}
        }
        public Int32 NumberOfLoses
        {
            get {return numberOfLoses;}
            set {numberOfLoses = value;}
        }
        public Int32 NumberOfWins
        {
            get {return numberOfWins;}
            set {numberOfWins = value;}
        }
        public Char Symbol
        {
            get {return symbol;}
            set {symbol = value;}
        }
        public String Path
        {
            get {return path;}
            set {path = value;}
        }
        public Int32 NumberOfPoints
        {
            get {return 2 * NumberOfWins + NumberOfDraws;}
        }
        public Double TimeLimit
        {
            get {return timeLimit;}
            set {timeLimit = value;}
        }
        /// <summary>
        /// generate a random movement
        /// </summary>
        /// <param name="numberOfWay">it needs for proving interface contract</param>
        /// <param name="Symbol">it needs only for proving interface contract</param>
        /// <returns></returns>
        public String ReadTurn(Int32 numberOfWay, Char Symbol)
        {
            Random ran = new Random();
            int i = ran.Next(0, 10);
            System.Threading.Thread.Sleep(80);
            return i.ToString();
        }
        /// <summary>
        /// write some movement in .txt file in game Directory with the symbol
        /// </summary>
        /// <param name="numberOfWay">needs for a name of the file</param>
        /// <param name="Symbol"></param>
        /// <param name="Way"></param>
        /// <param name="NumberOfGame"></param>
        public void WriteTurn(Int32 numberOfWay, Char Symbol, int Way, int NumberOfGame)
        {
            string name = "\\" + Symbol.ToString() + numberOfWay.ToString();
            using ( StreamWriter writer = new StreamWriter(Program.Path + '\\' + NumberOfGame + @"\" +
                    symbol + @"\" + Symbol + numberOfWay + ".txt", false) ) {
                writer.Write(Way.ToString());
            }
        }
    }
}

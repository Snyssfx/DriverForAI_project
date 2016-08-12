/*
   **************************************************************************
   * Judge for AI ("Connect Five" game).                                 	  *
   *                                                                        *
   * This program should be used for Connect Five Competition.           	  *
   * Connect Five is the game like Connect Four; for more information see   *
   * http://www.math.spbu.ru/user/chernishev/connectfive/connectfive.html   *
   *                                                                   	    *
   * Author: Gleb Zakharov                                              	  *
   * Email: <last name><first name>i@gmail.com                         	    *
   * Year: 2015                                                        	    *
   * See the LICENSE.txt file in the project root for more information.     *
   **************************************************************************
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DriverForAI
{
    static class Program
    { 
        private static Int32 numOfGames;
        private static Int32 numOfPlayers = 0;
        public static Int32 NumOfGames { get { return numOfGames; } set { numOfGames = value; } }
        public static List<Game> g;
        public static List<IPlayer> players;
        private static double timeLimit;
        public static double TimeLimit { get { return timeLimit; } set { timeLimit = value; } }
        public static readonly string Path = Directory.GetCurrentDirectory();//@"C:\Example\";

        /// <summary>
        /// read information from configs and write it to players
        /// </summary>
        public static void MakeAGame()
        {

            players = new List<IPlayer>();
            using ( var reader = new StreamReader(Path + @"\Configs.txt") ) {
                string str = "";
                str = reader.ReadLine();
                while ( !str.Contains("TimeLimit = ") ) {
                    numOfPlayers++;
                    int i = str.LastIndexOf('\\');
                    string pathh = str.Substring(0, i);
                    string namee = str.Substring(i + 1);

                    if ( pathh == "Random" )
                        players.Add(new RandomPlayer(Path, namee));
                    else if ( pathh != "Human" )
                        players.Add(new AIPlayer(pathh, namee));
                    str = reader.ReadLine();
                }
                for ( int i = 0; i < players.Count(); i++ ) {
                    var strs = str.Split(' ').Last();
                    TimeLimit = double.Parse(strs);
                    players[i].TimeLimit = TimeLimit * 1000;
                    if ( !reader.EndOfStream )
                        str = reader.ReadLine();
                }
            }
        }

        /// <summary>
        /// Main method.
        /// </summary>
        [STAThread]

        static void Main()
        {
            MakeAGame();
            NumOfGames = 0;
            g = new List<Game>() ;
            for (int i = 0; i < numOfPlayers - 1; i++ ) {
                for (int j = i + 1; j < numOfPlayers; j++ ) {
                    NumOfGames++;
                    g.Add(new Game(NumOfGames, players[i], players[j], TimeLimit,
                        new GraphicField()));

                    NumOfGames++;
                    g.Add(new Game(NumOfGames, players[j], players[i], TimeLimit,
                        new GraphicField()));
                }
            }
            for (int i = 1; i <= g.Count(); i++ ) {
                if ( Directory.Exists(Path + @"\" + i) ) {
                    var directory = new DirectoryInfo(Path + @"\" + i);
                    directory.Delete(true);
                }
                Directory.CreateDirectory(Path + @"\" + i);
                Directory.CreateDirectory(Path + @"\" + i + @"\" + 'X');
                Directory.CreateDirectory(Path + @"\" + i + @"\" + 'O');
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());   
        }
    }
}

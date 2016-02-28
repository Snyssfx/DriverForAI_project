using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DriverForAI
{
    //Arguments that brains' writers receive for their AI:
    //Session directory, symbol, timeLimit.
    //For example:
    //C:\Example\Game_5\O\ X 4,875

    //Before the contest you need to write this in Config.txt:
    //Player 1's folder, player 2's (absolute path to a player 2 folder) on a new line and so on.
    //Players' names are names of the .exe file.
    //On new lines timeLimits for all of the players.

    //If you want to add a random AI, write Random\some_random_name
    //as a new player.

    //For example:

    //C:\Example\Super_Hero
    //C:\Example\Potential_Winner
    //Random\Bot_David
    //TimeLimit = 4,875
    //TimeLimit = 5,0
    //TimeLimit = 1000
    
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

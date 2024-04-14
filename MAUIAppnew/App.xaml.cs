/*
 Program Author: Janit Rajkarnikar

USM ID: w10163086

Assignment: Capital Quiz 3

Description:
The program runs through the States Class of Quiz.cs and its methods. It uses the QuizView and ResultView Views.
The required frontend and backend for all the views are there.
 */
using MAUIAppnew.Classes;
using System.Reflection;

namespace MAUIAppnew
{
    public partial class App : Application
    {
        public static List<Classes.State> states = new List<Classes.State>();
        public App()
        {
            InitializeComponent();
            LoadStates();

            MainPage = new Pages.QuizView();
            MainPage = MainPage;
        }

        public static void newGame()
        {
            LoadStates();

            App.Current.MainPage = new Pages.QuizView();
        }
        public static void TestResult(int score, int overall, List<State> Missed)
        {
            App.Current.MainPage = new Pages.ResultView(score, overall, Missed); 
        }


        private static void LoadStates()
        {
            string resourceId = "MAUIAppnew.Resources.Raw.StateCapitals.txt"; //Using resourceID to load from raw

            var assembly = Assembly.GetExecutingAssembly();
            using Stream stream = assembly.GetManifestResourceStream(resourceId);
            using var reader = new StreamReader(stream);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(' ');
                data[0] = data[0].Replace("-", " ");
                data[1] = data[1].Replace("-", " ");
                Classes.State state = new Classes.State { StateName = data[0], Capital = data[1] };
                states.Add(state);
            }
        }

    }
}

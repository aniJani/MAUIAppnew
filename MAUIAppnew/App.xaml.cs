namespace MAUIAppnew
{
    public partial class App : Application
    {
        public static List<Classes.State> states = new List<Classes.State>();
        public App()
        {
            InitializeComponent();
            //TestResult();
            LoadStates();

            MainPage = new Pages.QuizView();
            MainPage = MainPage;
        }
        public static void TestResult()
        {
            int score = 0;
            int overall = 20;
            List<Classes.State> Missed = new List<Classes.State>();

            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int chosen = r.Next(0, App.states.Count);
                Missed.Add(App.states[chosen]);
            }

            App.Current.MainPage = new Pages.ResultsView(score, overall, Missed); //new AppShell();
        }


        private static void LoadStates()
        {
            string filePath = "C:\\Users\\rajka\\source\\repos\\MAUIAppnew\\MAUIAppnew\\StateCapitals.txt";
            try
            {
                var file = new StreamReader(filePath);

                string? line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(" ");
                    data[0] = data[0].Replace("-", " ");
                    data[1] = data[1].Replace("-", " ");
                    Classes.State state = new Classes.State { StateName = data[0], Capital = data[1] };
                    states.Add(state);
                }

                file.Close();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Could not load file.");
            }
        }
    }
}

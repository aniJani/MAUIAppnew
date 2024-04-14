/*
 Program Author: Janit Rajkarnikar

USM ID: w10163086

Assignment: Capital Quiz 3

Description:
The program runs through the States Class of Quiz.cs and its methods. It uses the QuizView and ResultView Views.
The required frontend and backend for all the views are there. The stateCapitals is loaded by App.xaml.cs
 */
using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using MAUIAppnew.Classes;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MAUIAppnew.Pages
{
    public partial class ResultView : ContentPage
    {

        class optionStrings { string _text = ""; public string Text { get { return _text; } set { _text = value; } } }

        public ResultView(int score, int overall, List<State> Missed)
        {
            InitializeComponent();
            ActualScore.Text = score.ToString();
            if (score == 20)
            {
                ResultLabel.Text = "You got all questions correct!";
                resultImage.IsVisible = true;
            }
            ObservableCollection<optionStrings> options_ = new ObservableCollection<optionStrings>();
            foreach (State state in Missed)
            {
                options_.Add(new optionStrings { Text = $"{state.Capital}, {state.StateName}" });
            }
            quizOptions.ItemsSource = options_;
        }

        private void NewGame_Clicked(object sender, EventArgs e)
        {
            App.newGame();
        }

        private void Exit_Clicked(object sender, EventArgs e)
        {
            App.Current.Quit();
        }
    }
}

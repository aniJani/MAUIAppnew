using Microsoft.Maui;
using MAUIAppnew.Classes;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MAUIAppnew.Pages
{
    public partial class QuizView : ContentPage
    {
        private Quiz quiz;
        private QuizQuestion? currentQuestion;
        private string ClickedName;
        private List<State> options1;
        private int score;
        private List<State> missedStates = new List<State>();
        private int totalQuestions;

        class optionStrings { string _text = ""; public string Text { get { return _text; } set { _text = value; } } }

        public QuizView()
        {
            InitializeComponent();
            quiz = new Quiz();

            // Display the first question
            DisplayNextQuestion();
        }

        private void DisplayNextQuestion()
        {
            totalQuestions++;
            ObservableCollection<optionStrings> options_ = new ObservableCollection<optionStrings>();
            currentQuestion = quiz.FetchNext();
            if (currentQuestion != null)
            {
                QuestionLabel.Text = "What is the capital of " + currentQuestion.Correct?.StateName + "?";

                var options = currentQuestion.GenerateOptions();

                foreach (State state in options)
                {
                    options_.Add(new optionStrings { Text = state.Capital });
                }
                quizOptions.ItemsSource = options_;
                options1 = options;
            }
            else
            {

            }
        }
        private void NextButton_Clicked(object sender, EventArgs e)
        {
            DisplayNextQuestion() ;
            submitButton.IsVisible = true;

            // Show the Next button
            nextButton.IsVisible = false;
        }
        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if (currentQuestion.Correct.Capital == options1[1].Capital.ToString())
            {
                resultImage.Source = "icon_correct.png";
                resultImage.IsVisible = true;
                score++;
                ActualScoreLabel.Text = score.ToString() + "/20";
            }
            else
            {
                resultImage.Source = "icon_incorrect.png";
                resultImage.IsVisible = true;
                missedStates.Add(currentQuestion.Correct);
            }
            if(totalQuestions == 20)
            {
                App.TestResult();
            }
            else
            {
                submitButton.IsVisible = false;

                // Show the Next button
                nextButton.IsVisible = true;
            }
            
        }

        private void SelectOption(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null && e.CurrentSelection.Any())
            {
                // Get the selected item
                var selectedItem = e.CurrentSelection.FirstOrDefault();

                var selectedOption = selectedItem;
                Console.WriteLine(selectedOption);
            }
        }
    }
}

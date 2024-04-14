/*
 Program Author: Janit Rajkarnikar

USM ID: w10163086

Assignment: Capital Quiz 3

Description:
The program runs through the States Class of Quiz.cs and its methods. It uses the QuizView and ResultView Views.
The required frontend and backend for all the views are there. The stateCapitals is loaded by App.xaml.cs
 */
using Microsoft.Maui;
using Microsoft.VisualBasic.FileIO;
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
        private string selectedOption;

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
            Radio1.IsChecked = false;
            Radio2.IsChecked = false;
            Radio3.IsChecked = false;
            Radio4.IsChecked = false;
        }
        private void SelectOption1(object sender, CheckedChangedEventArgs e)
        {
            Debug.WriteLine("herere");
            selectedOption = options1[0].Capital.ToString();
            Debug.WriteLine(selectedOption);

        }
        private void SelectOption2(object sender, CheckedChangedEventArgs e)
        {
            Debug.WriteLine("herere");
            selectedOption = options1[1].Capital.ToString();
            Debug.WriteLine(selectedOption);

        }
        private void SelectOption3(object sender, CheckedChangedEventArgs e)
        {
            Debug.WriteLine("herere");
            selectedOption = options1[2].Capital.ToString();
            Debug.WriteLine(selectedOption);

        }
        private void SelectOption4(object sender, CheckedChangedEventArgs e)
        {
            Debug.WriteLine("herere");
            selectedOption = options1[3].Capital.ToString();
            Debug.WriteLine(selectedOption);

        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            if (totalQuestions == 20)
            {
                App.TestResult(score, 20, missedStates);
            }
            else
            {
                DisplayNextQuestion();
                submitButton.IsVisible = true;

                // Show the Next button
                nextButton.IsVisible = false;
                resultImage.IsVisible = false;
                winImage.IsVisible = false;
            }
        }
        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine(currentQuestion.Correct.Capital);
            Debug.WriteLine(selectedOption);
            if (currentQuestion.Correct.Capital == selectedOption)
            {
                resultImage.Source = "icon_correct.png";
                resultImage.IsVisible = true;
                winImage.IsVisible = true;
                winImage.Text = "Correct!";
                score++;
                ActualScoreLabel.Text = $"{score}/20"; 
            }
            else
            {
                winImage.IsVisible = true;
                winImage.Text = "Incorrect...";
                resultImage.Source = "icon_incorrect.png";
                resultImage.IsVisible = true;
                missedStates.Add(currentQuestion.Correct);
            }
            submitButton.IsVisible = false;

            nextButton.IsVisible = true;
        }

        private void QuitButton_Clicked(object sender, EventArgs e)
        {
            App.Current.Quit();
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

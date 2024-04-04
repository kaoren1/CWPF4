using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using System.IO;
using Newtonsoft.Json;

namespace PR4WPF1
{
    public partial class TestPage : Page
    {
        private List<Test> testData = new List<Test>();
        private Test? currentTest;
        private int currentIndex = 0;
        private int score = 0;

        public TestPage()
        {
            InitializeComponent();
            LoadData();
            DisplayTest();
        }

        private void LoadData()
        {
            if (File.Exists("test.json"))
            {
                testData = SerDer.Deserialize();
            }
        }

        private void DisplayTest()
        {
            if (testData.Count > 0 && currentIndex < testData.Count)
            {
                currentTest = testData[currentIndex];
                Text1.Text = currentTest.Name;
                Text2.Text = currentTest.Description;
                Button1.Content = currentTest.Answer1;
                Button2.Content = currentTest.Answer2;
                Button3.Content = currentTest.CorrectAnswer;
            }
            else
            {
                MessageBox.Show("Ваш счет: " + score);
            }
        }

        private void ResetFields()
        {
            Text1.Text = "";
            Text2.Text = "";
            Button1.Content = "";
            Button2.Content = "";
            Button3.Content = "";
        }

        private void NextTest()
        {
            currentIndex++;
            if (currentIndex >= testData.Count)
            {
                DisplayTest();
            }
            else
            {
                DisplayTest();
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            ResetFields();
            NextTest();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ResetFields();
            NextTest();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            score++;
            ResetFields();
            NextTest();
        }
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using System.IO;

namespace PR4WPF1
{
    public partial class RedactorPage : Page
    {
        List<Test> tests = new List<Test>();

        public RedactorPage()
        {
            InitializeComponent();
            LoadData(); // Вызываем метод загрузки данных при открытии страницы
            Tabl.ItemsSource = tests;
        }

        private void LoadData()
        {
            if (File.Exists("test.json"))
            {
                tests = SerDer.Deserialize();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Test add = new Test(Text1.Text, Text2.Text, Text3.Text, Text4.Text, Text5.Text);
            tests.Add(add);
            SerDer.Serialize(tests);
            Tabl.ItemsSource = null; // Очищаем источник данных таблицы
            Tabl.ItemsSource = tests; // Устанавливаем обновленный источник данных
        }
    }

    public class Test
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string CorrectAnswer { get; set; }

        public Test(string name, string description, string ans1, string ans2, string ansC)
        {
            Name = name;
            Description = description;
            Answer1 = ans1;
            Answer2 = ans2;
            CorrectAnswer = ansC;
        }
    }

    public static class SerDer
    {
        public static void Serialize(List<Test> a)
        {
            string json = JsonConvert.SerializeObject(a);
            File.WriteAllText("test.json", json);
        }

        public static List<Test> Deserialize()
        {
            string json = File.ReadAllText("test.json");
            return JsonConvert.DeserializeObject<List<Test>>(json);
        }
    }
}


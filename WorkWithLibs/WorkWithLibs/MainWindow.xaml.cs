using System;
using System.Windows;
using Microsoft.Win32;
using Converter;
using System.Windows.Controls;
using System.Windows.Media;

namespace WorkWithLibs
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SerializeButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                DataSerializer.Serialize<string>("Данные лол", filePath);
                MessageBox.Show("Данные каеф записались.");
                FilePathTextBox.Text = filePath;
            }
        }

        private void DeserializeButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                // Десериализация строки из XML файла
                string deserializedData = DataSerializer.Deserialize<string>(filePath);
                MessageBox.Show("Уффф мы крч такое считали с файла. Вот чекай: " + deserializedData);
                FilePathTextBox.Text = filePath;
            }
        }


        public enum Theme
        {
            Dark,
            Light,
            Ruby
        }

        private Theme currentTheme = Theme.Dark; // Изначально установим тему Dark



        private void ThemeChanger_Click(object sender, RoutedEventArgs e)
        {
            // Переключаемся на следующую тему
            switch (currentTheme)
            {
                case Theme.Dark:
                    currentTheme = Theme.Light;
                    break;
                case Theme.Light:
                    currentTheme = Theme.Ruby;
                    break;
                case Theme.Ruby:
                    currentTheme = Theme.Dark;
                    break;
                default:
                    break;
            }

            // Устанавливаем новые стили для элементов управления в соответствии с текущей темой
            switch (currentTheme)
            {
                case Theme.Dark:
                    Resources["ButtonStyle"] = FindResource("DarkButtonStyle");
                    Resources["TextBoxStyle"] = FindResource("DarkTextBoxStyle");
                    Resources["GridBackgroundStyle"] = FindResource("DarkBackgroundStyle");
                    break;
                case Theme.Light:
                    Resources["ButtonStyle"] = FindResource("LightButtonStyle");
                    Resources["TextBoxStyle"] = FindResource("LightTextBoxStyle");
                    Resources["GridBackgroundStyle"] = FindResource("LightBackgroundStyle");
                    break;
                case Theme.Ruby:
                    Resources["ButtonStyle"] = FindResource("RubyButtonStyle");
                    Resources["TextBoxStyle"] = FindResource("RubyTextBoxStyle");
                    Resources["GridBackgroundStyle"] = FindResource("RubyBackgroundStyle");
                    break;
                default:
                    break;
            }
        }


    }
}

using System;
using UWPCode.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Windows.Storage;
using System.Threading.Tasks;

namespace UWPCode.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            CreateAndDisplayNewFile();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        public void UpdateTextArea(string text)
        {
            editor.Document.SetText(Windows.UI.Text.TextSetOptions.None, text);
        }

        public async void OpenAndDisplayFile()
        {
            var buffer = await ViewModel.ChooseAndOpenFile();
            DisplayBuffer(buffer);
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenAndDisplayFile();
        }

        private void AddFileButton_Click(object sender, RoutedEventArgs e)
        {
            CreateAndDisplayNewFile();
        }

        private Models.Buffer CreateAndDisplayNewFile()
        {
            var buffer = ViewModel.CreateNewBuffer();
            DisplayBuffer(buffer);
            return buffer;
        }

        private void DisplayBuffer(Models.Buffer buffer)
        {
            editor.Document.SetText(Windows.UI.Text.TextSetOptions.None, buffer.Text);
            pageHeader.Text = buffer.Name;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveCurrentBuffer();
        }

        private async Task<StorageFile> SaveCurrentBuffer()
        {
            var buffer = ((App)Application.Current).BufferOrganizer.CurrentBuffer;
            var text = GetEditorText();
            var file = await ViewModel.UpdateAndSaveBuffer(buffer, text);
            DisplayBuffer(buffer);
            return file;
        }

        private string GetEditorText()
        {
            string text;
            editor.Document.GetText(Windows.UI.Text.TextGetOptions.None, out text);
            return text;
        }

        private void fileListButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void splitViewButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void functionListButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void functionListButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void remoteFileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sourceControlButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void settingButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.GotoSettings();
        }
    }
}

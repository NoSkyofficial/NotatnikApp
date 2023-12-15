namespace NotatnikApp.Views
{
    public partial class NoteListPage : ContentPage
    {
        public NoteListPage()
        {
            InitializeComponent();
            LoadFiles();
        }
        public class FileItem
        {
            public string Name { get; set; }
            public string Path { get; set; }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadFiles();
        }

        private void LoadFiles()
        {
            var files = Directory.GetFiles(FileSystem.AppDataDirectory, "*.txt");
            var fileItems = files.Select(filePath => new FileItem { Name = Path.GetFileName(filePath), Path = filePath }).ToList();
            filesListView.ItemsSource = fileItems;
        }


        private async void OnFileSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is FileItem fileItem)
            {
                var noteContent = File.ReadAllText(fileItem.Path);
                await DisplayAlert("Zawartość notatki", noteContent, "OK");
            }
        }
    }
}

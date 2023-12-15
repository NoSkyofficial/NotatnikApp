namespace NotatnikApp.Views
{
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        private async void OnSaveNoteClicked(object sender, EventArgs e)
        {
            var noteText = noteEditor.Text;
            var timestamp = DateTime.Now;

            var location = await Geolocation.GetLastKnownLocationAsync();

            var latitude = location?.Latitude.ToString() ?? "Nieznana";
            var longitude = location?.Longitude.ToString() ?? "Nieznana";

            var fileName = $"Note_{timestamp:yyyyMMddHHmmss}.txt";
            var filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);

            var noteContent = $"Timestamp: {timestamp}\nLocation: {latitude}, {longitude}\n\n{noteText}";
            File.WriteAllText(filePath, noteContent);

            await DisplayAlert("Zapisano", $"Notatka zapisana w {filePath}", "OK");

            noteEditor.Text = string.Empty;
        }

    }
}

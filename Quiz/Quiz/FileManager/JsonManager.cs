using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Quiz.FileManager
{
    public class JsonManager
    {
        //Klassens ansvar är att läsa & skriva till/från Json-fil.
        private readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private readonly string _fileName = "Quiz.json";

        //Metoden sparar en lista av quiz till Json-fil.
        public async Task SaveQuiz(ObservableCollection<Models.Quiz> quizzes)
        {
            using (StreamWriter saveFile = new(Path.Combine(_path, _fileName)))
            {
                await saveFile.WriteAsync(JsonSerializer.Serialize(quizzes));
            }
        }

        //Metoden läser in från fil, sparar till en lista av quiz och returnerar den
        public async Task<ObservableCollection<Models.Quiz>> LoadQuiz()
        {
            using (FileStream LoadFile = File.OpenRead(Path.Combine(_path, _fileName)))
            {
                ObservableCollection<Models.Quiz> quizList = await JsonSerializer.DeserializeAsync<ObservableCollection<Models.Quiz>>(LoadFile);
                return quizList;
            }
        }
    }
}

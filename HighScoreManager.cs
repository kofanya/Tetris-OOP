using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public static class HighScoreManager
    {
        private static readonly string FilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Tetris",
            "highscores.json"
        );

        static HighScoreManager()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
        }

        public static List<HighScore> LoadHighScores()
        {
            if (!File.Exists(FilePath))
                return new List<HighScore>();

            try
            {
                string json = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<List<HighScore>>(json) ?? new List<HighScore>();
            }
            catch
            {
                return new List<HighScore>();
            }
        }
        public static void SaveHighScore(int score)
        {
            if (score == 0)
            {
                return;
            }

            var scores = LoadHighScores();

            scores.Add(new HighScore
            {
                Score = score,
                Date = DateTime.Now
            });

            scores = scores
                .OrderByDescending(s => s.Score)
                .Take(5)
                .ToList();

            string json = JsonConvert.SerializeObject(scores, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        public static List<HighScore> GetTop5()
        {
            return LoadHighScores().Take(5).ToList();
        }
    }
}

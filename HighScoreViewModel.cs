using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace Tetris
{
    public class HighScoreViewModel
    {
        public string DisplayText { get; set; }

        public HighScoreViewModel(HighScore highScore, int index)
        {
            string medal = index switch
            {
                0 => "1.",
                1 => "2.",
                2 => "3.",
                3 => "4.",
                4 => "5.",
            };

            string date = highScore.Date.ToString("dd MMM HH:mm");
            DisplayText = $"{medal} Score: {highScore.Score}     {date}";
        }
    }
}

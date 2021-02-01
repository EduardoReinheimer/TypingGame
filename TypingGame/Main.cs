using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypingGame
{
    public partial class Main : Form
    {
        Game game;

        public Main()
        {
            InitializeComponent();
            NewGame();
        }

        public void NewGame()
        {
            game = new Game();
            lblWord.Text = game.GetPhrase();
        }

        
        private void checkGame(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (textBox1.Text.Trim() == game.GetWord())
                {
                    
                    textBox1.Clear();
                    game.IsCorrect();
                    game.NextWord();
                    if (game.PhraseEnded)
                    {
                        NewGame();
                    }
                }
                else
                {
                    game.IsIncorrect();
                }
                lblRight.Text = $"Correct: {game.Correct}";
                lblWrong.Text = $"Incorrect: {game.Incorrect}";
            }
        }
    }
}

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

        string[] phrases = {"quero cafeh, isso aqui tah uma porcaria que nao tem merda nenhuma.",
                            "vai todo mundo pra casa do caraleo.",
                            "Foi otimo.",
                            "Essa novinha keh pressaum."

        };
        Random rnd = new Random();
        int correct = 0;
        int incorrect = 0;
        int index;
        string currentPhrase = "";
        List<string> words = new List<string> { };


        public Main()
        {
            InitializeComponent();
            NewGame();
        }

        public string GetPhrase()
        {
            string phrase = phrases[rnd.Next(0, phrases.Length)];
            return phrase;
        }

        public void NewGame()
        {
            index = 0;
            currentPhrase = GetPhrase();
            words = currentPhrase.Split(' ').ToList();
            lblWord.Text = currentPhrase;
        }

        
        private void checkGame(object sender, KeyEventArgs e)
        {
            int indexEnd = words.Count() - 1;
            if (e.KeyCode == Keys.Space)
            {
                if (textBox1.Text.Trim() == words[index])
                {
                    correct++;
                    textBox1.Clear();
                    if (index < indexEnd)
                    {
                        index++;
                    } else
                    {
                        NewGame();
                    }
                }
                else
                {
                    incorrect++;
                }
                lblRight.Text = $"Correct: {correct}";
                lblWrong.Text = $"Incorrect: {incorrect}";
            }
        }
    }
}

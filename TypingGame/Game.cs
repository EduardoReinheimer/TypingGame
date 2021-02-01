using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingGame
{
    class Game
    {
        public int Correct { get; private set; }
        public int Incorrect { get; private set; }
        public int Index { get; private set; }
        public int IndexEnd { get; private set; }
        public string Phrase { get; private set; }
        public string Word { get; private set; }
        public bool PhraseEnded { get; set; }
        public List<string> PhraseWords = new List<string>();

        private const string URL = "https://evilinsult.com/generate_insult.php?lang=en&amp;type=json";
        public void NextWord()
        {
            if (this.Index < this.IndexEnd)
            {
                this.Index++;
                this.Word = PhraseWords[Index];
            }
            else
            {
                this.PhraseEnded = true;
            }
        }
        public string GetWord()
        {
            return this.Word;
        }
        public string GetPhrase()
        {
            return this.Phrase;
        }

        public void IsCorrect()
        {
            this.Correct++;
        }
        public void IsIncorrect()
        {
            this.Incorrect++;
        }

        public string ReturnPhrase()
        {
            var client = new RestClient(URL);
            var response = client.Execute(new RestRequest());
            while (true)
            {
                if (response.Content.Length < 90)
                {
                    break;
                }
                response = client.Execute(new RestRequest());
            }
            return response.Content;
        } 
        public Game()
        {
            this.Index = 0;
            this.Correct = 0;
            this.Incorrect = 0;
            this.Phrase = ReturnPhrase();
            this.PhraseWords = Phrase.Split(' ').ToList();
            this.IndexEnd = PhraseWords.Count() - 1;
            this.Word = PhraseWords[0];
            this.PhraseEnded = false;
        }
    }
}

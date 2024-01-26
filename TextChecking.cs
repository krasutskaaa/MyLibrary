
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MyLibrary
{
    public class TextChecking
    {
        private string _text { get; set; }
        private static string[] _profanity = { "fuck", "bitch", "asshole" };
        public TextChecking()
        {
            _text = String.Empty;
        }
        public  bool ifСontainsProfanity()
        {
            string[] textSplit = _text.Split(' ');
            if(_profanity.Any(badWord => textSplit.Contains(badWord)))
                    return true;
            return false;
        }
        public void RemoveProfanity()
        {
            if(ifСontainsProfanity())
            {
                foreach(string badWord in _profanity)
                {
                    _text = _text.Replace(badWord,string.Empty);
                }
                _text = _text.Replace("  ", " ");
            }
        }
        public void LoadFromFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                string textJson = reader.ReadToEnd();
                _text = JsonSerializer.Deserialize<string>(textJson);
            }
        }
        public void SaveToFile(string fileName)
        {
            using (var writer = new StreamWriter(fileName))
            {
                string textJson = JsonSerializer.Serialize(_text);
                writer.Write(textJson);
            }
        }
    }
}
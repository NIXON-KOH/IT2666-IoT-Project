using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;


namespace WindowsFormsApplication1
{
    public partial class LanguageManager : Form
    {
        private static LanguageManager _instance;
        public Dictionary<string, string> Translations { get; private set; }
        public string CurrentLanguage { get; private set; }

        private LanguageManager()
        {
            LoadLanguage("English");
        }

        public static LanguageManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LanguageManager();
                return _instance;
            }
        }

        public void LoadLanguage(string language)
        {
            try
            {
                string jsonFilePath = "C:\\Users\\ASUS\\Desktop\\WinFrom\\WinFrom\\WinFrom\\WinFrom\\WindowsFormsApplication1\\Resources\\translation.json";

                if (!File.Exists(jsonFilePath))
                {
                    throw new FileNotFoundException($"Translation file not found at: {jsonFilePath}");
                }

                string json = File.ReadAllText(jsonFilePath);
                var allTranslations = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);

                if (allTranslations != null && allTranslations.ContainsKey(language))
                {
                    Translations = allTranslations[language];
                    CurrentLanguage = language;
                }
                else
                {
                    throw new Exception($"Language '{language}' not found in translations.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading language: {ex.Message}");
                Translations = new Dictionary<string, string>();
            }
        }

        public string GetTranslation(string key)
        {
            return Translations != null && Translations.ContainsKey(key) ? Translations[key] : key;
        }
    }
}
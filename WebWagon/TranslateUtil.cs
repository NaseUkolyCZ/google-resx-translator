using System;
using System.Text.RegularExpressions;
using System.Data;
using System.Collections;
using System.IO;
using System.Net;


namespace HttpUtils
{
	/// <summary>
	/// Google Translation Utility Class (c)Peter A. Bromberg 2005
	/// </summary>

    public enum LangPair
    {
        EnglishToGerman,
        EnglishToSpanish,
        EnglishToFrench,
        EnglishToItalian,
        EnglishToPortuguese,
        EnglishToJapanese,
        EnglishToKorean,
        EnglishToChineseSimplified,
        GermanToEnglish,
        GermanToFrench,
        SpanishToEnglish,
        FrenchToEnglish,
        FrenchToGerman,
        ItalianToEnglish,
        PortugueseToEnglish,
        JapaneseToEnglish,
        KoreanToEnglish,
        ChineseSimplifiedToEnglish,
        EnglishToCzech
    }
	

	public class TranslateUtil
	{
        static TranslateUtil _instance;
        Microsoft.TranslatorContainer translatorContainer;

        private TranslateUtil()
		{
            string rootUri = "https://api.datamarket.azure.com/Bing/MicrosoftTranslator/";
            translatorContainer = new Microsoft.TranslatorContainer(new Uri(rootUri));

            var accountKey = "YourAccountKey";
            translatorContainer.Credentials = new NetworkCredential(accountKey, accountKey);
        }

        public static TranslateUtil Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(TranslateUtil))
                    {
                        if (_instance == null)
                        {
                            _instance = new TranslateUtil();
                        }
                    }
                }
                return _instance;
            }
        }

		public static ArrayList  GetLangPairs()
		{
          ArrayList al = new ArrayList();
		Array vals=Enum.GetValues(typeof(LangPair)) ;
		al.Add("Please Select");
		 foreach (object o in vals)
			 al.Add(o.ToString());
			return al;
		}
		
		public static string GetTranslatedText(string textToTranslate , LangPair langPair)
		{
            string from = string.Empty;
            string to = string.Empty;
            string strLangPair = string.Empty;

			switch(langPair)
			{
				case (LangPair.ChineseSimplifiedToEnglish):
					strLangPair = "zh-CN|en";
					break;
				case (LangPair.EnglishToChineseSimplified):
					strLangPair = "en|zh-CN";
					break;
				case (LangPair.EnglishToFrench):
					strLangPair = "en|fr";
					break;
                case (LangPair.EnglishToGerman):
					strLangPair = "en|de";
					break;
				case (LangPair.EnglishToItalian):
					strLangPair = "en|it";
					break;
				case (LangPair.EnglishToJapanese):
					strLangPair = "en|ja";
					break;
				case (LangPair.EnglishToKorean):
					strLangPair = "en|ko";
					break;
				case (LangPair.EnglishToPortuguese):
					strLangPair = "en|pt";
					break;
				case (LangPair.EnglishToSpanish):
					strLangPair = "en|es";
					break;
				case (LangPair.FrenchToEnglish):
					strLangPair = "fr|en";
					break;
				case (LangPair.FrenchToGerman):
					strLangPair = "fr|de";
					break;
				case (LangPair.GermanToEnglish):
					strLangPair = "de|en";
					break;
				case (LangPair.GermanToFrench):
					strLangPair = "de|fr";
					break;
				case (LangPair.ItalianToEnglish):
					strLangPair = "it|en";
					break;
				case (LangPair.JapaneseToEnglish):
					strLangPair = "ja|en";
					break;
				case (LangPair.KoreanToEnglish):
					strLangPair = "ko|en";
					break;
				case (LangPair.PortugueseToEnglish):
					strLangPair ="pt|en";
					break;
				case (LangPair.SpanishToEnglish):
					strLangPair = "es|en";
					break;
                case (LangPair.EnglishToCzech):
                    strLangPair = "en|cz";
                    break;
				default:
					strLangPair="en|de";
					break;
			}

            string[] strLangPairs = strLangPair.Split('|');
            from = strLangPairs[0];
            to = strLangPairs[1];

            var imageQuery = Instance.translatorContainer.Translate(textToTranslate, to, from);
            var imageResults = imageQuery.Execute();

            foreach (var result in imageResults)
            {
                return result.Text;
            }

            return string.Empty;
		}
	}
}

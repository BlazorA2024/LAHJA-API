﻿using Newtonsoft.Json;

namespace Dto
{
  
    public class HelperTranslation
    {
        


        public  static Dictionary<string, string> ConvertTextToTranslationData(string textTranslation)
        {
            return string.IsNullOrEmpty(textTranslation)
                ? new Dictionary<string, string>()
                : JsonConvert.DeserializeObject<Dictionary<string, string>>(textTranslation);
        }

        public static string getTranslationValueByLG(string textTranslation,string  lg)
        {
            return ConvertTextToTranslationData(textTranslation)[lg];
        }

        public static string ConvertTranslationDataToText(Dictionary<string, string> translationData)
        {
            return JsonConvert.SerializeObject(translationData);
        }





    }
}
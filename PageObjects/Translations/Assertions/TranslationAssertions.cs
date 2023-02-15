using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Linq;
using TestSuite.Enums;
using TestSuite.Interfaces;
using TestSuite.Model;

namespace TestSuite.Translations.Assertions
{
    public static class TranslationAssertions
    {
        public static bool CheckIfTextCoitainsTranslation(this IWebElement webElement, string translationKey, ITranslationRepository translationRepository, Languages language = Languages.Polish)
        {
            TranslationModel translation;

            try
            {
                translation = translationRepository.Translations.Where(x => x.TranslationKey == translationKey).First();
            }
            catch (Exception)
            {
                throw new ArgumentException("Given Translation Key is not exists or is duplicated in Translation Repository");
            }

            switch (language)
            {
                case Languages.English:
                    webElement.Text.Should().Contain(translation.EnglishText);
                    return true;
                case Languages.Polish:
                    webElement.Text.Should().Contain(translation.PolishText);
                    return true;
            }

            return true;
        }
    }
}

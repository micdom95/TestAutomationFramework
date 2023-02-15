using System.Collections.Generic;
using TestSuite.Model;

namespace TestSuite.Interfaces
{
    public interface ITranslationRepository
    {
        public List<TranslationModel> Translations { get; }
    }
}

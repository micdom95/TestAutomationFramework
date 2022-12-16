using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSuite.Model;

namespace TestSuite.Interfaces
{
    public interface ITranslationRepository
    {
        public List<TranslationModel> Translations { get; }
    }
}

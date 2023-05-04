
using ModifiedSchemeElGamal.Interface;
using ModifiedSchemeElGamal.Model;

namespace ModifiedSchemeElGamal.SchemeElGamal
{
    public sealed partial class SEG:ISEG
    {
        public Keys GetKeys() => HelperClasses.GenerationKeys.GetKeys();
    }
}

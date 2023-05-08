using ModifiedSchemeElGamal.HelperClasses;
using ModifiedSchemeElGamal.Interface;
using ModifiedSchemeElGamal.MathematicalOperators;
using ModifiedSchemeElGamal.Model.EDS;
using System.Text;

namespace ModifiedSchemeElGamal.SchemeElGamal
{
    public sealed partial class SEG : ISEG
    {
        public Keys GetKeysEDS() => GenerationKeys.GetKeysEDS();
        public Signature? EDS(string Text, Keys _Keys)
        {
            if (Text == string.Empty)
                return null;
            var p = _Keys.OpenKey.P;
            var IndexHashFunction = CRNG.GenerationInt(0, Constants.NumHashFunctions);
            var m = HashFunctions.GetHash(IndexHashFunction, Encoding.ASCII.GetBytes(Text));
            var listPrimeK = MathActions.GetListPrimeValue(1, p - 1);
            var k = listPrimeK[CRNG.GenerationInt(0, listPrimeK.Count)];
            var R = MathActions.ModPow(_Keys.OpenKey.G, k, p);
            var S = MathActions.Mod((((m < 0) ? -m : m) - _Keys.SecretKey * R) * MathActions.InvMod(k, p - 1), p - 1);
            return new Signature(R, S, IndexHashFunction);
        }
        public bool? DSV(string Text, Signature _Signature, OpenKey _OpenKey)
        {
            if (Text == string.Empty)
                return null;
            var p = _OpenKey.P;
            if (0 > _Signature.R && _Signature.R > p && 0 > _Signature.S && _Signature.S > p - 1)
                return false;
            var m = HashFunctions.GetHash(_Signature.IndexHashFinction, Encoding.ASCII.GetBytes(Text));
            var v1 = MathActions.Mod(MathActions.ModPow(_OpenKey.Y, _Signature.R, p) * MathActions.ModPow(_Signature.R, _Signature.S, p), p);
            var v2 = MathActions.ModPow(_OpenKey.G, (m < 0) ? -m : m, p);
            return v1 == v2;
        }
    }
}

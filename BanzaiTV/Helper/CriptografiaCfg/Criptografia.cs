using System.Security.Cryptography;
using System.Text;

namespace BanzaiTV.Helper.CriptografiaCfg
{
    public static class Criptografia
    {
        public static string GerarHash(this string valorParaConverter)
        {
            var hash = SHA1.Create();
            var encode = new ASCIIEncoding();
            var array = encode.GetBytes(valorParaConverter);
            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}

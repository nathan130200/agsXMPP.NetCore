using System.Security.Cryptography;
using System.Text;

namespace agsXMPP.util;

public static class Hash
{
    public static byte[] Bytes(this string s, Encoding? encoding = default) => (encoding ?? Encoding.UTF8).GetBytes(s);

    public static string Md5Hash(this string value) => MD5.HashData(value.Bytes()).Hex();
    public static byte[] Md5HashBytes(this string value) => MD5.HashData(value.Bytes());

    public static byte[] CalcMd5(byte[] b) => MD5.HashData(b);
    public static byte[] CalcSha1(byte[] b) => SHA1.HashData(b);

    public static string Sha1Hash(this string pass) => SHA1.HashData(pass.Bytes()).Hex();
    public static byte[] Sha1HashBytes(this string pass) => SHA1.HashData(pass.Bytes());

    public static string Hex(this byte[] buf) => Convert.ToHexString(buf);
    public static string Hex(this string str) => str.Bytes().Hex();
    public static byte[] FromHex(this string buf) => Convert.FromHexString(buf);
}
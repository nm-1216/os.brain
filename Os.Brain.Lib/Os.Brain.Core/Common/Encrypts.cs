//-----------------------------------------------------------------------
// <copyright file="Encrypts.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>Common Regular Expression
// </discription>
//-----------------------------------------------------------------------



namespace Os.Brain.Common
{
    using System;
    using System.Text;
    using System.Security.Cryptography;

    public class Encrypts
    {

        public class BASE64
        {
            public static string Encrypt(string original)
            {
                byte[] bytes = Encoding.GetEncoding("ASCII").GetBytes(original);
                return Convert.ToBase64String(bytes);
            }

            public static string Decrypt(string original)
            {
                byte[] bytes = Convert.FromBase64String(original);
                return Encoding.GetEncoding("ASCII").GetString(bytes);
            }
        }

        public class AES
        {
            private const string DEFAULT_KEY = "Hwx_2009";
            private static byte[] Keys = { 0x41, 0x72, 0x65, 0x79, 0x6F, 0x75, 0x6D, 0x79, 0x53, 0x6E, 0x6F, 0x77, 0x6D, 0x61, 0x6E, 0x3F };//AreyoumySnowman

            public static string Encrypt(string original)
            {
                return Encrypt(original, DEFAULT_KEY);
            }

            public static string Decrypt(string original)
            {
                return Decrypt(original, DEFAULT_KEY);
            }

            public static string Encrypt(string original, string key)
            {
                key = key.PadRight(32, ' ');

                RijndaelManaged rijndaelProvider = new RijndaelManaged();
                rijndaelProvider.Key = Encoding.UTF8.GetBytes(key.Substring(0, 32));
                rijndaelProvider.IV = Keys;
                ICryptoTransform rijndaelEncrypt = rijndaelProvider.CreateEncryptor();

                byte[] inputData = Encoding.UTF8.GetBytes(original);
                byte[] encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);

                return Convert.ToBase64String(encryptedData);
            }

            public static string Decrypt(string original, string key)
            {
                try
                {
                    key = key.PadRight(32, ' ');

                    RijndaelManaged rijndaelProvider = new RijndaelManaged();
                    rijndaelProvider.Key = Encoding.UTF8.GetBytes(key);
                    rijndaelProvider.IV = Keys;
                    ICryptoTransform rijndaelDecrypt = rijndaelProvider.CreateDecryptor();

                    byte[] inputData = Convert.FromBase64String(original);
                    byte[] decryptedData = rijndaelDecrypt.TransformFinalBlock(inputData, 0, inputData.Length);

                    return Encoding.UTF8.GetString(decryptedData);
                }
                catch
                {
                    return "";
                }
            }

        }

        public class DES
        {
            private const string DEFAULT_KEY = "Hwx_2009";

            #region public method
            public static string Encrypt(string original)
            {
                return Encrypt(original, DEFAULT_KEY);
            }

            public static string Decrypt(string original)
            {
                return Decrypt(original, DEFAULT_KEY);
            }

            public static string Encrypt(string original, string key)
            {
                byte[] buff = System.Text.Encoding.Default.GetBytes(original);
                byte[] kb = System.Text.Encoding.Default.GetBytes(key);

                return Convert.ToBase64String(Encrypt(buff, kb));
            }

            public static string Decrypt(string original, string key)
            {
                return Decrypt(original, key, System.Text.Encoding.Default);
            }

            public static string Decrypt(string encrypted, string key, Encoding encoding)
            {
                byte[] buff = Convert.FromBase64String(encrypted);
                byte[] kb = System.Text.Encoding.Default.GetBytes(key);
                return encoding.GetString(Decrypt(buff, kb));
            }

            #endregion

            #region private method
            private static byte[] MD5(byte[] str)
            {
                MD5CryptoServiceProvider hashMd5 = new MD5CryptoServiceProvider();
                byte[] keyHash = hashMd5.ComputeHash(str);

                hashMd5.Clear();
                hashMd5 = null;

                return keyHash;
            }

            private static byte[] Encrypt(byte[] original)
            {
                return Encrypt(original, Encoding.Default.GetBytes(DEFAULT_KEY));
            }

            private static byte[] Decrypt(byte[] original)
            {
                return Decrypt(original, Encoding.Default.GetBytes(DEFAULT_KEY));
            }

            private static byte[] Encrypt(byte[] original, byte[] key)
            {
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                des.Key = MD5(key);
                des.Mode = CipherMode.ECB;

                return des.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
            }

            private static byte[] Decrypt(byte[] encrypted, byte[] key)
            {
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                des.Key = MD5(key);
                des.Mode = CipherMode.ECB;

                return des.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
            }
            #endregion
        }

        public class RSA
        {

            //产生 RSA 的密钥
            public void RSAKey(out string xmlKeys, out string xmlPublicKey)
            {
                System.Security.Cryptography.RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                xmlKeys = rsa.ToXmlString(true);
                xmlPublicKey = rsa.ToXmlString(false);
            }

            #region 加密函数
            public string RSAEncrypt(string xmlPublicKey, string m_strEncryptString)
            {
                byte[] PlainTextBArray;
                byte[] CypherTextBArray;
                string Result;
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(xmlPublicKey);
                PlainTextBArray = (new UnicodeEncoding()).GetBytes(m_strEncryptString);
                CypherTextBArray = rsa.Encrypt(PlainTextBArray, false);
                Result = Convert.ToBase64String(CypherTextBArray);
                return Result;
            }

            public string RSAEncrypt(string xmlPublicKey, byte[] EncryptString)
            {
                byte[] CypherTextBArray;
                string Result;
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(xmlPublicKey);
                CypherTextBArray = rsa.Encrypt(EncryptString, false);
                Result = Convert.ToBase64String(CypherTextBArray);
                return Result;
            }
            #endregion

            #region 解密函数
            public string RSADecrypt(string xmlPrivateKey, string m_strDecryptString)
            {
                byte[] PlainTextBArray;
                byte[] DypherTextBArray;
                string Result;
                System.Security.Cryptography.RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(xmlPrivateKey);
                PlainTextBArray = Convert.FromBase64String(m_strDecryptString);
                DypherTextBArray = rsa.Decrypt(PlainTextBArray, false);
                Result = (new UnicodeEncoding()).GetString(DypherTextBArray);
                return Result;

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="xmlPrivateKey"></param>
            /// <param name="DecryptString"></param>
            /// <returns></returns>
            public string RSADecrypt(string xmlPrivateKey, byte[] DecryptString)
            {
                byte[] DypherTextBArray;
                string Result;
                System.Security.Cryptography.RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(xmlPrivateKey);
                DypherTextBArray = rsa.Decrypt(DecryptString, false);
                Result = (new UnicodeEncoding()).GetString(DypherTextBArray);
                return Result;

            }
            #endregion

            #region 获取Hash描述表
            /// <summary>
            /// 
            /// </summary>
            /// <param name="m_strSource"></param>
            /// <param name="HashData"></param>
            /// <returns></returns>
            public bool GetHash(string m_strSource, ref byte[] HashData)
            {
                //从字符串中取得Hash描述 
                byte[] Buffer;
                System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5");
                Buffer = System.Text.Encoding.GetEncoding("GB2312").GetBytes(m_strSource);
                HashData = MD5.ComputeHash(Buffer);

                return true;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="m_strSource"></param>
            /// <param name="strHashData"></param>
            /// <returns></returns>
            public bool GetHash(string m_strSource, ref string strHashData)
            {

                ////从字符串中取得Hash描述 
                byte[] Buffer;
                byte[] HashData;
                System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5");
                Buffer = System.Text.Encoding.GetEncoding("GB2312").GetBytes(m_strSource);
                HashData = MD5.ComputeHash(Buffer);

                strHashData = Convert.ToBase64String(HashData);
                return true;

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="objFile"></param>
            /// <param name="HashData"></param>
            /// <returns></returns>
            public bool GetHash(System.IO.FileStream objFile, ref byte[] HashData)
            {

                //从文件中取得Hash描述 
                System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5");
                HashData = MD5.ComputeHash(objFile);
                objFile.Close();

                return true;

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="objFile"></param>
            /// <param name="strHashData"></param>
            /// <returns></returns>
            public bool GetHash(System.IO.FileStream objFile, ref string strHashData)
            {

                //从文件中取得Hash描述 
                byte[] HashData;
                System.Security.Cryptography.HashAlgorithm MD5 = System.Security.Cryptography.HashAlgorithm.Create("MD5");
                HashData = MD5.ComputeHash(objFile);
                objFile.Close();

                strHashData = Convert.ToBase64String(HashData);

                return true;

            }
            #endregion

            #region RSA签名
            /// <summary>
            /// 
            /// </summary>
            /// <param name="p_strKeyPrivate"></param>
            /// <param name="HashbyteSignature"></param>
            /// <param name="EncryptedSignatureData"></param>
            /// <returns></returns>
            public bool SignatureFormatter(string p_strKeyPrivate, byte[] HashbyteSignature, ref byte[] EncryptedSignatureData)
            {

                System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();

                RSA.FromXmlString(p_strKeyPrivate);
                System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA);
                //设置签名的算法为MD5 
                RSAFormatter.SetHashAlgorithm("MD5");
                //执行签名 
                EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature);

                return true;

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="p_strKeyPrivate"></param>
            /// <param name="HashbyteSignature"></param>
            /// <param name="m_strEncryptedSignatureData"></param>
            /// <returns></returns>
            public bool SignatureFormatter(string p_strKeyPrivate, byte[] HashbyteSignature, ref string m_strEncryptedSignatureData)
            {

                byte[] EncryptedSignatureData;

                System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();

                RSA.FromXmlString(p_strKeyPrivate);
                System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA);
                //设置签名的算法为MD5 
                RSAFormatter.SetHashAlgorithm("MD5");
                //执行签名 
                EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature);

                m_strEncryptedSignatureData = Convert.ToBase64String(EncryptedSignatureData);

                return true;

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="p_strKeyPrivate"></param>
            /// <param name="m_strHashbyteSignature"></param>
            /// <param name="EncryptedSignatureData"></param>
            /// <returns></returns>
            public bool SignatureFormatter(string p_strKeyPrivate, string m_strHashbyteSignature, ref byte[] EncryptedSignatureData)
            {

                byte[] HashbyteSignature;

                HashbyteSignature = Convert.FromBase64String(m_strHashbyteSignature);
                System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();

                RSA.FromXmlString(p_strKeyPrivate);
                System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA);
                //设置签名的算法为MD5 
                RSAFormatter.SetHashAlgorithm("MD5");
                //执行签名 
                EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature);

                return true;

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="p_strKeyPrivate"></param>
            /// <param name="m_strHashbyteSignature"></param>
            /// <param name="m_strEncryptedSignatureData"></param>
            /// <returns></returns>
            public bool SignatureFormatter(string p_strKeyPrivate, string m_strHashbyteSignature, ref string m_strEncryptedSignatureData)
            {

                byte[] HashbyteSignature;
                byte[] EncryptedSignatureData;

                HashbyteSignature = Convert.FromBase64String(m_strHashbyteSignature);
                System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();

                RSA.FromXmlString(p_strKeyPrivate);
                System.Security.Cryptography.RSAPKCS1SignatureFormatter RSAFormatter = new System.Security.Cryptography.RSAPKCS1SignatureFormatter(RSA);
                //设置签名的算法为MD5 
                RSAFormatter.SetHashAlgorithm("MD5");
                //执行签名 
                EncryptedSignatureData = RSAFormatter.CreateSignature(HashbyteSignature);

                m_strEncryptedSignatureData = Convert.ToBase64String(EncryptedSignatureData);

                return true;

            }
            #endregion

            #region 签名验证
            /// <summary>
            /// 
            /// </summary>
            /// <param name="p_strKeyPublic"></param>
            /// <param name="HashbyteDeformatter"></param>
            /// <param name="DeformatterData"></param>
            /// <returns></returns>
            public bool SignatureDeformatter(string p_strKeyPublic, byte[] HashbyteDeformatter, byte[] DeformatterData)
            {

                System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();

                RSA.FromXmlString(p_strKeyPublic);
                System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA);
                //指定解密的时候HASH算法为MD5 
                RSADeformatter.SetHashAlgorithm("MD5");

                if (RSADeformatter.VerifySignature(HashbyteDeformatter, DeformatterData))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="p_strKeyPublic"></param>
            /// <param name="p_strHashbyteDeformatter"></param>
            /// <param name="DeformatterData"></param>
            /// <returns></returns>
            public bool SignatureDeformatter(string p_strKeyPublic, string p_strHashbyteDeformatter, byte[] DeformatterData)
            {

                byte[] HashbyteDeformatter;

                HashbyteDeformatter = Convert.FromBase64String(p_strHashbyteDeformatter);

                System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();

                RSA.FromXmlString(p_strKeyPublic);
                System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA);
                //指定解密的时候HASH算法为MD5 
                RSADeformatter.SetHashAlgorithm("MD5");

                if (RSADeformatter.VerifySignature(HashbyteDeformatter, DeformatterData))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="p_strKeyPublic"></param>
            /// <param name="HashbyteDeformatter"></param>
            /// <param name="p_strDeformatterData"></param>
            /// <returns></returns>
            public bool SignatureDeformatter(string p_strKeyPublic, byte[] HashbyteDeformatter, string p_strDeformatterData)
            {

                byte[] DeformatterData;

                System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();

                RSA.FromXmlString(p_strKeyPublic);
                System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA);
                //指定解密的时候HASH算法为MD5 
                RSADeformatter.SetHashAlgorithm("MD5");

                DeformatterData = Convert.FromBase64String(p_strDeformatterData);

                if (RSADeformatter.VerifySignature(HashbyteDeformatter, DeformatterData))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="p_strKeyPublic"></param>
            /// <param name="p_strHashbyteDeformatter"></param>
            /// <param name="p_strDeformatterData"></param>
            /// <returns></returns>
            public bool SignatureDeformatter(string p_strKeyPublic, string p_strHashbyteDeformatter, string p_strDeformatterData)
            {

                byte[] DeformatterData;
                byte[] HashbyteDeformatter;

                HashbyteDeformatter = Convert.FromBase64String(p_strHashbyteDeformatter);
                System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();

                RSA.FromXmlString(p_strKeyPublic);
                System.Security.Cryptography.RSAPKCS1SignatureDeformatter RSADeformatter = new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(RSA);
                //指定解密的时候HASH算法为MD5 
                RSADeformatter.SetHashAlgorithm("MD5");

                DeformatterData = Convert.FromBase64String(p_strDeformatterData);

                if (RSADeformatter.VerifySignature(HashbyteDeformatter, DeformatterData))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            #endregion
        }

        public class HashEncode
        {
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public static string HashEncoding()
            {
                string Security = HashEncoding(GetRandomValue());
                return Security;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public static string GetRandomValue()
            {
                Random Seed = new Random();
                string RandomVaule = Seed.Next(1, int.MaxValue).ToString();
                return RandomVaule;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="Security"></param>
            /// <returns></returns>
            public static string HashEncoding(string Security)
            {
                byte[] Value;
                UnicodeEncoding Code = new UnicodeEncoding();
                byte[] Message = Code.GetBytes(Security);
                SHA512Managed Arithmetic = new SHA512Managed();
                Value = Arithmetic.ComputeHash(Message);
                Security = "";
                foreach (byte o in Value)
                {
                    Security += (int)o + "O";
                }
                return Security;
            }
        }

        public class MD5
        {
            #region 加密

            /// <summary>
            /// 
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
            public static string Encode(string str)
            {
                return Encode(str, Digit.L32);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="str"></param>
            /// <param name="L"></param>
            /// <returns></returns>
            public static string Encode(string str, Digit L)
            {
                if (L == Digit.L16)
                {
                    return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 16);
                }
                else
                {
                    return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
                }
            }
            #endregion
        }
    }

    public enum Digit
    {
        /// <summary>
        /// L16 十六位
        /// </summary>
        L16,

        /// <summary>
        /// L32 三十二位
        /// </summary>
        L32
    }

}



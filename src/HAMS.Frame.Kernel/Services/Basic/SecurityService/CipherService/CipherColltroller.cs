﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace HAMS.Frame.Kernel.Services
{
    public class CipherColltroller : ICipherColltroller
    {
        /// <summary>
        /// DES加解密 密钥和向量必须为8字节数据
        /// </summary>
        static readonly byte[] desKeyBytes = Encoding.Default.GetBytes("s6|x*GB3");
        static readonly byte[] desIVBytes = Encoding.Default.GetBytes("Dw_R~L6o");

        /// <summary>
        /// AES加解密 密钥必须为16位(128位)、24位(192位)、32位(256位) 向量为16位
        /// </summary>
        static readonly byte[] aesKeyBytes = Encoding.Default.GetBytes("#>?q-j6T22Qv1H8u");
        static readonly byte[] aesIVBytes = Encoding.Default.GetBytes("m%95-6C)#^')8<TL");

        public string DataBaseConnectionStringEncrypt(string plainTextArg)
        {
            DESCryptoServiceProvider desCryptoSrvPrv = new DESCryptoServiceProvider();
            MemoryStream desMemStream = new MemoryStream();

            AesCryptoServiceProvider aesCryptoSrvPrv = new AesCryptoServiceProvider();
            MemoryStream aesMemStream = new MemoryStream();

            try
            {
                byte[] desTextArr = Encoding.Default.GetBytes(plainTextArg);
                CryptoStream desCryStream = new CryptoStream(desMemStream, desCryptoSrvPrv.CreateEncryptor(desKeyBytes, desIVBytes), CryptoStreamMode.Write);
                desCryStream.Write(desTextArr, 0, desTextArr.Length);
                desCryStream.FlushFinalBlock();
            }
            catch (Exception ex)
            {
                throw new CryptographicException(ex.Message, ex);
            }

            try
            {
                byte[] aesTextArr = desMemStream.ToArray();
                CryptoStream aesCryStream = new CryptoStream(aesMemStream, aesCryptoSrvPrv.CreateEncryptor(aesKeyBytes, aesIVBytes), CryptoStreamMode.Write);
                aesCryStream.Write(aesTextArr, 0, aesTextArr.Length);
                aesCryStream.FlushFinalBlock();
            }
            catch (Exception ex)
            {
                throw new CryptographicException(ex.Message, ex);
            }

            return Convert.ToBase64String(aesMemStream.ToArray());
        }

        public string DataBaseConnectionStringDecrypt(string cipherTextArg)
        {
            AesCryptoServiceProvider aesCryptoSrvPrv = new AesCryptoServiceProvider();
            MemoryStream aesMemStream = new MemoryStream();

            DESCryptoServiceProvider desCryptoSrvPrv = new DESCryptoServiceProvider();
            MemoryStream desMemStream = new MemoryStream();

            try
            {
                byte[] aesTextArr = Convert.FromBase64String(cipherTextArg);
                CryptoStream aesCryStream = new CryptoStream(aesMemStream, aesCryptoSrvPrv.CreateDecryptor(aesKeyBytes, aesIVBytes), CryptoStreamMode.Write);
                aesCryStream.Write(aesTextArr, 0, aesTextArr.Length);
                aesCryStream.FlushFinalBlock();
            }
            catch (Exception ex)
            {
                throw new CryptographicException(ex.Message, ex);
            }

            try
            {
                byte[] desTextArr = aesMemStream.ToArray();
                CryptoStream desCryStream = new CryptoStream(desMemStream, desCryptoSrvPrv.CreateDecryptor(desKeyBytes, desIVBytes), CryptoStreamMode.Write);
                desCryStream.Write(desTextArr, 0, desTextArr.Length);
                desCryStream.FlushFinalBlock();
            }
            catch (Exception ex)
            {
                throw new CryptographicException(ex.Message, ex);
            }

            return Encoding.Default.GetString(desMemStream.ToArray());
        }
    }
}

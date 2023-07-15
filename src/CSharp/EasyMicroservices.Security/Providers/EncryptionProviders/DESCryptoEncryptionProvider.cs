﻿using EasyMicroservices.Security.Interfaces;
using System;
using System.Security.Cryptography;

namespace EasyMicroservices.Security.Providers.EncryptionProviders
{
    /// <summary>
    /// 
    /// </summary>
    public class DESCryptoEncryptionProvider : BaseEncryptionProvider, IEncryptionProvider
    {
        private readonly DES _provider;
        /// <summary>
        /// 
        /// </summary>
        public DESCryptoEncryptionProvider(byte[] key)
        {
            _provider = DES.Create();
            Key = key;
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] Key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override byte[] Encrypt(byte[] data)
        {
            var keyAndIv = GenerateKeyAndIv(Key, 8, 8);
            _provider.Key = keyAndIv.Key;
            _provider.IV = keyAndIv.Iv;

            using (var encryptor = _provider.CreateEncryptor())
            {
                byte[] encryptedData = encryptor.TransformFinalBlock(data, 0, data.Length);
                byte[] result = new byte[keyAndIv.Iv.Length + encryptedData.Length];
                Buffer.BlockCopy(keyAndIv.Iv, 0, result, 0, keyAndIv.Iv.Length);
                Buffer.BlockCopy(encryptedData, 0, result, keyAndIv.Iv.Length, encryptedData.Length);
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptedData"></param>
        /// <returns></returns>
        public override byte[] Decrypt(byte[] encryptedData)
        {
            var keyAndIv = GenerateKeyAndIv(Key, 8, 8);
            _provider.Key = keyAndIv.Key;
            _provider.IV = keyAndIv.Iv;
            Buffer.BlockCopy(encryptedData, 0, keyAndIv.Iv, 0, keyAndIv.Iv.Length);
            byte[] data = new byte[encryptedData.Length - keyAndIv.Iv.Length];
            Buffer.BlockCopy(encryptedData, keyAndIv.Iv.Length, data, 0, data.Length);

            using (var decryptor = _provider.CreateDecryptor())
            {
                return decryptor.TransformFinalBlock(data, 0, data.Length);
            }
        }
    }
}

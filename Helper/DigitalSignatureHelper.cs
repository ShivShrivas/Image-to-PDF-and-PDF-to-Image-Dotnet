using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
namespace Dummy_Console_App.Helper
{
    internal class DigitalSignatureHelper
    {

        public static byte[] SignData(byte[] data, X509Certificate2 certificate)
        {
            // Get the private key from the certificate
            RSACryptoServiceProvider privateKey = (RSACryptoServiceProvider)certificate.PrivateKey;

            // Create a signature using the private key
            byte[] signature = privateKey.SignData(data, CryptoConfig.MapNameToOID("SHA256"));

            return signature;
        }

        public static bool VerifyData(byte[] data, byte[] signature, X509Certificate2 certificate)
        {
            // Get the public key from the certificate
            RSACryptoServiceProvider publicKey = (RSACryptoServiceProvider)certificate.PublicKey.Key;

            // Verify the signature using the public key
            bool isValid = publicKey.VerifyData(data, CryptoConfig.MapNameToOID("SHA256"), signature);

            return isValid;
        }

        public static void start()
        {
            try
            {
                byte[] signature;
                // Load the certificate from a PFX file
                string certificatePath = @"C:\\Users\\admin\\Downloads\\rkj_seil_capricorn.pfx";
                string certificatePassword = "rkjain";
                X509Certificate2 privateCert = new X509Certificate2(certificatePath, certificatePassword, X509KeyStorageFlags.Exportable);
                using (RSA privateKey = privateCert.GetRSAPrivateKey())
                {
                    byte[] data = Encoding.UTF8.GetBytes("Data to be signed");

                    // Sign the data using SHA256
                    signature = privateKey.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    var signData = Convert.ToBase64String(signature);
                    // Verify the signature

                    bool isValid = privateKey.VerifyData(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    Console.WriteLine("Is Signature Valid? " + isValid);
                }

                using (RSA publickey = privateCert.GetRSAPublicKey())
                {
                    byte[] data = Encoding.UTF8.GetBytes("Data to be signed");

                    bool isValid = publickey.VerifyData(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    Console.WriteLine("Is Signature Valid? " + isValid);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}


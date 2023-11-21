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
                byte[] data;
                // Load the certificate from a PFX file
                string certificatePath = @"C:\\Users\\admin\\Downloads\\rkj_seil_capricorn.pfx";
                string certificatePassword = "rkjain"; 
                X509Certificate2 privateCert = new X509Certificate2(certificatePath, certificatePassword, X509KeyStorageFlags.Exportable);
                using (RSA privateKey = privateCert.GetRSAPrivateKey())
                {
                     data = Encoding.UTF8.GetBytes("Data to be signedw");

                    // Sign the data using SHA256
                    signature = privateKey.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    var signData = Convert.ToBase64String(signature);
                    // Verify the signature

                    bool isValids = privateKey.VerifyData(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    Console.WriteLine("Is Signature Valid? " + isValids);
                }

                using (RSA publickey = privateCert.GetRSAPublicKey())
                {

                    data = Encoding.UTF8.GetBytes("Data to be signedw");

                    bool isValid = publickey.VerifyData(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                    Console.WriteLine("Is Signature Valid? " + isValid);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }


        public static void ditalSign()
    {
        string pfxFilePath = "D:\\cert\\rkj_seil_capricorn.pfx";
        string pfxPassword = "rkjain";

             X509Certificate2 certificate = new X509Certificate2(pfxFilePath, pfxPassword, X509KeyStorageFlags.Exportable);

        // Get the private key from the certificate
        using (RSA privateKey = certificate.GetRSAPrivateKey())
        {
            // Create data to sign
            string dataToSign = "Hello, this is tha tujhfufholuigo sign.";

            // Convert the data to bytes
            byte[] dataBytes = Encoding.UTF8.GetBytes(dataToSign);

            // Create an RSAPKCS1SignatureFormatter object and set the hashing algorithm to SHA-256
            RSAPKCS1SignatureFormatter signatureFormatter = new RSAPKCS1SignatureFormatter(privateKey);
            signatureFormatter.SetHashAlgorithm("SHA256");

            // Compute the signature
            byte[] signature = signatureFormatter.CreateSignature(dataBytes);

            Console.WriteLine("Digital Signature:");
            Console.WriteLine(Convert.ToBase64String(signature));

            // Verify the signature (optional)
            RSAPKCS1SignatureDeformatter signatureDeformatter = new RSAPKCS1SignatureDeformatter(privateKey);
            signatureDeformatter.SetHashAlgorithm("SHA256");

            bool signatureIsValid = signatureDeformatter.VerifySignature(dataBytes, signature);
            Console.WriteLine("Signature is valid: " + signatureIsValid);
        }
        }
    }
}


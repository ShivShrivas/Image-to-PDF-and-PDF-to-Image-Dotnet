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

        public static void Main(string[] args)
        {
            try
            {
                // Load the certificate from a PFX file
                string certificatePath = @"C:\\Users\\admin\\Desktop\\shivam.pfx";
                string certificatePassword = "shivam";
                X509Certificate2 certificate = new X509Certificate2(certificatePath, certificatePassword);

                // Data to be signed
                byte[] dataToSign = System.Text.Encoding.UTF8.GetBytes("Hello, this is the data to be signed.");

                // Create a digital signature
                byte[] signature = SignData(dataToSign, certificate);

                // Verification
                bool isValid = VerifyData(dataToSign, signature, certificate);
                Console.WriteLine("Signature Verification Result: " + isValid);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}


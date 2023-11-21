using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.OpenSsl;

namespace Dummy_Console_App.Helper
{
    internal class PublicKeyHelper
    {

        public static void getPublicKey() {

            string certificatePath = "D:\\publickeyKTK\\uatreqencryption.pem";
            X509Certificate2 certificate = new X509Certificate2(certificatePath);

            // Get BouncyCastle's representation of the certificate
            X509CertificateParser parser = new X509CertificateParser();
            Org.BouncyCastle.X509.X509Certificate bcCert = parser.ReadCertificate(certificate.GetRawCertData());

            // Get the public key from the certificate
            var rsaPublicKey = (RsaKeyParameters)bcCert.GetPublicKey();

            // Export the public key to a PEM file in Base64 format
            string publicKeyPemPath = "D:\\publickeyKTK\\uatreqencryptionpublicKey.pem";
            string publicKeyPem = ExportPublicKeyToPem(rsaPublicKey);

            File.WriteAllText(publicKeyPemPath, publicKeyPem);

            Console.WriteLine("Public key extracted and saved to publicKey.pem");
        }
        public static void getPrivateKey()
        {

            string certificatePath = "D:\\publickeyKTK\\uatreqencryption.pem";
            X509Certificate2 certificate = new X509Certificate2(certificatePath);

            // Get BouncyCastle's representation of the certificate
            X509CertificateParser parser = new X509CertificateParser();
            Org.BouncyCastle.X509.X509Certificate bcCert = parser.ReadCertificate(certificate.GetRawCertData());

            // Get the public key from the certificate
            var rsaPublicKey = (RsaKeyParameters)bcCert.GetPublicKey();

            // Export the public key to a PEM file in Base64 format
            string publicKeyPemPath = "D:\\publickeyKTK\\uatreqencryptionpublicKey.pem";
            string publicKeyPem = ExportPublicKeyToPem(rsaPublicKey);

            File.WriteAllText(publicKeyPemPath, publicKeyPem);

            Console.WriteLine("Public key extracted and saved to publicKey.pem");
        }

        static string ExportPublicKeyToPem(RsaKeyParameters publicKey)
        {
            StringWriter stringWriter = new StringWriter();
            PemWriter pemWriter = new PemWriter(stringWriter);
            pemWriter.WriteObject(publicKey);
            pemWriter.Writer.Flush();

            string pemString = stringWriter.ToString();
            string[] lines = pemString.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Constructing the PEM format with headers
          //  string publicKeyPem = "-----BEGIN PUBLIC KEY-----\n";
            string publicKeyPem = string.Join("\n", lines) + "\n";
          //  publicKeyPem += "-----END PUBLIC KEY-----\n";

            return publicKeyPem;
        }

    }
}

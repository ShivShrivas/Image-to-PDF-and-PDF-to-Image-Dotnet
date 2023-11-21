using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.IO;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;

namespace Dummy_Console_App.Helper
{
    internal class ImageConverterHelper
    {

       public static void hexToBytes()
        {
            string hexData = "0x255044462D312E370A25B7BEADAA0A312030206F626A0A3C3C0A2F54797065202F436174616C6F670A2F50616765732032203020520A3E3E0A656E646F626A0A322030206F626A0A3C3C0A2F54797065202F50616765730A2F4B696473205B2034203020522031312030205220313820302052205D0A2F436F756E7420330A3E3E0A656E646F626A0A332030206F626A0A";

            // Remove "0x" from the hex string
            hexData = hexData.Replace("0x", "");

            // Convert the hex string to bytes
            byte[] data = StringToByteArray(hexData);

            // Create a MemoryStream from the bytes
            using (MemoryStream ms = new MemoryStream(data))
            {
                // Create an image from the MemoryStream
                Image image = Image.FromStream(ms);

                // Save the image to a file (you can change the format as needed)
                image.Save("D:\\dummy\\output.png", ImageFormat.Png);
            }
        }

        // Helper method to convert a hex string to a byte array
        static byte[] StringToByteArray(string hex)
        {
            int length = hex.Length;
            byte[] bytes = new byte[length / 2];
            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        public  static void convertFileToHex()
        {
            string filePath = "D:\\dummy\\2.png"; // Replace with the path to your file
            string hexFilePath = "D:\\dummy\\output_hex.txt"; // Replace with the desired output file path
            
            try
            {
                
                

                // Read the file into a byte array
                byte[] fileBytes = File.ReadAllBytes(filePath);

                // Convert the byte array to a hexadecimal string
                string hexString = BitConverter.ToString(fileBytes).Replace("-", "");

                // Write the hexadecimal string to a file
                File.WriteAllText(hexFilePath, hexString, Encoding.ASCII);

                Console.WriteLine("File converted to hex and saved as " + hexFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }



    
}





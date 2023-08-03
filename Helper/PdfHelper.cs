using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using iTextSharp.text;
using Image = iTextSharp.text.Image;
using PdfiumViewer;
using System.Drawing.Imaging;
using PdfDocument = PdfiumViewer.PdfDocument;

namespace Dummy_Console_App.Helper
{
    internal class PdfHelper
    {
        public static PdfHelper Instance { get; } = new PdfHelper();



        internal void SaveImageAsPdf(string imageFileName, string pdfFileName, int width = 600, bool deleteImage = false)
        {
            // Load the image
            Document doc = new Document();

            try
            {
                // Create a new PdfWriter instance to write the PDF
                PdfWriter.GetInstance(doc, new FileStream(pdfFileName, FileMode.Create));

                // Open the document for writing
                doc.Open();

                // Read the image from the file
                Image image = Image.GetInstance(imageFileName);

                // Set the image scale to fit the PDF page
                image.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);

                // Add the image to the document
                doc.Add(image);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Close the document after writing
                doc.Close();
                Console.WriteLine("file crreated succesfully!!");
            }
        }


        internal void SavePdfAsImage() {


            var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            try
            {
                using (var document = PdfDocument.Load(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\net6.0\\", "") + "files\\Saksham.pdf"))
                {
                    var pageCount = document.PageCount;

                    for (int i = 0; i < pageCount; i++)
                    {
                        var dpi = 300;

                        using (var image = document.Render(i, dpi, dpi, PdfRenderFlags.CorrectFromDpi))
                        {
                            var encoder = ImageCodecInfo.GetImageEncoders()
                                .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                            var encParams = new EncoderParameters(1);
                            encParams.Param[0] = new EncoderParameter(
                                System.Drawing.Imaging.Encoder.Quality, 100L);

                            image.Save(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\net6.0\\", "") + "files\\outputs_" + i + ".jpg", encoder, encParams);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press enter to continue...");

        }

    }




    }
   


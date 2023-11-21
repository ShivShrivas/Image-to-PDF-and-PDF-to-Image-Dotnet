using Azure.AI.Vision.Common;
using Azure.AI.Vision.ImageAnalysis;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf.parser;

namespace Dummy_Console_App.Helper
{
    internal class AzureCoginetiveHelper
    {
        //public static byte[] ReadImageFile()
        //{
        //    string imageLocation = "C:\\Users\\admin\\Downloads\\image.jpeg";

        //    byte[] imageData = null;
        //    FileInfo fileInfo = new FileInfo(imageLocation);
        //    long imageFileLength = fileInfo.Length;
        //    FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
        //    BinaryReader br = new BinaryReader(fs);
        //    imageData = br.ReadBytes((int)imageFileLength);
        //    Console.WriteLine(" Caption:" + Convert.ToBase64String(imageData));

        //    return imageData;
        //}
        public static void AnalyzeImage()
        {
            string visionEnpoint = "https://paisalocognitive.cognitiveservices.azure.com/";
            string VISION_KEY = "49706634dccd4a7ea760b885d74b98a0";
            var serviceOptions = new VisionServiceOptions(visionEnpoint,
                new AzureKeyCredential(VISION_KEY));

          //  using var imageSource = VisionSource.FromUrl(
               // Uri("https://i.pinimg.com/550x/2f/71/8a/2f718a069d9fa7dbc14cb87f099c6b3f.jpg"));
            
            using var imageSource = VisionSource.FromFile("C:\\Users\\admin\\Downloads\\test4.png");


            var analysisOptions = new ImageAnalysisOptions()
            {
                Features = ImageAnalysisFeature.Caption | ImageAnalysisFeature.Text,

                Language = "en",

                GenderNeutralCaption = true
            };

            using var analyzer = new ImageAnalyzer(serviceOptions, imageSource, analysisOptions);

            var result = analyzer.Analyze();

            if (result.Reason == ImageAnalysisResultReason.Analyzed)
            {
                //if (result.Caption != null)
                //{
                //    Console.WriteLine(" Caption:");
                //    Console.WriteLine($"   \"{result.Caption.Content}\", Confidence {result.Caption.Confidence:0.0000}");
                //}

                if (result.Text != null)
                                    {
                    ////////////////////Pan Card(Name,Father Name,DOB)////////
                    //for (int i = 0; i < result.Text.Lines.Count; i++)
                    //{
                    //    //Console.WriteLine($" Line: '{result.Text.Lines[i].Content}'");

                    //    //string pointsToString = "{" + string.Join(',', line.BoundingPolygon.Select(pointsToString => pointsToString.ToString())) + "}";
                    //    if (result.Text.Lines[i].Content.Contains("GOVT. OF INDIA"))
                    //    {
                    //        Console.WriteLine($" Name: '{result.Text.Lines[i + 1].Content}'");
                    //        Console.WriteLine($" Father Name: '{result.Text.Lines[i + 2].Content}'");
                    //        Console.WriteLine($" Date of Birth: '{result.Text.Lines[i + 3].Content}'");
                    //    }
                    //    if (result.Text.Lines[i].Content.Contains("Permanent Account Number"))
                    //    {
                    //        Console.WriteLine($" PAN No.: '{result.Text.Lines[i + 1].Content}'");

                    //    }

                    //}




                    ////////////////Data Fetching for adhar/////////
                    //for (int i = 0; i < result.Text.Lines.Count; i++)
                    //{
                    //    //Console.WriteLine($" line: '{result.Text.Lines[i].Content}'");

                    //    //string pointsToString = "{" + string.Join(',', line.BoundingPolygon.Select(pointsToString => pointsToString.ToString())) + "}";
                    //    if (result.Text.Lines[i].Content.Contains("Government of India"))
                    //    {
                    //        Console.WriteLine($" line: '{result.Text.Lines[i + 2].Content}'");
                    //        Console.WriteLine($" Name: '{result.Text.Lines[i + 2].Content}'");
                    //        Console.WriteLine($" Date of Birth: '{result.Text.Lines[i + 3].Content.Split(" / ")[1].Split(" : ")[1]}'");
                    //        Console.WriteLine($" Gender: '{result.Text.Lines[i + 4].Content.Split(" / ")[1]}'");
                    //        Console.WriteLine($" Adhar Id: '{result.Text.Lines[i + 5].Content}'");

                    //    }
                    //}


                    ////////////////Data Fetching for adhar back/////////
                    //for (int i = 0; i < result.Text.Lines.Count; i++)
                    //{
                    //    //Console.WriteLine($" line: '{result.Text.Lines[i].Content}'");

                    //    //string pointsToString = "{" + string.Join(',', line.BoundingPolygon.Select(pointsToString => pointsToString.ToString())) + "}";
                    //    if (result.Text.Lines[i].Content.Contains("Address:"))
                    //    {
                    //        Console.WriteLine($" Address: '{result.Text.Lines[i + 2].Content}'");
                    //        Console.WriteLine($" Address: '{result.Text.Lines[i + 4].Content}'");
                    //        Console.WriteLine($" Address: '{result.Text.Lines[i + 5].Content}'");
                    //        Console.WriteLine($" Adhar Id: '{result.Text.Lines[i + 6].Content}'");

                    //    }
                    //}


                    ////////////////Data Fetching for Voter Id/////////

                    //for (int i = 0; i < result.Text.Lines.Count; i++)
                    //{
                    //    //string pointsToString = "{" + string.Join(',', line.BoundingPolygon.Select(pointsToString => pointsToString.ToString())) + "}";
                    //    if (result.Text.Lines[i].Content.Contains("IDENTITY CARD"))
                    //    {
                    //        Console.WriteLine($" Voter Id: '{result.Text.Lines[i + 1].Content}'");

                    //    }

                    //    if (result.Text.Lines[i].Content.Contains("Elector's Name"))
                    //    {
                    //        Console.WriteLine($" Voter Name: '{result.Text.Lines[i + 1].Content}'");

                    //    }
                    //}



                    ////////////////Data matching for Adhar/////////
                    //for (int i = 0; i < result.Text.Lines.Count; i++)
                    //{
                    //    //Console.WriteLine($" line: '{result.Text.Lines[i].Content}'");

                    //    //string pointsToString = "{" + string.Join(',', line.BoundingPolygon.Select(pointsToString => pointsToString.ToString())) + "}";
                    //    if (result.Text.Lines[i].Content.Contains("Opeen Kumar"))
                    //    {
                    //        Console.WriteLine($" line:Name matched '{result.Text.Lines[i].Content}'");

                    //    }

                    //    if (result.Text.Lines[i].Content.Replace(" ","").Contains("820135121693"))
                    //    {
                    //        Console.WriteLine($" line:Adhar Id matched '{result.Text.Lines[i].Content}'");

                    //    } 
                    //    if (result.Text.Lines[i].Content.Replace(" ","").Contains("10/08/1990"))
                    //    {
                    //        Console.WriteLine($" line:DOB matched '{result.Text.Lines[i].Content.Split(" / ")[1]}'");

                    //    }
                    //}

                    //////////Data matcing for OSV
                    //for (int i = 0; i < result.Text.Lines.Count; i++)
                    //{
                    //    //Console.WriteLine($" line: '{result.Text.Lines[i].Content}'");
                    //    Console.WriteLine($"'{result.Text.Lines[i].Content}'");

                    //    //string pointsToString = "{" + string.Join(',', line.BoundingPolygon.Select(pointsToString => pointsToString.ToString())) + "}";
                    //    if (result.Text.Lines[i].Content.ToLower().Contains("original seen and verified"))
                    //    {
                    //        Console.WriteLine($" line:OSV stamp matched '{result.Text.Lines[i].Content}'");

                    //    }

                    //    if (result.Text.Lines[i].Content.ToLower().Contains("for paisalo digital limited"))
                    //    {
                    //        Console.WriteLine($" line:paisalo digital limited name matched'{result.Text.Lines[i].Content}'");

                    //    }

                    //}


                    //////////Data matcing for Voterid
                    //for (int i = 0; i < result.Text.Lines.Count; i++)
                    //{
                    //    //Console.WriteLine($" line: '{result.Text.Lines[i].Content}'");


                    //    //string pointsToString = "{" + string.Join(',', line.BoundingPolygon.Select(pointsToString => pointsToString.ToString())) + "}";
                    //    if (result.Text.Lines[i].Content.ToLower().Contains("rambeti"))
                    //    {
                    //        Console.WriteLine($" line: '{result.Text.Lines[i].Content}'");

                    //    }

                    //    if (result.Text.Lines[i].Content.ToLower().Contains("up/73/356/660080"))
                    //    {
                    //        Console.WriteLine($"line:paisalo digital limited name matched'{result.Text.Lines[i].Content}'");

                    //    }

                    //}

                    foreach (var line in result.Text.Lines)
                    {
                        //string pointsToString = "{" + string.Join(',', line.BoundingPolygon.Select(pointsToString => pointsToString.ToString())) + "}";
                        string pointstostring = "{" + string.Join(',', line.BoundingPolygon.Select(pointstostring => pointstostring.ToString())) + "}";
                        Console.WriteLine($"   line: '{line.Content}'");

                        foreach (var word in line.Words)
                        {
                            pointstostring = "{" + string.Join(',', word.BoundingPolygon.Select(pointstostring => pointstostring.ToString())) + "}";
                            Console.WriteLine($"     word: '{word.Content}', bounding polygon {pointstostring}, confidence {word.Confidence:0.0000}");
                        }
                    }
                }
            }
            else
            {
                var errorDetails = ImageAnalysisErrorDetails.FromResult(result);
                Console.WriteLine(" Analysis failed.");
                Console.WriteLine($"   Error reason : {errorDetails.Reason}");
                Console.WriteLine($"   Error code : {errorDetails.ErrorCode}");
                Console.WriteLine($"   Error message: {errorDetails.Message}");
            }
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;
using System.Net;
using iTextSharp.text.pdf;

namespace testSPReadFile
{

    class SpRead
    {
        public static string countFilePages(string siteUrl, string folderUrl)
        {
            try
            {


                using (SPSite site = new SPSite(siteUrl))
                {
                    using (SPWeb web = site.OpenWeb())
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\sp_admin\Documents\Visual Studio 2013\Projects\testSPReadFile\testSPReadFile\rsaForm.txt", true))
                    {
                        //get folder
                        SPFolder folder = web.GetFolder(folderUrl);
                        int count = 0;
                        int pages = 0;
                        /*while (count < 30)
                        {
                            Console.WriteLine(count.ToString() + " :");
                            count++;
                        }*/
                        /*foreach (SPFile file in folder.Files)
                        {
                            Console.WriteLine(file.Name);
                            Stream stream = file.OpenBinaryStream();
                            //StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                            PdfReader pdf = new PdfReader(stream);
                            Console.WriteLine(pdf.NumberOfPages);
                            pages += pdf.NumberOfPages;
                            count++;
                        }*/
                        sw.WriteLine("S/N|" + "Pdf File Name|" + "Pdf file number of pages|" + "Pdf File Date Created");
                        for (int i = 0; i < folder.Files.Count; i++)
                        {
                            SPFile f = folder.Files[i];
                            Stream stream = f.OpenBinaryStream();
                            PdfReader pdf = new PdfReader(stream);
                            sw.WriteLine(i + "|"+f.Name + "|" + pdf.NumberOfPages + "|" + f.TimeCreated.ToString());
                            Console.WriteLine("Docs " + i.ToString() + " with Pages " + pdf.NumberOfPages.ToString());
                        }
                        Console.WriteLine(pages);
                        Console.WriteLine(count);
                        //get list of items in folder to grant permission to
                        //SPFileCollection folderFiles = folder.Files;
                    }
                }
               return folderUrl;                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

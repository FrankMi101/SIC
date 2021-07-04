using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
namespace BLL
{
    public class RenderDocuments
    {
        public static void RenderDocument(string _reportName, string _reportFormat, List<ListOfSelected> myList)
        {
            try
            {
                Byte[] myDoc;

                if (myList.Count == 1) myDoc = GeneratePDFReport.GetOneReport(_reportName, myList[0]); 
                else  myDoc = GeneratePDFReport.GetMultipleReports(_reportName, _reportFormat, myList);  

                ShowDocument.Show(_reportName, _reportFormat, myDoc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SaveDocuments(string _reportName, string _reportFormat, List<ListOfSelected> myList)
        {
            foreach (var item in myList)
            {
                if (item.ObjID != "")
                {
                    try
                    {
                        Byte[] myPDF;
                        myPDF = GeneratePDFReport.GetOneReport(_reportName, item); //  item => ListOfSelected
                        string fileName = _reportName + " " + item.SchoolYear + " " + item.ObjID + " " + item.ObjNo + "." + _reportFormat;
                        string filePath = "C:Temp/" + _reportName;

                        SaveDocumentToFile(myPDF, fileName, filePath);
                    }
                    catch { }
                }
            }
        }
        private static void SaveDocumentToFile(Byte[] pdfDocument, string fileName, string filePath)
        {

            fileName = fileName.Replace(@"\", "");
            fileName = fileName.Replace("/", "");
            fileName = fileName.Replace("`", "");
            fileName = fileName.Replace("'", "");
            // fileName = filePath + @"\" + fileName; 
            var goFile = Path.Combine(filePath, fileName);
            try
            {
                if (!Directory.Exists(filePath))
                { System.IO.Directory.CreateDirectory(filePath); }
                else
                {
                    if (System.IO.File.Exists(goFile))
                    { System.IO.File.Delete(goFile); }

                    var objFileStream = new FileStream(goFile, FileMode.Create);
                    var objBinaryWriter = new BinaryWriter(objFileStream);
                    objBinaryWriter.Write(pdfDocument);
                    objBinaryWriter.Close();
                    objFileStream.Close();
                }
            }
            catch (Exception ex)
            {
                var mes = ex.Message;
            }


        }
    }
    public class ShowDocument
    {
        public static void Show(string _reportName, string _reportFormat, byte[] pdffile)
        {
            try
            {
                HttpContext.Current.Response.AppendHeader("content-disposition", "filename=" + _reportName + "." + _reportFormat);
                HttpContext.Current.Response.ContentType = getReportContentType(_reportFormat);
                HttpContext.Current.Response.OutputStream.Write(pdffile, 0, pdffile.GetLength(0));
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                string showmsg = ex.Message;
            }
        }
        private static string getReportContentType(string _reportFormat)
        {
            switch (_reportFormat)
            {
                case "PDF":
                    return "application/pdf";
                case "CSV":
                    return "application/csv";
                case "EXCEL":
                    return "application / vnd.ms - excel";
                case "IMAGE":
                    return "image/tiff";
                case "HTML":
                    return "application/html";
                case "XML":
                    return "application/xml";
                default:
                    return "application/pdf";
            }
        }

    }
}

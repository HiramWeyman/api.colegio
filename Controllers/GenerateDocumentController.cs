using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Xceed.Words.NET;
using System.Web.Hosting;
using Xceed.Document.NET;

//using System.Drawing;

namespace api.colegio.Controllers
{
    public class GenerateDocumentController : Controller
    {
        public ActionResult GenerateDocument()
        {
            return View();
        }


  
        [HttpGet]
        public void GenerateDocument(string gen)
        {
            DocX document = null;
            byte[] buffer;
            //document = DocX.Create(Server.MapPath("~/mydoc.docx"), DocumentTypes.Document);
            document = DocX.Create(HostingEnvironment.MapPath("~/mydoc.docx"), DocumentTypes.Document);
            //Image img = document.AddImage(Server.MapPath("~/Images/mvc.png"));
            Image img = document.AddImage(HostingEnvironment.MapPath("~/Images/mvc.png"));

            Picture pic = img.CreatePicture(100, 100);


            Paragraph picturepara = document.InsertParagraph();
            picturepara.Alignment = Alignment.center;
            // picturepara.Append("                                ");
            picturepara.AppendPicture(pic).Alignment = Alignment.center;

            var headLineFormat = new Formatting();
            headLineFormat.FontFamily = new Font("Arial Black");
/*      headLineFormat.FontFamily = new FontFamily("Arial Black")*/;
            headLineFormat.Size = 18D;
            headLineFormat.Position = 12;

            string headlineText = "What is Lorem Ipsum?";
            document.InsertParagraph(headlineText, false, headLineFormat);

            var paraFormat = new Formatting();
            //paraFormat.FontFamily = new System.Drawing.FontFamily("Calibri");
            paraFormat.FontFamily = new Font("Calibri");

            paraFormat.Size = 11.0f;
            paraFormat.CapsStyle = CapsStyle.none;



            string p1TExt = @"Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean. A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country.";
            document.InsertParagraph(p1TExt, false, paraFormat).Alignment = Alignment.both;
            document.InsertParagraph(" ");

            string p2Text = @"Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic life One day however a small line of blind text by the name of Lorem Ipsum decided to leave for the far World of Grammar. The Big Oxmox advised her not to do so, because there were thousands of bad Commas, wild Question Marks and devious Semikoli, but the Little Blind Text didn’t listen. She packed her seven versalia, put her initial into the belt and made herself on the way. When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown Bookmarksgrove, the headline of Alphabet Village and the subline of her own road, the Line Lane. Pityful a rethoric question ran over her cheek, then";
            document.InsertParagraph(p2Text, false, paraFormat).Alignment = Alignment.both;
            document.InsertParagraph(" ");

            Table tbl = document.AddTable(5, 4);
            tbl.Alignment = Alignment.center;
            tbl.Design = TableDesign.LightGridAccent2;

            tbl.Rows[0].Cells[0].Paragraphs.First().Append("Name");
            tbl.Rows[0].Cells[1].Paragraphs.First().Append("Father Name");
            tbl.Rows[0].Cells[2].Paragraphs.First().Append("Address");
            tbl.Rows[0].Cells[3].Paragraphs.First().Append("Phone");

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    tbl.Rows[i].Cells[j].Paragraphs.First().Append("(" + i + "," + j + ")");
                }
            }
            document.InsertTable(tbl);

            // For  Farsi, Arabic and Urdu.
            // document.SetDirection(Direction.RightToLeft); 

            document.Save();

           // HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);
            MemoryStream ms = new MemoryStream();
            document.SaveAs(ms);
            // document.Save(ms, SaveFormat.Docx);
            byte[] byteArray = ms.ToArray();
            ms.Flush();
            ms.Close();
            ms.Dispose();
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=report.docx");
            Response.AddHeader("Content-Length", byteArray.Length.ToString());
            Response.ContentType = "application/msword";
            Response.BinaryWrite(byteArray);
            Response.End();
            
        }

    }
}
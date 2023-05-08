//Load the PDF document
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using System.IO;

//Load the PDF document
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);
//Load an existing PDF document 
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Iterates the attachments 
foreach (PdfAttachment attachment in loadedDocument.Attachments)
{
    //Extracts the attachment and saves it to the disk 
    FileStream s = new FileStream(attachment.FileName, FileMode.Create);
    s.Write(attachment.Data, 0, attachment.Data.Length);
    s.Dispose();
}

//Close the PDF document. 
loadedDocument.Close(true);

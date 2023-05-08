using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

//Creates an attachment
Stream fileStream = new FileStream("../../../Input.txt", FileMode.Open, FileAccess.Read);
PdfAttachment attachment = new PdfAttachment("Input.txt", fileStream);
attachment.ModificationDate = DateTime.Now;
attachment.Description = "Input.txt";
attachment.MimeType = "application/txt";

if (loadedDocument.Attachments == null)
    loadedDocument.CreateAttachment();
//Add the attachment to the document
loadedDocument.Attachments.Add(attachment);

//Save the document into stream
MemoryStream stream = new MemoryStream();
loadedDocument.Save(stream);
File.WriteAllBytes("../../../Output.pdf",stream.ToArray());
loadedDocument.Close(true);
stream.Close();
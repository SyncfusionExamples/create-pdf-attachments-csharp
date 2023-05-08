using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

PdfAttachmentCollection attachments = loadedDocument.Attachments;
attachments.RemoveAt(0);
attachments.Remove(attachments[0]);
attachments.Clear();

//Save the document into stream
MemoryStream stream = new MemoryStream();
loadedDocument.Save(stream);
File.WriteAllBytes("../../../Output.pdf", stream.ToArray());
loadedDocument.Close();
stream.Close();
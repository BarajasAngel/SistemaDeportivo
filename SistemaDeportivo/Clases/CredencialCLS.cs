using iTextSharp.text;
using iTextSharp.text.pdf;
using SistemaDeportivo.Models;
using System.IO;
using System.Linq;

namespace SistemaDeportivo.Clases
{
    public class CredencialCLS
    {
        General generic = new General();
        public FileStream credencial()
        {
            string usuario;
            using (SistemaDeportivoDBContext db = new SistemaDeportivoDBContext())
            {
                var getAlumno = db.Alumnos.Where(x =>
                    x.IdAlumno == generic.IdAlumno).First();
                var getDeporte = db.Deporte.Where(x =>
                    x.IdDeporte == getAlumno.IdDeporte).First();
                var getProfesor = db.Profesores.Where(x => x.IdDeporte == getDeporte.IdDeporte).First();
                var getUSuario = db.Usuarios.Where(x => x.IdUsuario == getAlumno.IdUsuario).First();
                usuario = getUSuario.Usuario;

                bool comprobar = File.Exists(usuario + ".pdf");

                if (comprobar)
                {
                    File.Delete(usuario + ".pdf");
                }
                //Creamos un nuevo documento y lo definimos como PDF
                FileStream stream = new FileStream(getUSuario.Usuario + ".pdf", FileMode.Create);
                Document pdfDoc = new Document(PageSize.A5.Rotate(), 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);


                Font letra2 = new Font(Font.FontFamily.COURIER, 12, Font.BOLD, BaseColor.BLACK);

                pdfDoc.Open();

                PdfContentByte cb = writer.DirectContentUnder;
                Image imagen = Image.GetInstance("http://drive.google.com/uc?export=view&id=1OQOU-mB-0Knh-cU1MY7SKwvqvhBjwyA8");
                imagen.SetAbsolutePosition(0f, 0f);
                cb.AddImage(imagen);


                iTextSharp.text.Image logo1 = iTextSharp.text.Image.GetInstance("https://multipress.com.mx/wp-content/uploads/2020/04/ipn.jpg");
                logo1.ScalePercent(11);

                logo1.SetAbsolutePosition(23, 300);
                pdfDoc.Add(logo1);
                iTextSharp.text.Image logo2 = iTextSharp.text.Image.GetInstance("https://www.cecyt13.ipn.mx/assets/files/cecyt13/img/Inicio/banderin.png");
                logo2.ScalePercent(25);

                logo2.SetAbsolutePosition(490, 300);
                pdfDoc.Add(logo2);


                pdfDoc.Add(new Paragraph("Instituto Politécnico Nacional", letra2) { Alignment = Element.ALIGN_CENTER });
                pdfDoc.Add(new Paragraph("Centro de Estudios Científicos y Tecnológicos No.13", letra2) { Alignment = Element.ALIGN_CENTER });
                pdfDoc.Add(new Paragraph("Ricardo Flores Magón", letra2) { Alignment = Element.ALIGN_CENTER });
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(new Paragraph("Credencial Deportiva", letra2) { Alignment = Element.ALIGN_CENTER });
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(Chunk.NEWLINE);
                PdfPTable tabl1 = new PdfPTable(2);
                tabl1.WidthPercentage = 100;
                PdfPCell fila1 = new PdfPCell(new Phrase("Alumno: " + getAlumno.ApellidoPat + " " + getAlumno.ApellidoMat + " " + getAlumno.Nombre, letra2));
                fila1.BorderWidth = 0;
                tabl1.AddCell(fila1);
                PdfPCell fila2 = new PdfPCell(new Phrase("Boleta:" + generic.Usuario, letra2));
                fila2.BorderWidth = 0;
                tabl1.AddCell(fila2);
                pdfDoc.Add(tabl1);

                PdfPTable tabl2 = new PdfPTable(2);
                tabl2.WidthPercentage = 100;
                PdfPCell fila11 = new PdfPCell(new Phrase("Profesor: " + getProfesor.Nombre, letra2));
                fila11.BorderWidth = 0;
                PdfPCell fila22 = new PdfPCell(new Phrase("Deporte:" + getDeporte.NombreDeporte, letra2));
                fila22.BorderWidth = 0;
                tabl2.AddCell(fila11);
                tabl2.AddCell(fila22);
                pdfDoc.Add(tabl2);
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(Chunk.NEWLINE);

                pdfDoc.Close();
                writer.Close();
                stream.Close();
            }
            FileStream abrir = new FileStream(usuario + ".pdf", FileMode.Open);

            return abrir;
        }
    }
}

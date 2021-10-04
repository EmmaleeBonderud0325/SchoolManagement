
using iTextSharp.text;
using iTextSharp.text.pdf;
using SchoolManagement.ViewModel.Lesson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ViewModel.Report
{
    public class StudentReport
    {
        #region Declaration
        int _totalColumn = 3;
        Document _document;
        Font _fontStyle;
        iTextSharp.text.pdf.PdfPTable _pdfPTable = new PdfPTable(3);
        iTextSharp.text.pdf.PdfPCell _pdfPCell;
        MemoryStream _memoryStream = new MemoryStream();
        List<StudentReportViewModel> _students = new List<StudentReportViewModel>();
        #endregion
       
        public byte[] PrepareReport(List<StudentReportViewModel> response)
        {
            _students = response;

            #region
            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfPTable.WidthPercentage = 100;
            _pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("TimesNewRoman", 8f, 1);

            iTextSharp.text.pdf.PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfPTable.SetWidths(new float[] { 20f, 150f, 100f });
            #endregion

            this.ReportHeader();
            this.ReportBody();
            _pdfPTable.HeaderRows = 2;
            _document.Add(_pdfPTable);
            _document.Close();
            return _memoryStream.ToArray();

        }

        private void ReportHeader()
        {
            _fontStyle = FontFactory.GetFont("TimesNewRoman", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Student Marks Report", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("TimesNewRoman", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Student List", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();
        }

        private void ReportBody()
        {
            #region Table header
            _fontStyle = FontFactory.GetFont("TimesNewRoman", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Question ID", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPTable.AddCell(_pdfPCell);

           
            _pdfPCell = new PdfPCell(new Phrase("Student Name", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Student Answer", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();
            #endregion

            #region Table Body
            _fontStyle = FontFactory.GetFont("TimesNewRoman", 11f, 0);
            foreach (StudentReportViewModel vm in _students)
            {
                _pdfPCell = new PdfPCell(new Phrase(vm.StudentId.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                _pdfPTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(vm.StudentName, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                _pdfPTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(vm.Marks.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                _pdfPTable.AddCell(_pdfPCell);
                _pdfPTable.CompleteRow();
            }
            #endregion

        }


    }
}
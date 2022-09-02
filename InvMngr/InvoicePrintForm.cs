using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace InvMngr
{
    public partial class InvoicePrintForm : Form
    {
        public InvoicePrintForm()
        {
            InitializeComponent();
        }

        public object[] Reference;

        private OleDbDataReader reader;

        private object[] previousValues;
        private object[] values;
        private object[] nextValues;

        bool nextAvailable;
        bool endOfFile;

        private void openData()
        {
            string parameters = "";
            foreach (string s in Reference)
            {
                if (parameters != "") parameters += ", ";
                parameters += "?";
            }

            reader = Common.Application.Database.ExecuteReader(
                "SELECT " +
                    "Logo, CompanyName, CompanyLine1, CompanyLine2, CompanyLine3, CompanyLine4, InvoiceFooter, CurrencySymbol, " +
                    "Invoice.Reference, Date, Notes, " +
                    "Code, Name, Address1, Address2, Address3, " +
                    "ShipTo1, ShipTo2, ShipTo3, ShipTo4, Value, Discount, SubTotal, InvoiceB.Tax, Shipping, Total, " +
                    "LineType, InvoiceLine.Description, UnitPrice, InvoiceLine.Tax, Quantity, " +
                    "Amount " +
                "FROM ((((Invoice " +
                "INNER JOIN System ON System.Dummy = Invoice.Dummy) " +
                "INNER JOIN Customer ON Customer.Code = Invoice.Customer) " +
                "INNER JOIN InvoiceB ON InvoiceB.Reference = Invoice.Reference) " +
                "LEFT JOIN InvoiceLine ON InvoiceLine.Invoice = Invoice.Reference) " +
                "LEFT JOIN InvoiceLineB ON InvoiceLineB.Invoice = InvoiceLine.Invoice AND InvoiceLineB.LineNo = InvoiceLine.LineNo " +
                "WHERE Invoice.Reference IN (" + parameters + ") " +
                "ORDER BY Invoice.Reference, InvoiceLine.LineNo;", Reference);

            previousValues = new object[reader.FieldCount];
            values = new object[reader.FieldCount];
            nextValues = new object[reader.FieldCount];

            loadNext();
            nextRow();
        }

        private void loadNext()
        {
            if (reader.Read())
            {
                reader.GetValues(nextValues);
                for (int i = 0; i <= nextValues.GetUpperBound(0); i++)
                    nextValues[i] = Common.Database.DbNullToNull(nextValues[i]);
                nextAvailable = true;
            }
            else
            {
                for (int i = 0; i <= nextValues.GetUpperBound(0); i++)
                    nextValues[i] = null;
                nextAvailable = false;
            }
        }

        private void nextRow()
        {
            values.CopyTo(previousValues, 0);
            nextValues.CopyTo(values, 0);

            endOfFile = !nextAvailable;

            loadNext();
        }

        private void closeData()
        {
            reader.Close();
        }


        private void InvoicePrintForm_Load(object sender, EventArgs e)
        {
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            printDocument.DefaultPageSettings.Margins = new Margins(39, 38, 39, 40);
            printPreview.InvalidatePreview();
            printPreview.StartPage = 0;
        }

        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            openData();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Common.Draw.SetOffset(39, 39);

            //********** SECTION: PAGE
            if (values[reader.GetOrdinal("Logo")] == null)
            {
                Common.Draw.DrawText(g, 0, 0, 495, 15, (string)values[reader.GetOrdinal("CompanyName")], "Verdana", 8, true, false, false, Color.Black, StringAlignment.Near);
                Common.Draw.DrawText(g, 0, 20, 495, 35, (string)values[reader.GetOrdinal("CompanyLine1")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
                Common.Draw.DrawText(g, 0, 40, 495, 55, (string)values[reader.GetOrdinal("CompanyLine2")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
                Common.Draw.DrawText(g, 0, 60, 495, 75, (string)values[reader.GetOrdinal("CompanyLine3")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
                Common.Draw.DrawText(g, 0, 80, 495, 95, (string)values[reader.GetOrdinal("CompanyLine4")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
            }
            else
            {
                Common.Draw.DrawImage(g, 0, 0, 95, 95, Common.Draw.GetImage((byte[])values[reader.GetOrdinal("Logo")]));
                Common.Draw.DrawText(g, 100, 0, 495, 15, (string)values[reader.GetOrdinal("CompanyName")], "Verdana", 8, true, false, false, Color.Black, StringAlignment.Near);
                Common.Draw.DrawText(g, 100, 20, 495, 35, (string)values[reader.GetOrdinal("CompanyLine1")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
                Common.Draw.DrawText(g, 100, 40, 495, 55, (string)values[reader.GetOrdinal("CompanyLine2")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
                Common.Draw.DrawText(g, 100, 60, 495, 75, (string)values[reader.GetOrdinal("CompanyLine3")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
                Common.Draw.DrawText(g, 100, 80, 495, 95, (string)values[reader.GetOrdinal("CompanyLine4")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
            }

            Common.Draw.DrawText(g, 500, 0, 750, 30, "INVOICE", "Verdana", 16, true, true, false, Color.Black, StringAlignment.Center);

            Common.Draw.DrawBoxR(g, 500, 40, 750, 95, Color.Black, 5);
            Common.Draw.DrawLine(g, 625, 40, 625, 95, Color.Black);
            Common.Draw.DrawText(g, 505, 50, 620, 65, "REFERENCE", "Verdana", 8, true, false, false, Color.Black, StringAlignment.Center);
            Common.Draw.DrawText(g, 505, 70, 620, 85, (string)values[reader.GetOrdinal("Reference")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Center);
            Common.Draw.DrawText(g, 630, 50, 745, 65, "DATE", "Verdana", 8, true, false, false, Color.Black, StringAlignment.Center);
            Common.Draw.DrawText(g, 630, 70, 745, 85, string.Format("{0:d}", values[reader.GetOrdinal("Date")]), "Verdana", 8, false, false, false, Color.Black, StringAlignment.Center);

            Common.Draw.DrawBoxR(g, 0, 110, 365, 225, Color.Black, 5);
            Common.Draw.DrawText(g, 10, 120, 85, 135, "BILL TO", "Verdana", 8, true, false, false, Color.Black, StringAlignment.Near);
            Common.Draw.DrawText(g, 85, 120, 355, 135, (string)values[reader.GetOrdinal("Code")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
            Common.Draw.DrawText(g, 10, 140, 355, 155, (string)values[reader.GetOrdinal("Name")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
            Common.Draw.DrawText(g, 10, 160, 355, 175, (string)values[reader.GetOrdinal("Address1")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
            Common.Draw.DrawText(g, 10, 180, 355, 195, (string)values[reader.GetOrdinal("Address2")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
            Common.Draw.DrawText(g, 10, 200, 355, 215, (string)values[reader.GetOrdinal("Address3")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);

            Common.Draw.DrawBoxR(g, 380, 110, 750, 225, Color.Black, 5);
            Common.Draw.DrawText(g, 390, 120, 460, 135, "SHIP TO", "Verdana", 8, true, false, false, Color.Black, StringAlignment.Near);
            Common.Draw.DrawText(g, 390, 140, 740, 155, (string)values[reader.GetOrdinal("ShipTo1")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
            Common.Draw.DrawText(g, 390, 160, 740, 175, (string)values[reader.GetOrdinal("ShipTo2")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
            Common.Draw.DrawText(g, 390, 180, 740, 195, (string)values[reader.GetOrdinal("ShipTo3")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
            Common.Draw.DrawText(g, 390, 200, 740, 215, (string)values[reader.GetOrdinal("ShipTo4")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);

            Common.Draw.DrawBoxR(g, 0, 240, 750, 875, Color.Black, 5);
            Common.Draw.DrawLine(g, 430, 240, 430, 875, Color.Black);
            Common.Draw.DrawLine(g, 535, 240, 535, 875, Color.Black);
            Common.Draw.DrawLine(g, 595, 240, 595, 875, Color.Black);
            Common.Draw.DrawLine(g, 645, 240, 645, 875, Color.Black);

            Common.Draw.DrawText(g, 10, 250, 420, 265, "DESCRIPTION", "Verdana", 8, true, false, false, Color.Black, StringAlignment.Near);
            Common.Draw.DrawText(g, 440, 250, 525, 265, "UNIT PRICE", "Verdana", 8, true, false, false, Color.Black, StringAlignment.Far);
            Common.Draw.DrawText(g, 545, 250, 585, 265, "QTY", "Verdana", 8, true, false, false, Color.Black, StringAlignment.Center);
            Common.Draw.DrawText(g, 605, 250, 635, 265, "TAX", "Verdana", 8, true, false, false, Color.Black, StringAlignment.Center);
            Common.Draw.DrawText(g, 655, 250, 740, 265, "AMOUNT", "Verdana", 8, true, false, false, Color.Black, StringAlignment.Far);

            Common.Draw.DrawBoxR(g, 0, 890, 545, 1065, Color.Black, 5);
            Common.Draw.DrawText(g, 10, 900, 535, 915, "NOTES", "Verdana", 8, true, false, false, Color.Black, StringAlignment.Near);
            Common.Draw.DrawText(g, 10, 920, 535, 1055, (string)values[reader.GetOrdinal("Notes")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);

            Common.Draw.DrawBoxR(g, 560, 890, 750, 945, Color.Black, 5);
            Common.Draw.DrawText(g, 570, 900, 650, 915, "VALUE", "Verdana", 8, true, false, false, Color.Black, StringAlignment.Far);
            Common.Draw.DrawText(g, 655, 900, 685, 915, (string)values[reader.GetOrdinal("CurrencySymbol")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
            Common.Draw.DrawText(g, 655, 900, 740, 915, string.Format("{0:N2}", values[reader.GetOrdinal("Value")]), "Verdana", 8, false, false, false, Color.Black, StringAlignment.Far);
            Common.Draw.DrawText(g, 570, 920, 650, 935, "DISCOUNT", "Verdana", 8, true, false, false, Color.Black, StringAlignment.Far);
            Common.Draw.DrawText(g, 655, 920, 685, 935, (string)values[reader.GetOrdinal("CurrencySymbol")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
            Common.Draw.DrawText(g, 655, 920, 740, 935, string.Format("{0:N2}", values[reader.GetOrdinal("Discount")]), "Verdana", 8, false, false, false, Color.Black, StringAlignment.Far);

            Common.Draw.DrawBoxR(g, 560, 950, 750, 1025, Color.Black, 5);
            Common.Draw.DrawText(g, 570, 960, 650, 975, "SUB-TOTAL", "Verdana", 8, true, false, false, Color.Black, StringAlignment.Far);
            Common.Draw.DrawText(g, 655, 960, 685, 975, (string)values[reader.GetOrdinal("CurrencySymbol")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
            Common.Draw.DrawText(g, 655, 960, 740, 975, string.Format("{0:N2}", values[reader.GetOrdinal("SubTotal")]), "Verdana", 8, false, false, false, Color.Black, StringAlignment.Far);
            Common.Draw.DrawText(g, 570, 980, 650, 995, "TAX", "Verdana", 8, true, false, false, Color.Black, StringAlignment.Far);
            Common.Draw.DrawText(g, 655, 980, 685, 995, (string)values[reader.GetOrdinal("CurrencySymbol")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
            Common.Draw.DrawText(g, 655, 980, 740, 995, string.Format("{0:N2}", values[reader.GetOrdinal("InvoiceB.Tax")]), "Verdana", 8, false, false, false, Color.Black, StringAlignment.Far);
            Common.Draw.DrawText(g, 570, 1000, 650, 1015, "SHIPPING", "Verdana", 8, true, false, false, Color.Black, StringAlignment.Far);
            Common.Draw.DrawText(g, 655, 1000, 685, 1015, (string)values[reader.GetOrdinal("CurrencySymbol")], "Verdana", 8, false, false, false, Color.Black, StringAlignment.Near);
            Common.Draw.DrawText(g, 655, 1000, 740, 1015, string.Format("{0:N2}", values[reader.GetOrdinal("Shipping")]), "Verdana", 8, false, false, false, Color.Black, StringAlignment.Far);

            Common.Draw.DrawBoxR(g, 560, 1030, 750, 1065, Color.Black, 5);
            Common.Draw.DrawText(g, 570, 1040, 650, 1055, "TOTAL", "Verdana", 8, true, false, false, Color.Black, StringAlignment.Far);
            Common.Draw.DrawText(g, 655, 1040, 685, 1055, (string)values[reader.GetOrdinal("CurrencySymbol")], "Verdana", 8, true, false, false, Color.Black, StringAlignment.Near);
            Common.Draw.DrawText(g, 655, 1040, 740, 1055, string.Format("{0:N2}", values[reader.GetOrdinal("Total")]), "Verdana", 8, true, false, false, Color.Black, StringAlignment.Far);

            Common.Draw.DrawText(g, 0, 1075, 750, 1090, (string)values[reader.GetOrdinal("InvoiceFooter")], "Verdana", 8, true, true, false, Color.Black, StringAlignment.Center);


            e.HasMorePages = true;

            //********** SECTION: DETAILS
            int y0 = 290;
            for (;;)
            {
                int y1 = y0 + 15;

                Common.Draw.DrawText(g, 10, y0, 420, y1, (string)values[reader.GetOrdinal("Description")], "Verdana", 8, (string)values[reader.GetOrdinal("LineType")] == "B", false, false, Color.Black, StringAlignment.Near);

                Common.Draw.DrawText(g, 440, y0, 470, y1, values[reader.GetOrdinal("UnitPrice")] == null ? "" : (string)values[reader.GetOrdinal("CurrencySymbol")], "Verdana", 8, (string)values[reader.GetOrdinal("LineType")] == "B", false, false, Color.Black, StringAlignment.Near);
                Common.Draw.DrawText(g, 440, y0, 525, y1, string.Format("{0:N4}", values[reader.GetOrdinal("UnitPrice")]), "Verdana", 8, (string)values[reader.GetOrdinal("LineType")] == "B", false, false, Color.Black, StringAlignment.Far);

                Common.Draw.DrawText(g, 545, y0, 585, y1, string.Format("{0:N0}", values[reader.GetOrdinal("Quantity")]), "Verdana", 8, (string)values[reader.GetOrdinal("LineType")] == "B", false, false, Color.Black, StringAlignment.Far);

                Common.Draw.DrawText(g, 605, y0, 635, y1, (string)Common.Database.DbNullToNull(values[reader.GetOrdinal("InvoiceLine.Tax")]), "Verdana", 8, (string)values[reader.GetOrdinal("LineType")] == "B", false, false, Color.Black, StringAlignment.Center);

                Common.Draw.DrawText(g, 655, y0, 685, y1, values[reader.GetOrdinal("Amount")] == null ? "" : (string)values[reader.GetOrdinal("CurrencySymbol")], "Verdana", 8, (string)values[reader.GetOrdinal("LineType")] == "B", false, false, Color.Black, StringAlignment.Near);
                Common.Draw.DrawText(g, 655, y0, 740, y1, string.Format("{0:N2}", values[reader.GetOrdinal("Amount")]), "Verdana", 8, (string)values[reader.GetOrdinal("LineType")] == "B", false, false, Color.Black, StringAlignment.Far);

                nextRow();

                y0 += 20;
                if (y0 > 850)
                    break;

                if ((String) previousValues[reader.GetOrdinal("Reference")] !=
                    (String) values[reader.GetOrdinal("Reference")])
                    break;

                if (endOfFile)
                    break;
            }

            e.HasMorePages = !endOfFile;
        }

        private void printDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            closeData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDocument.Print();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (printPreview.StartPage > 0)
                printPreview.StartPage--;
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            printPreview.StartPage++;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

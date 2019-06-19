using SalajansBoyaMusteri;
using SalajansBoyaMusteri.Properties;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;

public static class PrintRapor
{

    public static Bitmap Gorsel;
    
    public static void Print()
    {
        DBEntities db = new DBEntities();
        string vyazici = @default.Default.VarsayilanYazici;
        PrintDocument pd = new PrintDocument();
        pd.DefaultPageSettings.Margins = new Margins(0, 45, 0, 45);
        pd.PrintPage += new PrintPageEventHandler(PrinterPage);

        pd.PrinterSettings.PrinterName = @default.Default.VarsayilanYazici;
        pd.Print();
        Gorsel.Dispose();
    }


      static void PrinterPage(object sender, PrintPageEventArgs e)
    {
        e.Graphics.DrawImage(Gorsel, e.MarginBounds);
    }
}


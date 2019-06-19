using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalajansBoyaMusteri;


public class AracYuklemeEkrani
{
    public static DBEntities db = new DBEntities();

    public static IList<TBLMARKA> markalist;
    public static IList<TBLMARKA> modellist;
}

public class musteridegerleri
{
    public static string plaka;
    public static string aracyili;
    public static string aracmodeli;
    public static string renk;
    public static string kmsi;
    public static string testsonucu;
    public static string barkodno;
    public static string arackasa;
    public static string alicitelefon;
    public static string veriadresi;
    public static string aliciadsoyad;
    public static string motorno;
    public static string sasino;
    public static string vites;
    public static string yakitturu;
    public static string uyarimesaji;
    public static bool AracResmi { get; set; }
}
public class sasikonumlari
{
    public Bitmap sasideger { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

}
public class sasilist
{
    public static List<sasikonumlari> sliste;

}
public class boyakonumlari
{
    public static float soloncamurlukX;
    public static float soloncamurlukY;
    public static float solonkapiX;
    public static float solonkapiY;
    public static float solarkakapiX;
    public static float solarkakapiY;
    public static float solarkacamurlukX;
    public static float solarkacamurlukY;

    public static float sagoncamurlukX;
    public static float sagoncamurlukY;
    public static float sagonkapiX;
    public static float sagonkapiY;
    public static float sagarkakapiX;
    public static float sagarkakapiY;
    public static float sagarkacamurlukX;
    public static float sagarkacamurlukY;

    public static float kaputX;
    public static float kaputY;

    public static float tavanX;
    public static float tavanY;

    public static float bagajX;
    public static float bagajY;

}
public class boyadegerleri
{
    //Sol Taraf
    public static Bitmap soloncamurluk;
    public static Bitmap solonkapi;
    public static Bitmap solarkakapi;
    public static Bitmap solarkacamurluk;
    //Sağ Taraf
    public static Bitmap sagoncamurluk;
    public static Bitmap sagonkapi;
    public static Bitmap sagarkakapi;
    public static Bitmap sagarkacamurluk;
    //Diğer Alanlar
    public static Bitmap kaput;
    public static Bitmap tavan;
    public static Bitmap bagaj;
    //Çalışan Radio
    public static string far;
    public static string onsinyal;
    public static string sis;

    //Çalışan Radio2
    public static string stop;
    public static string arkasinyal;
    public static string gvites;

}
public class onduzensonuclari
{
    public static string SolAmartisorTakozu;
    public static string SolUstTabla;
    public static string SolYanTablaKolu;
    public static string SolPorya;
    public static string SolZrot;
    public static string SolTabla;
    public static string SolTeraziKolu;

    public static string SagAmartisorTakozu;
    public static string SagUstTabla;
    public static string SagYanTablaKolu;
    public static string SagPorya;
    public static string SagZrot;
    public static string SagTabla;
    public static string SagTeraziKolu;

}
public class RaporBarkodNo
{
    public static string BarkodKodu { get; set; }
}
public class KullaniciveFirmaBilgileri
{
    public static string FirmaNo { get; set; }
    public static string FirmaAdi { get; set; }
    public static string KullaniciAdSoyad { get; set; }
    public static string Adres { get; set; }
    public static string Telefon { get; set; }
    public static string Email { get; set; }
    public static string website { get; set; }

    public static bool? Yetki { get; set; }
}
public class musterilistesi
{
    public string MusteriAdSoyad { get; set; }
    public string AliciTelefon { get; set; } 
    public string AracMarkaTip { get; set; }
    public string AracPlakasi { get; set; }
    public decimal? OdemeTutari { get; set; }
    public string BarkodNo { get; set; }
    public DateTime? Tarih { get; set; }
}

public class frendegerleri
{
    public static string AbsDurumu { get; set; }
    public static string EspDurumu { get; set; }
    public static string FrenAnaMerkezi { get; set; }
    public static string SolOnFrenDiski { get; set; }
    public static string SolOnFrenBalatasi { get; set; }
    public static string SolOnFrenHortumlari { get; set; }
    public static string SolOnFrenPistonlari { get; set; }
    public static string SolOnBijonGirisleri { get; set; }
    public static string SolOnHidrolikSeviyesi { get; set; }
    public static string SolOnMerkezPompasi { get; set; }
    public static string SolOnKampana { get; set; }
    public static string SolOnLimitor { get; set; }
    public static string SolOnServo { get; set; }
    public static string SagOnFrenDiski { get; set; }
    public static string SagOnFrenBalatasi { get; set; }
    public static string SagOnFrenHortumlari { get; set; }
    public static string SagOnFrenPistonlari { get; set; }
    public static string SagOnBijonGirisleri { get; set; }
    public static string SagOnHidrolikSeviyesi { get; set; }
    public static string SagOnMerkezPompasi { get; set; }
    public static string SagOnKampana { get; set; }
    public static string SagOnLimitor { get; set; }
    public static string SagOnServo { get; set; }
    public static string SolArkaFrenDiski { get; set; }
    public static string SolArkaFrenBalatasi { get; set; }
    public static string SolArkaFrenHortumlari { get; set; }
    public static string SolArkaFrenPistonlari { get; set; }
    public static string SolArkaBijonGirisleri { get; set; }
    public static string SolArkaHidrolikSeviyesi { get; set; }
    public static string SolArkaMerkezPompasi { get; set; }
    public static string SolArkaKampana { get; set; }
    public static string SolArkaLimitor { get; set; }
    public static string SolArkaServo { get; set; }
    public static string SagArkaFrenDiski { get; set; }
    public static string SagArkaFrenBalatasi { get; set; }
    public static string SagArkaFrenHortumlari { get; set; }
    public static string SagArkaFrenPistonlari { get; set; }
    public static string SagArkaBijonGirisleri { get; set; }
    public static string SagArkaHidrolikSeviyesi { get; set; }
    public static string SagArkaMerkezPompasi { get; set; }
    public static string SagArkaKampana { get; set; }
    public static string SagArkaLimitor { get; set; }
    public static string SagArkaServo { get; set; }
}

public class suspansiyondegerleri
{
    public static string solonamortisor { get; set; }
    public static string solonamortisortakozu { get; set; }
    public static string solonsuspansiyonkollari { get; set; }
    public static string solonhelezonyayi { get; set; }

    public static string solarkaamortisor { get; set; }
    public static string solarkaamortisortakozu { get; set; }
    public static string solarkasuspansiyonkollari { get; set; }
    public static string solarkahelezonyayi { get; set; }

    public static string sagonamortisor { get; set; }
    public static string sagonamortisortakozu { get; set; }
    public static string sagonsuspansiyonkollari { get; set; }
    public static string sagonhelezonyayi { get; set; }


    public static string sagarkaamortisor { get; set; }
    public static string sagarkaamortisortakozu { get; set; }
    public static string sagarkasuspansiyonkollari { get; set; }
    public static string sagarkahelezonyayi { get; set; }
}
public class motordegerleri
{
    public static string ustkapak { get; set; }
    public static string silindirkapak { get; set; }
    public static string sarjdinamosu { get; set; }
    public static string vkayisi { get; set; }
    public static string krankkasnagi { get; set; }
    public static string motorkasnaklari { get; set; }
    public static string marsdinamosu { get; set; }
    public static string yakitpompasi { get; set; }
    public static string elektriktesisati { get; set; }
    public static string klimahortumu { get; set; }
    public static string egr { get; set; }
    public static string turbo { get; set; }
    public static string turbohortumlari { get; set; }
    public static string klima { get; set; }
    public static string klimagazi { get; set; }
    public static string emmemanifortu { get; set; }
    public static string kelebekkutusu { get; set; }
    public static string ateslemesistemiveyakitenjektorleri { get; set; }
    public static string motorkulagi { get; set; }
    public static string motorbeyni { get; set; }
    public static string yagseviyesi { get; set; }
    public static string egzozemisyon { get; set; }
    public static string havaakisfiltresi { get; set; }
    public static string sogutmasistemi { get; set; }
    public static string yagkacagi { get; set; }
    public static string ufleme { get; set; }
    public static string yagyakma { get; set; }
    public static string sibopiticileri { get; set; }
    public static string silindirkapakconta { get; set; }
    public static string suhortumlari { get; set; }
    public static string yakithortumlari { get; set; }
    public static string lpgsistemivekizdirmabujileri { get; set; }
    public static string YakitTipi { get; set; }
    public static double MotorPerformansPuani { get; set; }
    public static string MotorGenelDurum { get; set; }
    public static Bitmap RaporResmi { get; set; }



}


public class sanzimandegerleri
{
    public static string baskibalata { get; set; }
    public static string vitesgecisleri { get; set; }
    public static string yagkacagi { get; set; }
    public static string sanzimankulagi { get; set; }
    public static string sanzimanbeyni { get; set; }

}


public class disaydinlatmadegerleri
{
    public static string solonsinyal { get; set; }
    public static string solonfarlar { get; set; }
    public static string solonparklambasi { get; set; }
    public static string solonsislambasi { get; set; }
    public static string solaynasinyallambasi { get; set; }


    public static string solarkasinyal { get; set; }
    public static string solarkafrenlambasi { get; set; }
    public static string solarkaparklambasi { get; set; }
    public static string solarkageriviteslambasi { get; set; }
    public static string sagaynasinyal { get; set; }


    public static string sagonsinyal { get; set; }
    public static string sagonfarlar { get; set; }
    public static string sagonparklambasi { get; set; }
    public static string sagonsislambasi { get; set; }
    public static string plakaisigi { get; set; }


    public static string sagarkasinyal { get; set; }
    public static string sagarkafrenlambasi { get; set; }
    public static string sagarkaparklambasi { get; set; }
    public static string sagarkageriviteslambasi { get; set; }
    public static string dortluisigi { get; set; }

}
public class donanimdegerleri
{
    public static string surucuhy { get; set; }
    public static string yolcuhy { get; set; }
    public static string bagajdosemesi { get; set; }
    public static string gogusdosemesi { get; set; }
    public static string camtavan { get; set; }


    public static string onemniyetk { get; set; }
    public static string arkaemniyet { get; set; }
    public static string otomatikcamlar { get; set; }
    public static string tavanaydinlatamasi { get; set; }
    public static string kapiaydinlatmasi { get; set; }


    public static string koltukdosemeleri { get; set; }
    public static string direksiyon { get; set; }
    public static string merkezikilit { get; set; }
    public static string sunroof { get; set; }
    public static string alarm { get; set; }


    public static string sagayna { get; set; }
    public static string solayna { get; set; }
    public static string panelvekadran { get; set; }
    public static string konsol { get; set; }
    public static string silecekler { get; set; }
}
public class elektrikdegerleri
{
    public static string akudurumu { get; set; }
    public static string sarjdinamosu { get; set; }
    public static string marsdinamosu { get; set; }
    public static string klimaelektrik { get; set; }


    public static string yakitsistemielektrik { get; set; }
    public static string motorelektrik { get; set; }
    public static string otomatikcamelektrik { get; set; }
    public static string aydinlatmaelektrik { get; set; }


    public static string teypelektrik { get; set; }
    public static string sogutmasistemielektrik { get; set; }
    public static string merkezikilitelektrik { get; set; }
    public static string alarmsistemielektrik { get; set; }


    public static string sagaynaelektrik { get; set; }
    public static string solaynaelektrik { get; set; }
    public static string panelvekadranelektrik { get; set; }
    public static string tesisatkacak { get; set; }
}
 
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using NpgsqlTypes;
using NUnit.Framework;

namespace Rozklady
{
    public class clKurs
    {
        public string id_rozkladu { get; private set; }
        public string identk { get; private set; }
        public string wazny_od { get; private set; }
        public string wazny_do { get; private set; }
        public string kalendarz { get; private set; }
        public string id_kursu { get; private set; }
        public string nr_przystanku { get; private set; }
        public string kod_przystanku { get; private set; }
        public string godz_p { get; private set; }
        public string godz_o { get; private set; }
        public string stanowisko { get; private set; }
        public string limit_sp { get; private set; }
        public string ile_dni_trwa_kurs { get; private set; }
        public string przystanek_poczatkowy { get; private set; } //FromStation
        public string przystanek_koncowy { get; private set; }//ToStation
        public string przystanek_tworzacy_1 { get; private set; }//FromThroughStation1
        public string przystanek_tworzacy_2 { get; private set; }//FromThroughStation2
        public string nr_bis { get; private set; }
        public string data { get; private set; }
        public string id_bisa { get; private set; }
        public string auto_duzy_bus { get; private set; }
        public string godz_odj { get; private set; }
        public string godz_przyjazdu { get; private set; }
        public string duzy_autobus { get; private set; }
        public string diagram_kurs_odwolany { get; private set; }
        public string NrPolaczenia { get; private set; }
        public string Typ { get; private set; }
        public string StacjaPocz { get; private set; }
        public string StacjaPrzez1 { get; private set; }
        public string StacjaPrzez2 { get; private set; }
        public string StacjaKon { get; private set; }
        public string Przewoznik { get; private set; }
        public string NazwaPrzewoznika { get; private set; }
        public string SymbolPrzewoznika { get; private set; }

        public clKurs(string _id_rozkladu, string _identk, string _wazny_od, string _wazny_do,
            string _kalendarz, string _id_kursu, string _nr_przystanku, string _kod_przystanku,
            string _godz_p, string _godz_o, string _stanowisko, string _limit_sp,
            string _ile_dni_trwa_kurs, string _przystanek_poczatkowy, string _przystanek_koncowy,
            string _przystanek_tworzacy_1, string _przystanek_tworzacy_2, string _nr_bis,
            string _data, string _id_bisa, string _auto_duzy_bus, string _godz_odj,
            string _godz_przyjazdu, string _duzy_autobus, string _diagram_kurs_odwolany,
            string _NrPolaczenia, string _Typ, string _StacjaPocz, string _StacjaPrzez1,
            string _StacjaPrzez2, string _StacjaKon, string _Przewoznik, string _NazwaPrzewoznika, string _SymbolPrzewoznika)
        {
            id_rozkladu = _id_rozkladu;
            identk = _identk;
            wazny_od = _wazny_od;
            wazny_do = _wazny_do;
            kalendarz = _kalendarz;
            id_kursu = _id_kursu;
            nr_przystanku = _nr_przystanku;
            kod_przystanku = _kod_przystanku;
            godz_p = _godz_p;
            godz_o = _godz_o;
            stanowisko = _stanowisko;
            limit_sp = _limit_sp;
            ile_dni_trwa_kurs = _ile_dni_trwa_kurs;
            przystanek_poczatkowy = _przystanek_poczatkowy;
            przystanek_koncowy = _przystanek_koncowy;
            przystanek_tworzacy_1 = _przystanek_tworzacy_1;
            przystanek_tworzacy_2 = _przystanek_tworzacy_2;
            nr_bis = _nr_bis;
            data = _data;
            id_bisa = _id_bisa;
            auto_duzy_bus = _auto_duzy_bus;
            godz_odj = _godz_odj;
            godz_przyjazdu = _godz_przyjazdu;
            duzy_autobus = _duzy_autobus;
            diagram_kurs_odwolany = _diagram_kurs_odwolany;
            NrPolaczenia = _NrPolaczenia;
            Typ = _Typ;
            StacjaPocz = _StacjaPocz;
            StacjaPrzez1 = _StacjaPrzez1;
            StacjaPrzez2 = _StacjaPrzez2;
            StacjaKon = _StacjaKon;
            Przewoznik = _Przewoznik;
            NazwaPrzewoznika = _NazwaPrzewoznika;
            SymbolPrzewoznika = _SymbolPrzewoznika;
        }
    }
    public partial class Default : System.Web.UI.Page
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();   
        private clKurs Kurs;
        private int UIDr = -1;
        private string strNazwaPrzewoznika = "";
        private string strNazwaSkrPrzewoznika = "";
        private string strNazwaPrzystP = "";
        private string strNazwaPrzystK = "";
        private string strNazwaPrzystT_1 = "";
        private string strNazwaPrzystT_2 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            /*SqlDataSource sqlRozklad = new SqlDataSource();
            sqlRozklad.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RozkladyConnectionString"].ConnectionString;
            sqlRozklad.DataSourceMode = "DataReader";*/

        }

        protected void btnPobierzRozklad_Click(object sender, EventArgs e)
        {
            //"SELECT * FROM rozklady WHERE wazny_od <= $1 AND aktywny = true ORDER BY wazny_od DESC, nazwa_a6 DESC"

            DateTime dtData = DateTime.Today;
            int intKodDworca = 12117743;
            //string strWersjaBazy;
            int intIdRozkl = -1;
            string strSQL;
            string flaga;

            sqlCzyscRozklad.Delete();

            using (NpgsqlConnection conn = new NpgsqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DworzecSQLConnectionString"].ConnectionString))
            {
                try
                {
                    //lblKom.Text = strSQL;
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    
                    cmd.CommandType = CommandType.Text;                    
                    cmd.Connection = conn;

                    strSQL = "DELETE FROM blokady WHERE (clock_timestamp() - blokada > '00:10:00') OR (tabela='dzienniki_dworca' AND id_rekordu=2458782012117743 AND uid='{76a158b2-6f2d-45f0-a103-958244e39446}' )";
                    cmd.CommandText = strSQL;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    strSQL = "INSERT INTO blokady (tabela,id_rekordu,blokada,uid) VALUES ('dzienniki_dworca',2458782012117743,clock_timestamp(),'{76a158b2-6f2d-45f0-a103-958244e39446}')";
                    cmd.CommandText = strSQL;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    strSQL = "DELETE FROM blokady WHERE tabela='dzienniki_dworca' AND id_rekordu=2458782012117743";
                    cmd.CommandText = strSQL;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    strSQL = "SELECT * FROM rozklady WHERE wazny_od <= '" + dtData.ToString() + "' AND aktywny=true ORDER BY wazny_od DESC, nazwa_a6 DESC LIMIT 1";                    
                    cmd.CommandText = strSQL;
                    conn.Open();
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                        while (dr.Read())
                        {                            
                            intIdRozkl = int.Parse(dr["id_rozkladu"].ToString());
                        }
                    conn.Close();

                    strSQL = "SELECT kursy.id_rozkladu, kursy.identk, kursy.wazny_od, kursy.wazny_do, kursy.kalendarz, kursy.id_kursu, kursy_trasy.nr_przystanku, ";
                    strSQL += "kursy_trasy.kod_przystanku, kursy_trasy.godz_p, kursy_trasy.godz_o, kursy_trasy.stanowisko, kursy.limit_sp, kursy.rk, ";
                    strSQL += "ile_dni_trwa_kurs( kursy.id_rozkladu, kursy.identk, kursy_trasy.nr_przystanku, bisy.roznica ), ";
                    strSQL += "przystanek_poczatkowy( kursy.id_rozkladu, kursy.identk ), przystanek_koncowy( kursy.id_rozkladu, kursy.identk ), ";
                    strSQL += "przystanek_tworzacy_linie( kursy.id_rozkladu, kursy.identk, 1, kursy_trasy.nr_przystanku ) AS przystanek_tworzacy_1, ";
                    strSQL += "przystanek_tworzacy_linie( kursy.id_rozkladu, kursy.identk, 2, kursy_trasy.nr_przystanku ) AS przystanek_tworzacy_2, ";
                    strSQL += "bisy.nr_bis, bisy.data, bisy.id_bisa, fpd.auto_duzy_bus, ";
                    strSQL += "godz_odj_z_przystanku( kursy.id_rozkladu, bisy.identk, kursy_trasy.nr_przystanku, bisy.roznica ) AS godz_odj, ";
                    strSQL += "godz_przyjazdu_na_przystanek( kursy.id_rozkladu, bisy.identk, kursy_trasy.nr_przystanku, bisy.roznica ) AS godz_przyjazdu, ";
                    strSQL += "duzy_autobus( firma( kursy.identk ),kursy_trasy.kod_przystanku, kursy.bus ), ";
                    strSQL += "CASE bisy.nr_bis IS NULL WHEN true THEN diagram_kurs_odwolany( data_start_kursu( kursy.id_rozkladu, kursy.identk, '" + dtData.ToString("yyyy-MM-dd") + "', kursy_trasy.nr_przystanku, NULL ), kursy.identk, FALSE, 0 ) ";
                    strSQL += "ELSE diagram_kurs_odwolany( data_start_kursu( kursy.id_rozkladu, kursy.identk, '" + dtData.ToString("yyyy-MM-dd") + "', kursy_trasy.nr_przystanku, bisy.roznica), ";
                    strSQL += "kursy.identk, FALSE, bisy.nr_bis ) END AS diagram_kurs_odwolany ";
                    strSQL += "FROM kursy LEFT JOIN kursy_trasy ON kursy.id_kursu = kursy_trasy.id_kursu LEFT JOIN bisy ON bisy.identk = kursy.identk ";
                    strSQL += "AND data_na_przystanku( kursy.id_rozkladu, bisy.identk, kursy_trasy.nr_przystanku, bisy.data, bisy.roznica ) = '" + dtData.ToString("yyyy-MM-dd") + "' ";
                    strSQL += "LEFT JOIN firmy_parametry_dworcow AS fpd ON firma( kursy.identk ) = fpd.firma_kod AND fpd.kod_przystanku = " + intKodDworca.ToString() + " ";
                    strSQL += "WHERE kursy.id_rozkladu = " + intIdRozkl.ToString() + " AND kursy.wazny_do >= '" + dtData.ToString("yyyy-MM-dd") + "' AND kursy_trasy.kod_przystanku = " + intKodDworca.ToString() + " AND NOT kursy.ks_dw_pomin AND ( kursy_trasy.godz_o IS NOT NULL OR kursy_trasy.godz_p IS NOT NULL ) ";
                    strSQL += "AND ( bisy.data IS NULL OR data_na_przystanku( kursy.id_rozkladu, bisy.identk, kursy_trasy.nr_przystanku, bisy.data, bisy.roznica ) = '" + dtData.ToString("yyyy-MM-dd") + "' ) ";
                    strSQL += "ORDER BY kursy.id_kursu, kursy_trasy.nr_przystanku";

                    //lblKom.Text += strSQL + "</br>";

                    cmd.CommandText = strSQL;                   
                    conn.Open();                    
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
//                            if ((dr["stanowisko"] != null) && (dr["stanowisko"].ToString().Trim() != "  "))
//                            {
                                Kurs = new clKurs(dr["id_rozkladu"].ToString(),
                                    dr["identk"].ToString(),
                                    dr["wazny_od"].ToString(),
                                    dr["wazny_do"].ToString(),
                                    dr["kalendarz"].ToString(),
                                    dr["id_kursu"].ToString(),
                                    dr["nr_przystanku"].ToString(),
                                    dr["kod_przystanku"].ToString(),
                                    dr["godz_p"].ToString(),
                                    dr["godz_o"].ToString(),
                                    dr["stanowisko"].ToString(),
                                    dr["limit_sp"].ToString(),
                                    dr["ile_dni_trwa_kurs"].ToString(),
                                    dr["przystanek_poczatkowy"].ToString(),
                                    dr["przystanek_koncowy"].ToString(),
                                    dr["przystanek_tworzacy_1"].ToString(),
                                    dr["przystanek_tworzacy_2"].ToString(),
                                    dr["nr_bis"].ToString(),
                                    dr["data"].ToString(),
                                    dr["id_bisa"].ToString(),
                                    dr["auto_duzy_bus"].ToString(),
                                    dr["godz_odj"].ToString(),
                                    dr["godz_przyjazdu"].ToString(),
                                    dr["duzy_autobus"].ToString(),
                                    dr["diagram_kurs_odwolany"].ToString(),
                                    dr["identk"].ToString().Substring(5, 4),
                                    dr["rk"].ToString(),
                                    null,
                                    null,
                                    null,
                                    null,
                                    int.Parse(dr["identk"].ToString().Substring(0, 4)).ToString(),
                                    null,
                                    null
                                    );
                                odsRozklad.Insert();
//                            }                         
                        }
                        dr.Close();
                    }
                    conn.Close();

                    sqlRozklad.DataBind();
                    using (SqlDataReader rdrSql = (SqlDataReader)sqlRozklad.Select(DataSourceSelectArguments.Empty))
                    {
                        while (rdrSql.Read())
                        {
                            UIDr = int.Parse(rdrSql["UID"].ToString());
                            strNazwaPrzewoznika = "";
                            strNazwaSkrPrzewoznika = "";
                            strNazwaPrzystP = "";
                            strNazwaPrzystK = "";
                            strNazwaPrzystT_1 = "";
                            strNazwaPrzystT_2 = "";
                            flaga = "0";

                            if ((rdrSql["id_rozkladu"] != null) && (rdrSql["kalendarz"]!= null))
                            {
                                strSQL = "select mapa from kalendarze where id_rozkladu = ";
                                strSQL += rdrSql["id_rozkladu"] + " AND kalend = " + rdrSql["kalendarz"];
                                strSQL += " AND rok = " + DateTime.Now.Year.ToString();
                                strSQL += " AND miesiac = " + DateTime.Now.Month.ToString();
                                cmd.CommandText = strSQL;
                                conn.Open();
                                using (NpgsqlDataReader dr = cmd.ExecuteReader())
                                {
                                    while (dr.Read())
                                    {
                                        if (dr["mapa"] != null)
                                            flaga = dr["mapa"].ToString().Substring(DateTime.Now.Day-1, 1);
                                        //lblKom.Text += dr["mapa"].ToString() + " - " + flaga + "</br>";
                                    }                                    
                                    dr.Close();
                                }                                
                                conn.Close();
                                if (flaga == "1")
                                {
                                    if ((rdrSql["Przewoznik"] != null) && (rdrSql["Przewoznik"].ToString() != ""))
                                    {
                                        strSQL = "select nazwa, symbol from firmy where kod = " + rdrSql["Przewoznik"].ToString();
                                        //lblKom.Text += strSQL + "</BR>";
                                        cmd.CommandText = strSQL;
                                        conn.Open();
                                        using (NpgsqlDataReader dr = cmd.ExecuteReader())
                                        {
                                            while (dr.Read())
                                            {
                                                if (dr["nazwa"] != null)
                                                    strNazwaPrzewoznika = dr["nazwa"].ToString();
                                                if (dr["symbol"] != null)
                                                    strNazwaSkrPrzewoznika = dr["symbol"].ToString();
                                            }
                                            dr.Close();
                                        }
                                        conn.Close();
                                    }

                                    if (rdrSql["przystanek_poczatkowy"] != null)
                                    {
                                        if ((rdrSql["przystanek_poczatkowy"].ToString() != null) && (rdrSql["przystanek_poczatkowy"].ToString() != ""))
                                        {
                                            strSQL = "select m.nazwa, p.id_miejscowosci, p.skrot from miejscowosci m right join przystanki p on p.id_miejscowosci = m.id_miejscowosci where p.kod_przystanku = " + rdrSql["przystanek_poczatkowy"].ToString() + " limit 1";
                                            cmd.CommandText = strSQL;
                                            conn.Open();
                                            using (NpgsqlDataReader dr = cmd.ExecuteReader())
                                            {
                                                while (dr.Read())
                                                {
                                                    if (int.Parse(dr["id_miejscowosci"].ToString()) < 9000000)
                                                        strNazwaPrzystP = dr["nazwa"].ToString();
                                                    else
                                                        strNazwaPrzystP = dr["skrot"].ToString();
                                                }
                                                dr.Close();
                                            }
                                            conn.Close();
                                        }

                                        if ((rdrSql["przystanek_koncowy"].ToString() != null) && (rdrSql["przystanek_koncowy"].ToString() != ""))
                                        {
                                            strSQL = "select m.nazwa, p.id_miejscowosci, p.skrot from miejscowosci m right join przystanki p on p.id_miejscowosci = m.id_miejscowosci where p.kod_przystanku = " + rdrSql["przystanek_koncowy"].ToString() + " limit 1";
                                            cmd.CommandText = strSQL;
                                            conn.Open();
                                            using (NpgsqlDataReader dr = cmd.ExecuteReader())
                                            {
                                                while (dr.Read())
                                                {
                                                    if (int.Parse(dr["id_miejscowosci"].ToString()) < 9000000)
                                                        strNazwaPrzystK = dr["nazwa"].ToString();
                                                    else
                                                        strNazwaPrzystK = dr["skrot"].ToString();
                                                }
                                                dr.Close();
                                            }
                                            conn.Close();
                                        }

                                        if ((rdrSql["przystanek_tworzacy_1"].ToString() != null) && (rdrSql["przystanek_tworzacy_1"].ToString() != ""))
                                        {
                                            strSQL = "select m.nazwa, p.id_miejscowosci, p.skrot from miejscowosci m right join przystanki p on p.id_miejscowosci = m.id_miejscowosci where p.kod_przystanku = " + rdrSql["przystanek_tworzacy_1"].ToString() + " limit 1";                                          
                                            cmd.CommandText = strSQL;
                                            conn.Open();
                                            using (NpgsqlDataReader dr = cmd.ExecuteReader())
                                            {
                                                while (dr.Read())
                                                {
                                                    if (int.Parse(dr["id_miejscowosci"].ToString()) < 9000000)
                                                        strNazwaPrzystT_1 = dr["nazwa"].ToString();
                                                    else
                                                        strNazwaPrzystT_1 = dr["skrot"].ToString();
                                                }
                                                dr.Close();
                                            }
                                            conn.Close();
                                        }

                                        if ((rdrSql["przystanek_tworzacy_2"].ToString() != null) && (rdrSql["przystanek_tworzacy_2"].ToString() != ""))
                                        {
                                            strSQL = "select m.nazwa, p.id_miejscowosci, p.skrot from miejscowosci m right join przystanki p on p.id_miejscowosci = m.id_miejscowosci where p.kod_przystanku = " + rdrSql["przystanek_tworzacy_2"].ToString() + " limit 1";
                                            cmd.CommandText = strSQL;
                                            conn.Open();
                                            using (NpgsqlDataReader dr = cmd.ExecuteReader())
                                            {
                                                while (dr.Read())
                                                {
                                                    if (int.Parse(dr["id_miejscowosci"].ToString()) < 9000000)
                                                        strNazwaPrzystT_2 = dr["nazwa"].ToString();
                                                    else
                                                        strNazwaPrzystT_2 = dr["skrot"].ToString();
                                                }
                                                dr.Close();
                                            }
                                            conn.Close();
                                        }
                                    }
                                }
                                else
                                {
                                    odsRozklad.Delete();
                                }
                            }
                            
                            //lblKom.Text += strNazwaPrzystP;

                            odsRozklad.Update();
                            UIDr = -1;
                        }
                        rdrSql.Close();
                    }
                }
                catch (Exception ex)
                {
                    lblKom.Text += ex.ToString();
                }
                finally
                {                    
                    conn.Close();
                }
            }
        }

        protected void btnOpublikujRozklad_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PKSPoznan"].ConnectionString))
            {
                //using (SqlCommand cmd = new SqlCommand("DELETE FROM daily.TrainSchedule WHERE TransDate < DATEADD(Day, -1, GETDATE())", conn))
                using (SqlCommand cmd = new SqlCommand("DELETE FROM daily.TrainSchedule", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.AddWithValue("@Name", name);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            
            sqlRozklad.DataBind();
            using (SqlDataReader rdrSql = (SqlDataReader)sqlRozklad.Select(DataSourceSelectArguments.Empty))
            {
                while (rdrSql.Read())
                {
                    Kurs = new clKurs(rdrSql["id_rozkladu"].ToString(),
                        rdrSql["identk"].ToString(),
                        rdrSql["wazny_od"].ToString(),
                        rdrSql["wazny_do"].ToString(),
                        rdrSql["kalendarz"].ToString(),
                        rdrSql["id_kursu"].ToString(),
                        rdrSql["nr_przystanku"].ToString(),
                        rdrSql["kod_przystanku"].ToString(),
                        rdrSql["godz_p"].ToString(),
                        rdrSql["godz_o"].ToString(),
                        rdrSql["stanowisko"].ToString(),
                        rdrSql["limit_sp"].ToString(),
                        rdrSql["ile_dni_trwa_kurs"].ToString(),
                        rdrSql["przystanek_poczatkowy"].ToString(),
                        rdrSql["przystanek_koncowy"].ToString(),
                        rdrSql["przystanek_tworzacy_1"].ToString(),
                        rdrSql["przystanek_tworzacy_2"].ToString(),
                        rdrSql["nr_bis"].ToString(),
                        rdrSql["data"].ToString(),
                        rdrSql["id_bisa"].ToString(),
                        rdrSql["auto_duzy_bus"].ToString(),
                        rdrSql["godz_odj"].ToString(),
                        rdrSql["godz_przyjazdu"].ToString(),
                        rdrSql["duzy_autobus"].ToString(),
                        rdrSql["diagram_kurs_odwolany"].ToString(),
                        rdrSql["identk"].ToString().Substring(5, 4),
                        rdrSql["Typ"].ToString(),
                        rdrSql["StacjaPocz"].ToString(),
                        rdrSql["StacjaPrzez1"].ToString(),
                        rdrSql["StacjaPrzez2"].ToString(),
                        rdrSql["StacjaKon"].ToString(),
                        rdrSql["Przewoznik"].ToString(),
                        rdrSql["NazwaPrzewoznika"].ToString(),
                        rdrSql["SymbolPrzewoznika"].ToString()
                        );
                    odsTrackerTrainSchedule.Insert();
                }
                rdrSql.Close();
            }
        }
        protected void odsTrackerTrainSchedule_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            if ((Kurs.godz_o != null) && (Kurs.godz_o != ""))
            {
                e.InputParameters["Departure"] = true;
                e.InputParameters["DepartureTime"] = TimeSpan.Parse(Kurs.godz_o);               
            }
            else
            {
                e.InputParameters["Departure"] = false;
            }

            if ((Kurs.godz_p != null) && (Kurs.godz_p != ""))
            {
                e.InputParameters["Arrival"] = true;
                e.InputParameters["ArrivalTime"] = TimeSpan.Parse(Kurs.godz_p);                
            }
            else
            {
                e.InputParameters["Arrival"] = false;
            }

            if ((Kurs.StacjaPocz != null) && (Kurs.StacjaPocz.Trim() != ""))
            {
                e.InputParameters["StacjaPocz"] = Kurs.StacjaPocz;
            }

            if ((Kurs.StacjaKon != null) && (Kurs.StacjaKon.Trim() != ""))
            {
                e.InputParameters["StacjaKon"] = Kurs.StacjaKon;
            }

            if ((Kurs.StacjaPrzez1 != null) && (Kurs.StacjaPrzez1.Trim() != ""))
            {
                e.InputParameters["StacjaPrzez1"] = Kurs.StacjaPrzez1;
            }

            if ((Kurs.StacjaPrzez2 != null) && (Kurs.StacjaPrzez2.Trim() != ""))
            {
                e.InputParameters["StacjaPrzez2"] = Kurs.StacjaPrzez2;
            }

            if (int.Parse(Kurs.Typ.ToString()) > 3)
                e.InputParameters["ParkingSectors"] = "Z";
            else
                e.InputParameters["ParkingSectors"] = "K";

            e.InputParameters["Typ"] = int.Parse(Kurs.Typ.ToString());
            e.InputParameters["TrackId"] = int.Parse(Kurs.stanowisko.ToString());
            e.InputParameters["OriginalTrackId"] = int.Parse(Kurs.stanowisko.ToString());
            e.InputParameters["Number"] = int.Parse(Kurs.NrPolaczenia).ToString();
            e.InputParameters["Przewoznik"] = Kurs.Przewoznik;
            e.InputParameters["NazwaPrzewoznika"] = Kurs.NazwaPrzewoznika;
            e.InputParameters["SymbolPrzewoznika"] = Kurs.SymbolPrzewoznika;
            e.InputParameters["Sectors"] = "";
            e.InputParameters["TransDate"] = DateTime.Now;
            e.InputParameters["Active"] = true;
            e.InputParameters["ArrivalDelay"] = 0;
            e.InputParameters["DepartureDelay"] = 0;
            e.InputParameters["ActiveZap"] = 0;
            e.InputParameters["Deleted"] = false;

        }
        protected void odsRozklad_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            //lblKom.Text += "Dodano rekord";
            if ((Kurs.NrPolaczenia != null) && (Kurs.NrPolaczenia != ""))
                e.InputParameters["NrPolaczenia"] = int.Parse(Kurs.NrPolaczenia);
            if ((Kurs.StacjaPocz != null) && (Kurs.StacjaPocz != ""))
                e.InputParameters["StacjaPocz"] = Kurs.StacjaPocz;
            if ((Kurs.StacjaPrzez1 != null) && (Kurs.StacjaPrzez1 != ""))
                e.InputParameters["StacjaPrzez1"] = Kurs.StacjaPrzez1;
            if ((Kurs.StacjaPrzez2 != null) && (Kurs.StacjaPrzez2 != ""))
                e.InputParameters["StacjaPrzez2"] = Kurs.StacjaPrzez2;
            if ((Kurs.StacjaKon != null) && (Kurs.StacjaKon != ""))
                e.InputParameters["StacjaKon"] = Kurs.StacjaKon;
            if ((Kurs.Przewoznik != null) && (Kurs.Przewoznik != ""))
                e.InputParameters["Przewoznik"] = int.Parse(Kurs.Przewoznik);
            if ((Kurs.Typ != null) && (Kurs.Typ != ""))
                e.InputParameters["Typ"] = int.Parse(Kurs.Typ);
            if ((Kurs.id_rozkladu != null) && (Kurs.id_rozkladu != ""))
                e.InputParameters["id_rozkladu"] = int.Parse(Kurs.id_rozkladu);
            if ((Kurs.identk != null) && (Kurs.identk != ""))
                e.InputParameters["identk"] = Kurs.identk;
            if ((Kurs.wazny_od != null) && (Kurs.wazny_od != ""))
                e.InputParameters["wazny_od"] = DateTime.Parse(Kurs.wazny_od);
            if ((Kurs.wazny_do != null) && (Kurs.wazny_do != ""))
                e.InputParameters["wazny_do"] = DateTime.Parse(Kurs.wazny_do);
            if ((Kurs.kalendarz != null) && (Kurs.kalendarz != ""))
                e.InputParameters["kalendarz"] = int.Parse(Kurs.kalendarz);
            if ((Kurs.id_kursu != null) && (Kurs.id_kursu != ""))
                e.InputParameters["id_kursu"] = int.Parse(Kurs.id_kursu);
            if ((Kurs.nr_przystanku != null) && (Kurs.nr_przystanku != ""))
                e.InputParameters["nr_przystanku"] = int.Parse(Kurs.nr_przystanku);
            if ((Kurs.kod_przystanku != null) && (Kurs.kod_przystanku != ""))
                e.InputParameters["kod_przystanku"] = int.Parse(Kurs.kod_przystanku);
            if ((Kurs.godz_p != null) && (Kurs.godz_p != ""))
                e.InputParameters["godz_p"] = TimeSpan.Parse(Kurs.godz_p);
            if ((Kurs.godz_o != null) && (Kurs.godz_o != ""))
                e.InputParameters["godz_o"] = TimeSpan.Parse(Kurs.godz_o);
            if ((Kurs.stanowisko != null) && (Kurs.stanowisko != ""))
                e.InputParameters["stanowisko"] = Kurs.stanowisko;
            if ((Kurs.limit_sp != null) && (Kurs.limit_sp != ""))
                e.InputParameters["limit_sp"] = int.Parse(Kurs.limit_sp);
            if ((Kurs.ile_dni_trwa_kurs != null) && (Kurs.ile_dni_trwa_kurs != ""))
                e.InputParameters["ile_dni_trwa_kurs"] = int.Parse(Kurs.ile_dni_trwa_kurs);
            if ((Kurs.przystanek_poczatkowy != null) && (Kurs.przystanek_poczatkowy != ""))
                e.InputParameters["przystanek_poczatkowy"] = int.Parse(Kurs.przystanek_poczatkowy);
            if ((Kurs.przystanek_koncowy != null) && (Kurs.przystanek_koncowy != ""))
                e.InputParameters["przystanek_koncowy"] = int.Parse(Kurs.przystanek_koncowy);
            if ((Kurs.przystanek_tworzacy_1 != null) && (Kurs.przystanek_tworzacy_1 != ""))
                e.InputParameters["przystanek_tworzacy_1"] = int.Parse(Kurs.przystanek_tworzacy_1);
            if ((Kurs.przystanek_tworzacy_2 != null) && (Kurs.przystanek_tworzacy_2 != ""))
                e.InputParameters["przystanek_tworzacy_2"] = int.Parse(Kurs.przystanek_tworzacy_2);
            if ((Kurs.nr_bis != null) && (Kurs.nr_bis != ""))
                e.InputParameters["nr_bis"] = int.Parse(Kurs.nr_bis);
            if ((Kurs.data != null) && (Kurs.data != ""))
                e.InputParameters["data"] = DateTime.Parse(Kurs.data);
            if ((Kurs.id_bisa != null) && (Kurs.id_bisa != ""))
                e.InputParameters["id_bisa"] = int.Parse(Kurs.id_bisa);
            if ((Kurs.auto_duzy_bus != null) && (Kurs.auto_duzy_bus != ""))
            {
                //lblKom.Text += Kurs.auto_duzy_bus;
                if (Kurs.auto_duzy_bus.Equals("True"))
                    e.InputParameters["auto_duzy_bus"] = true;
                else if (Kurs.auto_duzy_bus.Equals("False"))
                    e.InputParameters["auto_duzy_bus"] = false;
            }
            //    e.InputParameters["auto_duzy_bus"] = Convert.ToBoolean(Kurs.auto_duzy_bus);
            if ((Kurs.godz_odj != null) && (Kurs.godz_odj != ""))
                e.InputParameters["godz_odj"] = TimeSpan.Parse(Kurs.godz_odj);
            if ((Kurs.godz_przyjazdu != null) && (Kurs.godz_przyjazdu != ""))
                e.InputParameters["godz_przyjazdu"] = TimeSpan.Parse(Kurs.godz_przyjazdu);
            if ((Kurs.duzy_autobus != null) && (Kurs.duzy_autobus != ""))
            {
                if (Kurs.duzy_autobus.Equals("True"))
                    e.InputParameters["duzy_autobus"] = true;
                else if (Kurs.duzy_autobus.Equals("False"))
                    e.InputParameters["duzy_autobus"] = false;
            }
            //    e.InputParameters["duzy_autobus"] = Convert.ToBoolean(Kurs.duzy_autobus);
            if ((Kurs.diagram_kurs_odwolany != null) && (Kurs.diagram_kurs_odwolany != ""))
            {
                if (Kurs.diagram_kurs_odwolany.Equals("True"))
                    e.InputParameters["diagram_kurs_odwolany"] = true;
                else if (Kurs.diagram_kurs_odwolany.Equals("False"))
                    e.InputParameters["diagram_kurs_odwolany"] = false;
            }
            //e.InputParameters["diagram_kurs_odwolany"] = Convert.ToBoolean(Kurs.diagram_kurs_odwolany);
        }

        protected void odsRozklad_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            e.InputParameters["Original_UID"] = UIDr;
            if ((strNazwaPrzewoznika != null) && (strNazwaPrzewoznika != ""))
                e.InputParameters["NazwaPrzewoznika"] = strNazwaPrzewoznika;
            if ((strNazwaSkrPrzewoznika != null) && (strNazwaSkrPrzewoznika != ""))
                e.InputParameters["SymbolPrzewoznika"] = strNazwaSkrPrzewoznika;
            if ((strNazwaPrzystP != null) && (strNazwaPrzystP != ""))
                e.InputParameters["stacjaPocz"] = strNazwaPrzystP;
            if ((strNazwaPrzystT_1 != null) && (strNazwaPrzystT_1 != ""))
                e.InputParameters["stacjaPrzez1"] = strNazwaPrzystT_1;
            if ((strNazwaPrzystT_2 != null) && (strNazwaPrzystT_2 != ""))
                e.InputParameters["stacjaPrzez2"] = strNazwaPrzystT_2;
            if ((strNazwaPrzystK != null) && (strNazwaPrzystK != ""))
                e.InputParameters["stacjaKon"] = strNazwaPrzystK;
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#EEFFAA'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
             //   System.Data.DataRowView drv = e.Row.DataItem as System.Data.DataRowView;
             //   e.Row.Attributes.Add("ondblclick", String.Format("window.location='EdytujPustostan.aspx?ID={0}'", drv["ID"]));
            }
        }

        protected void odsRozklad_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            e.InputParameters["Original_UID"] = UIDr;
        }
    }
}
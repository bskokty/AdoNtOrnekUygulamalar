using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Markalar.Models
{
    public class Marka
    {
        public int ID { get; set; }
        public string FirmaAdi { get; set; }

        public string Aciklamasi { get; set; }



        public  static List<Marka> MarkalariGetir()
        {

            SqlConnection conec = Dataconnection.DataEntity.connectsql();

            

            SqlCommand com = new SqlCommand("select * from MarkaTablosu",conec );
            conec.Open();
            SqlDataReader read = com.ExecuteReader();
            List<Marka> markaListesi = new List<Marka>();
            while (read.Read()) 
            {
                Marka YeniMarka = new Marka {
                    ID = Convert.ToInt32(read["ID"]),
                    FirmaAdi = (read["FirmaAdi"]).ToString(),
                    Aciklamasi= (read["Aciklamasi"]).ToString()

                };
                markaListesi.Add(YeniMarka);

            }

            return markaListesi;


           

        }

        public static bool markaekle(string firmaAdi, string aciklamasi)
        {
            SqlConnection conec = Dataconnection.DataEntity.connectsql();
           

            //string x = firmaAdi;
            //string y = aciklamasi;
            SqlCommand com = new SqlCommand("insert MarkaTablosu  values (@x,@y) ", conec);

            com.Parameters.AddWithValue("x", firmaAdi);
            com.Parameters.AddWithValue("y", aciklamasi);

            conec.Open();

            int sonuc = com.ExecuteNonQuery();

            if(sonuc>0)
        
                return true;
            
           else
            
                return false;
            

        }



        public static bool guncelle( int ID,string firmaAdi, string aciklamasi)

        {
            SqlConnection conec = Dataconnection.DataEntity.connectsql();
            SqlCommand com = new SqlCommand("update MarkaTablosu set FirmaAdi=@x,Aciklamasi=@y where ID=@z" , conec);

            com.Parameters.AddWithValue("x", firmaAdi);
            com.Parameters.AddWithValue("y", aciklamasi);
            com.Parameters.AddWithValue("z", ID);

            conec.Open();



            int sonuc = com.ExecuteNonQuery();

            if (sonuc > 0)
            {

                return true;
            }
           

                return false;


        }


        public static Marka markaGetir(int userID) {
            SqlConnection conec = Dataconnection.DataEntity.connectsql();
            SqlCommand com = new SqlCommand("select * from MarkaTablosu where ID=@x", conec);
            com.Parameters.AddWithValue("x", userID);

            conec.Open();

            SqlDataReader read = com.ExecuteReader();

            List<Marka> markaListesi = new List<Marka>();
            while (read.Read())
            {
                Marka YeniMarka = new Marka
                {
                    ID = Convert.ToInt32(read["ID"]),
                    FirmaAdi = (read["FirmaAdi"]).ToString(),
                    Aciklamasi = (read["Aciklamasi"]).ToString()

                };
                markaListesi.Add(YeniMarka);

            }
            

            Models.Marka mrk = markaListesi[0];

            conec.Close();

            return mrk;

        }


        public static bool sil(int ID)

        {
            SqlConnection conec = Dataconnection.DataEntity.connectsql();
            SqlCommand com = new SqlCommand("Delete from MarkaTablosu where ID=@z", conec);

           
            com.Parameters.AddWithValue("z", ID);

            conec.Open();



            int sonuc = com.ExecuteNonQuery();

            if (sonuc > 0)
            {

                return true;
            }


            return false;


        }


    }


    
}
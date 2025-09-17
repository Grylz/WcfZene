using MySql.Data.MySqlClient;
using Mysqlx.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeneszamok.Models;

namespace Zeneszamok.Controllers
{
    public class EloadoController
    {
        static MySqlConnection sqlCon;

        private static void BludConnection()
        {
            string connectionString = "SERVER = localhost;" +
                                          "DATABASE= zene;" +
                                          "UID = root;" +
                                          "PASSWORD =;" +
                                          "SSL MODE= none;";
            sqlCon = new MySqlConnection();
            sqlCon.ConnectionString = connectionString;
        }

        public string EloadoDEL(int id)
        {
            BludConnection();
            sqlCon.Open();
            string sql = "DELETE FROM eloado WHERE Id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, sqlCon);
            cmd.Parameters.AddWithValue("@id", id);
            int sorokSzama = cmd.ExecuteNonQuery();
            sqlCon.Close();
            return sorokSzama > 0 ? "Sikeresen törölve!" : "Hiba a törlés során";
        }

        public string EloadoModositasa(Eloado modositando)
        {
            BludConnection();
            sqlCon.Open();
            string sql =
                "UPDATE eloado SET Nev = @nev, Nemzetiseg = @nemzetiseg, Szolo = @szolo WHERE Id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, sqlCon);
            cmd.Parameters.AddWithValue("@nev", modositando.Nev);
            cmd.Parameters.AddWithValue("@nemzetiseg", modositando.Nemzetiseg);
            cmd.Parameters.AddWithValue("@szolo", modositando.Szolo);
            cmd.Parameters.AddWithValue("@id", modositando.Id);
            int sorokSzama = cmd.ExecuteNonQuery();
            sqlCon.Close();
            return sorokSzama > 0 ? "Sikeresen módosítva!" : "Hiba a módosítás során";
        }

        public string EloadoFelvitele(Eloado rogzitendo)
        {
            BludConnection();
            sqlCon.Open();
            string sql =
                "INSERT INTO eloado(Nev, Nemzetiseg, Szolo) " +
                "VALUES(@nev, @nemzetiseg, @szolo)";
            MySqlCommand cmd = new MySqlCommand(sql, sqlCon);
            cmd.Parameters.AddWithValue("@nev", rogzitendo.Nev);
            cmd.Parameters.AddWithValue("@nemzetiseg", rogzitendo.Nemzetiseg);
            cmd.Parameters.AddWithValue("@szolo", rogzitendo.Szolo);
            int sorokSzama = cmd.ExecuteNonQuery();
            sqlCon.Close();
            return sorokSzama > 0 ? "Sikeresen rögzítve!" : "Hiba a rögzítésnél";
        }

        public List<Eloado> EloadokListaja()
        {
            List<Eloado> eloadoLista = new List<Eloado>();
            try
            { 
            BludConnection();
            sqlCon.Open();
            string sql = "SELECT * FROM eloado";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = sqlCon;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Eloado eloado = new Eloado();
                eloado.Id = reader.GetInt32("Id");
                eloado.Nev = reader.GetString("Nev");
                if (!reader.IsDBNull(2))
                {
                    eloado.Nemzetiseg = reader.GetString("Nemzetiseg");
                }
                eloado.Szolo = reader.GetBoolean("Szolo");
                eloadoLista.Add(eloado);
            }
            sqlCon.Close();
            return eloadoLista;
            }
            catch (Exception ex)
            {
                Eloado hiba = new Eloado()
                {

                }
            }
        }

    }
    
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TagokDesktop
{
    public class DBKapcsolat
    {
        private const string MYSQL_URL = "localhost";
        private const string MYSQL_USER = "root";
        private const string MYSQL_PASSWD = "";
        private const string MYSQL_DB = "tagdij";
        private const string MYSQL_CONNECTIONSTRING = $"server={MYSQL_URL};User Id={MYSQL_USER};Password={MYSQL_PASSWD};Initial catalog={MYSQL_DB}";

        private MySqlConnection sqlConnection;

        public DBKapcsolat()
        {
            sqlConnection = new MySqlConnection(MYSQL_CONNECTIONSTRING);
            sqlConnection.Open();
        }

        public List<Tag> TagokLekerdezese()
        {
            List<Tag> tagok = new List<Tag>();
            
            using (MySqlCommand command = new MySqlCommand("SELECT * FROM ugyfel", sqlConnection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tagok.Add(new Tag
                        {
                            Azon = reader.GetInt32(0),
                            Nev = reader.GetString(1),
                            Szulev = reader.GetInt32(2),
                            Irszam = reader.GetInt32(3),
                            Orsz = reader.GetString(4)
                        });
                    }
                }
            }
            return tagok;
        }

        public bool TagHozzaadasa(Tag ujtag)
        {
            string hozzadas_string = $"INSERT INTO `ugyfel`(`azon`, `nev`, `szulev`, `irszam`, `orsz`) VALUES ({ujtag.Azon},'{ujtag.Nev}',{ujtag.Szulev},{ujtag.Irszam},'{ujtag.Orsz}')";
            MySqlCommand command = new MySqlCommand(hozzadas_string, sqlConnection);

            if(command.ExecuteNonQuery() > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool TagFrissitese(int Azon, Tag tag)
        {
            if(Azon != tag.Azon)
            {
                return false;
            }
            string update_string = $"UPDATE `ugyfel` SET `nev`='{tag.Nev}',`szulev`='{tag.Szulev}',`irszam`='{tag.Irszam}',`orsz`='{tag.Orsz}' WHERE `azon`={Azon}";
            MySqlCommand command = new MySqlCommand(update_string, sqlConnection);

            if (command.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool TagTorlese(int Azon)
        {
            string update_string = $"DELETE FROM `ugyfel` WHERE `azon`={Azon}";
            MySqlCommand command = new MySqlCommand(update_string, sqlConnection);

            if (command.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

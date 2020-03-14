using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminUniv_1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }


    public class DBManager
    {
        //Clase encargada de conectarse a la BD (MySQL) e interactuar con esta


        private static String connString = "server = localhost; user id = root; database=tecvegetal";
        
        private static DBManager dbManager;

        private DBManager()
        {
        }

        public static DBManager getInstance()
        {
            if (dbManager == null)
            {
                dbManager = new DBManager();
                connect();
            }
            return dbManager;
        }

        private static void connect()
        {
            try
            {

                String JDBC_DRIVER = "org.mariadb.jdbc.Driver";
                String dbUrl = "localhost";
                String user = "root";
                String password = "";
                try
                {
                    //Paso 2: Registra el driver
                    Class.forName(JDBC_DRIVER);

                    //Paso 3: Abre la conexión
                    //System.out.println("Conectando a la Base de Datos...");
                    DBManager.conn = DriverManager.getConnection(dbUrl, user, password);
                    System.out.println("Conexión exitosa a la Base de Datos...");



                }
                catch (Exception e)
                {
                }

            }
            catch (Exception e)
            {
            }
        }


        



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;

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

        private static MySqlConnection conn;
        private static MySqlCommand cmd;
        private static DBManager dbManager;
        //private static CallableStatement callablestmt;

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


        public static MySqlConnection getCon()
        {
            return conn;
        }

        /*public CallableStatement getStmt(String query)
        {
            try
            {
                callablestmt = conn.prepareCall(query);
                return callablestmt;
            }
            catch (Exception e)
            {
                return null;
            }

        }*/

        private static void connect()
        {
            try
            {

                //Abre la conexión
                //System.out.println("Conectando a la Base de Datos...");
                DBManager.conn = new MySqlConnection("server = localhost; user id = root; database=tecvegetal; password=");
                conn.Open();

            }
            catch (Exception e)
            {
            }
        }


        public DataSet queryDB(String query)
        {
            try
            {
                cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                return ds;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void disconnectDB()
        {
            //finally block used to close resources
            try
            {
                if (cmd != null)
                {
                    conn.Close();
                }
            }
            catch (MySqlException se)
            {
            }// do nothing
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            catch (MySqlException se)
            {
                se.GetBaseException();
            }//end finally try
        }
    }

    public class Controller
    {
        private Controller controller;

        public Controller()
        {

        }

        Controller getInstance()
        {
            if (controller == null)
            {
                controller = new Controller();
            }
            return controller;
        }


    }

    public class Course
    {
        private String ID;
        private String name;
        private int credits;
    }

    public class Carreer
    {
        private String ID;
        private String name;

    }

    public abstract class User
    {
        protected String ID { get; set; }
        protected String name { get; set; }
        protected String email { get; set; }
        protected String password { get; set; }
        protected ArrayList groups;

        public User() { }

        public User(String ID, String name, String email, String password) {
            this.ID = ID;
            this.name = name;
            this.email = email;
            this.password = password;
            groups = new ArrayList();
        }



    }

    public class Student : User 
    {

        public Student(String ID, String name, String email, String password)
        {
            
        }

    }

    public class Professor : User
    {
        public Professor(String ID, String name, String email, String password)
        {

        }
    }


    public class Group
    {
        private String ID;
        //private evaluations; Se debe hacer una Matrix
    }

    public class Evaluation
    {
        private String name;
        private float points;
        private float percentage;
        private DateTime dueDate;
        private String rubric;
        private Boolean gradePublished;
    }

    public class EvaluationCategory
    {
        private String name;
        private float percentage;
    }

    /*public class Entrega
    {

    }*/

    public class Administrator
    {

    }


}

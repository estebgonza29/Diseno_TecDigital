﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
using AdminUniv_1.Model;

namespace AdminUniv_1.Controller.BDAccess
{
    public class DBAccessSingleton
    {
        //Clase encargada de conectarse a la BD (MySQL) e interactuar con esta        
        private static String connString;
        private static String password = "";
        private static String user = "root";
        private static MySqlConnection conn;
        private static MySqlCommand cmd;
        private static DBAccessSingleton dbAccess;

        private DBAccessSingleton() //Aqui se podrian inicializar el user y el password
        {
            dbAccess = new DBAccessSingleton();
            connect();
        }

        public static DBAccessSingleton getInstance()
        {
            if (dbAccess == null)
            {
                dbAccess = new DBAccessSingleton();
                connect();
            }
            return dbAccess;
        }


        public static MySqlConnection getCon()
        {
            return conn;
        }

        public MySqlCommand procedureDB(String proc)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("proc", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                return cmd;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        private static void connect()
        {
            try
            {

                //Abre la conexión
                //System.out.println("Conectando a la Base de Datos...");
                connString = "server = localhost; user id = " + user + "; database=base_tec; password=" + password;
                DBAccessSingleton.conn = new MySqlConnection(connString);
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

    public class courseManager
    {

        public Course get(String objectID)
        {
            MySqlCommand cmd;          
            String strReturn;
            try
            {
                cmd = DBAccessSingleton.getInstance().procedureDB("getCourse");
                cmd.Parameters.Add(new MySqlParameter("@CustomerID", objectID));
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (rdr.Read())
                    {
                        strReturn = rdr["ProductName"] + " " + rdr["Total"];
                    }
                }
                DBAccessSingleton.getInstance().disconnectDB();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.InnerException);
                return null;
            }
        }

        public LinkedList<Course> getAll()
        {

        }
    }

    public class groupManager
    {
        public Group get(String objectID)
        {

        }

        public LinkedList<Group> getAll()
        {

        }
    }

    public class professorManager
    {
        public Professor get(String objectID)
        {

        }

        public LinkedList<Professor> getAll()
        {

        }
    }

    public class studentManager
    {
        public Student get(String objectID)
        {

        }

        public LinkedList<Student> getAll()
        {

        }
    }

    public class carreerManager
    {
        public Carreer get(String objectID)
        {

        }

        public LinkedList<Carreer> getAll()
        {

        }
    }

    public class handingManager
    {
        public Handing get(String objectID)
        {

        }

        public LinkedList<Handing> getAll()
        {

        }
    }


}

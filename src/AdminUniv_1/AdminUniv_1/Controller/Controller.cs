﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;

namespace AdminUniv_1.Controller
{
    public class DBAccess
    {
        //Clase encargada de conectarse a la BD (MySQL) e interactuar con esta


        private static String connString = "server = localhost; user id = root; database=tecvegetal";

        private static MySqlConnection conn;
        private static MySqlCommand cmd;
        private static DBAccess dbAccess;

        private DBAccess()
        {
        }

        public static DBAccess getInstance()
        {
            if (dbAccess == null)
            {
                dbAccess = new DBAccess();
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
                DBAccess.conn = new MySqlConnection("server = localhost; user id = root; database=tecvegetal; password=");
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
}

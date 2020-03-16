using System;
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

        private DBAccessSingleton() //Aqui se podrian inicializar el user y el password de la BD
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
            
            try
            {
                if (cmd != null)
                {
                    conn.Close();
                }
            }
            catch (MySqlException se)
            {
            }
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
            }
        }

    }

    public class courseManager
    {        

        public LinkedList<LinkedList<String>> getAll()
        {
            MySqlCommand cmd;
            LinkedList<LinkedList<String>> matrixCursos = new LinkedList<LinkedList<string>>();
            LinkedList<String> strReturn = new LinkedList<string>(); ;
            try
            {
                cmd = DBAccessSingleton.getInstance().procedureDB("listCursos");
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Se itera entre los resultados
                    while (rdr.Read())
                    {                        
                        strReturn.AddLast(rdr["id_curso"].ToString());
                        strReturn.AddLast(rdr["nombre"].ToString());
                        strReturn.AddLast(rdr["creditos"].ToString());
                        matrixCursos.AddLast(strReturn);
                        strReturn.Clear();
                    }
                }
                DBAccessSingleton.getInstance().disconnectDB();
                return matrixCursos;                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return null;
            }
        }
    }

    public class groupManager
    {
        public LinkedList<LinkedList<String>> getTabla(String courseID, String groupID)
        {            
            MySqlCommand cmd;
            LinkedList<LinkedList<String>> matrixTabla = new LinkedList<LinkedList<string>>();
            LinkedList<String> listTabla = new LinkedList<String>();
            try
            {
                cmd = DBAccessSingleton.getInstance().procedureDB("tabla");
                cmd.Parameters.Add(new MySqlParameter("@id_curso", courseID));
                cmd.Parameters.Add(new MySqlParameter("@id_grupo", groupID));
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Se itera entre los resultados
                    while (rdr.Read())
                    {                        
                        listTabla.AddLast(rdr["id_evaluacion"].ToString());
                        listTabla.AddLast(rdr["descripcion"].ToString());
                        foreach(String s in getEvaluations(courseID, groupID))
                        {
                            listTabla.AddLast(rdr[s].ToString());
                        }                        
                        matrixTabla.AddLast(listTabla);
                        listTabla.Clear();
                    }
                }
                DBAccessSingleton.getInstance().disconnectDB();
                return matrixTabla;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return null;
            }
        }

        public LinkedList<String> getAll()
        {
            MySqlCommand cmd;
            LinkedList<String> strReturn = new LinkedList<string>();
            try
            {
                cmd = DBAccessSingleton.getInstance().procedureDB("listGrupos");
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Se itera entre los resultados
                    while (rdr.Read())
                    {
                        strReturn.AddLast(rdr["id_grupo"].ToString());
                    }
                }
                DBAccessSingleton.getInstance().disconnectDB();
                return strReturn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return null;
            }
        }
        public LinkedList<LinkedList<String>> getInfoCursoGrupo(String courseID, String groupID)
        {
            MySqlCommand cmd;
            LinkedList<LinkedList<String>> matrixCursoGrupo = new LinkedList<LinkedList<string>>();
            LinkedList<String> listCursoGrupo = new LinkedList<String>();
            try
            {
                cmd = DBAccessSingleton.getInstance().procedureDB("tabla");
                cmd.Parameters.Add(new MySqlParameter("@id_curso", courseID));
                cmd.Parameters.Add(new MySqlParameter("@id_grupo", groupID));
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Se itera entre los resultados
                    while (rdr.Read())
                    {
                        listCursoGrupo.AddLast(rdr["profesor"].ToString());
                        listCursoGrupo.AddLast(rdr["horario"].ToString());
                        listCursoGrupo.AddLast(rdr["aula"].ToString());
                        listCursoGrupo.AddLast(rdr["creditos"].ToString());
                        listCursoGrupo.AddLast(rdr["tipo_curso"].ToString());
                        matrixCursoGrupo.AddLast(listCursoGrupo);
                        listCursoGrupo.Clear();
                    }
                }
                DBAccessSingleton.getInstance().disconnectDB();
                return matrixCursoGrupo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return null;
            }
        }

        public LinkedList<String> getEvaluations(String courseID, String groupID)
        {
            MySqlCommand cmd;
            LinkedList<String> strReturn = new LinkedList<string>();
            try
            {
                cmd = DBAccessSingleton.getInstance().procedureDB("evaluaciones_cg");
                cmd.Parameters.Add(new MySqlParameter("@id_curso", courseID));
                cmd.Parameters.Add(new MySqlParameter("@id_grupo", groupID));
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Se itera entre los resultados
                    while (rdr.Read())
                    {
                        strReturn.AddLast(rdr["Evaluacion"].ToString());
                    }
                }
                DBAccessSingleton.getInstance().disconnectDB();
                return strReturn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return null;
            }
        }

        public LinkedList<LinkedList<String>> getEvaluationNames(String courseID, String groupID)
        {
            MySqlCommand cmd;
            LinkedList<LinkedList<String>> matrixEvaluationNames = new LinkedList<LinkedList<string>>();
            LinkedList<String> strReturn = new LinkedList<string>();
            try
            {
                cmd = DBAccessSingleton.getInstance().procedureDB("evaluaciones_cg");
                cmd.Parameters.Add(new MySqlParameter("@id_curso", courseID));
                cmd.Parameters.Add(new MySqlParameter("@id_grupo", groupID));
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    // Se itera entre los resultados
                    while (rdr.Read())
                    {
                        strReturn.AddLast(rdr["Categoria"].ToString());
                        strReturn.AddLast(rdr["Evaluacion"].ToString());
                        matrixEvaluationNames.AddLast(strReturn);
                        strReturn.Clear();
                    }
                }
                DBAccessSingleton.getInstance().disconnectDB();
                return matrixEvaluationNames;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return null;
            }
        }
    }    

    public class professorManager
    {
        /*public Professor get(String objectID)
        {

        }

        public LinkedList<Professor> getAll()
        {

        }*/
    }

    public class studentManager
    {
        /*public Student get(String objectID)
        {

        }

        public LinkedList<Student> getAll()
        {

        }*/
    }

    public class carreerManager
    {
        /*public Carreer get(String objectID)
        {

        }

        public LinkedList<Carreer> getAll()
        {

        }*/
    }

    public class handingManager
    {
        /*public Handing get(String objectID)
        {

        }

        public LinkedList<Handing> getAll()
        {

        }*/
    }


}

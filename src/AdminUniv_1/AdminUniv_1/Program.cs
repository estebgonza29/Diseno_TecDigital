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
    
    public enum TCourse {Teorico, Practico, TeoricoPractico, Laboratorio}

    public class Course
    {
        private String ID { get; set; }
        private String name { get; set; }
        private int credits { get; set; }
        private TCourse typeCourse { get; set; }

        public Course(String ID, String name, int credits, TCourse typeCourse)
        {
            this.ID = ID;
            this.name = name;
            this.credits = credits;
            this.typeCourse = typeCourse;
        }


    }

    public enum TGrade { Bachillerato, Licenciatura, Maestria, Doctorado}

    public class Carreer
    {
        private String ID { get; set; }
        private String name { get; set; }
        private int duration { get; set; }
        private TGrade typeGrade { get; set; }

        public Carreer(String ID, String name, int duration, TGrade typeGrade)
        {
            this.ID = ID;
            this.name = name;
            this.duration = duration;
            this.typeGrade = typeGrade;
        }


    }

    public abstract class Person
    {
        protected String ID { get; set; }
        protected String name { get; set; }
        protected String email { get; set; }
        protected String password { get; set; }
        protected LinkedList<Group> groups { get; set; }

        public Person() { }

        public Person(String ID, String name, String email, String password) {
            this.ID = ID;
            this.name = name;
            this.email = email;
            this.password = password;
            groups = new LinkedList<Group>();
        }



    }

    public class Student : Person 
    {
        private Carreer studentCarreer { get; set; }
        public Student() : base()
        {

        }

        public Student(String ID, String name, String email, String password, Carreer studentCarreer) : base(ID, name, email, password)
        {
            this.studentCarreer = studentCarreer;    
        }

    }

    public class Professor : Person
    {
        public Professor()
        {

        }
        public Professor(String ID, String name, String email, String password) : base(ID, name, email, password)
        {
            
        }
    }


    public class Group
    {
        private String number { get; set; }
        private Course courseData { get; set; }
        private String schedule { get; set; }
        private String classroom { get; set; }
        private Professor professorData { get; set; }
        private LinkedList<Student> studentList { get; set; }
        private LinkedList<Handing> grades { get; set; }

        public Group(String number, Course courseData, String schedule, String classroom, Professor professorData, LinkedList<Student> studentList, LinkedList<Handing> grades)
        {
            this.number = number;
            this.courseData = courseData;
            this.schedule = schedule;
            this.classroom = classroom;
            this.professorData = professorData;
            this.studentList = studentList;
        }

        public Boolean addStudent(Student s)
        {
            try
            {
                studentList.AddLast(s);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public Boolean eliminateStudent(Student s)
        {
            try
            {
                studentList.Remove(s);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }

    public class Evaluation
    {
        private String ID { get; set; }
        private String description { get; set; }
        private String instructions { get; set; }
        private float percentage { get; set; }
        private DateTime dueDate { get; set; }
        private Boolean isPublished { get; set; }

        public Evaluation(String ID, String description, float percentage, DateTime dueDate, String instructions, Boolean isPublished)
        {
            this.ID = ID;
            this.description = description;
            this.instructions = instructions;
            this.percentage = percentage;
            this.dueDate = dueDate;
            this.isPublished = isPublished;
        }


    }

    public enum TEvaluationState { ATiempo, NoEntregada, Tardia, CalificadaSinPublicar, CalificadaPublicada}

    public class Handing
    {
        private DateTime handed { get; set; }
        private float gradeObtained { get; set; }
        private TEvaluationState state { get; set; }
        private Student student { get; set; }
        private Evaluation evaluation { get; set; }


        public Handing(DateTime handed, float gradeObtained, TEvaluationState state, Student student, Evaluation evaluation)
        {
            this.handed = handed;
            this.gradeObtained = gradeObtained;
            this.state = state;
            this.student = student;
            this.evaluation = evaluation;
        }
    }

}

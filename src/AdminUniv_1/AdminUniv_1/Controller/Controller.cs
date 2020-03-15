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
using AdminUniv_1.Controller.BDAccess;

namespace AdminUniv_1.Controller
{    

    public class Controller
    {
        private DTOGroupData dto { get; set; }
        private groupManager mGroups { get; set; }
        private courseManager mCourses { get; set; }

        public Controller(DTOGroupData dto, groupManager mGroups, courseManager mCourses)
        {
            this.dto = dto;
            this.mGroups = mGroups;
            this.mCourses = mCourses;
        }        

        public void getGroup()
        {

        }

        public void loadCourses()
        {

        }


    }


    public class DTOGroupData
    {
        private String courseID { get; set; }
        private int groupNumber { get; set; }
        private Group groupData { get; set; }
        private LinkedList<Course> courseList { get; set; }

        public DTOGroupData(String courseID, int groupNumber, Group groupData)
        {
            this.courseID = courseID;
            this.groupNumber = groupNumber;
            this.groupData = groupData;
            courseList = new LinkedList<Course>();
        }





    }


}

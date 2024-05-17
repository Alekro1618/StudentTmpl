using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTmpl11
{
    class Student
    {
        private string nameSt;
        private string gender;
        private int yearsOld;
        private string group;
        int nS;
        public string NameSt
        {
            get
            {
                return nameSt;
            }
            set
            {
                nameSt = value;
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }
        public int YearsOld
        {
            get
            {
                return yearsOld;
            }
            set
            {
                yearsOld = value;
            }
        }
        public string Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
            }
        }
        public int NS
        {
            get
            {
                return nS;
            }
            set
            {
                nS = value;
            }
        }
    }
}

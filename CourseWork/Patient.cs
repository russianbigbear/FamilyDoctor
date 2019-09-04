using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CourseWork
{
    public class Patient
    {
        string _full_name;               
        string _family;                 //Семья [по фамилии]
        string _gender;                 //Пол 
        int _age;                       //Возраст 
        string _place_of_residence;     //Место проживания
        int _count_visit;               //Число посещений доктора
        string _diagnosis;              //Диагноз

        /*Свойства Set/ Get для переменных*/
        public string Full_name{
            set { _full_name = value; }
            get { return _full_name; }
        }

        public string Family {
            set { _family = value; }
            get { return _family; }
        }

        public string Gender {
            set { _gender = value; }
            get { return _gender; }
        }

        public int Age {
            set { _age = value; }
            get { return _age; }
        }

        public string Place_of_residence{
            set { _place_of_residence = value; }
            get { return _place_of_residence; }
        }

        public int Count_visit {
            set { _count_visit = value; }
            get { return _count_visit; }
        }

        public string Diagnosis {
            set { _diagnosis = value; }
            get { return _diagnosis; }
        }

        //конструктор с параметром / деструктор
        public Patient(string Obj_Full_name, string Obj_Family, string Obj_Gender, int Obj_Age, string Obj_Place_of_residence, int Obj_Count_visit,string Obj_diagnosis) {
            Full_name = Obj_Full_name;
            Family = Obj_Family;
            Gender = Obj_Gender;
            Age = Obj_Age;
            Place_of_residence = Obj_Place_of_residence;
            Count_visit = Obj_Count_visit;
            Diagnosis = Obj_diagnosis;
        }

        public Patient() {
            Full_name = "Obj_Full_name";
            Family = "Obj_Family";
            Gender = "G";
            Age = 1;
            Place_of_residence = "Obj_Place_of_residence";
            Count_visit = 0;
            Diagnosis = "Obj_diagnosis";
        }

        ~Patient(){}
    }
}

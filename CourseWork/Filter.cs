using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Filter : Form
    {
        Family_Doctor _parrent;
        public Filter(Family_Doctor parrent){
            InitializeComponent();
            _parrent = parrent;
        }

        private void button_Visiting_and_Diagnosis_Click(object sender, EventArgs e)
        {
            if (_parrent.Attendance_count.Count == 6) {
                textBox_D.Text = ""; textBox_S.Text = "";
                textBox_P.Text = ""; textBox_G.Text = "";
                textBox_R.Text = ""; textBox_K.Text = "";
            }

            if (_parrent.Get_dgv_count() > 0)  {
                _parrent.Visitng_and_Diagnosis();

                textBox_D.Text = _parrent.Attendance_count[0];
                textBox_S.Text = _parrent.Attendance_count[1];
                textBox_P.Text = _parrent.Attendance_count[2];
                textBox_G.Text = _parrent.Attendance_count[3];
                textBox_R.Text = _parrent.Attendance_count[4];
                textBox_K.Text = _parrent.Attendance_count[5];
            }
            else MessageBox.Show("Нет данных дря расчёта.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CourseWork
{
    public partial class Family_Doctor : Form
    {
        List<Patient> _patient;              //массив объектов Patient
        List<string> _attendance_count;            //массив диагнозов и посещений


        //конструктор
        public Family_Doctor() {
            InitializeComponent();
            _patient = new List<Patient>();
            _attendance_count = new List<string>();
        }

        public List<string> Attendance_count {
            set { _attendance_count = value; }
            get { return _attendance_count; }
        }

        public int Get_dgv_count() { return dataGridView_Main.Rows.Count; }

        //Защита на ввод
        private void textBox_Full_name_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsLetter(e.KeyChar) == true || e.KeyChar == 8 || e.KeyChar == 32 || e.KeyChar == '-') return;
            e.Handled = true; return;
        }

        private void textBox_Family_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsLetter(e.KeyChar) == true || e.KeyChar == 8 || e.KeyChar == '-') return;
            e.Handled = true; return;
        }

        private void checkBox_men_Enter(object sender, EventArgs e) {
            checkBox_women.CheckState = CheckState.Unchecked;
        }

        private void checkBox_women_Enter(object sender, EventArgs e)
        {
            checkBox_men.CheckState = CheckState.Unchecked;
        }


        private void checkedListBox_Place_of_residence_ItemCheck(object sender, ItemCheckEventArgs e) {
            var list = sender as CheckedListBox;
            if (e.NewValue == CheckState.Checked)
                foreach (int index in list.CheckedIndices)
                    if (index != e.Index)
                        list.SetItemChecked(index, false);
        }

        private void textBox_Diagnosis_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsLetter(e.KeyChar) == true || Char.IsDigit(e.KeyChar) == true || e.KeyChar == 13 || e.KeyChar == 8) {
                e.KeyChar = char.ToUpper(e.KeyChar); return;
            }
            e.Handled = true; return;
        }

        //добавление строки
        private void button_add_Click(object sender, EventArgs e)
        {
            if (textBox_Full_name.Text != "" && textBox_Family.Text != "" && (checkBox_men.CheckState == CheckState.Checked ||
            checkBox_women.CheckState == CheckState.Checked) && checkedListBox_Place_of_residence.CheckedItems.Count == 1
            && textBox_Diagnosis.Text != "")
            {
                dataGridView_Main.Rows.Add();

                //добавление в таблицу / создание обекта
                dataGridView_Main[0, dataGridView_Main.RowCount - 1].Value = textBox_Full_name.Text;

                dataGridView_Main[1, dataGridView_Main.RowCount - 1].Value = textBox_Family.Text;

                if (checkBox_men.CheckState == CheckState.Checked) dataGridView_Main[2, dataGridView_Main.RowCount - 1].Value = 'м';
                else dataGridView_Main[2, dataGridView_Main.RowCount - 1].Value = 'ж';

                dataGridView_Main[3, dataGridView_Main.RowCount - 1].Value = Convert.ToString(numericUpDown_year.Value);

                for (int i = 0; i <= (checkedListBox_Place_of_residence.Items.Count - 1); i++)
                {
                    if (checkedListBox_Place_of_residence.GetItemChecked(i))
                    {
                        dataGridView_Main[4, dataGridView_Main.RowCount - 1].Value = checkedListBox_Place_of_residence.Items[i].ToString();
                    }
                }

                dataGridView_Main[5, dataGridView_Main.RowCount - 1].Value = Convert.ToString(numericUpDown_Count_visit.Value);

                dataGridView_Main[6, dataGridView_Main.RowCount - 1].Value = textBox_Diagnosis.Text;

                //создание вспомогательного обекта ""
                _patient.Add(new Patient(textBox_Full_name.Text, textBox_Family.Text, dataGridView_Main[2, dataGridView_Main.RowCount - 1].Value.ToString(),
                    Convert.ToInt32(numericUpDown_year.Value), dataGridView_Main[4, dataGridView_Main.RowCount - 1].Value.ToString(),
                    Convert.ToInt32(numericUpDown_Count_visit.Value), dataGridView_Main[6, dataGridView_Main.RowCount - 1].Value.ToString()));

                //обнуление полей
                textBox_Full_name.Text = "";
                textBox_Family.Text = "";
                checkBox_men.CheckState = CheckState.Unchecked; checkBox_women.CheckState = CheckState.Unchecked;
                numericUpDown_year.Value = 1;
                for (int i = 0; i < checkedListBox_Place_of_residence.Items.Count; i++) checkedListBox_Place_of_residence.SetItemChecked(i, false);
                numericUpDown_Count_visit.Value = 0;
                textBox_Diagnosis.Text = "";
            }
        }

        //удаление строки
        private void button_delete_Click(object sender, EventArgs e) {
            foreach (DataGridViewRow row in dataGridView_Main.SelectedRows) { _patient.RemoveAt(row.Index); dataGridView_Main.Rows.Remove(row); }
        }

        //редактирование ячейки
        private void dataGridView_Main_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            string s = e.FormattedValue.ToString();

            if (e.ColumnIndex == 0)
                for (int i = 0; i < s.Length; i++)
                    if (char.IsLetter(s[i]) || s[i] == ' ');
                    else e.Cancel = true;

            if (e.ColumnIndex == 1)
                for (int i = 0; i < s.Length; i++) if (char.IsLetter(s[i])) ;
                    else e.Cancel = true;
          
            if (e.ColumnIndex == 2)
                if (s.Length < 1)
                    if (s[0] == 'м' ||  s[0] == 'ж' ) ;
                    else e.Cancel = true;

            if (e.ColumnIndex == 3)
                if (s.Length >= 1 && s.Length <= 3) {
                    int flag = 0;
                    for (int i = 0; i < s.Length; i++)
                        if (char.IsDigit(s[i])) flag = 1;
                        else flag = 0;
                    if (flag == 1) if (Convert.ToInt32(s) >= 1 && Convert.ToInt32(s) <= 117) ;
                        else e.Cancel = true;
                }
                else e.Cancel = true;

            if (e.ColumnIndex == 4)
                if (s == "Деревня" || s == "Село" || s == "Поселок" || s == "Город" || s == "Район" || s == "Краевой центр") ;
                else e.Cancel = true;

            if (e.ColumnIndex == 5)
                if (s.Length >= 1 && s.Length <= 3)
                {
                    int flag = 0;
                    for (int i = 0; i < s.Length; i++)
                        if (char.IsDigit(s[i])) flag = 1;
                        else flag = 0;
                    if (flag == 1) if (Convert.ToInt32(s) >= 0 && Convert.ToInt32(s) <= 100) ;
                        else e.Cancel = true;
                }
                else e.Cancel = true;

            if (e.ColumnIndex == 6)
                for (int i = 0; i < s.Length; i++) if (char.IsLetterOrDigit(s[i]));
                    else e.Cancel = true;
        }

         //защита ввода поиск
        private void toolStripTextBox_Full_name_KeyPress(object sender, KeyPressEventArgs e){
            if (Char.IsLetter(e.KeyChar) == true || e.KeyChar == 8 || e.KeyChar == 32 || e.KeyChar == '-') return;
            e.Handled = true; return;
        }

        private void toolStripTextBox_Family_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsLetter(e.KeyChar) == true || e.KeyChar == 8 || e.KeyChar == '-') return;
            e.Handled = true; return;
        }

        private void toolStripTextBox_Gender_KeyPress(object sender, KeyPressEventArgs e){
            if (toolStripTextBox_Gender.Text.Length < 1) {
                if (e.KeyChar == 'м' || e.KeyChar == 'ж'  || e.KeyChar == 8) return;
            }
            else if ( e.KeyChar == 8) return;
            e.Handled = true; return;
        }

        private void toolStripTextBox_Age_KeyPress(object sender, KeyPressEventArgs e){
            if (toolStripTextBox_Age.Text.Length < 3){
                if (char.IsDigit(e.KeyChar) == true || e.KeyChar == 8) return;
            }
            else if (e.KeyChar == 8) return;
            e.Handled = true; return;
        }

        private void toolStripTextBox_Place_of_residence_KeyPress(object sender, KeyPressEventArgs e){
            if(Char.IsLetter(e.KeyChar) == true || e.KeyChar == 8 || e.KeyChar == '-') return;
            e.Handled = true; return;
        }

        private void toolStripTextBox_Count_visit_KeyPress(object sender, KeyPressEventArgs e){
            if (toolStripTextBox_Count_visit.Text.Length < 3){
                if (char.IsDigit(e.KeyChar) == true || e.KeyChar == 8) return;
            }
            else if (e.KeyChar == 8) return;
            e.Handled = true; return;
        }

        private void toolStripTextBox_Diagnosis_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsLetter(e.KeyChar) == true || Char.IsDigit(e.KeyChar) == true || e.KeyChar == 13 || e.KeyChar == 8) {
                e.KeyChar = char.ToUpper(e.KeyChar); return;
            }
            e.Handled = true; return;
        }

        private void dataGridView_Main_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            _patient[e.RowIndex].Full_name = dataGridView_Main[0, e.RowIndex].Value.ToString();
            _patient[e.RowIndex].Family = dataGridView_Main[1, e.RowIndex].Value.ToString();
            _patient[e.RowIndex].Gender = dataGridView_Main[2, e.RowIndex].Value.ToString();
            _patient[e.RowIndex].Age = Convert.ToInt32(dataGridView_Main[3, e.RowIndex].Value);
            _patient[e.RowIndex].Place_of_residence = dataGridView_Main[4, e.RowIndex].Value.ToString();
            _patient[e.RowIndex].Count_visit = Convert.ToInt32(dataGridView_Main[5, e.RowIndex].Value);
            _patient[e.RowIndex].Diagnosis = dataGridView_Main[6, e.RowIndex].Value.ToString();
        }

        //поиск по значениям
        private void toolStripLabel_search_Click(object sender, EventArgs e) {
            
            for (int i = 0; i < dataGridView_Main.Rows.Count; i++) {
                dataGridView_Main.Rows[i].Visible = true;

                int[] flags = new int[7] { 0, 0, 0, 0, 0, 0, 0};

                if (toolStripTextBox_Full_name.Text == "") flags[0] = 1;
                if (toolStripTextBox_Family.Text == "") flags[1] = 1;
                if (toolStripTextBox_Gender.Text == "") flags[2] = 1;
                if (toolStripTextBox_Age.Text == "") flags[3] = 1;
                if (toolStripTextBox_Place_of_residence.Text == "") flags[4] = 1;
                if (toolStripTextBox_Count_visit.Text == "") flags[5] = 1;
                if (toolStripTextBox_Diagnosis.Text == "") flags[6] = 1;

                if (flags[0] == 0)
                    if (dataGridView_Main[0, i].Value.ToString() == toolStripTextBox_Full_name.Text) ;
                    else dataGridView_Main.Rows[i].Visible = false;

                if (flags[1] == 0)
                    if (dataGridView_Main[1, i].Value.ToString() == toolStripTextBox_Family.Text) ;
                    else dataGridView_Main.Rows[i].Visible = false;

                if (flags[2] == 0)
                    if (dataGridView_Main[2, i].Value.ToString() == toolStripTextBox_Gender.Text) ;
                    else dataGridView_Main.Rows[i].Visible = false;

                if (flags[3] == 0)
                    if (dataGridView_Main[3, i].Value.ToString() == toolStripTextBox_Age.Text) ;
                    else dataGridView_Main.Rows[i].Visible = false;

                if (flags[4] == 0)
                    if (dataGridView_Main[4, i].Value.ToString() == toolStripTextBox_Place_of_residence.Text) ;
                    else dataGridView_Main.Rows[i].Visible = false;

                if (flags[5] == 0)
                    if (dataGridView_Main[5, i].Value.ToString() == toolStripTextBox_Count_visit.Text) ;
                    else dataGridView_Main.Rows[i].Visible = false;

                if (flags[6] == 0)
                    if (dataGridView_Main[6, i].Value.ToString() == toolStripTextBox_Diagnosis.Text) ;
                    else dataGridView_Main.Rows[i].Visible = false;
            }

        }

        //сохранение/загрузка из файла
        private void button_save_Click(object sender, EventArgs e) {
            FileStream stream = new FileStream("Base.txt", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(stream);
            try {
                for (int j = 0; j < dataGridView_Main.Rows.Count; j++){
                    for (int i = 0; i < dataGridView_Main.Rows[j].Cells.Count; i++){
                        streamWriter.Write(dataGridView_Main.Rows[j].Cells[i].Value +  "#");
                    }
                    streamWriter.Write("$");
                }

            streamWriter.Close();
            stream.Close();

            MessageBox.Show("Файл успешно сохранен");
            }
            catch{
                MessageBox.Show("Ошибка при сохранении файла!");
            }
        }

        private void button_load_Click(object sender, EventArgs e) {
            FileStream fStream = new FileStream("Base.txt", FileMode.Open);
            StreamReader streamReader = new StreamReader(fStream);
            dataGridView_Main.Rows.Clear();

            string[] str;
            int numberOfRows = 0;
            try
            {
                string[] str1 = streamReader.ReadToEnd().Split('$');
                numberOfRows = str1.Count();

                for (int i = 0; i < numberOfRows - 1; i++)
                {
                    dataGridView_Main.Rows.Add();
                    str = str1[i].Split('#');
                    for (int j = 0; j < dataGridView_Main.ColumnCount; j++)
                    {
                        dataGridView_Main[j, i].Value = str[j];
                    }

                    _patient.Add(new Patient(dataGridView_Main[0, i].Value.ToString(), dataGridView_Main[1, i].Value.ToString(), dataGridView_Main[2, i].Value.ToString(),
                    Convert.ToInt32(dataGridView_Main[3, i].Value.ToString()), dataGridView_Main[4, i].Value.ToString(),
                    Convert.ToInt32(dataGridView_Main[5, i].Value.ToString()), dataGridView_Main[6, i].Value.ToString()));
                }

                streamReader.Close();
                fStream.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка при открытии файла!");
            }
        }

        private void button_Filter_Click(object sender, EventArgs e) {
            Filter _filter = new CourseWork.Filter(this);
            _filter.ShowDialog();
        }

        //метод по расчету посещений и диагнозов с выбранной территории
        public void Visitng_and_Diagnosis(){
            if (_attendance_count.Count >= 6) _attendance_count.Clear();

            int iD, iS, iP, iG, iR, iK; iD = iS = iP = iG = iR = iK = 0;
            List<string> ERROR = new List<string>();
            for (int i = 0; i < _patient.Count; i++) ERROR.Add(_patient[i].Diagnosis);

            List<string> diag = new List<string>(ERROR.Distinct());

            List<int> flD = new List<int>(); for (int i = 0; i < diag.Count; i++) flD.Add(0);
            List<int> flS = new List<int>(); for (int i = 0; i < diag.Count; i++) flS.Add(0);
            List<int> flP = new List<int>(); for (int i = 0; i < diag.Count; i++) flP.Add(0);
            List<int> flG = new List<int>(); for (int i = 0; i < diag.Count; i++) flG.Add(0);
            List<int> flR = new List<int>(); for (int i = 0; i < diag.Count; i++) flR.Add(0);
            List<int> flK = new List<int>(); for (int i = 0; i < diag.Count; i++) flK.Add(0);

            for (int i = 0; i < _patient.Count; i++) {
                if (_patient[i].Place_of_residence == "Деревня") {
                    iD += _patient[i].Count_visit;
                    for (int j = 0; j < diag.Count; j++)
                        if (_patient[i].Diagnosis == diag[j])
                            flD[j]++;
                }

                if (_patient[i].Place_of_residence == "Село") {
                    iS += _patient[i].Count_visit;
                    for (int j = 0; j < diag.Count; j++)
                        if (_patient[i].Diagnosis == diag[j])
                            flS[j]++;
                }

                if (_patient[i].Place_of_residence == "Поселок") {
                    iP += _patient[i].Count_visit;
                    for (int j = 0; j < diag.Count; j++)
                        if (_patient[i].Diagnosis == diag[j])
                            flP[j]++;
                }

                if (_patient[i].Place_of_residence == "Город") {
                    iG += _patient[i].Count_visit;
                    for (int j = 0; j < diag.Count; j++)
                        if (_patient[i].Diagnosis == diag[j])
                            flG[j]++;
                }

                if (_patient[i].Place_of_residence == "Район") {
                    iR += _patient[i].Count_visit;
                    for (int j = 0; j < diag.Count; j++)
                        if (_patient[i].Diagnosis == diag[j])
                            flR[j]++;
                }

                if (_patient[i].Place_of_residence == "Краевой центр"){
                    iK += _patient[i].Count_visit;
                    for (int j = 0; j < diag.Count; j++)
                        if (_patient[i].Diagnosis == diag[j])
                            flK[j]++;
                }
            }

            int max = 0, index_max = 0;
            if (iD != 0)
            {
                for (int i = 0; i < diag.Count; i++)
                    if (flD[i] > max) { max = flD[i]; index_max = i; }
                _attendance_count.Add("Деревня: Кол. посещений - " + iD.ToString() + ", Частый диагноз - " + diag[index_max] + ".");
            }
            else _attendance_count.Add("Деревня: нет данных по району.");

            max = 0; index_max = 0;
            if (iS != 0)
            {
                for (int i = 0; i < diag.Count; i++)
                    if (flS[i] > max) { max = flS[i]; index_max = i; }
                _attendance_count.Add("Село: Кол. посещений - " + iS.ToString() + ", Частый диагноз - " + diag[index_max] + ".");
            }
            else _attendance_count.Add("Село: нет данных по району.");

            max = 0; index_max = 0;
            if (iP != 0)
            {
                for (int i = 0; i < diag.Count; i++)
                    if (flP[i] > max) { max = flP[i]; index_max = i; }
                _attendance_count.Add("Поселок: Кол. посещений - " + iP.ToString() + ", Частый диагноз - " + diag[index_max] + ".");
            }
            else _attendance_count.Add("Поселок: нет данных по району.");

            max = 0; index_max = 0;
            if (iG != 0)
            {
                for (int i = 0; i < diag.Count; i++)
                    if (flG[i] > max) { max = flG[i]; index_max = i; }
                _attendance_count.Add("Город: Кол. посещений - " + iG.ToString() + ", Частый диагноз - " + diag[index_max] + ".");
            }
            else _attendance_count.Add("Город: нет данных по району.");

            max = 0; index_max = 0;
            if (iR != 0)
            {
                for (int i = 0; i < diag.Count; i++)
                    if (flR[i] > max) { max = flR[i]; index_max = i; }
                _attendance_count.Add("Район: Кол. посещений - " + iR.ToString() + ", Частый диагноз - " + diag[index_max] + ".");
            }
            else _attendance_count.Add("Район: нет данных по району.");

            max = 0; index_max = 0;
            if (iK != 0)
            {
                for (int i = 0; i < diag.Count; i++)
                    if (flK[i] > max) { max = flK[i]; index_max = i; }
                _attendance_count.Add("Краевой центр: Кол. посещений - " + iK.ToString() + ", Частый диагноз - " + diag[index_max] + ".");
            }
            else _attendance_count.Add("Краевой центр: нет данных по району.");

        }

        //сортировка по возрасту
        private void button_age_visible_Click(object sender, EventArgs e) {
            for (int i = 0; i < _patient.Count; i++) dataGridView_Main.Rows[i].Visible = true;

            int down_line = Convert.ToUInt16(numericUpDown_age1.Value);
            int up_line = Convert.ToUInt16(numericUpDown_age2.Value);
            
            if(down_line > up_line) { MessageBox.Show("Нижняя граница больше верхней."); return; }

            for (int i =0; i < _patient.Count; i++)
                if(_patient[i].Age < down_line || _patient[i].Age > up_line) dataGridView_Main.Rows[i].Visible = false;

            
        }

        private void button_cancel_Click(object sender, EventArgs e){
            for(int i = 0; i < _patient.Count; i++) dataGridView_Main.Rows[i].Visible = true;
        }
    }
}


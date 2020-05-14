using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfStudentManagments
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        EntityModel.StudentContext db = new EntityModel.StudentContext();
        EntityModel.Table_1 tblobj = new EntityModel.Table_1();

        private void btbAdd_Click(object sender, RoutedEventArgs e)
        {
             tblobj.StudentName = txtName.Text;
            tblobj.DateOfBirth = dataPicker.SelectedDate.Value.Date;
            tblobj.Gender = (rbMale.IsChecked==true?true:false);
            tblobj.Class = comboClass.Text;
            tblobj.Subject = (cbScienc.IsChecked==true?"Science":"Arts");
            tblobj.FatherName = txtFatherName.Text;
            tblobj.CaliberRate = (int)slider.Value;
            tblobj.Address = txtAddress.Text;
            db.Table_1.Add(tblobj);
            db.SaveChanges();
            ClearControl();
                loadGrid();
                

        }
        private void ClearControl() {
            txtName.Clear();
            txtFatherName.Clear();
            txtAddress.Clear();
            txtEditid.Clear();
            dataPicker.SelectedDate = null;
            rbMale.IsChecked = false;
            rbFmale.IsChecked = false;
            cbArts.IsChecked = false;
            cbScienc.IsChecked = false;
            comboClass.Text = "";
            slider.Value = 0;

        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearControl();
        }
        private void loadGrid() {
            var data = from x in db.Table_1 select x;
            dataGrid.ItemsSource = data.ToList();

        }
        private void cbShow_Checked(object sender, RoutedEventArgs e)
        {
            loadGrid();

        }
        private void cbShow_Unchecked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;

        }
        EntityModel.Table_1 result;
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt32(txtEditid.Text);
            result=db.Table_1.Single(u=>u.id==Id);
            txtName.Text = result.StudentName;
            dataPicker.SelectedDate = result.DateOfBirth;

            if (result.Gender == true)
            {
                rbMale.IsChecked = true;
            }
            else 
                rbFmale.IsChecked = true;
                comboClass.Text = result.Class;
                txtFatherName.Text = result.FatherName;
            if (result.Subject == "Science")
            {
                cbScienc.IsChecked = true;
            }
            else
                cbArts.IsChecked = true;

            slider.Value = (double)result.CaliberRate;
            txtAddress.Text = result.Address;

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            result.StudentName = txtName.Text;
            result.DateOfBirth = dataPicker.SelectedDate.Value.Date;
            result.Gender = (rbMale.IsChecked == true ? true : false);
            result.Class = comboClass.Text;
            result.Subject = (cbScienc.IsChecked == true ? "Science" : "Arts");
            result.FatherName = txtFatherName.Text;
            result.CaliberRate = (int)slider.Value;
            result.Address = txtAddress.Text;
            db.Table_1.Add(result);
            db.Entry(result).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            ClearControl();
            loadGrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt32(txtEditid.Text);
            var d= db.Table_1.Single(u => u.id == Id);
            db.Table_1.Remove(d);
            db.SaveChanges();
            ClearControl();
            loadGrid();


        }
    }
}

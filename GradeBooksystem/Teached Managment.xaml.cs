using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GradeBooksystem.Data;
using GradeBooksystem.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeBooksystem
{
    public partial class Teached_Managment : Window
    {
        Gradecontext con = new Gradecontext();
        public Teached_Managment()
        {
            InitializeComponent();
            LoadData();
        }


        //public void LoadData()
        //{
        //    try
        //    {
        //        var courses = context.Courses.ToList();
        //        coursebox.ItemsSource = courses;
        //        coursebox.DisplayMemberPath = "CName";

        //        var students = context.Users
        //            .Where(u => u.URole == "Student")
        //            .ToList();
        //        studentbox.ItemsSource = students;
        //        studentbox.DisplayMemberPath = "UName";

        //        var grades = context.Grades.ToList();
        //        dgAdmin.ItemsSource = grades;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }
        //}

        //private void btnAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(txtAssignment.Text) || txtAssignment.Text == "Enter assignment name")
        //        {
        //            MessageBox.Show("Please enter assignment name");
        //            return;
        //        }

        //        if (!decimal.TryParse(txtScore.Text, out decimal score))
        //        {
        //            MessageBox.Show("Please enter valid score");
        //            return;
        //        }

        //        if (!decimal.TryParse(txtMaxScore.Text, out decimal maxScore))
        //        {
        //            MessageBox.Show("Please enter valid max score");
        //            return;
        //        }

        //        var newGrade = new Grade
        //        {
        //            AssignmentName = txtAssignment.Text,
        //            Score = score,
        //            MaxScore = maxScore,
        //            EnrollId = 1
        //        };

        //        context.Grades.Add(newGrade);
        //        context.SaveChanges();

        //        MessageBox.Show("Added successfully! ✅");
        //        ClearForm();
        //        LoadData();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Add error: " + ex.Message);
        //    }
        //}

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgAdmin.SelectedItem == null)
            {
                MessageBox.Show("Please select a grade to edit");
                return;
            }

            var selectedGrade = (Grade)dgAdmin.SelectedItem;
            txtAssignment.Text = selectedGrade.AssignmentName;
            txtScore.Text = selectedGrade.Score.ToString();
            txtMaxScore.Text = selectedGrade.MaxScore.ToString();
        }

        //private void btnDelete_Click(object sender, RoutedEventArgs e)
        //{
        //    if (dgAdmin.SelectedItem == null)
        //    {
        //        MessageBox.Show("Please select a grade to delete");
        //        return;
        //    }

        //    var result = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButton.YesNo);
        //    if (result == MessageBoxResult.Yes)
        //    {
        //        var selectedGrade = (Grade)dgAdmin.SelectedItem;
        //        context.Grades.Remove(selectedGrade);
        //        context.SaveChanges();
        //        MessageBox.Show("Deleted successfully! ✅");
        //        LoadData();
        //    }
        //}



        //private void ClearForm()
        //{
        //    txtAssignment.Text = "Enter assignment name";
        //    txtScore.Text = "0";
        //    txtMaxScore.Text = "100";
        //}

        //private void dgAdmin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (dgAdmin.SelectedItem != null)
        //    {
        //        var selectedGrade = dgAdmin.SelectedItem as Grade;
        //        if (selectedGrade != null)
        //        {
        //            txtAssignment.Text = selectedGrade.AssignmentName;
        //            txtScore.Text = selectedGrade.Score.ToString();
        //            txtMaxScore.Text = selectedGrade.MaxScore.ToString();
        //        }
        //    }
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
        public void LoadData()
        {
            try
            {
                var course = con.Courses.ToList();
                 coursebox.ItemsSource = course;
                coursebox.DisplayMemberPath = "CName";

                var student = con.Users.Where(u => u.URole == "Student").ToList();
                studentbox.ItemsSource = student;
                studentbox.DisplayMemberPath = "UName";

                var grades = con.Grades.ToList();
                dgAdmin.ItemsSource = grades;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAssignment.Text))
                {
                    MessageBox.Show("Please enter AssignMent");
                    return;
                }
                else if (!decimal.TryParse(txtScore.Text, out decimal s))
                {
                    MessageBox.Show("please enter valid score");
                    return;
                }
                else if (!decimal.TryParse(txtMaxScore.Text, out decimal MS))
                {
                    MessageBox.Show("please enter valid MS");
                    return;
                }

                var newgrade = new Grade()
                {
                    AssignmentName = txtAssignment.Text,
                    MaxScore = decimal.Parse(txtMaxScore.Text),
                    Score = decimal.Parse(txtScore.Text),
                    EnrollId = 1
                };

                con.Grades.Add(newgrade);
                con.SaveChanges();
                MessageBox.Show("Done Add !!");
                txtAssignment.Clear();
                txtMaxScore.Clear();
                txtScore.Clear();
                LoadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        //private void btnEdit_Click(object sender, RoutedEventArgs e)
        //{
          
        //        if (dgAdmin.SelectedItem == null)
        //        {
        //            MessageBox.Show("Please select from datagrid to edit");
        //            return;
        //        }
        //        var select = (Grade)dgAdmin.SelectedItem;
        //        txtAssignment.Text = select.AssignmentName;
        //        txtMaxScore.Text = select.MaxScore.ToString();
        //        txtScore.Text = select.Score.ToString();
        //    LoadData();
            
        //}

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgAdmin.SelectedItem == null)
                {
                    MessageBox.Show("please select item to delete");
                    return;
                }
                var result = MessageBox.Show("Are you sure ?", "Confirm", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var select = (Grade)dgAdmin.SelectedItem;
                    con.Grades.Remove(select);
                    con.SaveChanges();
                    MessageBox.Show("Done delete");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void dgAdmin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dgAdmin.SelectedItem != null)
                {
                    var select = dgAdmin.SelectedItem as Grade;
                    if (select != null)
                    {
                        txtAssignment.Text = select.AssignmentName;
                        txtScore.Text = select.Score.ToString();
                        txtMaxScore.Text = select.MaxScore.ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error : "+ex.Message);
            }
        }
    }
}
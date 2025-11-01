using System;
using System.Linq;
using System.Windows;
using GradeBooksystem.Data;
using Microsoft.EntityFrameworkCore;

namespace GradeBooksystem
{
    public partial class ViewGradesPage : Window
    {
        Gradecontext con = new Gradecontext();

        public ViewGradesPage()
        {
            InitializeComponent();
            LoadGrades();
            CalculateAVG();
        }
        public void LoadGrades()
        {
            try
            {
                var grades = con.Grades.Include(g => g.enrollment).ThenInclude(e => e.User).Include(g => g.enrollment).ThenInclude(e => e.Course).ToList();
                dgGrades.ItemsSource = grades;
            }
            catch (Exception ex) {
                MessageBox.Show("Error" + ex.Message);
            }
        }
        public void CalculateAVG()
        {
            try
            {
                var grade = con.Grades.ToList();
                if (grade.Any())
                    {
                        decimal total = 0;
                        int count = 0;
                         foreach ( var g in grade)
                          {
                                 if (g.MaxScore > 0) {
                                      decimal present = (g.Score / g.MaxScore) * 100;
                                    total += present;
                                    count++;
                                 }
                         }
                    if (count > 0)
                    {
                        var avg = total / count;
                        AVG.Content = $"AVG : {avg:F2}%";
                    }
                    else
                    {
                        AVG.Content = "invalid AVG";
                    }
                }
                else
                {
                    AVG.Content = "No grades";
                }
                
            }catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }
        //public void LoadGrades()
        //{
        //    try
        //    {
        //        var grades = con.Grades.Include(g => g.enrollment).ThenInclude(e => e.User).Include(g => g.enrollment).ThenInclude(e => e.Course).ToList();
        //        dgGrades.ItemsSource = grades;
        //    } 
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show("Erorr"+ex.Message);
        //    }
        //}
        //public void CalculateAVG()
        //{
        //    try
        //    {
        //        var grade = con.Grades.ToList();
        //        if (grade.Any())
        //        {
        //            int count = 0;
        //            decimal total = 0;
        //            foreach(var item in grade)
        //            {
        //                if (item.MaxScore > 0)
        //                {
        //                    decimal present = (item.Score / item.MaxScore) * 100;
        //                    total += present;
        //                    count++;
        //                }
        //            }
        //            if(count > 0)
        //            {
        //                var avg = total / count;
        //                AVG.Content = $"AVG : {avg:F2}%";
        //            }
        //            else
        //            {
        //                AVG.Content = "invalid grade";
        //            }
        //        }
        //        else
        //        {
        //            AVG.Content = "no grade";
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show("error"+ex.Message);
        //    }
        //}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
    }
}
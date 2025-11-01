using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GradeBooksystem.Data;
using GradeBooksystem.Model;

namespace GradeBooksystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Gradecontext con=new Gradecontext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUser.Text;
            var password = txtpass.Password;
            if (string.IsNullOrWhiteSpace(txtUser.Text) && string.IsNullOrWhiteSpace(txtpass.Password))
            {
                MessageBox.Show("Enter all Data");
            }
            var user=con.Users.FirstOrDefault(u=>u.UName==username &&u.UPassword==password);
       
            if (user != null)
            {
                mytexttrue.Text = "Login Successfull";
                if(user.URole== "Student")
                {
                    ViewGradesPage v=new ViewGradesPage();
                    v.Show();
                    this.Close();
                }else if (user.URole== "Teacher")
                {
                    Teached_Managment g = new  Teached_Managment();
                    g.Show();
                    this.Close();
                }
            }
            else
            {
                mytxtfalse.Text = "invalid UserName and Password";
            }
           
        }
    }
}
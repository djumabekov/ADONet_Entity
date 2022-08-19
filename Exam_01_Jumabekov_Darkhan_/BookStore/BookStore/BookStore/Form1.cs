using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (textBox1.Text != String.Empty && textBox1.Text != String.Empty)
      {
        var newUser = new Users()
        {
          UserName = textBox1.Text,
          Password = textBox2.Text,
        };
        using (BookStoreEntities db = new BookStoreEntities())
        {
          var user = db.Users.Where(x => x.UserName == newUser.UserName).FirstOrDefault();
          if (user == null)
          {
            db.Users.Add(newUser);
            db.SaveChanges();
            MessageBox.Show("Пользователь " + newUser.UserName + " зарегистрирован", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

          }
          else
          {
            MessageBox.Show("Пользователь с таким именем уже существует", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }
      else
      {
        MessageBox.Show("Заполните все поля и попробуйте снова", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }



    private void button1_Click_1(object sender, EventArgs e)
    {
      if (textBox1.Text != String.Empty && textBox1.Text != String.Empty)
      {

        var userName = textBox1.Text;
        var password = textBox2.Text;

        using (BookStoreEntities db = new BookStoreEntities())
        {
          var user = db.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
          if (user != null)
          {
            Hide();
            Form2 newForm = new Form2();
            newForm.Show();
          }
          else
          {
            MessageBox.Show("Имя пользователя или пароль не верны", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }
      else
      {
        MessageBox.Show("Заполните все поля и попробуйте снова", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }
  }
}
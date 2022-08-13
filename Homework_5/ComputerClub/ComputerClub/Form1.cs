using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace ComputerClub
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void groupBox1_Enter(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void label5_Click(object sender, EventArgs e)
    {

    }

    private void label9_Click(object sender, EventArgs e)
    {

    }

    private void label12_Click(object sender, EventArgs e)
    {

    }

    private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void dataRefresh()
    {
      using (ComputerClubEntities db = new ComputerClubEntities())
      {
        var visitorsList = db.Visitors.ToList().Select(x => x.Name);
        var employeesList = db.Employees.ToList().Select(x => x.Name);
        var hallsList = db.Halls.ToList().Select(x => x.Name);
        var ordersList = db.Orders.ToList().Select(x => x.Id);
        var productsList = db.Products.ToList().Select(x => x.Name);
        var visitorsDateList = db.Visitors.ToList().Select(x => x.Date);
        var employeesSheduleDateList = db.EmployeeSchedule.ToList().Select(x => x.Date);
        comboBox1.Items.Clear();
        comboBox5.Items.Clear();
        comboBox6.Items.Clear();
        comboBox7.Items.Clear();
        comboBox8.Items.Clear();
        comboBox2.Items.Clear();
        comboBox3.Items.Clear();
        comboBox4.Items.Clear();
        comboBox9.Items.Clear();
        comboBox10.Items.Clear();
        foreach (string item in visitorsList)
        {
          comboBox1.Items.Add(item);
          comboBox5.Items.Add(item);
        }
        foreach (string item in employeesList)
        {
          comboBox6.Items.Add(item);
          comboBox7.Items.Add(item);
          comboBox8.Items.Add(item);
        }
        foreach (string item in hallsList)
        {
          comboBox2.Items.Add(item);
        }
        foreach (int item in ordersList)
        {
          comboBox3.Items.Add(item);
        }
        foreach (string item in productsList)
        {
          comboBox4.Items.Add(item);
        }
        foreach (DateTime item in visitorsDateList)
        {
          comboBox9.Items.Add(item.Date);
        }
        foreach (DateTime item in employeesSheduleDateList)
        {
          comboBox10.Items.Add(item.Date);
        }
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      dataRefresh();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      using (ComputerClubEntities db = new ComputerClubEntities())
      {
        if (comboBox9.SelectedIndex != -1)
        {
          DateTime date = DateTime.Parse(comboBox9.SelectedItem.ToString());
          var visitorsOnDate = db.Visitors.Where(x => x.Date.Equals(date)).ToList();
          dataGridView1.DataSource = visitorsOnDate;
        }
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      using (ComputerClubEntities db = new ComputerClubEntities())
      {

        if (comboBox1.SelectedIndex != -1 && comboBox9.SelectedIndex != -1)
        {
          DateTime date = DateTime.Parse(comboBox9.SelectedItem.ToString());
          string name = comboBox1.SelectedItem.ToString();
          var visitor = db.Visitors.Where(x => x.Name == name && x.Date.Equals(date)).FirstOrDefault();
          if (visitor != null)
          {

            var orders = db.Orders.Where(x => x.IdVisitor == visitor.Id).ToList();
            if (orders.Count != 0)
            {
              foreach (var item in orders)
              {
                db.Orders.Remove(item);
              }

            }
            db.Visitors.Remove(visitor);
            db.SaveChanges();
            MessageBox.Show("Посетитель " + visitor.Name + " от " + visitor.Date + " удален", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Посетитель на эту дату не найден", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }

        }

      }
      comboBox1.SelectedIndex = -1;
      comboBox9.SelectedIndex = -1;
      dataRefresh();
    }

    private void button3_Click(object sender, EventArgs e)
    {

      if (textBox1.Text != null && dateTimePicker3.Value != null && maskedTextBox2.Text != null && maskedTextBox3.Text != null && comboBox2.SelectedIndex != -1)
      {
        var newVisitor = new Visitors()
        {
          Name = textBox1.Text,
          Date = dateTimePicker3.Value,
          VisitTime = TimeSpan.Parse(maskedTextBox2.Text),
          Duration = TimeSpan.Parse(maskedTextBox3.Text),
          IdHall = comboBox2.SelectedIndex + 1
        };
        using (ComputerClubEntities db = new ComputerClubEntities())
        {
          var visitor = db.Visitors.Where(x => x.Name == newVisitor.Name).FirstOrDefault();
          if (visitor == null)
          {
            db.Visitors.Add(newVisitor);
            db.SaveChanges();
            MessageBox.Show("Посетитель " + newVisitor.Name + " добавлен", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

          }
          else
          {
            MessageBox.Show("Посетитель с таким именем уже существует", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
      comboBox2.SelectedIndex = -1;
      dataRefresh();
    }

    private void button11_Click(object sender, EventArgs e)
    {

      using (ComputerClubEntities db = new ComputerClubEntities())
      {
        if (comboBox10.SelectedIndex != -1)
        {
          db.Configuration.LazyLoadingEnabled = false;
          DateTime date = DateTime.Parse(comboBox10.SelectedItem.ToString());
          var employeesScheduleOnDate = db.EmployeeSchedule.Where(x => x.Date.Equals(date)).Select(x=> new {x.Id, x.Date, x.IdEmployee, x.TimeStart, x.TimeEnd, x.Employees.Name}).ToList();
          dataGridView1.DataSource = employeesScheduleOnDate;
        }
      }
    }

    private void button10_Click(object sender, EventArgs e)
    {
      using (ComputerClubEntities db = new ComputerClubEntities())
      {

        if (comboBox7.SelectedIndex != -1 && comboBox10.SelectedIndex != -1)
        {
          DateTime date = DateTime.Parse(comboBox10.SelectedItem.ToString());
          var employee = db.Employees.Where(x => x.Name == comboBox7.SelectedItem.ToString()).FirstOrDefault();
          if (employee != null)
          {
            var employeeShedule = db.EmployeeSchedule.Where(x => x.IdEmployee == employee.Id && x.Date.Equals(date)).FirstOrDefault();
            if (employeeShedule != null)
            {
              db.EmployeeSchedule.Remove(employeeShedule);
              db.SaveChanges();
              MessageBox.Show("Сотрудник " + employee.Name + " от " + employeeShedule.Date + " удален", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
              MessageBox.Show("Сотрудник на эту дату не найден", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          }
        }
      }
      comboBox7.SelectedIndex = -1;
      comboBox10.SelectedIndex = -1;
      dataRefresh();
    }

    private void button12_Click(object sender, EventArgs e)
    {

      using (ComputerClubEntities db = new ComputerClubEntities())
      {
        if (dateTimePicker6.Value != null && comboBox8.SelectedIndex != -1 && maskedTextBox1.Text != null && maskedTextBox4.Text != null)
        {
          var newEmployeeShedule = new EmployeeSchedule()
          {
            Date = dateTimePicker6.Value,
            IdEmployee = db.Employees.Where(x => x.Name == comboBox8.SelectedItem.ToString()).FirstOrDefault().Id,
            TimeStart = TimeSpan.Parse(maskedTextBox1.Text),
            TimeEnd = TimeSpan.Parse(maskedTextBox4.Text),
          };


          var employeeShedule = db.EmployeeSchedule.Where(x => (x.Date == newEmployeeShedule.Date && x.IdEmployee == newEmployeeShedule.IdEmployee)).FirstOrDefault();
          if (employeeShedule == null)
          {
            db.EmployeeSchedule.Add(newEmployeeShedule);
            db.SaveChanges();
            MessageBox.Show("Сотрудник добавлен", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

          }
          else
          {
            MessageBox.Show("Сотрудник с таким ИД в указанную дату уже существует", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
      comboBox8.SelectedIndex = -1;
      dataRefresh();
    }

    private void button5_Click(object sender, EventArgs e)
    {
      using (ComputerClubEntities db = new ComputerClubEntities())
      {
        db.Configuration.LazyLoadingEnabled = false;
        var orders = db.Orders.Select(x=>new { x.Id, x.IdVisitor, x.IdProduct, x.Products.Name, x.Visitors.Date }).ToList();
        dataGridView1.DataSource = orders;

      }
    }

    private void button4_Click(object sender, EventArgs e)
    {
      using (ComputerClubEntities db = new ComputerClubEntities())
      {

        if (comboBox3.SelectedIndex != -1)
        {
          var order = db.Orders.Where(x => x.Id.ToString() == comboBox3.SelectedItem.ToString()).FirstOrDefault();
          if (order != null)
          {
            db.Orders.Remove(order);
            db.SaveChanges();
            MessageBox.Show("Заказ ИД " + order.Id + " для посетителя с ИД " + order.IdVisitor + " удален", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Заказ не найден", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }

        }
      }
      comboBox3.SelectedIndex = -1;
      dataRefresh();
    }

    private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void button6_Click(object sender, EventArgs e)
    {
      using (ComputerClubEntities db = new ComputerClubEntities())
      {
        if (comboBox5.SelectedItem != null && comboBox4.SelectedItem != null)
        {
          var newOrder = new Orders()
          {
            IdVisitor = db.Visitors.Where(x => x.Name == comboBox5.SelectedItem.ToString()).FirstOrDefault().Id,
            IdProduct = db.Products.Where(x => x.Name == comboBox4.SelectedItem.ToString()).FirstOrDefault().Id,
          };
          db.Orders.Add(newOrder);
          db.SaveChanges();
          MessageBox.Show("Заказ добавлен", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
          MessageBox.Show("Выберите посетителя и заказ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
      comboBox5.SelectedIndex = -1;
      comboBox4.SelectedIndex = -1;
      dataRefresh();
    }

    private void button8_Click(object sender, EventArgs e)
    {
      using (ComputerClubEntities db = new ComputerClubEntities())
      {
        db.Configuration.LazyLoadingEnabled = false;

        var employees = db.Employees.Select(x => new {x.Id, x.Name}).ToList();
        dataGridView1.DataSource = employees;

      }
    }

    private void button7_Click(object sender, EventArgs e)
    {
      using (ComputerClubEntities db = new ComputerClubEntities())
      {


        if (comboBox6.SelectedIndex != -1)
        {
          var employee = db.Employees.Where(x => x.Name == comboBox6.SelectedItem.ToString()).FirstOrDefault();

          if (employee != null)
          {
            var employeeShedule = db.EmployeeSchedule.Where(x => x.IdEmployee == employee.Id).ToList();
            if (employeeShedule.Count != 0)
            {
              foreach (var item in employeeShedule)
              {
                db.EmployeeSchedule.Remove(item);
              }

            }
            db.Employees.Remove(employee);
            db.SaveChanges();
            MessageBox.Show("Сотрудник " + employee.Name + " удален", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Сотрудник не найден", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }

        }

      }
      comboBox6.SelectedIndex = -1;
      dataRefresh();
    }

    private void button9_Click(object sender, EventArgs e)
    {
      using (ComputerClubEntities db = new ComputerClubEntities())
      {
        if (textBox2.Text != null)
        {
          var newEmployee = new Employees()
          {
            Name = textBox2.Text,
          };
          var employee = db.Employees.Where(x => x.Name == newEmployee.Name).FirstOrDefault();
          if (employee == null)
          {
            db.Employees.Add(newEmployee);
            db.SaveChanges();
            MessageBox.Show("Сотрудник добавлен", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Сотрудник с таким именем уже существует", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
        else
        {
          MessageBox.Show("Введите имя сотрудника", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
      textBox2.Text = null;
      dataRefresh();
    }

    private void groupBox8_Enter(object sender, EventArgs e)
    {

    }

    private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
    {

    }
  }
}


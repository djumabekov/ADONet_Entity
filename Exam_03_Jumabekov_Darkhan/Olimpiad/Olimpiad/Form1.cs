using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Olimpiad
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

    private void Form1_Load(object sender, EventArgs e)
    {
      List<string> queries = new List<string>();
      queries.Add("Медальный зачет по странам");
      queries.Add("Медалисты по разным видам спорта");
      queries.Add("Страна, которая собрала больше всего золотых медалей");

      foreach (string item in queries)
      {
        comboBox1.Items.Add(item);
      }
      comboBox1.SelectedIndex = 0;

      comboboxDataLoader();
    }

    private void comboboxDataLoader()
    {
      comboBox2.Items.Clear();
      using (OlympiadsEntities db = new OlympiadsEntities())
      {
        var olimpiadNames = db.Olimpiads.Select(x => x.OlimpiadName).ToList();
        comboBox2.Items.Add("за всю историю олимпиад");
        comboBox6.Items.Add("за всю историю олимпиад");
        foreach (string item in olimpiadNames)
        {
          comboBox2.Items.Add(item);
          comboBox6.Items.Add(item);
          comboBox10.Items.Add(item);
          comboBox12.Items.Add(item);

        }
        comboBox2.SelectedIndex = 0;
        comboBox6.SelectedIndex = 0;
        comboBox10.SelectedIndex = 0;
        comboBox12.SelectedIndex = 0;

        var countries = db.Countries.Select(x => x.Country).ToList();
        foreach (string item in countries)
        {
          comboBox4.Items.Add(item);
          comboBox5.Items.Add(item);
          comboBox7.Items.Add(item);
        }
        comboBox4.SelectedIndex = 0;
        comboBox5.SelectedIndex = 0;
        comboBox7.SelectedIndex = 0;

        var sportTypes = db.SportTypes.Select(x => x.SportType).ToList();
        foreach (string item in sportTypes)
        {
          comboBox3.Items.Add(item);
          comboBox9.Items.Add(item);
          comboBox11.Items.Add(item);
        }
        comboBox3.SelectedIndex = 0;
        comboBox9.SelectedIndex = 0;
        comboBox11.SelectedIndex = 0;

        var athlets = db.Athlets.Select(x => x.Athlet).ToList();
        foreach (string item in athlets)
        {
          comboBox8.Items.Add(item);
          comboBox13.Items.Add(item);
        }
        comboBox8.SelectedIndex = 0;
        comboBox13.SelectedIndex = 0;
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      using (OlympiadsEntities db = new OlympiadsEntities())
      {
        var select = comboBox1.SelectedIndex;
        var temp = comboBox2.SelectedIndex != 0 ? db.Results.Where(x => x.SportGames.Olimpiads.OlimpiadName == comboBox2.SelectedItem.ToString()).ToList() : db.Results.ToList();

        if (select != -1)
        {
          switch (select)
          {
            case 0:
              var result = temp.Select(x => new { x.Athlets.Countries.Country, x.IdAthletWinner }).GroupBy(x => x.Country, x => x.IdAthletWinner).Select(x => new { Name = x.Key, GoldMedalCount = x.Count() }).OrderByDescending(x => x.GoldMedalCount).ToList();
              if (result.Count > 0)
                dataGridView1.DataSource = result;
              break;
            case 1:
              var result1 = temp.Select(x => new { x.SportGames.SportTypes.SportType, x.IdAthletWinner }).GroupBy(x => x.SportType, x => x.IdAthletWinner).Select(x => new { Name = x.Key, GoldMedalCount = x.Count() }).OrderByDescending(x => x.GoldMedalCount).ToList();
              if (result1.Count > 0)
                dataGridView1.DataSource = result1;
              break;
            case 2:
              var result2 = temp.Select(x => new { x.Athlets.Countries.Country, x.IdAthletWinner })
                .GroupBy(x => x.Country, x => x.IdAthletWinner)
                .Select(x => new { Name = x.Key, GoldMedalCount = x.Count() })
                .OrderByDescending(x => x.GoldMedalCount).Take(1).ToList();
              if (result2.Count > 0)
                dataGridView1.DataSource = result2;
              break;
          }
        }
      }
    }

    private void button5_Click(object sender, EventArgs e)
    {
      using (OlympiadsEntities db = new OlympiadsEntities())
      {
        dataGridView1.DataSource = null;
        var temp = comboBox6.SelectedIndex != 0 ? db.Results.Where(x => x.SportGames.Olimpiads.OlimpiadName == comboBox6.SelectedItem.ToString()).ToList() : db.Results.ToList();
        var result = temp.Where(x => x.Athlets.Countries.Country == comboBox5.SelectedItem.ToString())
          .Select(x => new { x.Athlets.Countries.Country, x.SportGames.Olimpiads.OlimpiadName, x.SportGames.IdSportType, x.Athlets.Id, x.IdAthletWinner })
          .GroupBy(x => new { x.Country, x.OlimpiadName, x.IdSportType, x.Id, x.IdAthletWinner }, (key, group) => new
          {
            Key1 = key.Country,
            Key2 = key.OlimpiadName,
            Key3 = key.IdSportType,
            Key4 = key.Id,
            Key5 = group.ToList(),
          })
          .Select(x => new { Country = x.Key1, Olimpiad = x.Key2, SportType = x.Key3, Athlet = x.Key4, GoldMedalCount = x.Key5.Count() })
          .ToList();
        if (result.Count > 0)
          dataGridView1.DataSource = result;
      }
    }


    private void button4_Click(object sender, EventArgs e)
    {
      using (OlympiadsEntities db = new OlympiadsEntities())
      {
        dataGridView1.DataSource = null;
        var result = db.Olimpiads.Select(x => new { x.Countries.Country, x.IdCountry })
                    .GroupBy(x => x.Country, x => x.IdCountry)
                    .Select(x => new { Country = x.Key, Olimpiads_Count = x.Count() })
                    .OrderByDescending(x => x.Olimpiads_Count).Take(1).ToList();
        if (result.Count > 0)
          dataGridView1.DataSource = result;
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      using (OlympiadsEntities db = new OlympiadsEntities())
      {
        dataGridView1.DataSource = null;
        var result = db.Results.Where(x => x.SportGames.SportTypes.SportType == comboBox3.SelectedItem.ToString())
          .Select(x => new { x.Athlets.Athlet, SportType = x.SportGames.SportTypes.SportType, x.IdAthletWinner })
          .GroupBy(x => x.Athlet, x => x.IdAthletWinner)
          .Select(x => new { Athlet = x.Key, GoldMedalCount = x.Count() })
          .OrderByDescending(x => x.GoldMedalCount).Take(1).ToList();
        if (result.Count > 0)
          dataGridView1.DataSource = result;
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      using (OlympiadsEntities db = new OlympiadsEntities())
      {
        dataGridView1.DataSource = null;
        var result = db.Athlets.Where(x => x.Countries.Country == comboBox4.SelectedItem.ToString()).Select(x => new { Name = x.Athlet }).ToList();
        if (result.Count > 0)
          dataGridView1.DataSource = result;
      }
    }

    private void button6_Click(object sender, EventArgs e)
    {
      if (textBox1.Text != String.Empty && comboBox7.SelectedIndex != -1)
      {
        using (OlympiadsEntities db = new OlympiadsEntities())
        {
          var newAthlet = new Athlets()
          {
            Athlet = textBox1.Text,
            Birthdate = dateTimePicker1.Value,
            IdCountry = db.Countries.Where(x => x.Country == comboBox7.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault(),
          };
          var athlet = db.Athlets.Where(x => x.Athlet == newAthlet.Athlet).FirstOrDefault();
          if (athlet == null)
          {
            db.Athlets.Add(newAthlet);
            db.SaveChanges();
            MessageBox.Show("Спортсмен " + newAthlet.Athlet + " добавлен", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Спортсмен с таким именем уже существует", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
      else
      {
        MessageBox.Show("Не все поля заполнены корректно", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void button7_Click(object sender, EventArgs e)
    {
      if (comboBox8.SelectedIndex != -1 && comboBox9.SelectedIndex != -1 && comboBox10.SelectedIndex != -1)
      {
        using (OlympiadsEntities db = new OlympiadsEntities())
        {
          var newSportGame = new SportGames()
          {
            IdSportType = db.SportTypes.Where(x => x.SportType == comboBox9.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault(),
            IdOlimpiad = db.Olimpiads.Where(x => x.OlimpiadName == comboBox10.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault(),
            IdAthlet = db.Athlets.Where(x => x.Athlet == comboBox8.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault(),
          };
          var sportGame = db.SportGames.Where(x => x.SportTypes.SportType == comboBox9.SelectedItem.ToString() && x.Athlets.Athlet == comboBox8.SelectedItem.ToString() && x.Olimpiads.OlimpiadName == comboBox10.SelectedItem.ToString()).FirstOrDefault();
          if (sportGame == null)
          {
            db.SportGames.Add(newSportGame);
            db.SaveChanges();
            MessageBox.Show("Участник " + comboBox8.SelectedItem.ToString() + " по " + comboBox9.SelectedItem.ToString() + " к олимпиаде " + comboBox10.SelectedItem.ToString() + " добавлен", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Участник с таким именем уже существует", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
      else
      {
        MessageBox.Show("Не все поля заполнены корректно", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void button8_Click(object sender, EventArgs e)
    {
      if (comboBox11.SelectedIndex != -1 && comboBox12.SelectedIndex != -1 && comboBox13.SelectedIndex != -1)
      {
        using (OlympiadsEntities db = new OlympiadsEntities())
        {
          var newResult = new Results()
          {
            IdSportGame = db.SportGames.Where(x => x.SportTypes.SportType == comboBox11.SelectedItem.ToString() && x.Olimpiads.OlimpiadName == comboBox10.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault(),
            IdAthletWinner = db.Athlets.Where(x => x.Athlet == comboBox8.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault(),
          };
          if (newResult.IdAthletWinner > 0)
          {
            var result = db.Results.Where(x => x.SportGames.SportTypes.SportType == comboBox11.SelectedItem.ToString() && x.SportGames.Olimpiads.OlimpiadName == comboBox10.SelectedItem.ToString() && x.Athlets.Athlet == comboBox8.SelectedItem.ToString()).FirstOrDefault();

            if (result == null)
            {
              db.Results.Add(newResult);
              db.SaveChanges();
              MessageBox.Show("Победитель " + comboBox8.SelectedItem.ToString() + " по виду спорта " + comboBox11.SelectedItem.ToString() + " добавлен", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
              MessageBox.Show("Победитель с таким именем уже существует", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          }
          else
          {
            MessageBox.Show("Спортсмен не участвует в данных соревнованиях", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

          }
        }
      }
      else
      {
        MessageBox.Show("Не все поля заполнены корректно", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
    {
      using (OlympiadsEntities db = new OlympiadsEntities())
      {
        var sportTypes = db.SportGames.Where(x => x.Olimpiads.OlimpiadName == comboBox12.SelectedItem.ToString()).Select(x => x.SportTypes.SportType).ToList();
        foreach (string item in sportTypes)
        {
          comboBox11.Items.Add(item);
        }
        comboBox11.SelectedIndex = 0;
      }
    }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicStore
{
  public partial class Form2 : Form
  {
    public Form2()
    {
      InitializeComponent();
    }

    private void Form2_Load(object sender, EventArgs e)
    {
      List<string> queries = new List<string>();
      queries.Add("Список новинок пластинок");
      queries.Add("Список самых продаваемых пластинок");
      queries.Add("Список самых популярных авторов");
      queries.Add("Список самых популярных жанров по итогам дня");
      queries.Add("Список самых популярных жанров по итогам недели");
      queries.Add("Список самых популярных жанров по итогам месяца");
      queries.Add("Список самых популярных жанров по итогам года");

      foreach (string item in queries)
      {
        comboBox2.Items.Add(item);
      }
      comboBox2.SelectedIndex = 0;

      List<string> findCriteria = new List<string>();
      findCriteria.Add("по названию");
      findCriteria.Add("по исполнителю");
      findCriteria.Add("по жанру");

      foreach (string item in findCriteria)
      {
        comboBox1.Items.Add(item);
      }
      comboBox1.SelectedIndex = 0;

      comboboxDataLoader();

    }

    private void comboboxDataLoader()
    {
      comboBox3.Items.Clear();
      comboBox4.Items.Clear();
      comboBox5.Items.Clear();
      comboBox6.Items.Clear();
      comboBox7.Items.Clear();
      comboBox9.Items.Clear();
      comboBox10.Items.Clear();
      comboBox11.Items.Clear();
      comboBox13.Items.Clear();
      comboBox14.Items.Clear();
      comboBox15.Items.Clear();
      comboBox16.Items.Clear();
      comboBox17.Items.Clear();
      comboBox18.Items.Clear();
      comboBox19.Items.Clear();

      using (MusicStoreEntities db = new MusicStoreEntities())
      {
        var groups = db.Groups.Select(x => x.GroupName).ToList();
        foreach (string item in groups)
        {
          comboBox11.Items.Add(item);
          comboBox5.Items.Add(item);
        }
        comboBox11.SelectedIndex = 0;
        comboBox5.SelectedIndex = 0;

        var publisher = db.Publishers.Select(x => x.PublisherName).ToList();
        foreach (string item in publisher)
        {
          comboBox10.Items.Add(item);
          comboBox6.Items.Add(item);
        }
        comboBox10.SelectedIndex = 0;
        comboBox6.SelectedIndex = 0;

        var seller = db.Sellers.Select(x => x.SellerName).ToList();
        foreach (string item in seller)
        {
          comboBox17.Items.Add(item);
        }
        comboBox17.SelectedIndex = 0;

        var buyer = db.Buyers.Select(x => x.BuyerName).ToList();
        foreach (string item in buyer)
        {
          comboBox18.Items.Add(item);
          comboBox19.Items.Add(item);
        }
        comboBox18.SelectedIndex = 0;
        comboBox19.SelectedIndex = 0;

        var genres = db.Genres.Select(x => x.GenrerName).ToList();
        foreach (string item in genres)
        {
          comboBox9.Items.Add(item);
          comboBox7.Items.Add(item);
        }
        comboBox9.SelectedIndex = 0;
        comboBox7.SelectedIndex = 0;

        var records = db.Records.Select(x => x.RecordName).ToList();
        foreach (string item in records)
        {
          comboBox3.Items.Add(item);
          comboBox4.Items.Add(item);
          comboBox13.Items.Add(item);
          comboBox14.Items.Add(item);
          comboBox15.Items.Add(item);
          comboBox16.Items.Add(item);
        }
        comboBox3.SelectedIndex = 0;
        comboBox4.SelectedIndex = 0;
        comboBox13.SelectedIndex = 0;
        comboBox14.SelectedIndex = 0;
        comboBox15.SelectedIndex = 0;
        comboBox16.SelectedIndex = 0;
      }
    }
    private void button2_Click(object sender, EventArgs e)
    {
      using (MusicStoreEntities db = new MusicStoreEntities())
      {
        var select = comboBox2.SelectedIndex;

        if (select != -1)
        {
          switch (select)
          {
            case 0:
              var result = db.Records.Where(x => x.PublishYear.Year == DateTime.Now.Year).Select(x => new { x.RecordName, x.PublishYear, x.Groups.GroupName, x.Publishers.PublisherName, x.Genres.GenrerName, x.CountTrack, x.Count, x.SellingPrice, x.CostPrice }).ToList();
              if (result.Count > 0)
                dataGridView1.DataSource = result;
              break;
            case 1:
              var result1 = db.Sales.Select(x => new { x.Records.RecordName, x.Count }).GroupBy(x => x.RecordName, x => x.Count).Select(x => new { Name = x.Key, Count = x.Sum() }).OrderByDescending(x => x.Count).ToList();
              if (result1.Count > 0)
                dataGridView1.DataSource = result1;
              break;
            case 2:
              var result2 = db.Sales.Select(x => new { x.Records.RecordName, x.Records.Groups.GroupName, x.Count }).GroupBy(x => x.GroupName, x => x.Count).Select(x => new { Name = x.Key, Count = x.Sum() }).OrderByDescending(x => x.Count).ToList();
              if (result2.Count > 0)
                dataGridView1.DataSource = result2;
              break;
            case 3:
              var result3 = db.Sales.Where(x => x.SellDate.Day == DateTime.Now.Day).Select(x => new { x.Records.RecordName, x.Records.Genres.GenrerName, x.Count }).GroupBy(x => x.GenrerName, x => x.Count).Select(x => new { Name = x.Key, Count = x.Sum() }).OrderByDescending(x => x.Count).ToList();
              if (result3.Count > 0)
                dataGridView1.DataSource = result3;
              break;
            case 4:
              var dateCriteria = DateTime.Now.Date.AddDays(-7);
              var result4 = db.Sales.Where(x => x.SellDate >= dateCriteria).Select(x => new { x.Records.RecordName, x.Records.Genres.GenrerName, x.Count }).GroupBy(x => x.GenrerName, x => x.Count).Select(x => new { Name = x.Key, Count = x.Sum() }).OrderByDescending(x => x.Count).ToList();
              if (result4.Count > 0)
                dataGridView1.DataSource = result4;
              break;
            case 5:
              var dateCriteria2 = DateTime.Now.Date.AddMonths(-1);
              var result5 = db.Sales.Where(x => x.SellDate >= dateCriteria2).Select(x => new { x.Records.RecordName, x.Records.Genres.GenrerName, x.Count }).GroupBy(x => x.GenrerName, x => x.Count).Select(x => new { Name = x.Key, Count = x.Sum() }).OrderByDescending(x => x.Count).ToList();
              if (result5.Count > 0)
                dataGridView1.DataSource = result5;
              break;
            case 6:
              var dateCriteria3 = DateTime.Now.Date.AddYears(-1);
              var result6 = db.Sales.Where(x => x.SellDate >= dateCriteria3).Select(x => new { x.Records.RecordName, x.Records.Genres.GenrerName, x.Count }).GroupBy(x => x.GenrerName, x => x.Count).Select(x => new { Name = x.Key, Count = x.Sum() }).OrderByDescending(x => x.Count).ToList();
              if (result6.Count > 0)
                dataGridView1.DataSource = result6;
              break;

          }
        }
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      using (MusicStoreEntities db = new MusicStoreEntities())
      {

        var select = comboBox1.SelectedIndex;
        var value = textBox1.Text;
        dataGridView1.DataSource = null;
        if (select != -1)
        {
          switch (select)
          {
            case 0:
              var result = db.Records.Where(x => x.RecordName.Contains(value)).Select(x => new { x.RecordName, x.PublishYear, x.Groups.GroupName, x.Genres.GenrerName, x.Publishers.PublisherName, x.CountTrack, x.Count, x.SellingPrice, x.CostPrice }).ToList();
              if (result.Count > 0)
                dataGridView1.DataSource = result;
              break;
            case 1:
              var result1 = db.Records.Where(x => x.Groups.GroupName.Contains(value)).Select(x => new { x.RecordName, x.PublishYear, x.Groups.GroupName, x.Genres.GenrerName, x.Publishers.PublisherName, x.CountTrack, x.Count, x.SellingPrice, x.CostPrice }).ToList();
              if (result1.Count > 0)
                dataGridView1.DataSource = result1;
              break;
            case 2:
              var result2 = db.Records.Where(x => x.Genres.GenrerName.Contains(value)).Select(x => new { x.RecordName, x.PublishYear, x.Groups.GroupName, x.Genres.GenrerName, x.Publishers.PublisherName, x.CountTrack, x.Count, x.SellingPrice, x.CostPrice }).ToList();
              if (result2.Count > 0)
                dataGridView1.DataSource = result2;
              break;
          }
        }
      }
    }

    private void button4_Click(object sender, EventArgs e)
    {
      if (
        textBox3.Text != String.Empty
        && comboBox11.SelectedIndex != -1
        && comboBox10.SelectedIndex != -1
        && comboBox9.SelectedIndex != -1
        && numericUpDown4.Value > 0
        && dateTimePicker2.Value != null
        && numericUpDown3.Value > 0
        && maskedTextBox4.Text != String.Empty
        && maskedTextBox3.Text != String.Empty
        )
      {
        using (MusicStoreEntities db = new MusicStoreEntities())
        {
          var newRecord = new Records()
          {
            RecordName = textBox3.Text,
            IdGroup = db.Groups.Where(x => x.GroupName == comboBox11.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault(),
            IdPublisher = db.Publishers.Where(x => x.PublisherName == comboBox10.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault(),
            IdGenre = db.Genres.Where(x => x.GenrerName == comboBox9.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault(),
            CountTrack = int.Parse(numericUpDown4.Value.ToString()),
            PublishYear = dateTimePicker2.Value,
            Count = int.Parse(numericUpDown3.Value.ToString()),
            CostPrice = decimal.Parse(maskedTextBox4.Text.ToString()),
            SellingPrice = decimal.Parse(maskedTextBox3.Text.ToString())
          };
          var record = db.Records.Where(x => x.RecordName == newRecord.RecordName).FirstOrDefault();
          if (record == null)
          {
            db.Records.Add(newRecord);
            db.SaveChanges();
            MessageBox.Show("Пластинка " + newRecord.RecordName + " добавлена", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Пластинка с таким именем уже существует", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
      comboboxDataLoader();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      if (comboBox3.SelectedIndex != -1)
      {
        using (MusicStoreEntities db = new MusicStoreEntities())
        {
          var record = db.Records.Where(x => x.RecordName == comboBox3.SelectedItem.ToString()).FirstOrDefault();
          if (record != null)
          {
            db.Records.Remove(record);
            db.SaveChanges();
            MessageBox.Show("Пластинка " + record.RecordName + " удалена", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Пластинка с таким именем не существует", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
      comboboxDataLoader();
    }

    private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
    {
      using (MusicStoreEntities db = new MusicStoreEntities())
      {
        textBox2.Text = comboBox4.SelectedItem.ToString();
        comboBox5.SelectedItem = db.Records.Where(x => x.RecordName == comboBox4.SelectedItem.ToString()).Select(x => x.Groups.GroupName).FirstOrDefault();
        comboBox6.SelectedItem = db.Records.Where(x => x.RecordName == comboBox4.SelectedItem.ToString()).Select(x => x.Publishers.PublisherName).FirstOrDefault();
        comboBox7.SelectedItem = db.Records.Where(x => x.RecordName == comboBox4.SelectedItem.ToString()).Select(x => x.Genres.GenrerName).FirstOrDefault();
      }
    }

    private void button5_Click(object sender, EventArgs e)
    {
      if (
        textBox2.Text != String.Empty
        && comboBox5.SelectedItem.ToString() != String.Empty
        && comboBox6.SelectedItem.ToString() != String.Empty
        && comboBox7.SelectedItem.ToString() != String.Empty
        && numericUpDown2.Value > 0
        && dateTimePicker1.Value != null
        && numericUpDown1.Value > 0
        && maskedTextBox2.Text != String.Empty
        && maskedTextBox1.Text != String.Empty
        )
      {
        using (MusicStoreEntities db = new MusicStoreEntities())
        {
          var record = db.Records.Where(x => x.RecordName == comboBox4.SelectedItem.ToString()).FirstOrDefault();
          if (record != null)
          {
            record.RecordName = textBox2.Text;
            record.IdGroup = db.Groups.Where(x => x.GroupName == comboBox5.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault();
            record.IdPublisher = db.Publishers.Where(x => x.PublisherName == comboBox6.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault();
            record.IdGenre = db.Genres.Where(x => x.GenrerName == comboBox7.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault();
            record.CountTrack = int.Parse(numericUpDown2.Value.ToString());
            record.PublishYear = dateTimePicker1.Value;
            record.Count = int.Parse(numericUpDown1.Value.ToString());
            record.CostPrice = decimal.Parse(maskedTextBox2.Text.ToString());
            record.SellingPrice = decimal.Parse(maskedTextBox1.Text.ToString());
            db.SaveChanges();

            MessageBox.Show("Пластинка " + record.RecordName + " обновлена", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Пластинка с таким именем не существует", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
      else
      {
        MessageBox.Show("Не все поля заполнены корректно", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      comboboxDataLoader();
    }

    private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
    {
      using (MusicStoreEntities db = new MusicStoreEntities())
      {
        var record = db.Records.Where(x => x.RecordName == comboBox13.SelectedItem.ToString()).FirstOrDefault();

        textBox6.Text = record.SellingPrice.ToString();
        textBox7.Text = (db.Stocks.Where(x => x.IdRecord == record.Id).Select(x => x.StockPercent).FirstOrDefault() * 100).ToString();
        textBox5.Text = 0.ToString();
        numericUpDown5.Value = 0;
      }
    }

    private void numericUpDown5_ValueChanged(object sender, EventArgs e)
    {
      if (textBox6.Text != String.Empty && textBox7.Text != String.Empty)
      {
        var totalSum = (decimal.Parse(textBox6.Text) - (decimal.Parse(textBox6.Text) * decimal.Parse(textBox7.Text) / 100)) * decimal.Parse(numericUpDown5.Value.ToString()) - decimal.Parse(textBox8.Text);
        textBox5.Text = totalSum >= 0 ? totalSum.ToString() : 0.ToString();
      }
    }

    private void button6_Click(object sender, EventArgs e)
    {
      if (
       comboBox13.SelectedIndex != -1
       && comboBox17.SelectedIndex != -1
       && comboBox18.SelectedIndex != -1
       && numericUpDown5.Value > 0
       )
      {
        using (MusicStoreEntities db = new MusicStoreEntities())
        {
          var record = db.Records.Where(x => x.RecordName == comboBox13.SelectedItem.ToString()).FirstOrDefault();
          var buyer = db.Buyers.Where(x => x.BuyerName == comboBox18.SelectedItem.ToString()).FirstOrDefault();
          var seller = db.Sellers.Where(x => x.SellerName == comboBox17.SelectedItem.ToString()).FirstOrDefault();
          var discount = db.Stocks.Where(x => x.IdRecord == record.Id).Select(x=>x.StockPercent).FirstOrDefault();
          var totalPrice = (record.SellingPrice - (record.SellingPrice * discount)) * int.Parse(numericUpDown5.Value.ToString()) - buyer.Discount;

          var newSale = new Sales()
          {
            IdRecord = record.Id,
            IdSeller = seller.Id,
            IdBuyer = buyer.Id,
            Count = int.Parse(numericUpDown5.Value.ToString()),
            SellDate = dateTimePicker3.Value,
            TotalPrice = decimal.Parse ((totalPrice >= 0 ? totalPrice : 0).ToString())
          };

          if (record.Count >= newSale.Count)
          {
            db.Sales.Add(newSale);
            record.Count -= newSale.Count;
            buyer.AccumAmount += newSale.TotalPrice;
            db.SaveChanges();
            MessageBox.Show("Пластинка " + newSale.Records.RecordName + " продана " + newSale.Buyers.BuyerName + " продавцом " + newSale.Sellers.SellerName, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Недостаточно книг для продажи", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
      comboboxDataLoader();
    }

    private void button7_Click(object sender, EventArgs e)
    {
      if (comboBox14.SelectedIndex != -1 && numericUpDown6.Value > 0)
      {
        using (MusicStoreEntities db = new MusicStoreEntities())
        {
          var record = db.Records.Where(x => x.RecordName == comboBox14.SelectedItem.ToString()).FirstOrDefault();
          if (record != null && record.Count >= int.Parse(numericUpDown6.Value.ToString()))
          {
            record.Count -= int.Parse(numericUpDown6.Value.ToString());
            db.SaveChanges();
            MessageBox.Show("Списано " + numericUpDown6.Value.ToString() + " пластинок", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Количество пластинок на списание не может превышать общее количество пластинок", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
      comboboxDataLoader();
    }

    private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
    {
      using (MusicStoreEntities db = new MusicStoreEntities())
      {
        var record = db.Records.Where(x => x.RecordName == comboBox15.SelectedItem.ToString()).FirstOrDefault();
        var stock = db.Stocks.Where(x => x.IdRecord == record.Id).FirstOrDefault();
        textBox4.Text = stock != null ? stock.StockName : null;
        numericUpDown8.Value = stock != null ? stock.StockPercent * 100 : 0;
      }
    }

    private void button8_Click(object sender, EventArgs e)
    {
      if (comboBox15.SelectedIndex != -1 && textBox4.Text != String.Empty && numericUpDown8.Value > 0)
      {
        using (MusicStoreEntities db = new MusicStoreEntities())
        {
          var record = db.Records.Where(x => x.RecordName == comboBox15.SelectedItem.ToString()).FirstOrDefault();
          var stock = db.Stocks.Where(x => x.IdRecord == record.Id).FirstOrDefault();

          if (stock != null)
          {
            stock.IdRecord = record.Id;
            stock.StockPercent = decimal.Parse(numericUpDown8.Value.ToString()) / 100;
            stock.StockName = textBox4.Text;
            db.SaveChanges();
            MessageBox.Show("Акция " + stock.StockName + " изменена", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            var newStock = new Stocks()
            {
              IdRecord = record.Id,
              StockPercent = decimal.Parse(numericUpDown8.Value.ToString()) / 100,
              StockName = textBox4.Text
            };
            db.Stocks.Add(newStock);
            db.SaveChanges();
            MessageBox.Show("Акция " + newStock.StockName + " добавлена", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
      else
      {
        MessageBox.Show("Не все поля заполнены корректно", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      comboboxDataLoader();
    }

    private void button9_Click(object sender, EventArgs e)
    {
      if (comboBox16.SelectedIndex != -1 && comboBox19.SelectedIndex != -1 && numericUpDown7.Value > 0)
      {
        using (MusicStoreEntities db = new MusicStoreEntities())
        {
          var record = db.Records.Where(x => x.RecordName == comboBox16.SelectedItem.ToString()).FirstOrDefault();
          var buyer = db.Buyers.Where(x => x.BuyerName == comboBox19.SelectedItem.ToString()).FirstOrDefault();
          if (record != null && buyer != null && record.Count >= int.Parse(numericUpDown7.Value.ToString()))
          {
            var newReserve = new Reserves()
            {
              IdRecord = record.Id,
              IdBuyer = buyer.Id,
              Count = int.Parse(numericUpDown7.Value.ToString())
            };
            db.Reserves.Add(newReserve);
            record.Count -= int.Parse(numericUpDown7.Value.ToString());
            db.SaveChanges();
            MessageBox.Show("Отложено " + numericUpDown7.Value.ToString() + " пластинок для покупателя " + buyer.BuyerName, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Количество пластинок на резерв не может превышать общее количество пластинок", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
      else
      {
        MessageBox.Show("Не все поля заполнены корректно", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      comboboxDataLoader();
    }

    private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
    {
      using (MusicStoreEntities db = new MusicStoreEntities())
      {
        var buyer = db.Buyers.Where(x => x.BuyerName == comboBox18.SelectedItem.ToString()).FirstOrDefault();
        textBox8.Text = buyer.Discount.ToString();
      }
    }

    private void button10_Click(object sender, EventArgs e)
    {
      if (textBox9.Text != String.Empty)
      {
        using (MusicStoreEntities db = new MusicStoreEntities())
        {
          var buyer = db.Buyers.Where(x => x.BuyerName == textBox9.Text).FirstOrDefault();
          if (buyer == null)
          {
            var newBuyer = new Buyers()
            {
              BuyerName = textBox9.Text,
              AccumAmount = 0
            };
            db.Buyers.Add(newBuyer);
            db.SaveChanges();
            MessageBox.Show("Покупатель " + textBox9.Text + " зарегистрирован", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Покупатель с таким именем уже существует", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
      else
      {
        MessageBox.Show("Не все поля заполнены корректно", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      comboboxDataLoader();
    }
  }
}

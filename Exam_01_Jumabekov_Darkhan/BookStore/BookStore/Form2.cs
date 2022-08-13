using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BookStore
{
  public partial class Form2 : Form
  {
    public Form2()
    {
      InitializeComponent();
    }

    private void label6_Click(object sender, EventArgs e)
    {

    }

    private void groupBox1_Enter(object sender, EventArgs e)
    {

    }

    private void Form2_Load(object sender, EventArgs e)
    {
      List<string> queries = new List<string>();
      queries.Add("Список новинок книг");
      queries.Add("Список самых продаваемых книг");
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
      findCriteria.Add("по автору");
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
      comboBox8.Items.Clear();
      comboBox9.Items.Clear();
      comboBox10.Items.Clear();
      comboBox12.Items.Clear();
      comboBox13.Items.Clear();
      comboBox14.Items.Clear();
      comboBox15.Items.Clear();
      comboBox16.Items.Clear();
      comboBox17.Items.Clear();
      comboBox18.Items.Clear();
      comboBox19.Items.Clear();

      using (BookStoreEntities db = new BookStoreEntities())
      {
        var authors = db.Authors.Select(x => x.AuthorName).ToList();
        foreach (string item in authors)
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

        var books = db.Books.Select(x => x.BookName).ToList();
        foreach (string item in books)
        {
          comboBox8.Items.Add(item);
          comboBox3.Items.Add(item);
          comboBox4.Items.Add(item);
          comboBox12.Items.Add(item);
          comboBox13.Items.Add(item);
          comboBox14.Items.Add(item);
          comboBox15.Items.Add(item);
          comboBox16.Items.Add(item);
        }
        comboBox8.SelectedIndex = 0;
        comboBox3.SelectedIndex = 0;
        comboBox4.SelectedIndex = 0;
        comboBox12.SelectedIndex = 0;
        comboBox13.SelectedIndex = 0;
        comboBox14.SelectedIndex = 0;
        comboBox15.SelectedIndex = 0;
        comboBox16.SelectedIndex = 0;
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      using (BookStoreEntities db = new BookStoreEntities())
      {
        var select = comboBox2.SelectedIndex;

        if (select != -1)
        {
          switch (select)
          {
            case 0:
              var result = db.Books.Where(x => x.PublishYear.Year == DateTime.Now.Year).Select(x => new { x.BookName, x.PublishYear, x.Authors.AuthorName, x.Publishers.PublisherName, x.Genres.GenrerName, Continue = x.Books2.BookName, x.Pages, x.Count, x.SellingPrice, x.CostPrice }).ToList();
              if (result.Count > 0)
                dataGridView1.DataSource = result;
              break;
            case 1:
              var result1 = db.Sales.Select(x => new { x.Books.BookName, x.Count }).GroupBy(x => x.BookName, x => x.Count).Select(x => new { Name = x.Key, Count = x.Sum() }).OrderByDescending(x => x.Count).ToList();
              if (result1.Count > 0)
                dataGridView1.DataSource = result1;
              break;
            case 2:
              var result2 = db.Sales.Select(x => new { x.Books.BookName, x.Books.Authors.AuthorName, x.Count }).GroupBy(x => x.AuthorName, x => x.Count).Select(x => new { Name = x.Key, Count = x.Sum() }).OrderByDescending(x => x.Count).ToList();
              if (result2.Count > 0)
                dataGridView1.DataSource = result2;
              break;
            case 3:
              var result3 = db.Sales.Where(x => x.SellDate.Day == DateTime.Now.Day).Select(x => new { x.Books.BookName, x.Books.Genres.GenrerName, x.Count }).GroupBy(x => x.GenrerName, x => x.Count).Select(x => new { Name = x.Key, Count = x.Sum() }).OrderByDescending(x => x.Count).ToList();
              if (result3.Count > 0)
                dataGridView1.DataSource = result3;
              break;
            case 4:
              var dateCriteria = DateTime.Now.Date.AddDays(-7);
              var result4 = db.Sales.Where(x => x.SellDate >= dateCriteria).Select(x => new { x.Books.BookName, x.Books.Genres.GenrerName, x.Count }).GroupBy(x => x.GenrerName, x => x.Count).Select(x => new { Name = x.Key, Count = x.Sum() }).OrderByDescending(x => x.Count).ToList();
              if (result4.Count > 0)
                dataGridView1.DataSource = result4;
              break;
            case 5:
              var dateCriteria2 = DateTime.Now.Date.AddMonths(-1);
              var result5 = db.Sales.Where(x => x.SellDate >= dateCriteria2).Select(x => new { x.Books.BookName, x.Books.Genres.GenrerName, x.Count }).GroupBy(x => x.GenrerName, x => x.Count).Select(x => new { Name = x.Key, Count = x.Sum() }).OrderByDescending(x => x.Count).ToList();
              if (result5.Count > 0)
                dataGridView1.DataSource = result5;
              break;
            case 6:
              var dateCriteria3 = DateTime.Now.Date.AddYears(-1);
              var result6 = db.Sales.Where(x => x.SellDate >= dateCriteria3).Select(x => new { x.Books.BookName, x.Books.Genres.GenrerName, x.Count }).GroupBy(x => x.GenrerName, x => x.Count).Select(x => new { Name = x.Key, Count = x.Sum() }).OrderByDescending(x => x.Count).ToList();
              if (result6.Count > 0)
                dataGridView1.DataSource = result6;
              break;

          }
        }
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      using (BookStoreEntities db = new BookStoreEntities())
      {

        var select = comboBox1.SelectedIndex;
        var value = textBox1.Text;
        dataGridView1.DataSource = null;
        if (select != -1)
        {
          switch (select)
          {
            case 0:
              var result = db.Books.Where(x => x.BookName.Contains(value)).Select(x => new { x.BookName, x.PublishYear, x.Authors.AuthorName, x.Genres.GenrerName, x.Publishers.PublisherName, Continue = x.Books2.BookName, x.Pages, x.Count, x.SellingPrice, x.CostPrice }).ToList();
              if (result.Count > 0)
                dataGridView1.DataSource = result;
              break;
            case 1:
              var result1 = db.Books.Where(x => x.Authors.AuthorName.Contains(value)).Select(x => new { x.BookName, x.PublishYear, x.Authors.AuthorName, x.Genres.GenrerName, x.Publishers.PublisherName, Continue = x.Books2.BookName, x.Pages, x.Count, x.SellingPrice, x.CostPrice }).ToList();
              if (result1.Count > 0)
                dataGridView1.DataSource = result1;
              break;
            case 2:
              var result2 = db.Books.Where(x => x.Genres.GenrerName.Contains(value)).Select(x => new { x.BookName, x.PublishYear, x.Authors.AuthorName, x.Genres.GenrerName, x.Publishers.PublisherName, Continue = x.Books2.BookName, x.Pages, x.Count, x.SellingPrice, x.CostPrice }).ToList();
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
        && comboBox8.SelectedIndex != -1
        && numericUpDown4.Value > 0
        && dateTimePicker2.Value != null
        && numericUpDown3.Value > 0
        && maskedTextBox4.Text != String.Empty
        && maskedTextBox3.Text != String.Empty
        )
      {
        using (BookStoreEntities db = new BookStoreEntities())
        {
          var newBook = new Books()
          {
            BookName = textBox3.Text,
            IdAuthor = db.Authors.Where(x => x.AuthorName == comboBox11.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault(),
            IdPublisher = db.Publishers.Where(x => x.PublisherName == comboBox10.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault(),
            IdGenre = db.Genres.Where(x => x.GenrerName == comboBox9.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault(),
            IdContinueBook = db.Books.Where(x => x.BookName == comboBox8.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault(),
            Pages = int.Parse(numericUpDown4.Value.ToString()),
            PublishYear = dateTimePicker2.Value,
            Count = int.Parse(numericUpDown3.Value.ToString()),
            CostPrice = decimal.Parse(maskedTextBox4.Text.ToString()),
            SellingPrice = decimal.Parse(maskedTextBox3.Text.ToString())
          };
          var book = db.Books.Where(x => x.BookName == newBook.BookName).FirstOrDefault();
          if (book == null)
          {
            db.Books.Add(newBook);
            db.SaveChanges();
            MessageBox.Show("Книга " + newBook.BookName + " добавлена", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Кинга с таким именем уже существует", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
      comboboxDataLoader();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      if (comboBox3.SelectedIndex != -1)
      {
        using (BookStoreEntities db = new BookStoreEntities())
        {
          var book = db.Books.Where(x => x.BookName == comboBox3.SelectedItem.ToString()).FirstOrDefault();
          if (book != null)
          {
            db.Books.Remove(book);
            db.SaveChanges();
            MessageBox.Show("Книга " + book.BookName + " удалена", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Кинга с таким именем не существует", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
      comboboxDataLoader();
    }

    private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
    {
      using (BookStoreEntities db = new BookStoreEntities())
      {
        textBox2.Text = comboBox4.SelectedItem.ToString();
        comboBox5.SelectedItem = db.Books.Where(x => x.BookName == comboBox4.SelectedItem.ToString()).Select(x => x.Authors.AuthorName).FirstOrDefault();
        comboBox6.SelectedItem = db.Books.Where(x => x.BookName == comboBox4.SelectedItem.ToString()).Select(x => x.Publishers.PublisherName).FirstOrDefault();
        comboBox7.SelectedItem = db.Books.Where(x => x.BookName == comboBox4.SelectedItem.ToString()).Select(x => x.Genres.GenrerName).FirstOrDefault();
        comboBox12.SelectedItem = db.Books.Where(x => x.BookName == comboBox4.SelectedItem.ToString()).Select(x => x.Books2.BookName).FirstOrDefault();

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
        using (BookStoreEntities db = new BookStoreEntities())
        {
          var book = db.Books.Where(x => x.BookName == comboBox4.SelectedItem.ToString()).FirstOrDefault();
          if (book != null)
          {
            book.BookName = textBox2.Text;
            book.IdAuthor = db.Authors.Where(x => x.AuthorName == comboBox5.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault();
            book.IdPublisher = db.Publishers.Where(x => x.PublisherName == comboBox6.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault();
            book.IdGenre = db.Genres.Where(x => x.GenrerName == comboBox7.SelectedItem.ToString()).Select(x => x.Id).FirstOrDefault();
            book.IdContinueBook = db.Books.Where(x => x.BookName == comboBox4.SelectedItem.ToString()).Select(x => x.Books2.Id).FirstOrDefault();
            book.Pages = int.Parse(numericUpDown2.Value.ToString());
            book.PublishYear = dateTimePicker1.Value;
            book.Count = int.Parse(numericUpDown1.Value.ToString());
            book.CostPrice = decimal.Parse(maskedTextBox2.Text.ToString());
            book.SellingPrice = decimal.Parse(maskedTextBox1.Text.ToString());
            db.SaveChanges();

            MessageBox.Show("Книга " + book.BookName + " обновлена", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Кинга с таким именем не существует", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
      else
      {
        MessageBox.Show("Не все поля заполнены корректно", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      comboboxDataLoader();
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
        using (BookStoreEntities db = new BookStoreEntities())
        {
          var book = db.Books.Where(x => x.BookName == comboBox13.SelectedItem.ToString()).FirstOrDefault();
          var seller = db.Sellers.Where(x => x.SellerName == comboBox17.SelectedItem.ToString()).FirstOrDefault();
          var buyer = db.Buyers.Where(x => x.BuyerName == comboBox18.SelectedItem.ToString()).FirstOrDefault();
          var discount = db.Stocks.Where(x => x.IdBook == book.Id).Select(x=>x.StockPercent).FirstOrDefault();
          var totalPrice = (book.SellingPrice - (book.SellingPrice * discount)) * int.Parse(numericUpDown5.Value.ToString());

          var newSale = new Sales()
          {
            IdBook = book.Id,
            IdSeller = seller.Id,
            IdBuyer = buyer.Id,
            Count = int.Parse(numericUpDown5.Value.ToString()),
            SellDate = dateTimePicker3.Value,
            TotalPrice = totalPrice
          };

          if (book.Count >= newSale.Count)
          {
            db.Sales.Add(newSale);
            book.Count -= newSale.Count;
            db.SaveChanges();
            MessageBox.Show("Книга " + newSale.Books.BookName + " продана " + newSale.Buyers.BuyerName + " продавцом " + newSale.Sellers.SellerName, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Недостаточно книг для продажи", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
      comboboxDataLoader();
    }

    private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
    {
      using (BookStoreEntities db = new BookStoreEntities())
      {
        var book = db.Books.Where(x => x.BookName == comboBox13.SelectedItem.ToString()).FirstOrDefault();

        textBox6.Text = book.SellingPrice.ToString();
        textBox7.Text = (db.Stocks.Where(x => x.IdBook == book.Id).Select(x => x.StockPercent).FirstOrDefault() * 100).ToString();
        textBox5.Text = 0.ToString();
        numericUpDown5.Value = 0;
      }
    }

    private void numericUpDown5_ValueChanged(object sender, EventArgs e)
    {
      if (textBox6.Text != String.Empty && textBox7.Text != String.Empty)
      {
        textBox5.Text = ((decimal.Parse(textBox6.Text) - (decimal.Parse(textBox6.Text) * decimal.Parse(textBox7.Text) / 100)) * decimal.Parse(numericUpDown5.Value.ToString())).ToString();
      }
    }

    private void button7_Click(object sender, EventArgs e)
    {
      if (comboBox14.SelectedIndex != -1 && numericUpDown6.Value > 0)
      {
        using (BookStoreEntities db = new BookStoreEntities())
        {
          var book = db.Books.Where(x => x.BookName == comboBox14.SelectedItem.ToString()).FirstOrDefault();
          if (book != null && book.Count >= int.Parse(numericUpDown6.Value.ToString()))
          {
            book.Count -= int.Parse(numericUpDown6.Value.ToString());
            db.SaveChanges();
            MessageBox.Show("Списано " + numericUpDown6.Value.ToString() + " книг", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Количество книг на списание не может превышать общее количество книг", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
      comboboxDataLoader();
    }

    private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
    {
      using (BookStoreEntities db = new BookStoreEntities())
      {
        var book = db.Books.Where(x => x.BookName == comboBox15.SelectedItem.ToString()).FirstOrDefault();
        var stock = db.Stocks.Where(x => x.IdBook == book.Id).FirstOrDefault();
        textBox4.Text = stock != null ? stock.StockName : null;
        numericUpDown8.Value = stock != null ? stock.StockPercent * 100 : 0;
      }
    }

    private void button8_Click(object sender, EventArgs e)
    {
      if (comboBox15.SelectedIndex != -1 && textBox4.Text != String.Empty && numericUpDown8.Value > 0)
      {
        using (BookStoreEntities db = new BookStoreEntities())
        {
          var book = db.Books.Where(x => x.BookName == comboBox15.SelectedItem.ToString()).FirstOrDefault();
          var stock = db.Stocks.Where(x => x.IdBook == book.Id).FirstOrDefault();

          if (stock != null)
          {
            stock.IdBook = book.Id;
            stock.StockPercent = decimal.Parse(numericUpDown8.Value.ToString()) / 100;
            stock.StockName = textBox4.Text;
            db.SaveChanges();
            MessageBox.Show("Акция " + stock.StockName + " изменена", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            var newStock = new Stocks()
            {
              IdBook = book.Id,
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
        using (BookStoreEntities db = new BookStoreEntities())
        {
          var book = db.Books.Where(x => x.BookName == comboBox16.SelectedItem.ToString()).FirstOrDefault();
          var buyer = db.Buyers.Where(x => x.BuyerName == comboBox19.SelectedItem.ToString()).FirstOrDefault();
          if (book != null && buyer != null && book.Count >= int.Parse(numericUpDown7.Value.ToString()))
          {
            var newReserve = new Reserves()
            {
              IdBook = book.Id,
              IdBuyer = buyer.Id,
              Count = int.Parse(numericUpDown7.Value.ToString())
            };
            db.Reserves.Add(newReserve);
            book.Count -= int.Parse(numericUpDown7.Value.ToString());
            db.SaveChanges();
            MessageBox.Show("Отложено " + numericUpDown7.Value.ToString() + " книг для покупателя " + buyer.BuyerName, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Количество книг на резерв не может превышать общее количество книг", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    }
  }
}


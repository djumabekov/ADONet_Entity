﻿namespace MusicStore
{
  partial class Form1
  {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.button2 = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.button2);
      this.groupBox1.Controls.Add(this.textBox1);
      this.groupBox1.Controls.Add(this.button1);
      this.groupBox1.Controls.Add(this.textBox2);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Location = new System.Drawing.Point(39, 51);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(485, 315);
      this.groupBox1.TabIndex = 7;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Авторизация";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(87, 59);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 20);
      this.label1.TabIndex = 2;
      this.label1.Text = "Логин";
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(91, 232);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(131, 46);
      this.button2.TabIndex = 5;
      this.button2.Text = "Регистрация";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(91, 82);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(276, 26);
      this.textBox1.TabIndex = 0;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(243, 232);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(124, 46);
      this.button1.TabIndex = 4;
      this.button1.Text = "Вход";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(91, 178);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(276, 26);
      this.textBox2.TabIndex = 1;
      this.textBox2.UseSystemPasswordChar = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(87, 155);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(67, 20);
      this.label2.TabIndex = 3;
      this.label2.Text = "Пароль";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(580, 422);
      this.Controls.Add(this.groupBox1);
      this.Name = "Form1";
      this.Text = "Авторизация";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Label label2;
  }
}

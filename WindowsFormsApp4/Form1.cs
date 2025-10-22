using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic; // 用于 InputBox 查找功能

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 打开文件
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件|*.txt|所有文件|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(ofd.FileName);
                toolStripStatusLabel1.Text = "已打开：" + ofd.FileName;
            }
        }

        // 保存文件
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, richTextBox1.Text);
                toolStripStatusLabel1.Text = "已保存：" + sfd.FileName;
            }
        }

        // 设置字体
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font;
            }
        }

        // 设置颜色
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog.Color;
            }
        }

        // 查找文字
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form inputForm = new Form())
            {
                inputForm.Text = "查找";
                Label label = new Label() { Left = 10, Top = 20, Text = "请输入要查找的文字：" };
                TextBox textBox = new TextBox() { Left = 10, Top = 50, Width = 200 };
                Button okButton = new Button() { Text = "确定", Left = 80, Width = 80, Top = 80, DialogResult = DialogResult.OK };

                inputForm.Controls.Add(label);
                inputForm.Controls.Add(textBox);
                inputForm.Controls.Add(okButton);
                inputForm.AcceptButton = okButton;

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    string findText = textBox.Text;
                    if (!string.IsNullOrEmpty(findText))
                    {
                        int index = richTextBox1.Find(findText);
                        if (index >= 0)
                        {
                            richTextBox1.Select(index, findText.Length);
                            richTextBox1.Focus();
                        }
                        else
                        {
                            MessageBox.Show("未找到指定内容！");
                        }
                    }
                }
            }
        }


        // 退出
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

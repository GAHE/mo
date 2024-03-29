﻿#using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //*************************************** *******
            //来自博客http://blog.csdn.net/fujie724
            //**********************************************
            object oMissing = System.Reflection.Missing.Value;
            //创建一个Word应用程序实例
            Microsoft.Office.Interop.Word.Application oWord = new Microsoft.Office.Interop.Word.Application();
            //设置为不可见
            oWord.Visible = false;
           
            //模板文件地址，这里假设在X盘根目录
            object oTemplate = "D://template.dot";
            //以模板为基础生成文档
            Microsoft.Office.Interop.Word._Document oDoc = oWord.Documents.Add(ref oTemplate, ref oMissing, ref oMissing, ref oMissing);
            //声明书签数组
            object[] oBookMark = new object[5];
            //赋值书签名
            oBookMark[0] = "beizhu";
            oBookMark[1] = "name";
            oBookMark[2] = "sex";
            oBookMark[3] = "birthday";
            oBookMark[4] = "hometown";
            //赋值任意数据到书签的位置
            oDoc.Bookmarks.get_Item(ref oBookMark[0]).Range.Text = "使用模板实现Word生成";
            oDoc.Bookmarks.get_Item(ref oBookMark[1]).Range.Text = "李四";
            oDoc.Bookmarks.get_Item(ref oBookMark[2]).Range.Text = "女";
            oDoc.Bookmarks.get_Item(ref oBookMark[3]).Range.Text = "1987.06.07";
            oDoc.Bookmarks.get_Item(ref oBookMark[4]).Range.Text = "贺州";
            //弹出保存文件对话框，保存生成的Word
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word Document(*.doc)|*.doc";
            sfd.DefaultExt = "Word Document(*.doc)|*.doc";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                object filename = sfd.FileName;

                oDoc.SaveAs(ref filename, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing);
                oDoc.Close(ref oMissing, ref oMissing, ref oMissing);
                //关闭word
                oWord.Quit(ref oMissing, ref oMissing, ref oMissing);
            }

        }
    }
}

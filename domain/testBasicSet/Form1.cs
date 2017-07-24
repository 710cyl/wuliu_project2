using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.ByteCode.Castle;
using domain;
using WebSocketSharp;
using Basic_SetTest;
using System.Threading;
using Newtonsoft.Json;
namespace testBasicSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        public void showData()
        {
            List<Basic_Set> bs = null;
            string msg = null;
            using (var ws = new WebSocket("ws://localhost:9000/ShowData"))
            {
                ws.Connect();
                ws.Send("连接成功！！");
                while (msg == null)
                {
                    ws.OnMessage += (sender, e) =>
                    msg = e.Data;
                }

                //Thread.Sleep(2000);

                //MessageBox.Show(msg);
                bs = JsonConvert.DeserializeObject<List<Basic_Set>>(msg);
                gridControl1.DataSource = bs;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //s//howData();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            showData();
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            showData();
        }
    }
}

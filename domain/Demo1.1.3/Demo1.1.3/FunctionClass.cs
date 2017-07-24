using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
using System.Reflection;
using System.Data.OleDb;
using Newtonsoft.Json.Converters;
using Demo1._1._3.MyWorkBench_SkipForm;
using System.IO;
using DevExpress.XtraEditors;
using System.Drawing.Printing;

namespace Demo1._1._3
{
        public class FunctionClass //存有各个表功能的相关接口的接口定义
        {
        /// <summary>
        /// 初始化分页
        /// </summary>
        /// <param name="datanavigator">分页栏</param>
        /// <param name="total_Page">总页数</param>
        /// <param name="now_Page">当前页数</param>
        public void InitPage(DataNavigator datanavigator, long total_Page, long now_Page) 
            {
                datanavigator.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
            }

              public long getTotal<T>(T t,long total_Page) //获得总条目函数
            {
                 using (var ws = new WebSocket("ws://localhost:9000/GetCount"))
               {
                    ws.Connect();
                    string sendMsg = t.GetType().Name.ToString();
                    ws.Send(sendMsg); //传类名
                    while (total_Page == 0)
                    {
                         ws.OnMessage += (sender, e) =>
                                    total_Page = (Convert.ToInt64(e.Data) / 5) + 1;
                    }
                 }
                    return total_Page;
             }
        /// <summary>
        /// 单表删除
        /// </summary>
        /// <param name="gv">锁定gridview</param>
        public void DeleteData(DevExpress.XtraGrid.Views.Grid.GridView gv)  //删除单一表一行内容
        {
            string deleteIndex = gv.GetFocusedRowCellDisplayText(gv.Columns["ID"]);
            if (MessageBox.Show("是否删除此消息？", "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                deleteData(deleteIndex);
                gv.DeleteRow(gv.FocusedRowHandle);
            }
            else
            {

            }
        }

        /// <summary>
        /// 单表删除
        /// </summary>
        /// <param name="deleteIndex"></param>
        public void deleteData(string deleteIndex)
        {
            using (var ws = new WebSocket("ws://localhost:9000/DeleteData"))
            {
                ws.Connect();
                ws.Send(deleteIndex);
                ws.Close();
            }
        }


        public void DeleteMain(DevExpress.XtraGrid.Views.Grid.GridView gv,string classname)  //删除主表信息
        {
            string deleteIndex = gv.GetFocusedRowCellDisplayText(gv.Columns["StorageNumber"]);
            if (MessageBox.Show("是否删除此消息？", "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                deleteMain(deleteIndex,classname);
                gv.DeleteRow(gv.FocusedRowHandle);
            }
            else
            {

            }
        }

        /// <summary>
        /// 删除主表
        /// </summary>
        /// <param name="deleteIndex"></param>
        public void deleteMain(string deleteIndex,string classname)
        {
            using (var wsn = new WebSocket("ws://localhost:9000/GetClassName/Main"))
            {
                wsn.Connect();
                wsn.Send(classname);
                
                using (var ws = new WebSocket("ws://localhost:9000/DeleteMain"))
                {
                    ws.Connect();
                    ws.Send(deleteIndex);
                    ws.Close();
                }
                wsn.Close();
            }
        }

        public string ShowSaveFileDialog() //保存文件地址
        {
            string localFilePath = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel表格(*.xls)|*.xls"; //设置文件类型
            sfd.FilterIndex = 1;//默认文件类型显示顺序
            sfd.RestoreDirectory = true;//保存对话框是否记忆上次打开的目录
            if (sfd.ShowDialog() == DialogResult.OK) // 点击保存按钮进入
            {
                localFilePath = sfd.FileName.ToString();//获取文件路径
            }
            return localFilePath;
        }

        public string ReadFileDialog()//读取文件地址
        {
            string localFilePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel表格(*.xls)|*.xls";
            ofd.RestoreDirectory = true;//保存对话框是否记忆上次打开的目录
            if (ofd.ShowDialog() == DialogResult.OK) // 点击保存按钮进入
            {
                localFilePath = ofd.FileName.ToString();//获取文件路径
            }
            return localFilePath;
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <returns></returns>
        public string getDataTable()   
        {
            string localFilePath = ReadFileDialog();//获取上传文件信息
            if (localFilePath != "")
            {
                string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                            localFilePath +
                            ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'";
                OleDbConnection con = new OleDbConnection(constr);
                OleDbCommand oconn = new OleDbCommand("Select * From [Sheet$]", con);
                con.Open();

                OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                // List<Basic_Set> data = new List<Basic_Set>();
                DataTable data = new DataTable();
                sda.Fill(data);
                string dataString = JsonConvert.SerializeObject(data, new DataTableConverter());
                return dataString;
            }
            return null;
        }


        public List<T> showData<T>(T t, string nowpage) //显示数据
        {
            List<T> bs = null;
            string msg = null;
            string sendMsg = t.GetType().Name.ToString();
            using (var ws = new WebSocket("ws://localhost:9000/ShowData"))
            {
                ws.Connect();
                ws.Send(sendMsg);
                using (var wsp = new WebSocket("ws://localhost:9000/NowPage"))
                {
                    wsp.Connect();
                    wsp.Send(nowpage);
                    wsp.Close();
                }
                while (msg == null)
                {
                    ws.OnMessage += (sender, e) =>
                    msg = e.Data;
                }
                ws.Close();
                bs = JsonConvert.DeserializeObject<List<T>>(msg);
                //   main_basic.gridControl2.DataSource = bs;
            }
            return bs;
        }


        /// <summary>
        /// 主表保存
        /// </summary>
        /// <param name="jsonMain">传主表对象到服务器</param>
        /// <param name="Json">传明细表对象到服务器</param>
        /// <param name="main">主表类名</param>
        /// <param name="detail">明细表类名</param>
        public void SaveData(string jsonMain, string Json, string main, string detail)
        {
            using (var wsn = new WebSocket("ws://localhost:9000/GetClassName/Main"))
            {
                wsn.Connect();
                wsn.Send(main);
               
                using (var wsm = new WebSocket("ws://localhost:9000/MainSave")) //保存主表
                {
                    wsm.Connect();
                    wsm.Send(jsonMain);
                    wsm.Close();
                }

                wsn.Close();
            }

            using (var wsn = new WebSocket("ws://localhost:9000/GetClassName/Detail"))
            {
                wsn.Connect();
                wsn.Send(detail);
                
                using (var ws = new WebSocket("ws://localhost:9000/MutiSave")) //保存明细表
                {
                    ws.Connect();
                    ws.Send(Json);
                    ws.Close();
                }
                wsn.Close();
            }
        }

        /// <summary>
        /// 获取表头
        /// </summary>
        /// <returns></returns>
        public string GridViewInit()
        {
            string json = null;
            using (var wsn = new WebSocket("ws://localhost:9000/GetClassName/Main"))
            {
                wsn.Connect();
                wsn.Send("StorageDetails");

                using (var ws = new WebSocket("ws://localhost:9000/GetField"))
                {
                    ws.Connect();
                    while (json == null)
                    {
                        ws.Send("GetFieldDetail!!");
                        ws.OnMessage += (sender, e) =>
                        json = e.Data;
                    }
                    ws.Close();
                }
                wsn.Close();
            }
            return json;
        }


        /// <summary>
        /// 查明细
        /// </summary>
        /// <param name="primaryKey">主键信息</param>
        /// <returns></returns>
        public string FindDeteils(string primaryKey,string detailsname)
        {
            string msg = null;
            using (var wsn = new WebSocket("ws://localhost:9000/GetClassName/Detail"))
            {
                wsn.Connect();
                wsn.Send(detailsname);
                

                using (var ws = new WebSocket("ws://localhost:9000/FindDetails"))
                {
                    ws.Connect();
                    while (msg == null)
                   {
                        ws.Send(primaryKey);
                        ws.OnMessage += (sender1, e1) =>
                        msg = e1.Data;
                    }
                    //sd = JsonConvert.DeserializeObject<List<domain.StorageDetails>>(msg);
                        ws.Close();
                }
                wsn.Close();
            }
            return msg;
        }


        /// <summary>
        /// 明细表修改
        /// </summary>
        /// <param name="jsonMain">传主表对象到服务器</param>
        /// <param name="Json">传明细表对象到服务器</param>
        /// <param name="main">主表类名</param>
        /// <param name="detail">明细表类名</param>
        public void ChangeData(string jsonMain, string Json, string main, string detail)
        {
            string error = null;
            using (var wsn = new WebSocket("ws://localhost:9000/GetClassName/Main"))
            {
                try
                {
                    wsn.Connect();
                    wsn.Send(main);
                    wsn.Close();
                }
                catch (Exception)
                {
                    throw;
                }
                
                using (var wsm = new WebSocket("ws://localhost:9000/MainChange")) //修改主表
                {
                    try
                    {
                        wsm.Connect();
                        wsm.Send(jsonMain);
                        wsm.Close();
                       
                    }
                    catch (Exception)
                    {
                        wsm.Connect();
                        while (error == null)
                        {
                            wsm.OnMessage += (send, e) =>
                                        error = e.Data;
                        }
                        MessageBox.Show(error);
                        wsm.Close();
                    }
                }
            }
                    Thread.Sleep(1500);
            using (var wsn = new WebSocket("ws://localhost:9000/GetClassName/Detail"))
            {
                wsn.Connect();
                wsn.Send(detail);
                wsn.Close();

                using (var ws = new WebSocket("ws://localhost:9000/DetailsChange")) //修改明细表
                {
                    try
                    {
                        ws.Connect();
                        ws.Send(Json);
                        ws.Close();
                    }
                    catch (Exception)
                    {
                        ws.Connect();
                        while (error == null)
                        {
                            ws.OnMessage += (send, e) =>
                                        error = e.Data;
                        }
                        MessageBox.Show(error);
                        ws.Close();
                    }        
                }
            }
        }
        public void PrintDocument(object sender, PrintPageEventArgs e)
        {
            Font printFont = null;
            StringReader streamToPrint = null;
            //记录每页最大行数
            float yPos = 0;//记录将要打印的一行数据在垂直方向的位置
            int count = 0;//记录每页已打印行数
            float leftMargin = e.MarginBounds.Left;//左边距
            float topMargin = e.MarginBounds.Top;//顶边距
            string line = null;//从RichTextBox中读取一段字符将存到line中
            //每页最大行数=一页纸打印区域的高度/一行字符的高度
            float linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
            //如果当前页已打印行数小于每页最大行数而且读出数据不为null，继续打印
            while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
            {   //yPos为要打印的当前行在垂直方向上的位置
                yPos = topMargin + (count * printFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(line, printFont, Brushes.Black,
                leftMargin, yPos, new StringFormat());//打印
                count++;//已打印行数加1
            }
            //是否需要打印下一页
            if (line != null)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }  

        public void PageSet(PageSetupDialog psd, PrintDocument printDocument) //页面设置
        {
            psd.Document = printDocument;
            psd.ShowDialog();
        }

        public void PageView(PageSetupDialog psd, PrintDocument printDocument)
        {
            psd.Document = printDocument;
            psd.ShowDialog();
        }
        //********************
        //客户端发送数据（新建）
        //********************
        public void saveData<T>(T t)
        {
            string json;
            json = JsonConvert.SerializeObject(t);
            using (var ws = new WebSocket("ws://localhost:9000/SaveData"))
            {
                ws.Connect();
                ws.Send(json);
                ws.Close();
            }
        }

        //********************
        //客户端发送数据（更新）
        //********************
        public void updateData<T>(T t)
        {
            string json;
            json = JsonConvert.SerializeObject(t);

            using (var ws = new WebSocket("ws://localhost:9000/UpdateData"))
            {
                ws.Connect();
                ws.Send(json);
                ws.Close();
            }

        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <typeparam name="T">查询类型</typeparam>
        /// <param name="t">类型对象</param>
        /// <param name="nowpage">获取当前页数</param>
        /// <param name="input_val">获取输入值</param>
        /// <returns></returns>
        public object showDataLike<T>(T t, string nowpage, string input_val)
        {
            List<T> bs = null;
            string msg = null;
            string sendMsg = t.GetType().Name.ToString();
            using (var ws = new WebSocket("ws://localhost:9000/ShowDataLike"))
            {
                ws.Connect();
                ws.Send(sendMsg);
                using (var wsp = new WebSocket("ws://localhost:9000/GetValLike"))
                {
                    wsp.Connect();
                    wsp.Send(input_val);
                    wsp.Close();
                }
                using (var wb = new WebSocket("ws://localhost:9000/NowPage"))
                {
                    wb.Connect();
                    wb.Send(nowpage);
                    wb.Close();
                }
                while (msg == null)
                {
                    ws.OnMessage += (sender, e) =>
                    msg = e.Data;

                }
                ws.Close();
                bs = JsonConvert.DeserializeObject<List<T>>(msg);
            }
            return bs;
        }
    }
}

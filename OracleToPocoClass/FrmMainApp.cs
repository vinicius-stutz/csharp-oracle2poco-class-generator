using OracleToPocoClass.DataBase;
using OracleToPocoClass.Properties;
using OracleToPocoClass.Util;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace OracleToPocoClass
{
    public partial class FrmMainApp : Form
    {
        private XmlData xd;
        private Image img;
        private Timer timer;
        private static string ip;
        private int x, y, w, h;

        #region Form Events
        public FrmMainApp()
        {
            InitializeComponent();

            x = txtCode.Location.X;
            y = txtCode.Location.Y;
            w = txtCode.Size.Width;
            h = txtCode.Size.Height;

            xd = XmlOperations.ReadFile();

            if (xd != null) AssignData();

            AddCredits(); // Credit to the author (optional)
        }

        private void OnConnectClick(object sender, EventArgs e)
        {
            if (!CheckError())
            {
                img = btnConnect.Image;
                btnConnect.Image = new Bitmap(Resources.appbar_disconnect);
                btnConnect.Text = "...";
                btnConnect.Enabled = false;
                txtTablespace.Text = txtUser.Text;

                SaveXmlData();

                backgroundWorker.RunWorkerAsync();
            }
        }

        private void OnGenerateClick(object sender, EventArgs e)
        {
            if (!CheckError())
            {
                this.Cursor = Cursors.WaitCursor;
                GenerateCode();
                txtCode.Focus();
                this.Cursor = Cursors.Default;
            }
        }

        private void OnCopyClick(object sender, EventArgs e)
        {
            txtCode.SelectAll();
            txtCode.Copy();

            Alert(TpAlert.success, "O código foi copiado para a sua área de transferência");
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            saveFileDialog.FileName = StringUtil.ToPascalCase(cmbTables.Text.ToString()) + ".cs";
            DialogResult result = saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                if (result == DialogResult.OK)
                {
                    txtCode.SaveToFile(saveFileDialog.FileName, Encoding.UTF8);
                    Alert(TpAlert.success, string.Format("O arquivo {0} foi salvo com sucesso no padrão UTF-8", saveFileDialog.FileName));
                }
            }
            else { Alert(TpAlert.error, "Por favor, informe o nome do arquivo!"); }
        }

        private void OnExpandClick(object sender, EventArgs e)
        {
            if (txtCode.Location.X == 260) // Expand
            {
                Point p = new Point(0, y);
                txtCode.Location = p;

                Size s = new Size(1132, h);
                txtCode.Size = s;

                btnAmpliarEditor.Text = "&Reduzir editor";
                btnAmpliarEditor.Image = new Bitmap(Resources.appbar_arrow_collapsed);
            }
            else // Collapsed
            {
                Point p = new Point(x, y);
                txtCode.Location = p;

                Size s = new Size(w, h);
                txtCode.Size = s;

                btnAmpliarEditor.Text = "&Ampliar editor";
                btnAmpliarEditor.Image = new Bitmap(Resources.appbar_arrow_expand);
            }
        }

        private void OnSelectClick(object sender, EventArgs e) { txtCode.SelectAll(); }

        private void OnClearClick(object sender, EventArgs e) { txtCode.Text = string.Empty; }

        private void OnSobreClick(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            sb.AppendLine("    Oracle To POCO Class Generator (EF tool)");
            sb.AppendLine("    Copyright (C) 2016 Vinícius Stutz.");
            sb.AppendLine("");
            sb.AppendLine("    This program is provided to you under the terms of the The MIT");
            sb.AppendLine("    License(MIT) as published at https://opensource.org/licenses/MIT");
            sb.AppendLine("");
            sb.AppendLine("    For more features, controls, and support, please check the");
            sb.AppendLine("    website http://www.vinicius-stutz.com/");
            sb.AppendLine("");
            sb.AppendLine("    Stay informed: follow @vinicius_stutz on Twitter or");
            sb.AppendLine("    Like http://facebook.com/vinicius.stutz");
            sb.AppendLine("");
            sb.AppendLine("");

            MessageBox.Show(sb.ToString(), "Sobre", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnCloseClick(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void OnToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            OracleDB.Close();
            SaveXmlData();
        }
        #endregion

        // ---------------------------------------------------------------------------------------------

        #region Background Worker
        private void DoWork(object sender, DoWorkEventArgs e) { Connect(); }

        void ProgressChanged(object sender, ProgressChangedEventArgs e) { }

        void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmbTables.Enabled = true;
            cmbTables.Focus();

            btnCode.Enabled = true;
            btnCopy.Enabled = true;
            btnSave.Enabled = true;

            btnConnect.Text = "Conectar";
            btnConnect.Image = img;
            btnConnect.Enabled = true;

            FillCombo();
        }
        #endregion

        // ---------------------------------------------------------------------------------------------

        #region Auxiliary Methods
        private bool CheckError()
        {
            bool erro = false;

            if (string.IsNullOrEmpty(txtIp1.Text))
            {
                Alert(TpAlert.error, "Informe o Data Source");
                txtIp1.Focus();
                erro = true;
            }
            else if (string.IsNullOrEmpty(txtPass.Text))
            {
                Alert(TpAlert.error, "Informe a Senha");
                txtPass.Focus();
                erro = true;
            }
            else if (string.IsNullOrEmpty(txtUser.Text))
            {
                Alert(TpAlert.error, "Informe o Usuário");
                txtUser.Focus();
                erro = true;
            }
            else if (!CheckIp())
            {
                Alert(TpAlert.error, "Endereço de UP inválido");
                txtIp1.Focus();
                erro = true;
            }
            else { erro = false; }

            return erro;
        }

        private bool CheckIp()
        {
            IPAddress ipVal;
            ip = string.Format("{0}.{1}.{2}.{3}", txtIp1.Text, txtIp2.Text, txtIp3.Text, txtIp4.Text);

            return IPAddress.TryParse(ip, out ipVal);
        }

        private void Connect()
        {
            try { OracleDB.Connect(xd); }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void AssignData()
        {
            string[] ip = xd.Host.Split('.');

            txtIp1.Text = ip[0];
            txtIp2.Text = ip[1];
            txtIp3.Text = ip[2];
            txtIp4.Text = ip[3];
            txtNameSpace.Text = xd.NameSpace;
            txtPort.Text = xd.Port1;
            txtPort2.Text = xd.Port2;
            txtPass.Text = xd.Pass;
            txtService.Text = xd.Service;
            txtTablespace.Text = xd.TableSpace;
            txtUser.Text = xd.Uid;
        }

        private void SaveXmlData()
        {
            CheckIp();

            xd.Set(
                txtUser.Text,
                txtPass.Text,
                ip,
                txtPort.Text,
                txtPort2.Text,
                txtService.Text,
                txtTablespace.Text,
                txtNameSpace.Text
            );

            XmlOperations.WriteFile(xd, true);
        }

        private void FillCombo()
        {
            try { cmbTables.DataSource = OracleDAL.GetTables(); }
            catch (Exception ex) { Alert(TpAlert.error, ex.Message); }
        }

        private void GenerateCode()
        {
            try
            {
                txtCode.Text = OracleDAL
                    .GenerateCode(txtTablespace.Text, cmbTables.Text, txtNameSpace.Text, cbDataLength.Checked, cbComments.Checked)
                ;
            }
            catch (Exception ex) { Alert(TpAlert.error, ex.Message); }
        }

        private enum TpAlert
        {
            success,
            error,
            info
        }

        private void Alert(TpAlert tp, string msg)
        {
            pnlMsg.Visible = true;
            pnlMsg.BackColor = (tp == TpAlert.error) ? Color.Tomato : (tp == TpAlert.info) ? Color.LightBlue : Color.PaleGreen;
            pnlMsg.ForeColor = (tp == TpAlert.error) ? Color.DarkRed : (tp == TpAlert.info) ? Color.MidnightBlue : Color.DarkGreen;
            lblMsg.Text = msg;

            timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += new EventHandler(ControlMsgPnl);
            timer.Start();
        }

        private void ControlMsgPnl(object sender, EventArgs e)
        {
            pnlMsg.Visible = false;
            timer.Stop();
        }

        private void AddCredits()
        {
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine("/*************************************************************************************");
            //sb.AppendLine("");
            //sb.AppendLine("    Oracle To POCO Class Generator (EF tool)");
            //sb.AppendLine("    Copyright (C) 2016 Vinícius Stutz.");
            //sb.AppendLine("");
            //sb.AppendLine("    This program is provided to you under the terms of the The MIT");
            //sb.AppendLine("    License(MIT) as published at https://opensource.org/licenses/MIT");
            //sb.AppendLine("");
            //sb.AppendLine("    For more features, controls, and support, please check the");
            //sb.AppendLine("    website http://www.vinicius-stutz.com/");
            //sb.AppendLine("");
            //sb.AppendLine("    Stay informed: follow @vinicius_stutz on Twitter or");
            //sb.AppendLine("    Like http://facebook.com/vinicius.stutz");
            //sb.AppendLine("");
            //sb.AppendLine(" ***********************************************************************************/");
            //sb.AppendLine("");
            //sb.AppendLine("// Your code will be generated here :)");

            //txtCode.Text = sb.ToString();
        }
        #endregion

        // ---------------------------------------------------------------------------------------------
    }
}

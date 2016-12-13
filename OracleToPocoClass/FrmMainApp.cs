using FastColoredTextBoxNS;
using Stutz.EF.OracleToPoco.DataBase;
using Stutz.EF.OracleToPoco.Properties;
using Stutz.EF.OracleToPoco.Util;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Stutz.EF.OracleToPoco
{
    /// <summary>
    /// Main class.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FrmMainApp : Form
    {
        private XmlData xd;
        private Image img;
        private Timer timer;
        private static string ip;
        private int x, y, w, h;

        #region Form Events
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmMainApp"/> class.
        /// </summary>
        public FrmMainApp()
        {
            InitializeComponent();

            x = txtCode.Location.X;
            y = txtCode.Location.Y;
            w = txtCode.Size.Width;
            h = txtCode.Size.Height;

            xd = XmlOperations.ReadFile();

            if (xd != null) AssignData();

            gbConexao.Paint += PaintBorderlessGroupBox;
            gbExibir.Paint += PaintBorderlessGroupBox;

            txtCode.SyntaxHighlighter = new SyntaxHighlighter()
            {
                AttributeStyle = new TextStyle(Brushes.White, null, FontStyle.Regular),
                AttributeValueStyle = new TextStyle(Brushes.White, null, FontStyle.Regular),
                ClassNameStyle = new TextStyle(Brushes.LightSeaGreen, null, FontStyle.Regular),
                CommentStyle = new TextStyle(Brushes.ForestGreen, null, FontStyle.Italic),
                CommentTagStyle = new TextStyle(Brushes.ForestGreen, null, FontStyle.Italic),
                FunctionsStyle = new TextStyle(Brushes.SteelBlue, null, FontStyle.Regular),
                KeywordStyle = new TextStyle(Brushes.SteelBlue, null, FontStyle.Regular),
                NumberStyle = new TextStyle(Brushes.LightYellow, null, FontStyle.Regular),
                StringStyle = new TextStyle(Brushes.SandyBrown, null, FontStyle.Regular)
            };

            // Credit to the author (optional)
            AddCredits();
        }

        /// <summary>
        /// Paints the borderless group box.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="p">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void PaintBorderlessGroupBox(object sender, PaintEventArgs p)
        {
            GroupBox box = (GroupBox)sender;
            p.Graphics.Clear(Color.Gray);
            p.Graphics.DrawString(box.Text, box.Font, Brushes.Black, 0, 0);
        }

        /// <summary>
        /// Called when [connect click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnConnectClick(object sender, EventArgs e)
        {
            if (!CheckError())
            {
                img = btnConnect.Image;
                // If you want to add an image to the button
                // btnConnect.Image = new Bitmap(Resources.appbar_disconnect);
                btnConnect.Text = "Conectando...";
                btnConnect.Enabled = false;
                txtTablespace.Text = txtUser.Text;

                SaveXmlData();

                backgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Called when [generate click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnGenerateClick(object sender, EventArgs e)
        {
            if (!CheckError())
            {
                Cursor = Cursors.WaitCursor;
                GenerateCode();
                txtCode.Focus();
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Called when [copy click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnCopyClick(object sender, EventArgs e)
        {
            txtCode.SelectAll();
            txtCode.Copy();

            Alert(TpAlert.success, "O código foi copiado para a sua área de transferência");
        }

        /// <summary>
        /// Called when [save click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Called when [expand click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnExpandClick(object sender, EventArgs e)
        {
            if (txtCode.Location.X == 239) // Expand
            {
                Point p = new Point(0, y);
                txtCode.Location = p;

                Size s = new Size(1132, 585);
                txtCode.Size = s;

                btnAmpliarEditor.Text = "&Reduzir editor";
                btnAmpliarEditor.Image = new Bitmap(Resources.appbar_arrow_collapsed);

                msMenu.BackColor = txtCode.BackColor;
                msMenu.ForeColor = txtCode.ForeColor;
                msMenu.Size = new Size(185, 23);
                msMenu.Location = new Point(920, 0);

            }
            else // Collapsed
            {
                Point p = new Point(x, y);
                txtCode.Location = p;

                Size s = new Size(w, h);
                txtCode.Size = s;

                btnAmpliarEditor.Text = "&Ampliar editor";
                btnAmpliarEditor.Image = new Bitmap(Resources.appbar_arrow_expand);

                msMenu.BackColor = BackColor;
                msMenu.ForeColor = ForeColor;
                msMenu.Size = new Size(236, 23);
                msMenu.Location = new Point(0, 0);
            }
        }

        /// <summary>
        /// Called when [select click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnSelectClick(object sender, EventArgs e) { txtCode.SelectAll(); }

        /// <summary>
        /// Called when [clear click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnClearClick(object sender, EventArgs e) { txtCode.Text = string.Empty; }

        /// <summary>
        /// Called when [about click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Called when [close click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnCloseClick(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        /// <summary>
        /// Called when [tool tip draw].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DrawToolTipEventArgs"/> instance containing the event data.</param>
        private void OnToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        /// <summary>
        /// Called when [form closing].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            OracleDB.Close();
            SaveXmlData();
        }
        #endregion

        // ---------------------------------------------------------------------------------------------

        #region Background Worker
        /// <summary>
        /// Does the work.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void DoWork(object sender, DoWorkEventArgs e) { Connect(); }

        /// <summary>
        /// Progresses the changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
        void ProgressChanged(object sender, ProgressChangedEventArgs e) { }

        /// <summary>
        /// Runs the worker completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
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
        /// <summary>
        /// Checks the error.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Checks the ip.
        /// </summary>
        /// <returns></returns>
        private bool CheckIp()
        {
            IPAddress ipVal;
            ip = string.Format("{0}.{1}.{2}.{3}", txtIp1.Text, txtIp2.Text, txtIp3.Text, txtIp4.Text);

            return IPAddress.TryParse(ip, out ipVal);
        }

        /// <summary>
        /// Connects this instance.
        /// </summary>
        private void Connect()
        {
            try { OracleDB.Connect(xd); }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        /// <summary>
        /// Assigns the data.
        /// </summary>
        private void AssignData()
        {
            string[] ip = new string[] { };

            if (xd != null)
            {
                if (xd.Host != null)
                {
                    ip = xd.Host.Split('.');

                    txtIp1.Text = ip[0];
                    txtIp2.Text = ip[1];
                    txtIp3.Text = ip[2];
                    txtIp4.Text = ip[3];
                }

                txtNameSpace.Text = xd.NameSpace;
                txtPort.Text = xd.Port1;
                txtPort2.Text = xd.Port2;
                txtPass.Text = xd.Pass;
                txtService.Text = xd.Service;
                txtTablespace.Text = xd.TableSpace;
                txtUser.Text = xd.Uid;
            }
        }

        /// <summary>
        /// Saves the XML data.
        /// </summary>
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

        /// <summary>
        /// Fills the combo.
        /// </summary>
        private void FillCombo()
        {
            try { cmbTables.DataSource = OracleDAL.GetTables(); }
            catch (Exception ex) { Alert(TpAlert.error, ex.Message); }
        }

        /// <summary>
        /// Generates the code.
        /// </summary>
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

        /// <summary>
        /// Type of alert in screen.
        /// </summary>
        private enum TpAlert
        {
            success,
            error,
            info
        }

        /// <summary>
        /// Alerts the specified tp.
        /// </summary>
        /// <param name="tp">The tp.</param>
        /// <param name="msg">The MSG.</param>
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

        /// <summary>
        /// Controls the message panel.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ControlMsgPnl(object sender, EventArgs e)
        {
            pnlMsg.Visible = false;
            timer.Stop();
        }

        /// <summary>
        /// Adds the credits to the author (optional).
        /// </summary>
        private void AddCredits()
        {
            // The code below is commented.
            // If you want to give credits to the author, just uncomment the code ;)

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

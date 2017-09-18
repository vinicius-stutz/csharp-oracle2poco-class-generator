// <copyright file="FrmMainApp.cs" company="Vinicius de Araujo Stutz">
// Copyright (c) Vinicius de Araujo Stutz. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Stutz.EF.OracleToPoco
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;
    using FastColoredTextBoxNS;
    using Stutz.EF.OracleToPoco.Util;

    /// <summary>
    /// Main class.
    /// </summary>
    /// <seealso cref="Stutz.EF.OracleToPoco.Util.Controller" />
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FrmMainApp : Controller
    {
        private const string AppTitle = "Oracle Database EF Tool: POCO Class Generator";

        private static string _ip;
        private XmlData _xd;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmMainApp"/> class.
        /// </summary>
        public FrmMainApp()
        {
            InitializeComponent();

            layout.Dock = DockStyle.Fill;

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

            _xd = XmlOperations.ReadFile();

            if (_xd != null)
            {
                AssignData();
            }

            DraggItens();

            // Credit to the author (optional)
            AddCredits();
        }

        /// <summary>
        /// Gets or sets the timer.
        /// </summary>
        /// <value>
        /// The timer.
        /// </value>
        internal Timer Timer { get; set; }

        /// <summary>
        /// Called when [FRM main application resize].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnFrmMainAppResize(object sender, EventArgs e)
        {
            try
            {
                if (Size.Width > 0 && Size.Height > 0)
                {
                    if (Size.Width < 964)
                    {
                        Size = new Size(964, Size.Height);
                    }

                    if (Size.Height < 770)
                    {
                        Size = new Size(Size.Width, 770);
                    }
                }
            }
            catch (Exception ex)
            {
                Alert(TpAlert.Error, ex.Message);
                Size = new Size(964, 770);
            }
        }

        #region Menu Events

        /// <summary>
        /// Called when [copy click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnCopyClick(object sender, EventArgs e)
        {
            txtCode.SelectAll();
            txtCode.Copy();

            Alert(TpAlert.Success, "O código foi copiado para a sua área de transferência");
        }

        /// <summary>
        /// Called when [save click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnSaveClick(object sender, EventArgs e)
        {
            saveFileDialog.FileName = StringUtil.ToPascalCase(_xd.TableName);

            if (ckBll.Checked)
            {
                saveFileDialog.FileName += "BLL";
            }

            DialogResult result = saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != string.Empty)
            {
                if (result == DialogResult.OK)
                {
                    txtCode.SaveToFile(saveFileDialog.FileName, Encoding.UTF8);
                    Alert(TpAlert.Success, string.Format("O arquivo {0} foi salvo com sucesso no padrão UTF-8", saveFileDialog.FileName + ".cs"));
                }
            }
            else
            {
                Alert(TpAlert.Error, "Por favor, informe o nome do arquivo!");
            }
        }

        /// <summary>
        /// Called when [select click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnSelectClick(object sender, EventArgs e)
        {
            txtCode.SelectAll();
        }

        /// <summary>
        /// Called when [clear click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnClearClick(object sender, EventArgs e)
        {
            txtCode.Text = string.Empty;
        }

        /// <summary>
        /// Called when [close click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Called when [show hide connection click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnShowHideConnectionClick(object sender, EventArgs e)
        {
            ShowHideMenuItem(pnlConexao, menuShowHideControls);
        }

        /// <summary>
        /// Called when [show hide tables click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnShowHideTablesClick(object sender, EventArgs e)
        {
            ShowHideMenuItem(pnlTables, menuShowHideTables);
        }

        /// <summary>
        /// Called when [show hide namespace click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnShowHideNamespaceClick(object sender, EventArgs e)
        {
            ShowHideMenuItem(pnlNamespace, menuShowHideNamespace);
        }

        /// <summary>
        /// Called when [show hide opcoes click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnShowHideOptionsClick(object sender, EventArgs e)
        {
            ShowHideMenuItem(pnlOpcoes, menuShowHideOpcoes);
        }

        /// <summary>
        /// Show or hide panel by menu item.
        /// </summary>
        /// <param name="panel">The panel.</param>
        /// <param name="menu">The menu.</param>
        private void ShowHideMenuItem(Panel panel, ToolStripMenuItem menu)
        {
            menu.Checked = !panel.Visible;
            panel.Visible = !panel.Visible;
        }

        /// <summary>
        /// Called when [entity click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnckEntityClick(object sender, EventArgs e)
        {
            ckBll.Checked = false;
            OnGenerateClick(sender, e);
        }

        /// <summary>
        /// Called when [BLL click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnckBllClick(object sender, EventArgs e)
        {
            ckEntity.Checked = false;
            OnGenerateClick(sender, e);
        }

        /// <summary>
        /// Called when [about click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnSobreClick(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Empty);
            sb.AppendLine("    Oracle To POCO Class Generator (EF tool)");
            sb.AppendLine("    Copyright (C) 2016 Vinícius Stutz.");
            sb.AppendLine(string.Empty);
            sb.AppendLine("    This program is provided to you under the terms of the The MIT");
            sb.AppendLine("    License(MIT) as published at https://opensource.org/licenses/MIT");
            sb.AppendLine(string.Empty);
            sb.AppendLine("    For more features, controls, and support, please check the");
            sb.AppendLine("    website http://www.vinicius-stutz.com/");
            sb.AppendLine(string.Empty);
            sb.AppendLine("    Stay informed: follow @vinicius_stutz on Twitter or");
            sb.AppendLine("    Like http://facebook.com/vinicius.stutz");
            sb.AppendLine(string.Empty);
            sb.AppendLine(string.Empty);

            MessageBox.Show(sb.ToString(), "Sobre", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Controles

        /// <summary>
        /// Draggs the itens.
        /// </summary>
        private void DraggItens()
        {
            Draggable(pnlConexao, true);
            Draggable(pnlNamespace, true);
            Draggable(pnlOpcoes, true);
            Draggable(pnlTables, true);
        }

        /// <summary>
        /// Called when [PNL conexao mouse down].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void OnPnlConexaoMouseDown(object sender, MouseEventArgs e)
        {
            pnlConexao.BringToFront();
        }

        /// <summary>
        /// Called when [PNL namespace mouse down].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void OnPnlNamespaceMouseDown(object sender, MouseEventArgs e)
        {
            pnlNamespace.BringToFront();
        }

        /// <summary>
        /// Called when [PNL opcoes mouse down].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void OnPnlOpcoesMouseDown(object sender, MouseEventArgs e)
        {
            pnlOpcoes.BringToFront();
        }

        /// <summary>
        /// Called when [PNL tables mouse down].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void OnPnlTablesMouseDown(object sender, MouseEventArgs e)
        {
            pnlTables.BringToFront();
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
                // _img = btnConnect.Image;
                // If you want to add an image to the button
                // btnConnect.Image = new Bitmap(Resources.appbar_disconnect);
                btnConnect.Text = "CONECTANDO...";
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
                _xd.TableName = cmbTables.Text;

                Cursor = Cursors.WaitCursor;
                GenerateCode();
                txtCode.Focus();
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Validations

        /// <summary>
        /// Checks the error.
        /// </summary>
        /// <returns><see cref="bool"/></returns>
        private bool CheckError()
        {
            bool erro = false;

            if (string.IsNullOrEmpty(txtIp1.Text))
            {
                Alert(TpAlert.Error, "Informe o Data Source");
                txtIp1.Focus();
                erro = true;
            }
            else if (string.IsNullOrEmpty(txtPass.Text))
            {
                Alert(TpAlert.Error, "Informe a Senha");
                txtPass.Focus();
                erro = true;
            }
            else if (string.IsNullOrEmpty(txtUser.Text))
            {
                Alert(TpAlert.Error, "Informe o Usuário");
                txtUser.Focus();
                erro = true;
            }
            else if (!CheckIp(txtIp1.Text, txtIp2.Text, txtIp3.Text, txtIp4.Text))
            {
                Alert(TpAlert.Error, "Endereço de UP inválido");
                txtIp1.Focus();
                erro = true;
            }
            else
            {
                erro = false;
            }

            return erro;
        }

        /// <summary>
        /// Checks the ip.
        /// </summary>
        /// <param name="ip1">The ip1.</param>
        /// <param name="ip2">The ip2.</param>
        /// <param name="ip3">The ip3.</param>
        /// <param name="ip4">The ip4.</param>
        /// <returns>
        ///   <see cref="bool" />
        /// </returns>
        private bool CheckIp(string ip1, string ip2, string ip3, string ip4)
        {
            IPAddress ipVal;

            _ip = string.Format("{0}.{1}.{2}.{3}", ip1, ip2, ip3, ip4);

            return IPAddress.TryParse(_ip, out ipVal);
        }
        #endregion

        #region Background Worker

        /// <summary>
        /// Does the work.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            Connect();
        }

        /// <summary>
        /// Progresses the changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        /// <summary>
        /// Runs the worker completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string conInfo = txtUser.Text.ToLower() + "@" + txtService.Text.ToUpper();

            cmbTables.Enabled = true;
            cmbTables.Focus();

            btnCode.Enabled = true;
            btnCode.BackColor = Color.FromArgb(52, 157, 215);
            btnCode.FlatAppearance.BorderColor = Color.FromArgb(52, 157, 215);

            btnCopy.Enabled = true;
            btnSave.Enabled = true;

            btnConnect.Text = "NOVA CO&NEXÃO";
            btnConnect.Enabled = true;

            lblStatusConexao.Text = "Conectado a " + conInfo;
            Text = conInfo + " - " + AppTitle;

            FillCombo();
        }
        #endregion

        #region Auxiliary Methods

        /// <summary>
        /// Connects this instance.
        /// </summary>
        private void Connect()
        {
            try
            {
                Helper.Connect(_xd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Assigns the data.
        /// </summary>
        private void AssignData()
        {
            string[] ip = new string[] { };

            if (_xd != null)
            {
                if (_xd.Host != null)
                {
                    ip = _xd.Host.Split('.');

                    txtIp1.Text = ip[0];
                    txtIp2.Text = ip[1];
                    txtIp3.Text = ip[2];
                    txtIp4.Text = ip[3];
                }

                txtPort.Text = _xd.Port1;
                txtPort2.Text = _xd.Port2;
                txtPass.Text = _xd.Pass;
                txtService.Text = _xd.Service;
                txtTablespace.Text = _xd.TableSpace;
                txtUser.Text = _xd.Uid;

                txtNamespaceEntidade.Text = _xd.NamespaceEntidade;
                txtNamespaceBll.Text = _xd.NamespaceBll;
                txtNamespacePersistencia.Text = _xd.NamespacePersistencia;
                txtNamespaceUtil.Text = _xd.NamespaceUtil;
            }
        }

        /// <summary>
        /// Saves the XML data.
        /// </summary>
        private void SaveXmlData()
        {
            CheckIp(txtIp1.Text, txtIp2.Text, txtIp3.Text, txtIp4.Text);

            _xd.Set(
                txtUser.Text,
                txtPass.Text,
                _ip,
                txtPort.Text,
                txtPort2.Text,
                txtService.Text,
                txtTablespace.Text,
                txtNamespaceEntidade.Text,
                txtNamespacePersistencia.Text,
                txtNamespaceUtil.Text,
                txtNamespaceBll.Text);

            XmlOperations.WriteFile(_xd, true);
        }

        /// <summary>
        /// Called when [form closing].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            Helper.CloseConnection();
            SaveXmlData();

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
        /// Fills the combo.
        /// </summary>
        private void FillCombo()
        {
            try
            {
                cmbTables.DataSource = Helper.Tables;
            }
            catch (Exception ex)
            {
                Alert(TpAlert.Error, ex.Message);
            }
        }

        /// <summary>
        /// Generates the code.
        /// </summary>
        private void GenerateCode()
        {
            try
            {
                _xd.TableName = cmbTables.Text;

                if (ckEntity.Checked)
                {
                    txtCode.Text = Helper.GetCode(txtTablespace.Text, _xd.TableName, txtNamespaceEntidade.Text, cbDataLength.Checked, cbComments.Checked);
                }
                else
                {
                    txtCode.Text = Helper.GetCode(txtNamespaceEntidade.Text, txtNamespacePersistencia.Text, txtNamespaceUtil.Text, txtNamespaceBll.Text, StringUtil.ToPascalCase(_xd.TableName));
                }
            }
            catch (Exception ex)
            {
                Alert(TpAlert.Error, ex.Message);
            }
        }
        #endregion

        #region Alert

        /// <summary>
        /// Alerts the specified tp.
        /// </summary>
        /// <param name="tp">The tp.</param>
        /// <param name="msg">The MSG.</param>
        private void Alert(TpAlert tp, string msg)
        {
            pnlMsg.Visible = true;
            pnlMsg.BackColor = (tp == TpAlert.Error) ? Color.Tomato : (tp == TpAlert.Info) ? Color.LightBlue : Color.PaleGreen;
            pnlMsg.ForeColor = (tp == TpAlert.Error) ? Color.DarkRed : (tp == TpAlert.Info) ? Color.MidnightBlue : Color.DarkGreen;
            lblMsg.Text = msg;

            Timer = new Timer();
            Timer.Interval = 3000;
            Timer.Tick += new EventHandler(ControlMsgPnl);
            Timer.Start();
        }

        /// <summary>
        /// Controls the message panel.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ControlMsgPnl(object sender, EventArgs e)
        {
            pnlMsg.Visible = false;
            Timer.Stop();
        }
        #endregion
    }
}

namespace OracleToPocoClass
{
    partial class FrmMainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainApp));
            this.txtTablespace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new FastColoredTextBoxNS.FastColoredTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtService = new System.Windows.Forms.TextBox();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnCode = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtIp1 = new System.Windows.Forms.MaskedTextBox();
            this.txtPort = new System.Windows.Forms.MaskedTextBox();
            this.txtPort2 = new System.Windows.Forms.MaskedTextBox();
            this.txtIp2 = new System.Windows.Forms.MaskedTextBox();
            this.txtIp3 = new System.Windows.Forms.MaskedTextBox();
            this.txtIp4 = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pnlMsg = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbDataLength = new System.Windows.Forms.CheckBox();
            this.cbComments = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFechar = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClear = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAmpliarEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSobre = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).BeginInit();
            this.pnlMsg.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.msMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTablespace
            // 
            this.txtTablespace.Enabled = false;
            this.txtTablespace.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTablespace.Location = new System.Drawing.Point(89, 174);
            this.txtTablespace.Name = "txtTablespace";
            this.txtTablespace.ReadOnly = true;
            this.txtTablespace.Size = new System.Drawing.Size(141, 25);
            this.txtTablespace.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tablespace:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tabela:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Host:";
            // 
            // txtCode
            // 
            this.txtCode.AutoScrollMinSize = new System.Drawing.Size(27, 17);
            this.txtCode.BackBrush = null;
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCode.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtCode.Font = new System.Drawing.Font("Monaco", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.IsReplaceMode = false;
            this.txtCode.Language = FastColoredTextBoxNS.Language.CSharp;
            this.txtCode.LeftBracket = '(';
            this.txtCode.Location = new System.Drawing.Point(260, 0);
            this.txtCode.Name = "txtCode";
            this.txtCode.Paddings = new System.Windows.Forms.Padding(0);
            this.txtCode.RightBracket = ')';
            this.txtCode.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtCode.Size = new System.Drawing.Size(875, 585);
            this.txtCode.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "User ID:";
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(89, 19);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(141, 25);
            this.txtUser.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Senha:";
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(89, 50);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(141, 25);
            this.txtPass.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Portas:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Service:";
            // 
            // txtService
            // 
            this.txtService.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtService.Location = new System.Drawing.Point(89, 143);
            this.txtService.Name = "txtService";
            this.txtService.Size = new System.Drawing.Size(141, 25);
            this.txtService.TabIndex = 8;
            // 
            // cmbTables
            // 
            this.cmbTables.Enabled = false;
            this.cmbTables.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(88, 24);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(141, 25);
            this.cmbTables.TabIndex = 10;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "cs";
            this.saveFileDialog.Filter = "C# Class|.cs";
            this.saveFileDialog.FilterIndex = 0;
            this.saveFileDialog.Title = "Salvar Classe";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Namespace:";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameSpace.Location = new System.Drawing.Point(88, 55);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(141, 25);
            this.txtNameSpace.TabIndex = 11;
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Black;
            this.toolTip.ForeColor = System.Drawing.Color.White;
            this.toolTip.OwnerDraw = true;
            this.toolTip.ShowAlways = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.OnToolTipDraw);
            // 
            // btnCode
            // 
            this.btnCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCode.Enabled = false;
            this.btnCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCode.ForeColor = System.Drawing.Color.Black;
            this.btnCode.Image = global::OracleToPocoClass.Properties.Resources.appbar_code_xml;
            this.btnCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCode.Location = new System.Drawing.Point(11, 86);
            this.btnCode.Name = "btnCode";
            this.btnCode.Size = new System.Drawing.Size(219, 50);
            this.btnCode.TabIndex = 13;
            this.btnCode.Text = "        &Gerar código";
            this.toolTip.SetToolTip(this.btnCode, "Clique para gerar a classe com o modelo de dados em C#");
            this.btnCode.UseCompatibleTextRendering = true;
            this.btnCode.UseVisualStyleBackColor = true;
            this.btnCode.Click += new System.EventHandler(this.OnGenerateClick);
            // 
            // btnConnect
            // 
            this.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.Black;
            this.btnConnect.Image = global::OracleToPocoClass.Properties.Resources.appbar_connect;
            this.btnConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect.Location = new System.Drawing.Point(12, 205);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(218, 50);
            this.btnConnect.TabIndex = 12;
            this.btnConnect.Text = "        Co&nectar";
            this.toolTip.SetToolTip(this.btnConnect, "Clique para conectar ao banco utilizando as informações indicadas");
            this.btnConnect.UseCompatibleTextRendering = true;
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.OnConnectClick);
            // 
            // txtIp1
            // 
            this.txtIp1.Culture = new System.Globalization.CultureInfo("en-US");
            this.txtIp1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtIp1.Location = new System.Drawing.Point(89, 81);
            this.txtIp1.Mask = "999";
            this.txtIp1.Name = "txtIp1";
            this.txtIp1.Size = new System.Drawing.Size(30, 25);
            this.txtIp1.TabIndex = 2;
            this.txtIp1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPort
            // 
            this.txtPort.Culture = new System.Globalization.CultureInfo("en-US");
            this.txtPort.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPort.Location = new System.Drawing.Point(89, 112);
            this.txtPort.Mask = "0000";
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(68, 25);
            this.txtPort.TabIndex = 6;
            // 
            // txtPort2
            // 
            this.txtPort2.Culture = new System.Globalization.CultureInfo("en-US");
            this.txtPort2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPort2.Location = new System.Drawing.Point(162, 112);
            this.txtPort2.Mask = "0000";
            this.txtPort2.Name = "txtPort2";
            this.txtPort2.Size = new System.Drawing.Size(68, 25);
            this.txtPort2.TabIndex = 7;
            // 
            // txtIp2
            // 
            this.txtIp2.Culture = new System.Globalization.CultureInfo("en-US");
            this.txtIp2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtIp2.Location = new System.Drawing.Point(127, 81);
            this.txtIp2.Mask = "999";
            this.txtIp2.Name = "txtIp2";
            this.txtIp2.Size = new System.Drawing.Size(30, 25);
            this.txtIp2.TabIndex = 3;
            this.txtIp2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIp3
            // 
            this.txtIp3.Culture = new System.Globalization.CultureInfo("en-US");
            this.txtIp3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtIp3.Location = new System.Drawing.Point(164, 81);
            this.txtIp3.Mask = "999";
            this.txtIp3.Name = "txtIp3";
            this.txtIp3.Size = new System.Drawing.Size(30, 25);
            this.txtIp3.TabIndex = 4;
            this.txtIp3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIp4
            // 
            this.txtIp4.Culture = new System.Globalization.CultureInfo("en-US");
            this.txtIp4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtIp4.Location = new System.Drawing.Point(200, 81);
            this.txtIp4.Mask = "999";
            this.txtIp4.Name = "txtIp4";
            this.txtIp4.Size = new System.Drawing.Size(30, 25);
            this.txtIp4.TabIndex = 5;
            this.txtIp4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(118, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 15);
            this.label12.TabIndex = 28;
            this.label12.Text = ".";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(156, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(10, 15);
            this.label13.TabIndex = 29;
            this.label13.Text = ".";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(193, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(10, 15);
            this.label14.TabIndex = 30;
            this.label14.Text = ".";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMsg
            // 
            this.pnlMsg.BackColor = System.Drawing.Color.LightBlue;
            this.pnlMsg.Controls.Add(this.lblMsg);
            this.pnlMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMsg.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMsg.ForeColor = System.Drawing.Color.MidnightBlue;
            this.pnlMsg.Location = new System.Drawing.Point(0, 553);
            this.pnlMsg.Name = "pnlMsg";
            this.pnlMsg.Size = new System.Drawing.Size(1135, 32);
            this.pnlMsg.TabIndex = 31;
            this.pnlMsg.Visible = false;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(7, 7);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(106, 17);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "Mensagem aqui";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPort2);
            this.groupBox1.Controls.Add(this.txtIp4);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtIp3);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtIp2);
            this.groupBox1.Controls.Add(this.txtService);
            this.groupBox1.Controls.Add(this.txtIp1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTablespace);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 266);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CONEXÃO";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtNameSpace);
            this.groupBox2.Controls.Add(this.cmbTables);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnCode);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 415);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 147);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CÓDIGO";
            // 
            // cbDataLength
            // 
            this.cbDataLength.AutoSize = true;
            this.cbDataLength.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDataLength.Location = new System.Drawing.Point(6, 24);
            this.cbDataLength.Name = "cbDataLength";
            this.cbDataLength.Size = new System.Drawing.Size(226, 55);
            this.cbDataLength.TabIndex = 20;
            this.cbDataLength.Text = "Exibir precisão, escala e tamanho\r\ndos campos? Antenção: Pode não\r\nfuncionar em s" +
    "eu código!";
            this.cbDataLength.UseVisualStyleBackColor = true;
            // 
            // cbComments
            // 
            this.cbComments.AutoSize = true;
            this.cbComments.Checked = true;
            this.cbComments.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbComments.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbComments.Location = new System.Drawing.Point(6, 81);
            this.cbComments.Name = "cbComments";
            this.cbComments.Size = new System.Drawing.Size(186, 21);
            this.cbComments.TabIndex = 21;
            this.cbComments.Text = "Exibir dicas e comentários?";
            this.cbComments.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbDataLength);
            this.groupBox3.Controls.Add(this.cbComments);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 301);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(242, 108);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "OPÇÕES";
            // 
            // msMenu
            // 
            this.msMenu.BackColor = System.Drawing.SystemColors.Control;
            this.msMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.msMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(1135, 23);
            this.msMenu.TabIndex = 36;
            this.msMenu.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripMenuItem1,
            this.btnFechar});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(70, 19);
            this.arquivoToolStripMenuItem.Text = "&ARQUIVO";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::OracleToPocoClass.Properties.Resources.appbar_disk;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(186, 22);
            this.btnSave.Text = "&Salvar em arquivo";
            this.btnSave.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 6);
            // 
            // btnFechar
            // 
            this.btnFechar.Image = global::OracleToPocoClass.Properties.Resources.appbar_close;
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(186, 22);
            this.btnFechar.Text = "&Fechar conexão e sair";
            this.btnFechar.Click += new System.EventHandler(this.OnCloseClick);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSelect,
            this.btnClear,
            this.btnCopy,
            this.toolStripMenuItem2,
            this.btnAmpliarEditor});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(58, 19);
            this.editarToolStripMenuItem.Text = "&EDITAR";
            // 
            // btnSelect
            // 
            this.btnSelect.Image = global::OracleToPocoClass.Properties.Resources.appbar_interface_textbox;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(156, 22);
            this.btnSelect.Text = "Selecionar &tudo";
            this.btnSelect.Click += new System.EventHandler(this.OnSelectClick);
            // 
            // btnClear
            // 
            this.btnClear.Image = global::OracleToPocoClass.Properties.Resources.appbar_new;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(156, 22);
            this.btnClear.Text = "&Limpar editor";
            this.btnClear.Click += new System.EventHandler(this.OnClearClick);
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::OracleToPocoClass.Properties.Resources.appbar_page_copy;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(156, 22);
            this.btnCopy.Text = "&Copiar código";
            this.btnCopy.Click += new System.EventHandler(this.OnCopyClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(153, 6);
            // 
            // btnAmpliarEditor
            // 
            this.btnAmpliarEditor.Image = global::OracleToPocoClass.Properties.Resources.appbar_arrow_expand;
            this.btnAmpliarEditor.Name = "btnAmpliarEditor";
            this.btnAmpliarEditor.Size = new System.Drawing.Size(156, 22);
            this.btnAmpliarEditor.Text = "&Ampliar editor";
            this.btnAmpliarEditor.Click += new System.EventHandler(this.OnExpandClick);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSobre});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(55, 19);
            this.ajudaToolStripMenuItem.Text = "A&JUDA";
            // 
            // btnSobre
            // 
            this.btnSobre.Image = global::OracleToPocoClass.Properties.Resources.appbar_information_circle;
            this.btnSobre.Name = "btnSobre";
            this.btnSobre.Size = new System.Drawing.Size(152, 22);
            this.btnSobre.Text = "S&obre";
            this.btnSobre.Click += new System.EventHandler(this.OnSobreClick);
            // 
            // FrmMainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1135, 585);
            this.Controls.Add(this.pnlMsg);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.msMenu);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenu;
            this.MaximizeBox = false;
            this.Name = "FrmMainApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oracle Database EF Tool: POCO Class Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).EndInit();
            this.pnlMsg.ResumeLayout(false);
            this.pnlMsg.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTablespace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCode;
        private System.Windows.Forms.Label label3;
        private FastColoredTextBoxNS.FastColoredTextBox txtCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtService;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MaskedTextBox txtIp1;
        private System.Windows.Forms.MaskedTextBox txtPort;
        private System.Windows.Forms.MaskedTextBox txtPort2;
        private System.Windows.Forms.MaskedTextBox txtIp2;
        private System.Windows.Forms.MaskedTextBox txtIp3;
        private System.Windows.Forms.MaskedTextBox txtIp4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel pnlMsg;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbDataLength;
        private System.Windows.Forms.CheckBox cbComments;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnSelect;
        private System.Windows.Forms.ToolStripMenuItem btnClear;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.ToolStripMenuItem btnFechar;
        private System.Windows.Forms.ToolStripMenuItem btnCopy;
        private System.Windows.Forms.ToolStripMenuItem btnAmpliarEditor;
        private System.Windows.Forms.ToolStripMenuItem btnSobre;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}


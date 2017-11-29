using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using NationalInstruments.VisaNS;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;


namespace NationalInstruments.Examples.SimpleReadWrite
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        private MessageBasedSession mbSession;
        private string lastResourceString = null;
        private System.Windows.Forms.TextBox writeTextBox;
        private System.Windows.Forms.TextBox readTextBox;
        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button openSessionButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button closeSessionButton;
        private System.Windows.Forms.Label stringToWriteLabel;
        private System.Windows.Forms.Label stringToReadLabel;
        private ComboBox ddlCommandos;
        private Button bntnReadMemory;
        private TextBox txtCommandDescription;
        private CheckBox checkBoxLog;
        private List<Commands> commands;

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("commands.json"))
            {
                string json = r.ReadToEnd();
                
                    commands = JsonConvert.DeserializeObject<List<Commands>>(json);

                
            }
        }

        public class Commands
        {
            public int id;
            public string value;
            public string type;
            public string description;
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            SetupControlState(false);
            InitializeCustomComponent();
        }

        private void InitializeCustomComponent()
        {
           LoadJson();
            
            ddlCommandos.DataSource = commands.Select(x=>x.value).OrderByDescending(y => y).ToList();
        }



        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(mbSession != null)
                {
                    mbSession.Dispose();
                }
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.queryButton = new System.Windows.Forms.Button();
            this.writeButton = new System.Windows.Forms.Button();
            this.readButton = new System.Windows.Forms.Button();
            this.openSessionButton = new System.Windows.Forms.Button();
            this.writeTextBox = new System.Windows.Forms.TextBox();
            this.readTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.closeSessionButton = new System.Windows.Forms.Button();
            this.stringToWriteLabel = new System.Windows.Forms.Label();
            this.stringToReadLabel = new System.Windows.Forms.Label();
            this.bntnReadMemory = new System.Windows.Forms.Button();
            this.ddlCommandos = new System.Windows.Forms.ComboBox();
            this.txtCommandDescription = new System.Windows.Forms.TextBox();
            this.checkBoxLog = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // queryButton
            // 
            this.queryButton.Location = new System.Drawing.Point(0, 159);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(74, 23);
            this.queryButton.TabIndex = 3;
            this.queryButton.Text = "Query";
            this.queryButton.Click += new System.EventHandler(this.query_Click);
            // 
            // writeButton
            // 
            this.writeButton.Location = new System.Drawing.Point(74, 159);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(74, 23);
            this.writeButton.TabIndex = 4;
            this.writeButton.Text = "Escribir";
            this.writeButton.Click += new System.EventHandler(this.write_Click);
            // 
            // readButton
            // 
            this.readButton.Location = new System.Drawing.Point(148, 159);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(74, 23);
            this.readButton.TabIndex = 5;
            this.readButton.Text = "Leer";
            this.readButton.Click += new System.EventHandler(this.read_Click);
            // 
            // openSessionButton
            // 
            this.openSessionButton.Location = new System.Drawing.Point(5, 5);
            this.openSessionButton.Name = "openSessionButton";
            this.openSessionButton.Size = new System.Drawing.Size(92, 22);
            this.openSessionButton.TabIndex = 0;
            this.openSessionButton.Text = "Abrir Sesion";
            this.openSessionButton.Click += new System.EventHandler(this.openSession_Click);
            // 
            // writeTextBox
            // 
            this.writeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.writeTextBox.Location = new System.Drawing.Point(0, 133);
            this.writeTextBox.Name = "writeTextBox";
            this.writeTextBox.Size = new System.Drawing.Size(472, 20);
            this.writeTextBox.TabIndex = 2;
            this.writeTextBox.Text = "*IDN?\\n";
            // 
            // readTextBox
            // 
            this.readTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.readTextBox.Location = new System.Drawing.Point(5, 251);
            this.readTextBox.Multiline = true;
            this.readTextBox.Name = "readTextBox";
            this.readTextBox.ReadOnly = true;
            this.readTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.readTextBox.Size = new System.Drawing.Size(472, 176);
            this.readTextBox.TabIndex = 6;
            this.readTextBox.TabStop = false;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(6, 429);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(472, 24);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Limpiar";
            this.clearButton.Click += new System.EventHandler(this.clear_Click);
            // 
            // closeSessionButton
            // 
            this.closeSessionButton.Location = new System.Drawing.Point(97, 5);
            this.closeSessionButton.Name = "closeSessionButton";
            this.closeSessionButton.Size = new System.Drawing.Size(92, 22);
            this.closeSessionButton.TabIndex = 1;
            this.closeSessionButton.Text = "Cerrar Sesion";
            this.closeSessionButton.Click += new System.EventHandler(this.closeSession_Click);
            // 
            // stringToWriteLabel
            // 
            this.stringToWriteLabel.Location = new System.Drawing.Point(0, 116);
            this.stringToWriteLabel.Name = "stringToWriteLabel";
            this.stringToWriteLabel.Size = new System.Drawing.Size(91, 14);
            this.stringToWriteLabel.TabIndex = 8;
            this.stringToWriteLabel.Text = "String:";
            // 
            // stringToReadLabel
            // 
            this.stringToReadLabel.Location = new System.Drawing.Point(3, 233);
            this.stringToReadLabel.Name = "stringToReadLabel";
            this.stringToReadLabel.Size = new System.Drawing.Size(101, 15);
            this.stringToReadLabel.TabIndex = 9;
            this.stringToReadLabel.Text = "Salida:";
            // 
            // bntnReadMemory
            // 
            this.bntnReadMemory.Enabled = false;
            this.bntnReadMemory.Location = new System.Drawing.Point(380, 159);
            this.bntnReadMemory.Name = "bntnReadMemory";
            this.bntnReadMemory.Size = new System.Drawing.Size(75, 23);
            this.bntnReadMemory.TabIndex = 10;
            this.bntnReadMemory.Text = "Leer A";
            this.bntnReadMemory.UseVisualStyleBackColor = true;
            this.bntnReadMemory.Click += new System.EventHandler(this.bntnReadMemory_Click);
            // 
            // ddlCommandos
            // 
            this.ddlCommandos.Enabled = false;
            this.ddlCommandos.FormattingEnabled = true;
            this.ddlCommandos.Location = new System.Drawing.Point(6, 43);
            this.ddlCommandos.Name = "ddlCommandos";
            this.ddlCommandos.Size = new System.Drawing.Size(121, 21);
            this.ddlCommandos.TabIndex = 11;
            this.ddlCommandos.SelectedIndexChanged += new System.EventHandler(this.ddlCommandos_SelectedIndexChanged);
            // 
            // txtCommandDescription
            // 
            this.txtCommandDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommandDescription.Location = new System.Drawing.Point(133, 43);
            this.txtCommandDescription.Multiline = true;
            this.txtCommandDescription.Name = "txtCommandDescription";
            this.txtCommandDescription.ReadOnly = true;
            this.txtCommandDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCommandDescription.Size = new System.Drawing.Size(339, 65);
            this.txtCommandDescription.TabIndex = 6;
            this.txtCommandDescription.TabStop = false;
            // 
            // checkBoxLog
            // 
            this.checkBoxLog.AutoSize = true;
            this.checkBoxLog.Checked = true;
            this.checkBoxLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLog.Enabled = false;
            this.checkBoxLog.Location = new System.Drawing.Point(6, 189);
            this.checkBoxLog.Name = "checkBoxLog";
            this.checkBoxLog.Size = new System.Drawing.Size(149, 17);
            this.checkBoxLog.TabIndex = 12;
            this.checkBoxLog.Text = "Guardar en archivo de log";
            this.checkBoxLog.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.checkBoxLog);
            this.Controls.Add(this.ddlCommandos);
            this.Controls.Add(this.bntnReadMemory);
            this.Controls.Add(this.stringToReadLabel);
            this.Controls.Add(this.stringToWriteLabel);
            this.Controls.Add(this.closeSessionButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.txtCommandDescription);
            this.Controls.Add(this.readTextBox);
            this.Controls.Add(this.writeTextBox);
            this.Controls.Add(this.openSessionButton);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.queryButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lectura/Escritura simple";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new MainForm());
        }

        private void openSession_Click(object sender, System.EventArgs e)
        {
            using (SelectResource sr = new SelectResource())
            {
                if(lastResourceString != null)
                {
                    sr.ResourceName = lastResourceString;
                }
                DialogResult result = sr.ShowDialog(this);
                if(result == DialogResult.OK)
                {
                    lastResourceString = sr.ResourceName;
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        mbSession = (MessageBasedSession)ResourceManager.GetLocalManager().Open(sr.ResourceName);
                        SetupControlState(true);
                    }
                    catch(InvalidCastException)
                    {
                        MessageBox.Show("El recurso seleccionado debe ser una sesión basada en mensajes");
                    }
                    catch(Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }

        private void closeSession_Click(object sender, System.EventArgs e)
        {
            SetupControlState(false);
            mbSession.Dispose();
        }

        private void query_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {               
                
                string textToWrite = ReplaceCommonEscapeSequences(writeTextBox.Text);
                string responseString = mbSession.Query(textToWrite);
                readTextBox.Text = InsertCommonEscapeSequences(responseString);
                if (checkBoxLog.Checked)
                {
                    Log.WriteLog("Query - " + textToWrite, responseString);
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        

        private void write_Click(object sender, System.EventArgs e)
        {
            try
            {
                string textToWrite = ReplaceCommonEscapeSequences(writeTextBox.Text);
                mbSession.Write(textToWrite);
                if (checkBoxLog.Checked)
                {
                    Log.WriteLog("Write - " + textToWrite, "");
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void read_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string responseString = mbSession.ReadString();
                readTextBox.Text = InsertCommonEscapeSequences(responseString);
                if (checkBoxLog.Checked) { 
                    Log.WriteLog("", responseString);
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void clear_Click(object sender, System.EventArgs e)
        {
            readTextBox.Text = String.Empty;
        }

        private void SetupControlState(bool isSessionOpen)
        {
            openSessionButton.Enabled = !isSessionOpen;
            closeSessionButton.Enabled = isSessionOpen;
            queryButton.Enabled = isSessionOpen;
            writeButton.Enabled = isSessionOpen;
            readButton.Enabled = isSessionOpen;
            writeTextBox.Enabled = isSessionOpen;
            clearButton.Enabled = isSessionOpen;
            ddlCommandos.Enabled = isSessionOpen;
            bntnReadMemory.Enabled = isSessionOpen;
            if(isSessionOpen)
            {
                readTextBox.Text = String.Empty;
                writeTextBox.Focus();
            }
        }

        private string ReplaceCommonEscapeSequences(string s)
        {
            return s.Replace("\\n", "\n").Replace("\\r", "\r");
        }

        private string InsertCommonEscapeSequences(string s)
        {
            return s.Replace("\n", "\\n").Replace("\r", "\\r");
        }

        private void bntnReadMemory_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                mbSession.SetAttributeBoolean(AttributeType.DmaAllowEn, true);
                var responseString = mbSession.Query("DBA?");

                // tmpByteArray = mbSession.ReadByteArray(1024);
                //.ReadToFile("martin");
                //var a = mbSession.ReadString(1024);

                //string textToWrite = ReplaceCommonEscapeSequences(writeTextBox.Text);

                readTextBox.Text = InsertCommonEscapeSequences(responseString);
                if (checkBoxLog.Checked)
                {
                    Log.WriteLog("", responseString);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ddlCommandos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = ddlCommandos.SelectedValue;
            txtCommandDescription.Text = commands.FirstOrDefault(x => x.value == text.ToString()).description;
            writeTextBox.Text = ddlCommandos.SelectedValue.ToString();
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace Barcode_Scanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.tb_barcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.tb_datetime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.label1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.label2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.btn_export.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.btn_exportall.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
        }
        public Dictionary<string, string> barcode_today = new Dictionary<string, string>();
        public Array total_barcode_today;
        public string init_barcode = "";
        public string current_barcode = "";
        public string txtfilepath = "";
        const string SPLITTER = "@splitter#";
        public delegate void UpdateTextBoxDelegate(string cur_barcode);
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() != "\r")
            {
                string cur_char = e.KeyChar.ToString();
                    
                init_barcode += cur_char;
            }
            else
            {
                current_barcode = init_barcode;
                init_barcode = "";
                Console.WriteLine(sender);
                Invoke(new UpdateTextBoxDelegate(InvokeUpdateTextBox), current_barcode);

            }
        }

        private void playsound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("warning_sound.wav");
            player.Play();
        }

        public void UpdateTextBoxThread()
        {
            //Invoke the delegate within the UI thread context
            Invoke(new UpdateTextBoxDelegate(InvokeUpdateTextBox), current_barcode);
        }

        public void InvokeUpdateTextBox(string cur_barcode)
        {
            DateTime now = DateTime.Now;
            tb_barcode.Text = cur_barcode;
            tb_datetime.Text = now.ToString();


            if (!barcode_today.ContainsKey(cur_barcode))
            {
                barcode_today.Add(cur_barcode, now.ToString());
                using (StreamWriter w = File.AppendText(txtfilepath))
                {
                    string wline = cur_barcode + SPLITTER + now.ToString();
                    w.WriteLine(wline);
                }
            }
            else
            {
                //MessageBox.Show("This barcode already exists!");
                playsound();
                //item = container[s];
            }

            //item.Add("value1");
        }

        private void load_exist_data(string file_path)
        {
            string[] existed_data = System.IO.File.ReadAllText(file_path).Split("\n"); 
            //existed_data = existed_data.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            foreach (string line in existed_data)
            {
                try
                {
                    if (line != "")
                    {
                        if (line.Split(SPLITTER).Length >= 2)
                        {
                            string barcode = line.Split(SPLITTER)[0];
                            string _datetime = line.Split(SPLITTER)[1];
                            barcode_today.Add(barcode, _datetime);
                        }
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show("cannot read existed file");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string today = now.ToString().Split(" ")[0].Replace("/", "_");
            Thread thread = new Thread(new ThreadStart(UpdateTextBoxThread));
            string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);
            txtfilepath = Path.Combine(exeDir, "scanned_data\\"+today+".txt");
            bool isExist = File.Exists(txtfilepath);
            if (isExist == true)
            {
                load_exist_data(txtfilepath);
            }
            else
            {
                using (StreamWriter sw = File.CreateText(txtfilepath));
            }
            thread.Start();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);
            string csv_dir = Path.Combine(exeDir, "scanned_data\\exported_csv");
            if (Directory.Exists(csv_dir) == false)
            {
                Directory.CreateDirectory(csv_dir);
            }
            export_single_file(txtfilepath);
        }

        private void export_single_file(string export_file)
        {
            string[] existed_data = System.IO.File.ReadAllText(export_file).Split("\n");
            existed_data = existed_data.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string[] filenames = export_file.Split("\\");
            string filename = filenames[filenames.Length - 1];
            string csv_filepath = export_file.Replace(filename, "exported_csv\\" + filename.Replace(".txt", ".csv"));
            using (StreamWriter w = new StreamWriter(csv_filepath))
            {
            foreach (string line in existed_data)
            {
                try
                {
                    string barcode = line.Split(SPLITTER)[0].ToString();
                    string _datetime = line.Split(SPLITTER)[1];
                    string new_line = "'" + barcode + "," + _datetime;
                    string wline = new_line;
                    w.Write(wline);
                }
                catch
                {
                    MessageBox.Show("cannot export file:" + export_file);
                }
            }
            }
        }

        private void btn_exportall_Click(object sender, EventArgs e)
        {
            string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);
            string csv_dir = Path.Combine(exeDir, "scanned_data\\exported_csv");
            string txt_dir = Path.Combine(exeDir, "scanned_data");
            if (Directory.Exists(csv_dir) == false)
            {
                Directory.CreateDirectory(csv_dir);
            }
            DirectoryInfo dinfo = new DirectoryInfo(txt_dir);
            FileInfo[] Files = dinfo.GetFiles("*.txt");
            foreach (FileInfo file in Files)
            {
                export_single_file(file.FullName);
            }
        }
    }
}

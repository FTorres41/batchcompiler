using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalAppCompilator3000Tabajara
{
    public partial class PAC3K : Form
    {
        #region Atributos

        public string folderPath;
        public string[] batFiles;
        public string[] vbsFiles;
        public List<string> batchList;

        #endregion

        public PAC3K()
        {
            InitializeComponent();
        }

        #region Funções
        private void runBatch(string path)
        {
            ProcessStartInfo psi = new ProcessStartInfo(path);

            psi.UseShellExecute = false;

            Process proc = new Process();
            proc.StartInfo = psi;

            proc.Start();
            proc.WaitForExit();
        }

        private List<string> getBatches()
        {
            List<string> batchList = new List<string>();

            if (comboBox1.SelectedItem != null)
            {
                batchList.Add(comboBox1.SelectedItem.ToString());
            }

            if (comboBox2.SelectedItem != null)
            {
                batchList.Add(comboBox2.SelectedItem.ToString());
            }

            if (comboBox3.SelectedItem != null)
            {
                batchList.Add(comboBox3.SelectedItem.ToString());
            }

            if (comboBox4.SelectedItem != null)
            {
                batchList.Add(comboBox4.SelectedItem.ToString());
            }

            if (comboBox5.SelectedItem != null)
            {
                batchList.Add(comboBox5.SelectedItem.ToString());
            }

            return batchList;
        }

        #endregion

        private void quantityCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (quantityCmbBox.SelectedItem.ToString() == "1")
            {
                lbl1.Visible = true;
                comboBox1.Visible = true;
            }
            else if (quantityCmbBox.SelectedItem.ToString() == "2")
            {
                lbl1.Visible = true;
                comboBox1.Visible = true;
                lbl2.Visible = true;
                comboBox2.Visible = true;
            }
            else if (quantityCmbBox.SelectedItem.ToString() == "3")
            {
                lbl1.Visible = true;
                comboBox1.Visible = true;
                lbl2.Visible = true;
                comboBox2.Visible = true;
                lbl3.Visible = true;
                comboBox3.Visible = true;
            }
            else if (quantityCmbBox.SelectedItem.ToString() == "4")
            {
                lbl1.Visible = true;
                comboBox1.Visible = true;
                lbl2.Visible = true;
                comboBox2.Visible = true;
                lbl3.Visible = true;
                comboBox3.Visible = true;
                lbl4.Visible = true;
                comboBox4.Visible = true;
            }
            else if (quantityCmbBox.SelectedItem.ToString() == "5")
            {
                lbl1.Visible = true;
                comboBox1.Visible = true;
                lbl2.Visible = true;
                comboBox2.Visible = true;
                lbl3.Visible = true;
                comboBox3.Visible = true;
                lbl4.Visible = true;
                comboBox4.Visible = true;
                lbl5.Visible = true;
                comboBox5.Visible = true;
            }

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            batchList = getBatches();

            foreach(var batch in batchList)
            {
                runBatch(batch);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            folderPath = folderTxtBox.Text;

            if (quantityCmbBox.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione uma quantidade de arquivos a serem rodados", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (folderPath == string.Empty)
            {
                MessageBox.Show("Por favor, insira uma pasta válida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                folderTxtBox.Focus();
                return;
            }
            else if (!folderPath.Contains("\\"))
            {
                if (MessageBox.Show("Por favor, insira uma pasta válida", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1).Equals(DialogResult.Yes))
                {
                    folderTxtBox.Text = "";
                    folderTxtBox.Clear();
                    folderTxtBox.Focus();
                    return;
                }
            }

            batFiles = Directory.GetFiles(folderPath, "*.bat");
            vbsFiles = Directory.GetFiles(folderPath, "*.vbs");

            comboBox1.Items.AddRange(batFiles);
            comboBox2.Items.AddRange(batFiles);
            comboBox3.Items.AddRange(batFiles);
            comboBox4.Items.AddRange(batFiles);
            comboBox5.Items.AddRange(batFiles);

            comboBox1.Items.AddRange(vbsFiles);
            comboBox2.Items.AddRange(vbsFiles);
            comboBox3.Items.AddRange(vbsFiles);
            comboBox4.Items.AddRange(vbsFiles);
            comboBox5.Items.AddRange(vbsFiles);

            MessageBox.Show("Arquivos encontrados!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}

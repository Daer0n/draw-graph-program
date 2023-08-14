using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystAnalys_lr1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(textBox1.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex) {
                MessageBox.Show(String.Format("Введите вес в нужном формате!"));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        public double ReturnData()
        {
            try
            {
                return (Convert.ToDouble(textBox1.Text));
            }
            catch (Exception ex) { return 0; }
        }

    }
}

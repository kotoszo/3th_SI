using Regular_Expression;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Regular_UI
{
    public partial class Form1 : Form
    {
        Validator validator = new Validator();

        public Form1()
        {
            InitializeComponent();

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!validator.IsValidName(nameBox.Text) && !validator.IsValidPhone(phoneBox.Text) 
                && !validator.IsValidEmail(mailBox.Text))
            {
                MessageBox.Show("NAH");
            }else
            {
                MessageBox.Show("YEAH");
            }
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            if (validator.IsValidName(nameBox.Text))
            {
                nameCheck.Checked = true;
            }
            else
            {
                nameCheck.Checked = false;
            }
        }

        private void phoneBox_TextChanged(object sender, EventArgs e)
        {
            if (validator.IsValidPhone(phoneBox.Text))
            {
                phoneCheck.Checked = true;
            } else
            {
                phoneCheck.Checked = false;
            }
        }

        private void mailBox_TextChanged(object sender, EventArgs e)
        {
            if (validator.IsValidEmail(mailBox.Text))
            {
                mailCheck.Checked = true;
            } else
            {
                mailCheck.Checked = false;
            }
        }
    }
}

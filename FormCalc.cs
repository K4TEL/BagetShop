using BagetShop.BS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagetShop
{
    public partial class FormCalc : Form
    {
        public FormCalc()
        {
            Calc calc = new Calc(new DB(), BagetType.getByName("Elite"), 20, 30, 2);
            calc.PrintCalc();
            InitializeComponent();
        }

        private void FormCalc_Load(object sender, EventArgs e)
        {
            
        }
    }
}

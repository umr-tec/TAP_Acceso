﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAP_U1_Ejemplo2
{
    public partial class frmCategorias : Form
    {
        public frmCategorias()
        {
            InitializeComponent();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = frmAcceso.nombreConectado;
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            //Application.Exit();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmCategorias_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

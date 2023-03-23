using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TAP_U1_Ejemplo2
{
    public partial class frmAcceso : Form
    {
        //Crear Dictionary para los datos de acceso
        Dictionary<string, string> credencialesAcceso = new System.Collections.Generic.Dictionary<string, string>();
        public static string nombreConectado;

        public frmAcceso()
        {
            InitializeComponent();
        }

        private void frmAcceso_Load(object sender, EventArgs e)
        {            
            //LLenar el Dictionary
            credencialesAcceso.Add("211000112", "Amador Rivera Martínez");
            credencialesAcceso.Add("211000126", "Ezequiel");
            credencialesAcceso.Add("211000122", "Daniela");
            credencialesAcceso.Add("211000115", "Walter");
            credencialesAcceso.Add("211000183", "Sonia");
            //Programar el componente niBarra
            niBarra.BalloonTipIcon = ToolTipIcon.Info;
            niBarra.Visible = true;
            niBarra.BalloonTipTitle = "TAP Acceso";
            niBarra.BalloonTipText = "Acceso directo para salir del sistema";

            //Agregar un icono que no este en el proyevto
            niBarra.Icon = new Icon(@"C:\Users\ulise\Downloads\imas\icons\tecsanpedro_solo.ico");
            niBarra.ShowBalloonTip(1000);

        }

        private void btnAceptar_MouseMove(object sender, MouseEventArgs e)
        {
            //Cambiar la imagen
            btnAceptar.Image = Properties.Resources.check_circle_FILL1_;
        }

        private void btnAceptar_MouseLeave(object sender, EventArgs e)
        {
            btnAceptar.Image = Properties.Resources.check_circle_FILL0;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.Image = Properties.Resources.cancel_FILL0;
        }

        private void btnCancelar_MouseMove(object sender, MouseEventArgs e)
        {
            btnCancelar.Image = Properties.Resources.cancel_FILL1_;
        }

        private void niBarra_Click(object sender, EventArgs e)
        {
            //Cuando se de clicl en en notifiIcon, saldrá de la app
            Environment.Exit(-1);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Intanciar el Form frmCategorias
            frmCategorias categorias = new frmCategorias();

            //Validar credenciales de acceso
            string user = "UMR", pass = "1234";
            if (credencialesAcceso.ContainsKey(txtUsuario.Text) )
            {
                MessageBox.Show("Bienvenido al sistema.", "TAP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nombreConectado = credencialesAcceso[txtUsuario.Text];
                this.Hide();
                categorias.Show();
            }
            else
            {
                MessageBox.Show("Error de conexión.", "TAP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 00 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                e.Handled = true;                
                //MessageBox.Show("Solo puedes ingersar números.", "TAP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
                //Error Provider, permite notificar de manera visual un error.
                //En este caso al ingrsar algún valor no númerico, aparecera el error provider parpadeando
                //para que esto suceda, se debe usar el metodo SetError, el cual permite que aparezca el error provider
                //el método SetError, recibe dos parametros:
                //el 1ro. es el control en donde queremos que aparezca el error provider (en este ejemplo el error provider aparecerá a lado de la caja de texto llamada txtUsuario)
                // el 2o. indica que texto queremos que muestre el error provider (para ver el texto debemos colocar el cursos por encima del error provider cuando este aparezca en pantalla)
                epNumeros.SetError(txtUsuario, "Debes ingrsar solo números.");
                return;
            }//activamos un else para ocular nuevamente el error provoder cuando la entrada a la caja de texto sea la deseada
            else
            {
                epNumeros.SetError(txtUsuario, "");
            }
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                this.BackColor = Color.Red;
            }
            if (e.KeyCode == Keys.A)
            {
                e.Handled = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PRG2_21222_P7_2_71
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtNamaProdi.Enabled = false;
            txtSingkatan.Enabled = false;
            txtKaProdi.Enabled = false;
            txtSekProdi.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtIdProdi.Text == "")
            {
                MessageBox.Show("Masukkan ID Prodi terlebih Dahulu!", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    txtNamaProdi.Enabled = true;
                    txtSingkatan.Enabled = true;
                    txtKaProdi.Enabled = true;
                    txtSekProdi.Enabled = true;

                    string connectionString = "integrated security=true; data source=DZDEKSTOP\\SQLEXPRESS; initial catalog=P5_71";
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("SELECT*FROM msprodi where id_prodi='" + txtIdProdi.Text + "'", connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    txtNamaProdi.Text = dt.Rows[0]["nama_prodi"].ToString();
                    txtSingkatan.Text = dt.Rows[0]["singkatan"].ToString();
                    txtKaProdi.Text = dt.Rows[0]["ka_prodi"].ToString();
                    txtSekProdi.Text = dt.Rows[0]["sek_prodi"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                    txtNamaProdi.Enabled = false;
                    txtSingkatan.Enabled = false;
                    txtKaProdi.Enabled = false;
                    txtSekProdi.Enabled = false;
                }
            }
        }

        public void reset()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Clear();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            reset();
            txtNamaProdi.Enabled = false;
            txtSingkatan.Enabled = false;
            txtKaProdi.Enabled = false;
            txtSekProdi.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdProdi.Text == "" && txtNamaProdi.Text == "" && txtSingkatan.Text == ""
                    && txtKaProdi.Text == "" && txtSekProdi.Text == "")
                {
                    MessageBox.Show("Silahkan Lengkapi Data!", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    using (LINQ_0320210071DataContext context = new LINQ_0320210071DataContext())
                    {
                        msprodi update = context.msprodis.FirstOrDefault(update1 => update1.id_prodi.Equals(txtIdProdi.Text));

                        update.nama_prodi = txtNamaProdi.Text;
                        update.singkatan = txtSingkatan.Text;
                        update.ka_prodi = txtKaProdi.Text;
                        update.sek_prodi = txtSekProdi.Text;

                        context.SubmitChanges();

                        MessageBox.Show("Update Sukses!", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                txtNamaProdi.Enabled = false;
                txtSingkatan.Enabled = false;
                txtKaProdi.Enabled = false;
                txtSekProdi.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdProdi.Text == "" && txtNamaProdi.Text == "" && txtSingkatan.Text == ""
                    && txtKaProdi.Text == "" && txtSekProdi.Text == "")
                {
                    MessageBox.Show("Silahkan Lengkapi Data!", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    using (LINQ_0320210071DataContext context = new LINQ_0320210071DataContext())
                    {
                        msprodi delete = context.msprodis.FirstOrDefault(delete1 => delete1.id_prodi.Equals(txtIdProdi.Text));

                        context.msprodis.DeleteOnSubmit(delete);
                        context.SubmitChanges();

                        MessageBox.Show("Delete Sukses!", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                        reset();
                        txtNamaProdi.Enabled = false;
                        txtSingkatan.Enabled = false;
                        txtKaProdi.Enabled = false;
                        txtSekProdi.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                txtNamaProdi.Enabled = false;
                txtSingkatan.Enabled = false;
                txtKaProdi.Enabled = false;
                txtSekProdi.Enabled = false;
            }
        }
    }
}

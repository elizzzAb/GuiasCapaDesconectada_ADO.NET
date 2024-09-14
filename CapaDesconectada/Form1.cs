using AccesoDatos;
using CapaDesconectada.NorthwindTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDesconectada
{
    public partial class Form1 : Form
    {
        #region No Tipado 
        private CustomerRepository customerRepository = new CustomerRepository();

        private void btnObtenerNoTipado_Click_1(object sender, EventArgs e)
        {

            gridNotipado.DataSource = customerRepository.ObtenerTodos();

        }

        private void btnBuscarNt_Click(object sender, EventArgs e)
        {
            var cliente = customerRepository.obtenerPorID(tbBusquedaNt.Text);
            if (cliente == null)
            {
                MessageBox.Show("El objeto es null");
            }
            if (cliente != null)
            {
                var listaClientes = new List<Customer> { cliente };
                gridNotipado.DataSource = listaClientes;
            }
        }

        private void btonInsertarCliente_Click(object sender, EventArgs e)
        {
            var cliente = CrearCliente();
            int insertados = customerRepository.InsertarCliente(cliente);
            MessageBox.Show($"{insertados} registrados");
        }

        private Customer CrearCliente()
        {
            var cliente = new Customer
            {
                CustomerID = tboxCustomerID.Text,
                CompanyName = tboxCompaniName.Text,
                ContactName = tboxContactName.Text,
                ContactTitle = tboxContactTitle.Text,
                Address = tboxAddres.Text
            };
                MessageBox.Show(cliente.CustomerID);
                MessageBox.Show(cliente.CompanyName);
                MessageBox.Show(cliente.ContactName);
                MessageBox.Show(cliente.ContactTitle);
                MessageBox.Show(cliente.Address);
                return cliente;
        }

        #endregion

        #region tipado
        CustomersTableAdapter adaptador = new CustomersTableAdapter();

        private void btnObtenerTipado_Click(object sender, EventArgs e)
        {
            var customers = adaptador.GetData();
            gridTipado.DataSource = customers;
        }

        private void btnBuscarTipado_Click(object sender, EventArgs e)
        {
            var customer = adaptador.GetDataByCustomerID(tboxBuscarTipado.Text);

            if (customer != null)
            {
                var objeto1 = customerRepository.ExtraerInformacionCliente(customer);
                Console.WriteLine(customer);
                gridTipado.DataSource = customer;

            }


        }
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        
    }
}

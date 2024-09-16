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
                return cliente;
        }

        #endregion
//------------------------------------------------------------------------------------------------------------

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
                //var objeto1 = customerRepository.ExtraerInformacionCliente(customer);
                //Console.WriteLine(customer);
                gridTipado.DataSource = customer;

            }

        }

        private void btnInsertarT_Click(object sender, EventArgs e)
        {
            var cliente = CrearCliente();
            int insertados = adaptador.Insert(cliente.CustomerID, cliente.CompanyName,
                cliente.ContactName, cliente.ContactTitle, cliente.Address, cliente.City,
                cliente.Region, cliente.PostalCode, cliente.Country, cliente.Phone, cliente.Fax
                ); //Aparece error por las restricciones que tiene la BD, si respetamos las restricciones no, pasa nada. 

            MessageBox.Show($"{insertados} registros insertados");

        }

        #endregion

//------------------------------------------------------------------------------------------------------------

        public Form1()
        {
            InitializeComponent();
        }

        
    }
}

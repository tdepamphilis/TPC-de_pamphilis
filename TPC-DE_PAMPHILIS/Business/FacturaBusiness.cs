﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Diagnostics;

namespace Business
{
    public class FacturaBusiness
    {

        public void GenerarCompra(Factura factura)
        {
            bool done = false;
            while (!done)
            {
                factura.codigo = generateCode();
                SaveFactura(factura);
                if (checkFactura(factura))
                    done = true;
            }
            foreach (ItemCarrito item in factura.items)
            {
                saveItems(item, factura.codigo);

            }
        }
        // ------------LECTURA GENERAL-------------
        public List<Factura> listarFacturas(string userCode)
        {
            GestorConexion gestor = new GestorConexion();
            List<Factura> aux = new List<Factura>();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_facturas where CodigoUsuario = @user order by Fecha desc";
                command.Parameters.AddWithValue("@user", userCode);
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    Factura x = new Factura();
                    x.codigo = lector.GetString(0);
                    x.codigoUsuario = lector.GetString(1);
                    x.fecha = lector.GetDateTime(2);
                    x.estado = lector.GetBoolean(3);
                    x.modoDePago = lector.GetString(4)[0];
                    x.monto = (float)lector.GetDecimal(5);
                    x.dir = lector.GetString(6);
                    x.ApellidoNombre = lector.GetString(7);
                    x.pago = lector.GetBoolean(8);
                    x.estadoEntrega = lector.GetInt32(9);

                    aux.Add(x);
                }
                connection.Close();
                return aux;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Factura buscarId(string code)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_facturas where Codigo = @code";
                command.Parameters.AddWithValue("@code", code);
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                lector.Read();
                Factura x = new Factura();
                x.codigo = lector.GetString(0);
                x.codigoUsuario = lector.GetString(1);
                x.fecha = lector.GetDateTime(2);
                x.estado = lector.GetBoolean(3);
                x.modoDePago = lector.GetString(4)[0];
                x.monto = (float)lector.GetDecimal(5);
                x.dir = lector.GetString(6);
                x.ApellidoNombre = lector.GetString(7);
                x.pago = lector.GetBoolean(8);
                x.estadoEntrega = lector.GetInt32(9);
                connection.Close();
                x.items = cargarItems(x.codigo);

                return x;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private List<ItemCarrito> cargarItems(string codigoFactura)
        {
            GestorConexion gestor = new GestorConexion();
            List<ItemCarrito> aux = new List<ItemCarrito>();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_itemFactura where CodigoFactura = @code";
                command.Parameters.AddWithValue("@code", codigoFactura);
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    ItemCarrito x = new ItemCarrito();
                    x.code = lector.GetString(1);
                    x.name = lector.GetString(2);
                    x.ammount = lector.GetInt32(3);
                    x.unitPrice = (float)lector.GetDecimal(4);
                    aux.Add(x);
                }
                connection.Close();
                return aux;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string getLastCode(string usercode)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_facturas where CodigoUsuario = @user order by Fecha desc ";
                command.Parameters.AddWithValue("@user", usercode);
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                lector.Read();                     
                string result = lector.GetString(0);                                       
                connection.Close();
                if (result == null)
                    return "notFount";
                else
                    return result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //---------LECTURA DE EN CAMINO-----------

        public List<Factura> listarFacturasCode(string code)
        {
            GestorConexion gestor = new GestorConexion();
            List<Factura> aux = new List<Factura>();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_facturas where Codigo like '%" + code + "%' and Entrega = 1 order by ApellidoNombre, Fecha";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    Factura x = new Factura();
                    x.codigo = lector.GetString(0);
                    x.codigoUsuario = lector.GetString(1);
                    x.fecha = lector.GetDateTime(2);
                    x.estado = lector.GetBoolean(3);
                    x.modoDePago = lector.GetString(4)[0];
                    x.monto = (float)lector.GetDecimal(5);
                    x.dir = lector.GetString(6);
                    x.ApellidoNombre = lector.GetString(7);
                    x.pago = lector.GetBoolean(8);
                    x.estadoEntrega = lector.GetInt32(9);
                    aux.Add(x);
                }
                connection.Close();
                return aux;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Factura> listarFacturasUserCode(string code)
        {
            GestorConexion gestor = new GestorConexion();
            List<Factura> aux = new List<Factura>();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_facturas where CodigoUsuario like '%" + code + "%' and Entrega = 1 order by ApellidoNombre, Fecha";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    Factura x = new Factura();
                    x.codigo = lector.GetString(0);
                    x.codigoUsuario = lector.GetString(1);
                    x.fecha = lector.GetDateTime(2);
                    x.estado = lector.GetBoolean(3);
                    x.modoDePago = lector.GetString(4)[0];
                    x.monto = (float)lector.GetDecimal(5);
                    x.dir = lector.GetString(6);
                    x.ApellidoNombre = lector.GetString(7);
                    x.pago = lector.GetBoolean(8);
                    x.estadoEntrega = lector.GetInt32(9);
                    aux.Add(x);
                }
                connection.Close();
                return aux;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Factura> listarFacturasUserName(string username)
        {
            GestorConexion gestor = new GestorConexion();
            List<Factura> aux = new List<Factura>();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_facturas where ApellidoNombre like '%" + username + "%' and Entrega = 1 order by ApellidoNombre, Fecha";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    Factura x = new Factura();
                    x.codigo = lector.GetString(0);
                    x.codigoUsuario = lector.GetString(1);
                    x.fecha = lector.GetDateTime(2);
                    x.estado = lector.GetBoolean(3);
                    x.modoDePago = lector.GetString(4)[0];
                    x.monto = (float)lector.GetDecimal(5);
                    x.dir = lector.GetString(6);
                    x.ApellidoNombre = lector.GetString(7);
                    x.pago = lector.GetBoolean(8);
                    x.estadoEntrega = lector.GetInt32(9);
                    aux.Add(x);
                }
                connection.Close();
                return aux;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //--------LECTURA DE PENDIENTES-------

        public List<Factura> listarPendientesCode(string code)
        {
            GestorConexion gestor = new GestorConexion();
            List<Factura> aux = new List<Factura>();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_facturas where Codigo like '%" + code + "%' and Entrega = 0 order by Fecha";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    Factura x = new Factura();
                    x.codigo = lector.GetString(0);
                    x.codigoUsuario = lector.GetString(1);
                    x.fecha = lector.GetDateTime(2);
                    x.estado = lector.GetBoolean(3);
                    x.modoDePago = lector.GetString(4)[0];
                    x.monto = (float)lector.GetDecimal(5);
                    x.dir = lector.GetString(6);
                    x.ApellidoNombre = lector.GetString(7);
                    x.pago = lector.GetBoolean(8);
                    x.estadoEntrega = lector.GetInt32(9);
                    aux.Add(x);
                }
                connection.Close();
                return aux;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int contarPendientes()
        {
            int x;
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_facturasPendientes";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                lector.Read();
                x = lector.GetInt32(0);

                return x;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //--------LECTURA DE CONPLETOS----------

        public List<Factura> listarCompletasCode(string code)
        {

            GestorConexion gestor = new GestorConexion();
            List<Factura> aux = new List<Factura>();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_facturas where Codigo like '%" + code + "%' and Entrega = 2 order by ApellidoNombre, Fecha";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    Factura x = new Factura();
                    x.codigo = lector.GetString(0);
                    x.codigoUsuario = lector.GetString(1);
                    x.fecha = lector.GetDateTime(2);
                    x.estado = lector.GetBoolean(3);
                    x.modoDePago = lector.GetString(4)[0];
                    x.monto = (float)lector.GetDecimal(5);
                    x.dir = lector.GetString(6);
                    x.ApellidoNombre = lector.GetString(7);
                    x.pago = lector.GetBoolean(8);
                    x.estadoEntrega = lector.GetInt32(9);
                    aux.Add(x);
                }
                connection.Close();
                return aux;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public List<Factura> listarCompletasUserCode(string code)
        {
            GestorConexion gestor = new GestorConexion();
            List<Factura> aux = new List<Factura>();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_facturas where CodigoUsuario like '%" + code + "%' and Entrega = 2 order by ApellidoNombre, Fecha";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    Factura x = new Factura();
                    x.codigo = lector.GetString(0);
                    x.codigoUsuario = lector.GetString(1);
                    x.fecha = lector.GetDateTime(2);
                    x.estado = lector.GetBoolean(3);
                    x.modoDePago = lector.GetString(4)[0];
                    x.monto = (float)lector.GetDecimal(5);
                    x.dir = lector.GetString(6);
                    x.ApellidoNombre = lector.GetString(7);
                    x.pago = lector.GetBoolean(8);
                    x.estadoEntrega = lector.GetInt32(9);
                    aux.Add(x);
                }
                connection.Close();
                return aux;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Factura> listarCompletasUserName(string username)
        {
            GestorConexion gestor = new GestorConexion();
            List<Factura> aux = new List<Factura>();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from vw_facturas where ApellidoNombre like '%" + username + "%' and Entrega = 2 order by ApellidoNombre, Fecha";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    Factura x = new Factura();
                    x.codigo = lector.GetString(0);
                    x.codigoUsuario = lector.GetString(1);
                    x.fecha = lector.GetDateTime(2);
                    x.estado = lector.GetBoolean(3);
                    x.modoDePago = lector.GetString(4)[0];
                    x.monto = (float)lector.GetDecimal(5);
                    x.dir = lector.GetString(6);
                    x.ApellidoNombre = lector.GetString(7);
                    x.pago = lector.GetBoolean(8);
                    x.estadoEntrega = lector.GetInt32(9);
                    aux.Add(x);
                }
                connection.Close();
                return aux;
            }
            catch (Exception)
            {

                throw;
            }
        }


        //-------ESCRITURA---------------


        public void saveItems(ItemCarrito item, string codigoFactura)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into itemsxfactura values(@ArtCode, @CodigoFactura, @price, @cant) ";
                command.Parameters.AddWithValue("@ArtCode", item.code);
                command.Parameters.AddWithValue("@CodigoFactura", codigoFactura);
                command.Parameters.AddWithValue("@price", (decimal)item.unitPrice);
                command.Parameters.AddWithValue("@cant", item.ammount);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();

            }
        }

        public void SaveFactura(Factura factura)
        {
            if (factura.codigo == null)
                factura.codigo = generateCode();

            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "exec SP_CargaFactura @code, @userCode, @date , @status, @payment, @value, @dir, @paid, @deliveryst";
                command.Parameters.AddWithValue("@code", factura.codigo);
                command.Parameters.AddWithValue("@userCode", factura.codigoUsuario);
                command.Parameters.AddWithValue("@status", factura.estado);
                command.Parameters.AddWithValue("@payment", factura.modoDePago);
                command.Parameters.AddWithValue("@value", (decimal)factura.monto);
                command.Parameters.AddWithValue("@date", factura.fecha);
                command.Parameters.AddWithValue("@dir", factura.dir);
                command.Parameters.AddWithValue("@paid", factura.pago);
                command.Parameters.AddWithValue("@deliveryst", factura.estadoEntrega);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }




        }

        public void anularFactura(string code)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update facturas set Estado = 0 where Codigo = @code";
                command.Parameters.AddWithValue("@code", code);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();

            }
        }

        public void upEnvio(string code)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update facturas set Entrega = Entrega +1 where Codigo = @code";
                command.Parameters.AddWithValue("@code", code);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();

            }
        }

        public void downEnvio(string code)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update facturas set Entrega = Entrega -1 where Codigo = @code";
                command.Parameters.AddWithValue("@code", code);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public void changePrice(Factura factura)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update facturas set Monto = @monto where Codigo = @code";
                command.Parameters.AddWithValue("@code", factura.codigo);
                command.Parameters.AddWithValue("@monto", (decimal)factura.totalPrice());
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public void updateFacturaItems(Factura factura, List<string> itemsOriginales)
        {
            foreach(ItemCarrito item in factura.items)
            {
                changeItemAmmount(item.code, factura.codigo, item.ammount);
            }
            foreach(string item in itemsOriginales)
            {
                bool exists = false;
                foreach(ItemCarrito itemfactura in factura.items)
                {
                    if (itemfactura.code == item)
                        exists = true;
                }
                if (!exists)
                    deleteItem(item,factura.codigo);
                    

            }


        }

        private void changeItemAmmount(string itemCode, string facturaCode, int ammount)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update itemsxfactura set Cantidad = @cant where CodigoFactura = @fac and CodigoArticulo = @art";
                command.Parameters.AddWithValue("@cant", ammount);
                command.Parameters.AddWithValue("@fac", facturaCode);
                command.Parameters.AddWithValue("@art", itemCode);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();

            }
        }

        private void deleteItem(string itemCode, string facturaCode)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete itemsxfactura  where CodigoFactura = @fac and CodigoArticulo = @art";
                command.Parameters.AddWithValue("@fac", facturaCode);
                command.Parameters.AddWithValue("@art", itemCode);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();

            }
        }

        public void devolverStock(string code)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            try
            {

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "exec SP_DevolucionFactura @code";
                command.Parameters.AddWithValue("@code", code);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();

            }
        }

        //--------GENERACION DE CODIGO--------------

        private bool checkCode(string code)
        {
            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;
            bool found = false;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from facturas where Codigo ='" + code + "'";
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                while (lector.Read())
                {
                    found = true;
                }
                connection.Close();
                return found;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string generateCode()
        {
            while (true)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var stringChars = new Char[15];
                Random random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                string result = new string(stringChars);

                if (!checkCode(result))
                {
                    return result;

                }
            }
        }

        // ---------------VALIDACION--------------------

        private bool checkFactura(Factura factura)
        {

            GestorConexion gestor = new GestorConexion();
            SqlConnection connection = gestor.connection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;

            int x;
            try
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Count(*) from facturas where Codigo = @code and CodigoUsuario = @user";
                command.Parameters.AddWithValue("@code", factura.codigo);
                command.Parameters.AddWithValue("@user", factura.codigoUsuario);
                command.Connection = connection;
                connection.Open();
                lector = command.ExecuteReader();
                lector.Read();
                x = lector.GetInt32(0);
                connection.Close();
                if (x != 0)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }

        }



    }

}

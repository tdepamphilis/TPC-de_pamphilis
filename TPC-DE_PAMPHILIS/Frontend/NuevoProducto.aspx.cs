using Business;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Security.Permissions;
using Microsoft.Ajax.Utilities;

namespace Frontend
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Medium)]
    public partial class NuevoProducto : System.Web.UI.Page
    {
        MarcaBusiness marcaBusiness = new MarcaBusiness();
        CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
        ProductoBusiness productoBusiness = new ProductoBusiness();
        List<Marca> marcas;
        List<Categoria> categorias;
        public Producto producto = new Producto();
        public string title = "Nuevo";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                marcas = marcaBusiness.listar();
                BrandSelector.DataSource = marcas;
                BrandSelector.DataBind();
                loadCat();
                if (!ismod())
                {
                    generateCode();
                }


            }
        }

        //----------CARGA---------------------
        private void loadCat()
        {
            categorias = categoriaBusiness.listar();
            foreach (Categoria x in categorias)
            {
                ListItem aux = new ListItem(x.name, x.id.ToString());

                Categorybox.Items.Add(aux);

            }

        }

        private bool ismod()
        {
            string code = Request.QueryString["mod"];
            if (code == null)
                return false;
            loadProduct(code);
            title = "Modificar";
            return true;


        }
        //-------------NUEVO PRODUCTO------------------
        private void generateCode()
        {
            TextCode.Text = productoBusiness.generateCode();
            TextCode.ReadOnly = true;

        }
        //----------MODIFICAR PRODUCTO

        private void loadProduct(string code)
        {
            producto = productoBusiness.buscarid(code);
            TextCode.Text = producto.code;
            TextCode.ReadOnly = true;
            TextName.Text = producto.name;
            TextDesc.Text = producto.desc;
            BrandSelector.Items.FindByText(producto.marca.name).Selected = true;

        }
        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (TextName.Text != "" && TextDesc.Text != "" && FileImage.HasFile)
            {



                StockBusiness stockBusiness = new StockBusiness();
                productoBusiness.delete(TextCode.Text);                
                Producto nuevo = new Producto();
                Marca marca = new Marca();
                nuevo.name = TextName.Text;
                nuevo.code = TextCode.Text;
                nuevo.desc = TextDesc.Text;
                marca = marcaBusiness.buscarnombre((string)BrandSelector.SelectedItem.Value);
                nuevo.marca = marca;
                nuevo.margin = 25;
                nuevo.urlimagen = save();
                productoBusiness.create(nuevo);
                stockBusiness.createData(nuevo.code);
                Response.Redirect("TiendaAdmin.aspx");

            }
        }

        private string save()
        {
            string root = Server.MapPath("~");
            string savePath = root + "\\Images\\";
            string filename = TextCode.Text + ".jpg";
            FileImage.SaveAs(savePath + filename);
            return "\\Images\\" + filename;

        }
    }
}
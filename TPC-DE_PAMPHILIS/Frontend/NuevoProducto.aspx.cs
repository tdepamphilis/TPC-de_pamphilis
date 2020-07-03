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

            if (!login())
                Response.Redirect("MainPage.aspx");
            
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

        private bool login()
        {
            AdminBusiness adminBusiness = new AdminBusiness();
            if (Session["adminmail"] == null || Session["adminpass"] == null)
                return false;
            if (adminBusiness.checkAdmin((string)Session["adminmail"], (string)Session["adminpass"]) == 0)
                return false;
            return true;
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
            TextMargin.Text = producto.margin.ToString();
            for (int x = 0; x < Categorybox.Items.Count; x++)
            {
                Categoria aux = categoriaBusiness.getFromName(Categorybox.Items[x].Text);
                if (categoriaBusiness.checkItemInCategory(aux.id, producto.code))
                    Categorybox.Items[x].Selected = true;
            }


        }
        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (TextName.Text != "" && TextDesc.Text != "" && FileImage.HasFile)
            {



                StockBusiness stockBusiness = new StockBusiness();
                Producto nuevo = new Producto();
                Marca marca = new Marca();
                nuevo.name = TextName.Text;
                nuevo.code = TextCode.Text;
                nuevo.desc = TextDesc.Text;
                marca = marcaBusiness.buscarnombre((string)BrandSelector.SelectedItem.Value);
                nuevo.marca = marca;
                nuevo.margin = int.Parse(TextMargin.Text);
                nuevo.urlimagen = save();
               // si el codigo de producto no esta en la bbdd se trata de una creacion y se genera un codigo y stock nuevo, sino se trata de una modificacion y se hace un update
                if (!productoBusiness.checkcode(nuevo.code))
                {
                   
                    productoBusiness.create(nuevo);
                    stockBusiness.createData(nuevo.code);
                }
                else
                {
                    productoBusiness.mod(nuevo);
                }




                productoBusiness.clearcategories(nuevo.code);
                for (int x = 0; x < Categorybox.Items.Count; x++)
                {
                    if (Categorybox.Items[x].Selected == true)
                    {
                        Categoria aux = new Categoria();
                        aux = categoriaBusiness.getFromName(Categorybox.Items[x].Text);
                        categoriaBusiness.assignCategories(aux.id, nuevo.code);

                    }
                }



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
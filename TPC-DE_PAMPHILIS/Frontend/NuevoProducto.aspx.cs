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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                marcas = marcaBusiness.listar();
                BrandSelector.DataSource = marcas;
                BrandSelector.DataBind();
                loadCat();
                generateCode();
            }
        }

        private void loadCat()
        {
            categorias = categoriaBusiness.listar();
            foreach(Categoria x in categorias)
            {
                ListItem aux = new ListItem(x.name,x.id.ToString());
                
                Categorybox.Items.Add(aux);
            
            }
            
        }
        
        private void generateCode()
        {
            TextCode.Text = productoBusiness.generateCode();
            TextCode.ReadOnly = true;

        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if(true)
            {

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
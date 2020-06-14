using Business;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class Marcas : System.Web.UI.Page
    {
        public MarcaBusiness marcaBusiness = new MarcaBusiness();
        public List<Marca> marcas;
        public Marca selected;
        public int action = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            action = 0;
            fillcards();
            if (isrenaming())
                action = 1;
            else if (isdelete())
                action = 2;
        }
        private void fillcards()
        {
            marcas = marcaBusiness.buscar(TextSearch.Text);
        }

        private bool isrenaming()
        {
            string code = (string)Request.QueryString["rnm"];
            if (code == null)
                return false;
            selected = marcaBusiness.buscarid(int.Parse(code));
            return true;


        }

        private bool isdelete()
        {
            string code = (string)Request.QueryString["del"];
            if (code == null)
                return false;
            selected = marcaBusiness.buscarid(int.Parse(code));
            return true;

        }

        protected void Confirmar_Click(object sender, EventArgs e)
        {
            if (TextRename.Text != "")
            {
                marcaBusiness.rename(selected.id, TextRename.Text);
                Response.Redirect("Marcas.aspx");
            }
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            ProductoBusiness productoBusiness = new ProductoBusiness();
            try
            {
                productoBusiness.deleteBrandProducts(selected.id);
                marcaBusiness.delete(selected.id);
                Response.Redirect("Marcas.aspx");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
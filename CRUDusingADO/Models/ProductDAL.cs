using System.Data.SqlClient;
using CRUDusingADO.Models;


namespace CRUDusingADO.Models
{
    public class ProductDAL
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public ProductDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }


        public IEnumerable<Cate> GetCate()
        {
            List<Cate> cates = new List<Cate>();
            string qry = "select * from category";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cate c = new Cate();
                    c.Cid = Convert.ToInt32(dr["cid"]);
                    c.Cname = dr["cname"].ToString();
                    cates.Add(c);
                }
            }
            con.Close();
            return cates;
        }



        public IEnumerable<Product> GetProducts()
        {
            List<Product> products= new List<Product>();
            string qry = "select p.*,c.cname from product1 p inner join category c on c.cid=p.cid where p.isActive=1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product pro = new Product();
                    pro.Id = Convert.ToInt32(dr["pid"]);
                    pro.Name = dr["pname"].ToString();
                   
                    pro.Price = Convert.ToInt32(dr["price"]);
                    pro.Company = dr["company"].ToString();
                    pro.ImageUrl = dr["imageurl"].ToString();
               
                    pro.IsActive = Convert.ToInt32(dr["IsActive"]);
                    pro.Cname = dr["cname"].ToString();
                    products.Add(pro);
                }
            }
            con.Close();
            return products;
        }
        public Product GetProductById(int id)
        {
            Product pro = new Product();
            string qry = "select p.*,c.cname from product1 p inner join category c on c.cid=p.cid where p.pid=@id and p.isActive=1";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                   
                    pro.Id = Convert.ToInt32(dr["pid"]);
                    pro.Name = dr["pname"].ToString();

                    pro.Price = Convert.ToInt32(dr["price"]);
                    pro.Company = dr["company"].ToString();
                    pro.ImageUrl = dr["imageurl"].ToString();

                    pro.IsActive = Convert.ToInt32(dr["IsActive"]);
                    pro.Cid = Convert.ToInt32(dr["cid"]);
                    pro.Cname = dr["cname"].ToString();



                }
            }
            con.Close();
            return pro;
        }


        public int AddProduct(Product pro)
        {
            pro.IsActive = 1;
            int result = 0;
            string qry = "insert into product1 values(@name,@price,@company,@cid,@imageurl, @isActive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", pro.Name);
            cmd.Parameters.AddWithValue("@price", pro.Price);
            cmd.Parameters.AddWithValue("@company", pro.Company);
            cmd.Parameters.AddWithValue("@cid", pro.Cid);
            cmd.Parameters.AddWithValue("@imageurl", pro.ImageUrl);
            cmd.Parameters.AddWithValue("@isActive", pro.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateProduct(Product pro)
        {
            pro.IsActive = 1;
            int result = 0;
            string qry = "update product1 set name=@name,price=@price,company=@company,cid=@cid,imageurl=@imageurl where pid=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", pro.Name);
            cmd.Parameters.AddWithValue("@price", pro.Price);
            cmd.Parameters.AddWithValue("@company", pro.Company);
            cmd.Parameters.AddWithValue("@cid", pro.Cid);
            cmd.Parameters.AddWithValue("@imageurl", pro.ImageUrl);
            cmd.Parameters.AddWithValue("@id", pro.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        // soft delete 
        public int DeleteProduct(int id)
        {
            int result = 0;
            string qry = "update product1 set isActive=0 where pid=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}

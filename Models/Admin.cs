
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace HiTech.Models
{
    public class Admin
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLExpress;Database=hi-tech;User Id=sa;pwd=336633");
        public string name { get; set; }
        public string position { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string product_name { get; set; }
        public int user_id { get; set; }
        public string brand { get; set; }
        public string color { get; set; }
        public string price { get; set; }
        public string condition { get; set; }
        public string description { get; set; }
        public string starting_bid { get; set; }
        public string ProductImage { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public string b_name { get; set; }
        public string b_description { get; set; }
        public string b_title { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string report { get; set; }
        public string cart { get; set; }
        public string pkg_desc { get; set; }
        public int num_product { get; set; }
        public string p_date { get; set; }
        public int num_bid { get; set; }
        public string PType { get; set; }
        public string teamImage { get; set; }
        public string sub_title { get;set; }
        public string blogImg { get;set; }
        public DataSet login(string email, string password)
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[AdminLogin] where email='" + email + "' and password='" + password + "'", con);
            con.Open();
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public DataSet user()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[Register]", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public int delete(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[Register] where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public DataSet select_data(int id)
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[Register] where id='" + id + "'", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public int update(string name, string email, string password, int id)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[Register] set name='" + name + "',email='" + email + "',password='" + password + "' where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public int insert(string name, string email, string password, string status)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[Register] (name,email,password,status,report)values('" + name + "','" + email + "','" + password + "','" + status + "','" + false + "')", con);
            con.Open();
            return cmd.ExecuteNonQuery();

        }
        public int productInsert(string name, int id, string brand, string color, string conditin, string des, string bid, string price, string pType, string image)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[Table_1] (product_name,user_id,brand,color,condition,description,starting_bid,price,status,report,auctionLive,pType,p_image)values('" + name + "','" + id + "','" + brand + "','" + color + "','" + conditin + "','" + des + "','" + bid + "','" + price + "','" + false + "','" + "False" + "','" +
                "true" + "','" + pType + "','" + image + "')", con);
            con.Open();
            return cmd.ExecuteNonQuery();

        }
        public int SubscritpionInsert(string desc, int prodcut, string price, string p_date, string status,string sub_title,int num_bid)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[PackageMaster] (pkg_desc,num_product,price,p_date,status,sub_title,num_bid)values('" + desc + "','" + prodcut + "','" + price + "','" + p_date + "','" + status + "','"+sub_title+"','"+num_bid+"')", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public DataSet allSubscription()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[PackageMaster]", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public DataSet allproduct()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[Table_1]", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public DataSet allEnableProduct()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[Table_1] where status = '" + "True" + "'", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public DataSet allDisabledProduct()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[Table_1] where status = '" + "false" + "'", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public DataSet liveAuction()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[Table_1] where auctionLive = '" + "True" + "'", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public DataSet DeadAuction()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[Table_1] where auctionLive = '" + "false" + "'", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public DataSet totalWinner()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[SubmitBid1] where winner = '" + "True" + "'", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public DataSet allproduct_status(int id)
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[Table_1] where id='" + id + "'", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public DataSet select_Product(int id)
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[Table_1] where id='" + id + "'", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public int updateproduct(string name, string brand, string color, string conditin, string des, string bid, string price, int pid)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[Table_1] set product_name='" + name + "',brand='" + brand + "',color='" + color + "',condition='" + conditin + "',description='" + des + "',starting_bid='" + bid + "',price='" + price + "' where id='" + pid + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public int deleteproduct(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[Table_1] where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public DataSet contact_data(int id)
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[ContactUs]", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public DataSet allTeam()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[AboutUs]", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public int teamInsert(string name, string position, string des,string image)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[AboutUs] (name,position,description,image) values('" + name + "','" + position + "','" + des + "','"+image+"')", con);
            con.Open();
            return cmd.ExecuteNonQuery();

        }
        public DataSet select_Team(int id)
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[AboutUs] where id='" + id + "'", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public int deleteTeam(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[AboutUs] where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public int updateTeam(string name, string position, string description, int id)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[AboutUs] set name='" + name + "',position='" + position + "',description='" + description + "' where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public DataSet allblog()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[Blog]", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public DataSet select_status(int id)
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[Blog] where id='" + id + "'", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public int bloginsert(string title, string description, string name, string date,string img)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[Blog] (b_title,b_description,b_name,b_date,img) values('" + title + "','" + description + "','" + name + "','" + date + "','"+img+"')", con);
            con.Open();
            return cmd.ExecuteNonQuery();

        }
        public int deleteBlog(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[Blog] where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public DataSet select_Blog(int id)
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[Blog] where id='" + id + "'", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public int updateBlog(string title, string description, string name, string date, int id)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[Blog] set b_title='" + title + "',b_description='" + description + "',b_name='" + name + "',b_date='" + date + "' where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public int update_false(string status, int id)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[Register] set status='" + status + "' where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public int update_Ban(string status, int id)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[Register] set report='" + status + "' where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public int update_Pfalse(string status, int id)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[Table_1] set status='" + status + "' where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public DataSet admin()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[AdminLogin]", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public DataSet select_Admin(int id)
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[AdminLogin] where id='" + id + "'", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public int updateAdmin(string email, string password, int id)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[AdminLogin] set email='" + email + "',password='" + password + "' where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public int Reply(int user_id, string message)
        {
            SqlCommand cmd = new SqlCommand("insert into [dbo].[Reply] (user_id,message) values('" + user_id + "','" + message + "')", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public int update_product(string status, int id)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[Table_1] set status='" + status + "' where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public DataSet select_contact(int id)
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[ContactUs] where id='" + id + "'", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public int update_Ban_product(string status, int id)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[Table_1] set report='" + status + "' where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public int addtocart(string status, int id)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[Table_1] set cart='" + status + "' where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public DataSet SelectBidder()
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[SubmitBid1] ", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public DataSet Subscription(int id)
        {
            SqlCommand sqlCommand = new SqlCommand("select * from [dbo].[PackageMaster] where id='" + id + "'", con);
            SqlDataAdapter dn = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            dn.Fill(ds);
            return ds;
        }
        public int updateSubscription(string pkg_desc,int num_product,string price,string p_date,string title,int num_bid,int id)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[PackageMaster] set pkg_desc='" + pkg_desc + "',num_product='" + num_product + "',price='"+ price + "',p_date='"+ p_date + "',sub_title='"+title+"',num_bid='"+num_bid+"' where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public int deleteSubscription(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from [dbo].[PackageMaster] where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
        public int update_Subscription(string status, int id)
        {
            SqlCommand cmd = new SqlCommand("update [dbo].[PackageMaster] set status='" + status + "' where id='" + id + "'", con);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
       
    }
}
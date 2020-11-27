using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompShop.Models;
using CompShop.DAO;
using System.Data.SqlClient;


namespace CompShop.DAO.DAOclasses
{
    public class GoodsDAO : DAO

    {
        public List<Goods> GetAllGoods()
        {
            Connect();
            List<Goods> goodsList = new List<Goods>();

            try
            {
                SqlCommand command = new SqlCommand(@"SELECT *
               FROM [Goods] ", Connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Goods goods = new Goods();
                    goods.GoodsID = Convert.ToInt32(reader["GoodsID"]);
                    goods.Category =
                   Convert.ToInt32(reader["Category"]);
                    goods.Price =
                   Convert.ToDouble(reader["Price"]);
                    goods.Name =
                   Convert.ToString(reader["Name"]);
                    goods.Quantity =
                   Convert.ToInt32(reader["Quantity"]);
                    goods.ProvidedBy =
                Convert.ToInt32(reader["ProvidedBy"]);
                    goodsList.Add(goods);
                }
                reader.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                Disconnect();
            }
            return goodsList;
        }


        public void AddNew(Goods goods)
        {
            CSEntities3 db = new CSEntities3();

         
            db.Goods.Add(goods);
            db.SaveChanges();

        }


        public bool DeleteGoods(int id)
        {
            Boolean result = true;
            Connect();
            try
            {
                String delStr = @"delete from [Goods] where Id = @GoodsID";
                SqlCommand deleteCommand = new SqlCommand(delStr, Connection);
                deleteCommand.Parameters.AddWithValue("@GoodsID", id);
                deleteCommand.ExecuteNonQuery();
            }
            catch
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }

        public Goods ShowGoods(int GoodsID)
        {
            Goods good = new Goods();
            Connect();
            String selectString = @"select * from [Goods] where GoodsID = @GoodsID";
            SqlCommand selectCMD = new SqlCommand(selectString, Connection);
            selectCMD.Parameters.AddWithValue("@GoodsID", GoodsID);
            SqlDataReader reader = selectCMD.ExecuteReader();
            reader.Read();
            good.GoodsID = Convert.ToInt32(reader["GoodsID"]);
            good.Category = Convert.ToInt32(reader["Category"]);
            good.Price = Convert.ToDouble(reader["Price"]);
            good.Name = reader["Name"].ToString();
            good.Quantity = Convert.ToInt32(reader["Quantity"]);
            good.ProvidedBy = Convert.ToInt32(reader["ProvidedBy"]);
            reader.Close();
            return good;
        }



        public bool EditGoods(Goods goods)
        {
            bool result = true;
            Connect();
            try
            {
                string edit = @"update [Goods] set Category = @Category, Price = @Price,Name =@Name,Quantity = @Quantity,ProvidedBy= @ProvidedBy where GoodsID = @GoodsID";
                SqlCommand upEdit = new SqlCommand(edit, Connection);
                upEdit.Parameters.AddWithValue("@GoodsID", goods.GoodsID);
                upEdit.Parameters.AddWithValue("@Category", goods.Category);
                upEdit.Parameters.AddWithValue("@Price", goods.Price);
                upEdit.Parameters.AddWithValue("@Name", goods.Name);
                upEdit.Parameters.AddWithValue("@Quantity", goods.Quantity);
                upEdit.Parameters.AddWithValue("@ProvidedBy", goods.ProvidedBy);
                upEdit.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }


      



    }

   


}

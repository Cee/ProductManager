using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml;
using MySql.Data.MySqlClient;

namespace Lab_3
{
    public class Products
    {
        private List<Product> ret = new List<Product>();
        private MySqlConnection mysql = getMySqlCon();
            
        public Products()
        {
            
        }

        private static MySqlConnection getMySqlCon()
        {
            String mysqlStr = "Database=products;Data Source=127.0.0.1;User Id=root;Password=;pooling=false;CharSet=utf8;port=3306";
            MySqlConnection mysql = new MySqlConnection(mysqlStr);
            return mysql;
        }

        public static MySqlCommand getSqlCommand(String sql, MySqlConnection mysql)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mysql);
            return mySqlCommand;
        }

        public List<Product> GetProducts()
        {
            ret.Clear();

            mysql.Open();
            String sqlSearch = "select * from product";
            MySqlCommand mySqlCommand = getSqlCommand(sqlSearch, mysql);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Product p = new Product(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                        ret.Add(p);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fail!");
            }
            finally
            {
                reader.Close();
                mysql.Close();
            }

            return ret;
        }

        public void InsertProduct(string id, string name, string price)
        {
            mysql.Open();
            String sqlInsert = "insert into product values (" + id + ", " + name + ", " + price + ")";
            MySqlCommand mySqlCommand = getSqlCommand(sqlInsert, mysql);
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Fail!");
            }
            finally
            {
                mysql.Close();
            }
            ret = GetProducts();
        }
        public void DeleteProduct(string id)
        {
            mysql.Open();
            String sqlDelete = "delete from product where id='" + id + "'";
            MySqlCommand mySqlCommand = getSqlCommand(sqlDelete, mysql);
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Fail!");
            }
            finally
            {
                mysql.Close();
            }
            
            ret = GetProducts();
        }
        public void UpdateProduct(string id, string name, string price)
        {
            mysql.Open();
            String sqlUpdate = "update product set name='" + name + "' , price='" + price + "' where id='" + id + "'";
            MySqlCommand mySqlCommand = getSqlCommand(sqlUpdate, mysql);
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Fail!");
            }
            finally
            {
                mysql.Close();
            }

            ret = GetProducts();
        }
    }

    public class Product
    {
        public string id { get; set; }
        public string name { get; set; }
        public string price { get; set; }

        public Product(string id, string name, string price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
    }
}
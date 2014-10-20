using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml;

namespace Lab_3
{
    public class Products
    {
        private List<Product> ret = new List<Product>();
        private string xmlPath = HttpContext.Current.Server.MapPath("~/Products.xml");//相对路径
        //private string xmlPath = "C:/Users/Cee/Documents/Visual Studio 2013/Projects/Lab 3/Lab 3/Products.xml";
        private XmlDocument xml = new XmlDocument();
            
        public Products()
        {
            
        }

        public List<Product> GetProducts()
        {
            
            xml.Load(xmlPath);
            XmlNodeList items = xml.SelectNodes("/products/product");
            xml.Save(xmlPath);
            foreach (XmlNode item in items)
            {
                Product p = new Product(item.ChildNodes.Item(0).InnerText,
                                        item.ChildNodes.Item(1).InnerText,
                                        item.ChildNodes.Item(2).InnerText);
                ret.Add(p);
            }
            return ret;
        }

        public void InsertProduct(string id, string name, string price)
        {
            Product p = new Product(id, name, price);

            XmlElement idItem = xml.CreateElement("id");
            XmlElement nameItem = xml.CreateElement("name");
            XmlElement priceItem = xml.CreateElement("price");

            idItem.InnerText = id;
            nameItem.InnerText = name;
            priceItem.InnerText = price;

            XmlElement newItem = xml.CreateElement("product");
            newItem.AppendChild(idItem);
            newItem.AppendChild(nameItem);
            newItem.AppendChild(priceItem);

            xml.Load(xmlPath);
            xml.SelectNodes("/products").Item(0).AppendChild(newItem);
            xml.Save(xmlPath);

            ret.Clear();
            ret = GetProducts();
        }
        public void DeleteProduct(string id)
        {
            xml.Load(xmlPath);
            XmlNodeList items = xml.SelectNodes("/products/product");
            foreach (XmlNode item in items)
            {
                if (item.ChildNodes.Item(0).InnerText == id)
                {
                    //remove
                    xml.SelectNodes("/products").Item(0).RemoveChild(item);
                    break;
                }
            }
            xml.Save(xmlPath);
            ret.Clear();
            ret = GetProducts();
        }
        public void UpdateProduct(string id, string name, string price)
        {
            xml.Load(xmlPath);
            XmlNodeList items = xml.SelectNodes("/products/product");
            foreach (XmlNode item in items)
            {
                if (item.ChildNodes.Item(0).InnerText == id)
                {
                    //update
                    item.ChildNodes.Item(1).InnerText = name;
                    item.ChildNodes.Item(2).InnerText = price;
                    break;
                }
            }
            xml.Save(xmlPath);
            ret.Clear();
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
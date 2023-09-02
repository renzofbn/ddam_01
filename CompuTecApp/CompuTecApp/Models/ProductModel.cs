using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CompuTecApp.Models
{
    public class ProductModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public string Price { get; set;}
    }
}

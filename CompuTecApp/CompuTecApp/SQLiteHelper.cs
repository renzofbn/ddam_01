using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using CompuTecApp.Models;

namespace CompuTecApp
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection _database;
        public SQLiteHelper(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ProductModel>().Wait();
        }
        public Task<int> CreateProduct (ProductModel product)
        {
            return _database.InsertAsync(product);
        }
        public Task<List<ProductModel>> ReadProducts()
        {
            return _database.Table<ProductModel>().ToListAsync();
        }
        public Task<int> UpdateProduct(ProductModel product)
        {
            return _database.UpdateAsync(product);
        }
        public Task<int> DeleteProduct(ProductModel product)
        {
            return _database.DeleteAsync(product);
        }
        public Task<List<ProductModel>> SearchProducts(string name)
        {
            return _database.Table<ProductModel>().Where(i => i.Name.Contains(name)).ToListAsync();
        }
    }
}

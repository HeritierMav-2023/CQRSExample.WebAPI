using CQRSExample.Domain.Entities;
using CQRSExample.Domain.Interfaces;
using CQRSExample.Persistance.Context;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;

using Dapper;

namespace CQRSExample.Persistance.Repositories
{
    public class ProductRepository : IProductRepository
    {
        //1-propriéte connexion BD
        private  ConnectionString _config;

        //2- Constructeur DI
        #region Constructeur DI
        public ProductRepository(IOptions<ConnectionString> configuration)
        {
            _config = configuration.Value;
        }
        #endregion

        #region Methods
        public async Task<Product> CreateAsync(Product entity)
        {
            try
            {
                using var con = new SqlConnection(_config.DefaultConnection);

                var param = new DynamicParameters();
                string sQuery = "spGetProductsDetails";
                param.Add("@Action", "Post");
                param.Add("@ID", entity.Id);
                param.Add("@NAME", entity.Name);
                param.Add("@UNIT", entity.Unit);
                param.Add("@PRIX", entity.Prix);
                param.Add("@DateAdded", DateTime.Now);
                param.Add("@OnCreated", 1);
                param.Add("@DateModified", null);
                param.Add("@OnUpdated", 0);
                var result = await con.QueryAsync<Product>(sQuery, param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Product> DeleteAsync(Product entity)
        {
            try
            {
                using var con = new SqlConnection(_config.DefaultConnection);
                var param = new DynamicParameters();
                string Query = "spGetProductsDetails";
                param.Add("@Action", "Delete");
                param.Add("@ID", entity.Id);
                var result = await con.QueryAsync<Product>(Query, param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Product> EventOccured(Product entity, string evt)
        {
            throw new NotImplementedException();
           
          
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                using var con = new SqlConnection(_config.DefaultConnection);
                var param = new DynamicParameters();
                string Query = "spGetProductsDetails";
                param.Add("@Action", "GetAll");
                var result = await con.QueryAsync<Product>(Query, param, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Product> GetbyIdAsync(int id)
        {
            try
            {
                using var con = new SqlConnection(_config.DefaultConnection);
                var param = new DynamicParameters();
                string sQuery = "spGetProductsDetails";
                param.Add("@Action", "GetData");
                param.Add("@ID", id);
                var result = await con.QueryAsync<Product>(sQuery, param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            try
            {
                using var con = new SqlConnection(_config.DefaultConnection);

                var param = new DynamicParameters();
                string sQuery = "spGetProductsDetails";
                param.Add("@Action", "Put");
                param.Add("@ID", entity.Id);
                param.Add("@NAME", entity.Name);
                param.Add("@UNIT", entity.Unit);
                param.Add("@PRIX", entity.Prix);
                param.Add("@CREATEON", null);
                param.Add("@ONCREATED", 0);
                param.Add("@UPDATEON", DateTime.Now);
                param.Add("@ONUPDATED", 1);
                var result = await con.QueryAsync<Product>(sQuery, param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
        #endregion

    }
}

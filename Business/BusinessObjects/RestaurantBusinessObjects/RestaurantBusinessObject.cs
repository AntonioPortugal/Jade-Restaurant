using Microsoft.EntityFrameworkCore.Internal;
using RECODME.RD.Jade.Business.OperationResults;
using RECODME.RD.Jade.Data.RestaurantInfo;
using RECODME.RD.Jade.DataAccess.DataAccessObjects.RestaurantDataAccessObjects;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Transactions;

namespace RECODME.RD.Jade.Business.BusinessObjects.RestaurantBusinessObjects
{
    public class RestaurantBusinessObject
    {
        private RestaurantDataAccessObject _dao;

        public RestaurantBusinessObject()
        {
            _dao = new RestaurantDataAccessObject();

        }

        #region C

        public OperationResult Create (Restaurant item)
        {

            var exists = 

            try
            {
                _dao.Create(item);
                return new OperationResult() { Success = true };

            }
            catch(Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }
        public async Task<OperationResult> CreateAsync(Restaurant item)
        {
            try
            {
                await _dao.CreateAsync(item);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }

        #endregion

        #region R

        public OperationResult<Restaurant> Read(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)

                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.Read(id);
                transactionScope.Complete();
                return new OperationResult<Restaurant>() { Success = true, Result = result };

            }
            catch (Exception e)
            {
                return new OperationResult<Restaurant>() { Success = false, Exception = e };

            }


        }

        public async Task<OperationResult<Restaurant>> ReadAsync(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)

                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                await _dao.ReadAsync(id);
                transactionScope.Complete();
                return new OperationResult<Restaurant>() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult<Restaurant>() { Success = false, Exception = e };

            }

        }

        #endregion

        #region U

        public OperationResult Update(Restaurant item)
        {
            try
            {
                _dao.Update(item);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }
        public async Task<OperationResult> UpdateAsync(Restaurant item)
        {
            try
            {
                await _dao.UpdateAsync(item);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }

        #endregion

        #region D

        public OperationResult Delete(Restaurant item)
        {
            try
            {
                _dao.Delete(item);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }

        public async Task<OperationResult> DeleteAsync(Guid id)
        {
            try
            {
                await _dao.DeleteAsync(id);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }
        public OperationResult Delete(Guid id)
        {
            try
            {
                _dao.Delete(id);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }
        public async Task<OperationResult> DeleteAsync(Restaurant item)
        {
            try
            {
                await _dao.DeleteAsync(item);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }

        #endregion

        #region L

        public OperationResult<List<Restaurant>> List()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                _dao.List();
                transactionScope.Complete();

                return new OperationResult<List<Restaurant>>() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Restaurant>>() { Success = false, Exception = e };
            }

        }
        public async Task<OperationResult<List<Restaurant>>> ListAsync()
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };

                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                await _dao.ListAsync();
                transactionScope.Complete();

                return new OperationResult<List<Restaurant>>() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Restaurant>>() { Success = false, Exception = e };
            }
        }

        #endregion
    }
}
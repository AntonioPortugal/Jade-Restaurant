﻿

using RECODME.RD.Jade.Business.OperationResults;
using RECODME.RD.Jade.Data.MenuInfo;
using RECODME.RD.Jade.DataAccess.DataAccessObjects.MenuDataAccessObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace RECODME.RD.Jade.Business.BusinessObjects.MenuBusinessObjects
{
    public class MenuBusinessObject
    {
        private MenuDataAccessObject _dao;

        public MenuBusinessObject()
        {
            _dao = new MenuDataAccessObject();

        }

        #region C

        public OperationResult Create(Menu item)
        {
            try
            {
                _dao.Create(item);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }
        public async Task<OperationResult> CreateAsync(Menu item)
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

        public OperationResult<Menu> Read(Guid id)
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
                return new OperationResult<Menu>() { Success = true, Result = result };

            }
            catch (Exception e)
            {
                return new OperationResult<Menu>() { Success = false, Exception = e };

            }


        }

        public async Task<OperationResult<Menu>> ReadAsync(Guid id)
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
                return new OperationResult<Menu>() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult<Menu>() { Success = false, Exception = e };

            }

        }

        #endregion

        #region U

        public OperationResult Update(Menu item)
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
        public async Task<OperationResult> UpdateAsync(Menu item)
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

        public OperationResult Delete(Menu item)
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
        public async Task<OperationResult> DeleteAsync(Menu item)
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
        public OperationResult<List<Menu>> List()
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
                return new OperationResult<List<Menu>>() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult<List<Menu>>() { Success = false, Exception = e };

            }

        }
        public async Task<OperationResult<List<Menu>>> ListAsync()
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
                return new OperationResult<List<Menu>>() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult<List<Menu>>() { Success = false, Exception = e };

            }

        }

#endregion

    }

}

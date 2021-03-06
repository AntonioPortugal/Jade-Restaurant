﻿using RECODME.RD.Jade.Business.OperationResults;
using RECODME.RD.Jade.Data.RestaurantInfo;
using RECODME.RD.Jade.DataAccess.DataAccessObjects.RestaurantDataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace RECODME.RD.Jade.Business.BusinessObjects.RestaurantBusinessObjects
{
    public class TitleBusinessObject
    {
        private TitleDataAccessObject _dao;

        public TitleBusinessObject()
        {
            _dao = new TitleDataAccessObject();

        }

        #region C

        public OperationResult Create(Title item)
        {
            try
            {
                var itemHasSameName = _dao.List().Any(x => x.Name == item.Name && x.Position == item.Position);
                if (itemHasSameName)
                    return new OperationResult() { Success = false };
                _dao.Create(item);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }
        public async Task<OperationResult> CreateAsync(Title item)
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

        public OperationResult<Title> Read(Guid id)
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
                return new OperationResult<Title>() { Success = true, Result = result };

            }
            catch (Exception e)
            {
                return new OperationResult<Title>() { Success = false, Exception = e };

            }


        }

        public async Task<OperationResult<Title>> ReadAsync(Guid id)
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
                return new OperationResult<Title>() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult<Title>() { Success = false, Exception = e };

            }

        }

        #endregion

        #region U

        public OperationResult Update(Title item)
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
        public async Task<OperationResult> UpdateAsync(Title item)
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

        public OperationResult Delete(Title item)
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
        public async Task<OperationResult> DeleteAsync(Title item)
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

        public OperationResult<List<Title>> List()
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
                return new OperationResult<List<Title>>() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult<List<Title>>() { Success = false, Exception = e };

            }

        }
        public async Task<OperationResult<List<Title>>> ListAsync()
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
                return new OperationResult<List<Title>>() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult<List<Title>>() { Success = false, Exception = e };

            }

        }

        #endregion

    }

}

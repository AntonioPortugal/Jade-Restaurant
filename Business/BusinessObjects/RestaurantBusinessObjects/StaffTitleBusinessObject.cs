using RECODME.RD.Jade.Business.OperationResults;
using RECODME.RD.Jade.Data.RestaurantInfo;
using RECODME.RD.Jade.DataAccess.DataAccessObjects.RestaurantDataAccessObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace RECODME.RD.Jade.Business.BusinessObjects.RestaurantBusinessObjects
{
    public class StaffTitleBusinessObject
    {
        private StaffTitleDataAccessObject _dao;

        public StaffTitleBusinessObject()
        {
            _dao = new StaffTitleDataAccessObject();

        }

        #region C

        public OperationResult Create(StaffTitle item)
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
        public async Task<OperationResult> CreateAsync(StaffTitle item)
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

        public OperationResult<StaffTitle> Read(Guid id)
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
                return new OperationResult<StaffTitle>() { Success = true, Result = result };

            }
            catch (Exception e)
            {
                return new OperationResult<StaffTitle>() { Success = false, Exception = e };

            }


        }

        public async Task<OperationResult<StaffTitle>> ReadAsync(Guid id)
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
                return new OperationResult<StaffTitle>() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult<StaffTitle>() { Success = false, Exception = e };

            }

        }

        #endregion

        #region U

        public OperationResult Update(StaffTitle item)
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
        public async Task<OperationResult> UpdateAsync(StaffTitle item)
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

        public OperationResult Delete(StaffTitle item)
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
        public async Task<OperationResult> DeleteAsync(StaffTitle item)
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

        public OperationResult<List<StaffTitle>> List()
        {
            try
            {
                _dao.List();
                return new OperationResult<List<StaffTitle>>() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<StaffTitle>>() { Success = false, Exception = e };
            }

        }
        public async Task<OperationResult<List<StaffTitle>>> ListAsync()
        {
            try
            {
                await _dao.ListAsync();
                return new OperationResult<List<StaffTitle>>() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<StaffTitle>>() { Success = false, Exception = e };
            }
        }

        #endregion
    }

}
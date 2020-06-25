using Business.OperationResults;
using RECODME.RD.Jade.Data.RestaurantInfo;
using RECODME.RD.Jade.DataAccess.DataAccessObjects.RestaurantDataAccessObjects;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Business.BusinessObjects
{
    public class RestaurantBusinessObject
    {
        private RestaurantDataAccessObject _dao;

        public RestaurantBusinessObject()
        {
            _dao = new RestaurantDataAccessObject();

        }

        #region C

        public OperationResult Create (Restaurant restaurant)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)

                };
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                _dao.Create(restaurant);
                transactionScope.Complete();
                return new OperationResult() { Success = true };

            }
            catch(Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }
        //public async Task<OperationResult> CreateAsync(Restaurant restaurant)
        //{
        //    await _dao.CreateAsync(restaurant);

        //}

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

        #endregion

        #region U



        #endregion

        #region D



        #endregion

    }

}

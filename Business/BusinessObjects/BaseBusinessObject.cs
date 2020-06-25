using RECODME.RD.Jade.Business.OperationResults;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace RECODME.RD.Jade.Business.BusinessObjects
{
    public class BaseBusinessObject
    {

        private TransactionOptions transactionOptions = new TransactionOptions
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)

        };

        protected OperationResult ExecuteOpetation(Action operation)
        {
            try
            {
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                operation.Invoke();
                transactionScope.Complete();
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }

        protected async Task<OperationResult> ExecuteOperationAsync(Func<Task> operation)
        {
            try
            {
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                await operation.Invoke();
                transactionScope.Complete();
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };

            }

        }

        protected OperationResult<T> ExecuteOperation<T>(Func<T> operation)
        {
            try
            {
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = operation.Invoke();
                transactionScope.Complete();
                return new OperationResult<T>() { Success = true, Result = result };

            }
            catch (Exception e)
            {
                return new OperationResult<T>() { Success = false, Exception = e };

            }

        }

        protected async Task<OperationResult<T>> ExecuteOperationAsync<T>(Func<Task<T>> operation)
        {
            try
            {
                var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = await operation.Invoke();
                transactionScope.Complete();
                return new OperationResult<T>() { Success = true, Result = result};

            }
            catch (Exception e)
            {
                return new OperationResult<T>() { Success = false, Exception = e };

            }

        }

    }

}

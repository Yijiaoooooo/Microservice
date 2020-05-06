using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeekTime.Infrastructure.Core
{
    public class EFContext : DbContext, IUnitOfWork, ITransaction
    {
        protected IMediator _mediator;

        public EFContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        #region IUnitOfWork
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return true;
        }
        #endregion

        #region ITransaction
        private IDbContextTransaction _currentTransaction;

        public bool HasActiveTransaction => _currentTransaction != null;

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            throw new NotImplementedException();
        }

        

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

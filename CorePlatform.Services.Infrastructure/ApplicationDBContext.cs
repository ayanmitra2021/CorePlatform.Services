using CorePlatform.Services.Core.Abstraction;
using CorePlatform.Services.Core.Employee;
using CorePlatform.Services.UseCases.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CorePlatform.Services.Infrastructure
{
    public sealed class ApplicationDBContext : DbContext, IUnitOfWork
    {

        private static readonly JsonSerializerSettings JsonSerializerSettings = new()
        {
            TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All
        };

        private readonly IPublisher _publisher;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ApplicationDBContext() { }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public ApplicationDBContext(
            DbContextOptions opt,
            IPublisher publisher,
            IDateTimeProvider dateTimeProvider
        ) : base(opt)
        {
            _publisher = publisher;
            this._dateTimeProvider = dateTimeProvider;
        }

        public DbSet<Employee> Employee { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            try
            {

                //AddDomainEventsAsOutboxMessages();

                var result = await base.SaveChangesAsync(ct);

                /*await PublishDomainEventsAsync();*/

                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("Concurrency Exception occurred.", ex);
            }
        }


        //public void AddDomainEventsAsOutboxMessages()
        //{
        //    var domainEvents = ChangeTracker
        //       .Entries<IEntity>()
        //       .Select(entry => entry.Entity)
        //       .SelectMany(entity =>
        //       {
        //           var domEvs = entity.GetDomainEvents();
        //           entity.ClearDomainEvents();
        //           return domEvs;
        //       }).Select(domainEvent => new OutboxMessage(
        //        Guid.NewGuid(),
        //        _dateTimeProvider.UtcNow,
        //        domainEvent.GetType().Name,
        //        JsonConvert.SerializeObject(domainEvent, JsonSerializerSettings)
        //       )).ToList();


        //    AddRange(domainEvents);
        //}

        /* private async Task PublishDomainEventsAsync()
        {
            var domainEvents = ChangeTracker
                .Entries<IEntity>()
                .Select(entry => entry.Entity)
                .SelectMany(entity =>
                {
                    var domEvs = entity.GetDomainEvents();
                    entity.ClearDomainEvents();
                    return domEvs;
                })
                .ToList();

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent);
            }
        }*/
    }
}

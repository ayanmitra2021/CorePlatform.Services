using Ardalis.GuardClauses;
using CorePlatform.Services.Core.Rule;
using CorePlatform.Services.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePlatform.Services.Infrastructure.Repository
{
    public static class UnitOfWork
    {
        private static AppDbContext _dbContext;
        private static GenericRepository<RulesLibrary> _ruleRepository;
        private static GenericRepository<PlanAssociation> _planAssociationRepository;
        public static void Initialize(AppDbContext context)
        {
            if (_dbContext == null) _dbContext = context;
        }

        public static GenericRepository<RulesLibrary> RuleLibraryRepository
        {
            get
            {
                Guard.Against.Null<DbContext>(_dbContext);
                if (_ruleRepository == null) _ruleRepository = new GenericRepository<RulesLibrary>(_dbContext);
                return _ruleRepository;

            }
        }

        public static GenericRepository<PlanAssociation> PlanRepository
        {
            get
            {
                Guard.Against.Null<DbContext>(_dbContext);
                if (_planAssociationRepository == null) _planAssociationRepository = new GenericRepository<PlanAssociation>(_dbContext);
                return _planAssociationRepository;

            }
        }

        public async static Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}

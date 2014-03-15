using Schrader.Eve.Models;
using Schrader.Eve.Models.DbContexts;
using Schrader.Eve.Models.Repositories;
using Schrader.Eve.Models.Repositories.Interfaces;
using Schrader.Eve.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Schrader.Eve.Services
{
    public class MissionService : IMissionService
    {
        private bool _disposed;
        private IUnitOfWork<MissionDbContext> _uow;
        
        private IRepository<Mission, long> _missionRepo;
        private IRepository<MissionPilot, long> _pilotRepo;

        public MissionService()
        {
            _uow = new UnitOfWork<MissionDbContext>();
            _missionRepo = new Repository<Mission, long>(_uow.GetContext());
            _pilotRepo = new Repository<MissionPilot, long>(_uow.GetContext());
        }

        public MissionService(IUnitOfWork<MissionDbContext> uow, IRepository<Mission, long> missionRepo, IRepository<MissionPilot, long> pilotRepo)
        {
            _uow = uow;
            _missionRepo = missionRepo;
            _pilotRepo = pilotRepo;
        }

        public IEnumerable<Mission> GetMissions(Expression<Func<Mission, bool>> filter = null, Func<IQueryable<Mission>, IOrderedQueryable<Mission>> orderby = null)
        {
            return _missionRepo.GetFiltered(filter, orderby);
        }

        public Mission GetMission(long id)
        {
            return _missionRepo.GetById(id);
        }

        public MissionPilot GetPilot(long id)
        {
            return _pilotRepo.GetById(id);
        }

        #region IDisposable
        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _uow.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
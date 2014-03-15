using Schrader.Eve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Schrader.Eve.Services.Interfaces
{
    public interface IMissionService : IDisposable
    {
        IEnumerable<Mission> GetMissions(Expression<Func<Mission, bool>> filter = null, Func<IQueryable<Mission>, IOrderedQueryable<Mission>> orderby = null);
        Mission GetMission(long id);
        MissionPilot GetPilot(long id);
    }
}

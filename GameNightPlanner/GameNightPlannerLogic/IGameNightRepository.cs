using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNightPlannerLogic
{
    public interface IGameNightRepository
    {
        bool IsUserMemberOfGroup(int userId, int groupId);

        void Add(GameNight gameNight);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamPortal.Models
{
    public interface IStateRepository
    {
        List<State> GetStates();
    }
}

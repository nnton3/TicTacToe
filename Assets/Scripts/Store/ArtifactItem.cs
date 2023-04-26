using System;
using System.Collections.Generic;
using Assets.Scripts.PlayerResources;

namespace Assets.Scripts.Store
{
    [Serializable]
    public class ArtifactItem : ItemModel
    {
        public Dictionary<PlayerStat, int> stats;
    }
}

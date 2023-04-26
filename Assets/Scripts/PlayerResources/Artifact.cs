using System;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Assets.Scripts.PlayerResources
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PlayerStat { Damage };

    [Serializable]
    public class Artifact : PlayerResource
    {
        public Dictionary<PlayerStat, int> stats;
    }
}

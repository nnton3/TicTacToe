using UnityEngine;

namespace Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "LoadConfig", menuName = "Scenes/LoadConfig")]
    public class SceneLoadConfig : ScriptableObject
    {
        public string SceneName;
        public Sprite[] Backs;
        public string[] LoadTags;
    }
}

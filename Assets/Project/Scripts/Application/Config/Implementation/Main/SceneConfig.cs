using Project.Application.Config.Abstraction;
using UnityEngine;

namespace Project.Application.Config.Implementation
{
    [CreateAssetMenu(fileName = nameof(SceneConfig), menuName = "Project/Config/" + nameof(SceneConfig))]
    public class SceneConfig : ScriptableObject, ISceneConfig
    {
        [SerializeField] private string _metaSceneName;
        [SerializeField] private string _coreaSceneName;

        public string MetaSceneName => _metaSceneName;
        public string CoreSceneName => _coreaSceneName;
    }
}
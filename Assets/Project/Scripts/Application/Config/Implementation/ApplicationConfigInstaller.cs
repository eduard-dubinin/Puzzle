using Project.Utility;
using UnityEngine;
using Zenject;

namespace Project.Application.Config.Implementation
{
    public class ApplicationConfigInstaller : MonoInstaller
    {
        [SerializeField] private PictureConfig _pictureConfig;
        [SerializeField] private SceneConfig _sceneConfig;
        [SerializeField] private PuzzleConfig _puzzleConfig;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ConfigLoader>().AsSingle();
            
            Container.BindInterfacesInstance(_pictureConfig);
            Container.BindInterfacesInstance(_sceneConfig);
            Container.BindInterfacesInstance(_puzzleConfig);
        }
    }
}
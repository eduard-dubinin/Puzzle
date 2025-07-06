using System.Collections.Generic;
using Project.Application.Config.Abstraction;
using UnityEngine;

namespace Project.Application.Config.Implementation
{
    [CreateAssetMenu(fileName = nameof(PictureConfig), menuName = "Project/Config/" + nameof(PictureConfig))]
    public class PictureConfig : ScriptableObject, IPictureConfig
    {
        [SerializeField] private PictureDef[] _pictureDefs;
        
        public IReadOnlyList<IPictureDef> AllPictureDefs => _pictureDefs;
    }
}
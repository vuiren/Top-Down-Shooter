using System;
using Client.UnityComponents.Factory;
using Client.UnityComponents.MonoLinks;
using UnityEngine;

namespace Client.UnityComponents
{
    [Serializable]
    public class SceneData
    {
        public PrefabFactory PrefabFactory;
        public MonoEntity[] MonoEntities;
    }
}
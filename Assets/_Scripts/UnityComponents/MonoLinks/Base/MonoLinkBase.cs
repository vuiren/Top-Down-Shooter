using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public abstract class MonoLinkBase : MonoBehaviour
    {
        public abstract void Make(ref EcsEntity entity);
    }
}
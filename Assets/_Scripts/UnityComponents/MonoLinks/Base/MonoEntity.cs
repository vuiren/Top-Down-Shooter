using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public class MonoEntity : MonoLinkBase
    {
        public EcsEntity _entity;
        
        private MonoLinkBase[] _monoLinks;

        public MonoLink<T> Get<T>() where T: struct
        {
            foreach (MonoLinkBase link in _monoLinks)
            {
                if (link is MonoLink<T> monoLink)
                {
                    return monoLink;
                }
            }

            return null;
        }
        
        public override void Make(ref EcsEntity entity)
        {
            _entity = entity;
            
            _monoLinks = GetComponentsInChildren<MonoLinkBase>();
            foreach (MonoLinkBase monoLink in _monoLinks)
            {
                if (monoLink is MonoEntity)
                {
                    continue;
                }
                monoLink.Make(ref entity);
            }
        }
    }
}
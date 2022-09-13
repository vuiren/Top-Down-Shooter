using Client.Components;
using Client.UnityComponents.MonoLinks;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class DetectDamageSystem: IEcsRunSystem
    {
        private EcsFilter<OnCollisionEnterEvent, Health> _filter;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                var a = _filter.Get1(index);
                
                var monoEntity = a.Collision.gameObject.GetComponent<MonoEntity>();
                if(!monoEntity) continue;
                
                var damage = monoEntity.Get<Damage>();

                if (damage)
                {
                    entity.Get<TakeDamageEvent>() = new TakeDamageEvent()
                    {
                        DamageCount = damage.Value.Value
                    };
                }
            }    
        }
    }
}
using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

public class ControlSelectedUnit: IEcsRunSystem
{
    private EcsFilter<UnitFlag, SelectedFlag> _filter;
    public void Run()
    {
        foreach (var index in _filter)
        {
            ref var unit = ref _filter.GetEntity(index);
            var horizontal = Vector2.right * Input.GetAxis("Horizontal");
            var vertical = Vector2.up * Input.GetAxis("Vertical");

            unit.Get<Velocity>() = new Velocity()
            {
                Value = horizontal + vertical
            };
        }
    }
}
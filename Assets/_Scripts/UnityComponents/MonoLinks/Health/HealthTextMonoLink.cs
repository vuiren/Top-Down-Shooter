using Client.Components;
using Leopotam.Ecs;
using TMPro;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public class HealthTextMonoLink: MonoLink<HealthText>
    {
        [SerializeField] private TextMeshProUGUI text;

        public override void Make(ref EcsEntity entity)
        {
            entity.Get<HealthText>() = new HealthText()
            {
                Value = text
            };
        }
    }
}
using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class DamageBlinkSystem : IEcsRunSystem
    {
        private EcsFilter<DamageBlinkEffect, SpriteRendererLink> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                var effect = _filter.Get1(index);
                var sprite = _filter.Get2(index);

                if (effect.RemainingTime > 1.5)
                {
                    var a = 2 - effect.RemainingTime;
                    if (!Mathf.Approximately(a, 0))
                    {
                        a += 0.5f;
                    }

                    var color = Color.Lerp(Color.white, Color.red, a);

                    sprite.SpriteRenderer.color = color;
                }

                if (effect.RemainingTime is > 1f and < 1.5f)
                {
                    var a = 1.5f - effect.RemainingTime;
                    if (!Mathf.Approximately(a, 0))
                    {
                        a += 0.5f;
                    }

                    var color = Color.Lerp(Color.red, Color.white, a);

                    sprite.SpriteRenderer.color = color;
                }

                if (effect.RemainingTime is > 0.5f and < 1)
                {
                    var a = 1 - effect.RemainingTime;
                    if (!Mathf.Approximately(a, 0))
                    {
                        a += 0.5f;
                    }

                    var color = Color.Lerp(Color.white, Color.red, a);

                    sprite.SpriteRenderer.color = color;
                }

                if (effect.RemainingTime is > 0 and < 0.5f)
                {
                    var a = 0.5f - effect.RemainingTime;
                    if (!Mathf.Approximately(a, 0))
                    {
                        a += 0.5f;
                    }

                    var color = Color.Lerp(Color.red, Color.white, a);

                    sprite.SpriteRenderer.color = color;
                }
            }
        }
    }
}
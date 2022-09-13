using UnityEngine;

namespace Client.Components
{
    public struct OnCollisionEnterEvent
    {
        public GameObject Sender;
        public Collision2D Collision;
    }
}
using System;
using UnityEngine;

namespace Client.UnityComponents.Util
{
    public class KeepRotation : MonoBehaviour
    {
        private void LateUpdate()
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
}
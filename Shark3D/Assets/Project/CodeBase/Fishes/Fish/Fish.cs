using System;
using UnityEngine;

namespace Assets.Project.CodeBase.Fish
{
    public abstract class Fish : MonoBehaviour
    {
        public event Action<Fish> FishDied;
        
        private void Awake()
        {
        }

        public void Destroys()
        {
            FishDied?.Invoke(this);
            Destroy(gameObject);
        }
    }
}

using System;
using UnityEngine;

namespace PoolingSystem.Samples.Demo_01.Scripts.Runtime
{
    public interface ITarget
    {
        Transform GetTransform();
        void DoDamage(int damage);
        public bool RecentlyDamaged { get; set; }
    }
}
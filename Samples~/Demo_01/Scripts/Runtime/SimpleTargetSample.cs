using System;
using UnityEngine;

namespace PoolingSystem.Samples.Demo_01.Scripts.Runtime
{
    public class SimpleTargetSample : MonoBehaviour, ITarget
    {
        /// <summary>
        /// In case you need the position of the object to instantiate something, e.g. a visual effect
        /// </summary>
        public Transform GetTransform() => transform;
        
        /// <summary>
        /// Method to verify projectile damage. It can be complemented with a healing system
        /// </summary>
        public void DoDamage(int damage) => Debug.Log("Damage Confirmed " + "Object Pooling Sample");
        
        /// <summary>
        /// Useful in case you need it for some behaviour. 
        /// </summary>
        public bool RecentlyDamaged { get; set; }
    }
}
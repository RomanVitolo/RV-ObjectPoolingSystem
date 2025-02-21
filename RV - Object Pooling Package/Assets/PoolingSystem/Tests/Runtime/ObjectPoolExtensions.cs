using System.Collections.Generic;
using PoolingSystem.Runtime;
using UnityEngine;

namespace PoolingSystem.Tests.Runtime
{
    public static class ObjectPoolExtensions
    {
        public static int GetAvailableObjectsCount<T>(this ObjectPool<T> pool) where T : Component
        {
            return typeof(ObjectPool<T>)
                .GetField("objects", System.Reflection.BindingFlags.NonPublic
                                     | System.Reflection.BindingFlags.Instance)
                                        ?.GetValue(pool) is Queue<T> queue ? queue.Count : 0;
        }
    }
}
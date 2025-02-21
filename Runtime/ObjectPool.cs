using System.Collections.Generic;
using UnityEngine;

namespace PoolingSystem.Runtime
{
    public class ObjectPool<T> where T : Component
    {
        private readonly T componentType;
        private readonly Queue<T> objects = new Queue<T>();
        private readonly Transform parentTransform; 
        
        public ObjectPool(T componentType, int initialSize, Transform parent)
        {
            this.componentType = componentType;
            this.parentTransform = parent;

            for (int i = 0; i < initialSize; i++)
            {
                T newObject = Object.Instantiate(componentType, parent); 
                newObject.gameObject.SetActive(false);
                objects.Enqueue(newObject);
            }
        }
        
        public T Get()
        {
            if (objects.Count > 0)
            {
                T obj = objects.Dequeue();
                obj.gameObject.SetActive(true);
                obj.transform.SetParent(parentTransform); 
                return obj;
            }
            else
            {
                T newObject = Object.Instantiate(componentType, parentTransform);  
                return newObject;
            }
        }
       
        public void ReturnToPool(T obj)
        {
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(parentTransform);  
            objects.Enqueue(obj);
        }
    }
}
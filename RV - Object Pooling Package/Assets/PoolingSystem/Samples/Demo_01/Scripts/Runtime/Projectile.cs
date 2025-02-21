using UnityEngine;

namespace PoolingSystem.Samples.Demo_01.Scripts.Runtime
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private int _damage;
        
        private ProjectilePool _projectilePool;
        private void OnEnable() => _projectilePool ??= FindAnyObjectByType<ProjectilePool>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out ITarget target))
            {
                target.RecentlyDamaged = true;
                target.DoDamage(_damage);
                Debug.Log("Invoke event to some Action");
                _projectilePool.ReturnObject(this);
            }
            else
            {
                _projectilePool.ReturnObject(this);
            }
        }
    }
}
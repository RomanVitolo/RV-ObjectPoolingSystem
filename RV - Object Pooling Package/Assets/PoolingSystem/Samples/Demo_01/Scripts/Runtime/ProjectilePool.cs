using PoolingSystem.Runtime;

namespace PoolingSystem.Samples.Demo_01.Scripts.Runtime
{
    public class ProjectilePool : BaseObjectPool<Projectile>
    {
        protected override void Awake() => objectPool = 
            new ObjectPool<Projectile>(_objectType, _initialPoolSize, _objectParent);
        public override void ReturnObject(Projectile obj) => base.ReturnObject(obj);
    }
}
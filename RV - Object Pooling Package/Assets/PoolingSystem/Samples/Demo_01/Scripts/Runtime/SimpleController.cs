using UnityEngine;

namespace PoolingSystem.Samples.Demo_01.Scripts.Runtime
{
    public class SimpleController : MonoBehaviour
    {
        [SerializeField] private ProjectilePool _projectilePool;
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private  float _bulletSpeed = 20f;
        [SerializeField] private  float _moveSpeed = 10f;

        private float _horizontalInput;
        private Rigidbody _rb;
        private bool _isShooting;

        private void Awake() => _rb = GetComponent<Rigidbody>();

        private void Update()
        {
            _horizontalInput = Input.GetAxis("Horizontal") * _moveSpeed;
            _isShooting |= Input.GetKeyDown(KeyCode.Space);
        }

        private void FixedUpdate()
        {
            if(_isShooting) CreateBullet();

            Move();

            _isShooting = false;
        }

        public void CreateBullet()
        {
            Projectile newBullet = _projectilePool.GetObject();
            newBullet.transform.position = _bulletSpawnPoint.position;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.linearVelocity = _bulletSpawnPoint.forward * _bulletSpeed;
        }

        private void Move() =>
            _rb.MovePosition(transform.position + transform.right * (_horizontalInput * Time.fixedDeltaTime));
    }
}
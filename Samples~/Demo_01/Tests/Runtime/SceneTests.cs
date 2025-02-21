using System.Collections;
using NUnit.Framework;
using PoolingSystem.Samples.Demo_01.Scripts.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace PoolingSystem.Samples.Demo_01.Tests.Runtime
{
    public class SceneTests
    {
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            yield return SceneManager.LoadSceneAsync("TestScene", LoadSceneMode.Single);
        }
        
        [UnityTest]
        public IEnumerator SimpleController_SpawnsProjectile()
        {
            var simpleController = Object.FindAnyObjectByType<SimpleController>();
            Assert.IsNotNull(simpleController, "SimpleController not found in the scene.");
        
            var projectilePool = Object.FindAnyObjectByType<ProjectilePool>();
            Assert.IsNotNull(projectilePool, "ProjectilePool not found in the scene.");
        
            int initialProjectileCount = CountActiveProjectiles();
        
            simpleController.CreateBullet();
            
            yield return new WaitForSeconds(0.1f);
           
            int newProjectileCount = CountActiveProjectiles();
            Assert.AreEqual(initialProjectileCount + 1, newProjectileCount, "Projectile was not spawned.");
        }
        
        [UnityTest]
        public IEnumerator Projectile_HitsTarget()
        {
            var simpleController = Object.FindAnyObjectByType<SimpleController>();
            Assert.IsNotNull(simpleController, "SimpleController not found in the scene.");
        
            var target = Object.FindAnyObjectByType<SimpleTargetSample>();
            Assert.IsNotNull(target, "SimpleTargetSample not found in the scene.");
        
            simpleController.CreateBullet();
           
            yield return new WaitForSeconds(2f);
            
            Assert.IsTrue(target.RecentlyDamaged = true);
        }
        
        private int CountActiveProjectiles()
        {
            var projectiles = Object.FindObjectsByType<Projectile>(FindObjectsSortMode.None);
            int count = 0;
            foreach (var projectile in projectiles)
            {
                if (projectile.gameObject.activeInHierarchy)
                    count++;
            }
            return count;
        }
    }
}
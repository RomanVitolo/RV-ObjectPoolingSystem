using System.Collections;
using NUnit.Framework;
using PoolingSystem.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace PoolingSystem.Tests.Runtime
{
    public class ObjectPoolTests
    {
        private GameObject _testPrefab;
        private Transform _testParent;
        private ObjectPool<TestComponent> _objectPool;
    
        [UnitySetUp]
        public IEnumerator SetUp()
        {
            if (!IsSceneInBuildSettings("PoolingSceneTests"))
            {
                Assert.Fail("Scene 'PoolingSceneTests' is not in Build Settings. Please add it.");
            }

            SceneManager.LoadScene("PoolingSceneTests");
            yield return new WaitForSeconds(1f);
        
            _testPrefab = new GameObject("TestObject");
            _testPrefab.AddComponent<TestComponent>();
            _testParent = new GameObject("TestParent").transform;
            _objectPool = new ObjectPool<TestComponent>(_testPrefab.GetComponent<TestComponent>(),
                5, _testParent);
            yield return null;
        }
    
        [TearDown]
        public void TearDown()
        {
            Object.Destroy(_testPrefab);
            Object.Destroy(_testParent.gameObject);
        }

        [UnityTest]
        public IEnumerator Pool_Initializes_Correctly()
        {
            Assert.AreEqual(5, _objectPool.GetAvailableObjectsCount());
            yield return null;
        }

        [UnityTest]
        public IEnumerator GetObject_Returns_Active_Object()
        {
            TestComponent obj = _objectPool.Get();
            Assert.IsNotNull(obj);
            Assert.IsTrue(obj.gameObject.activeSelf);
            yield return null;
        }

        [UnityTest]
        public IEnumerator ReturnObject_Disables_And_Queues_Object()
        {
            TestComponent obj = _objectPool.Get();
            _objectPool.ReturnToPool(obj);
            Assert.IsFalse(obj.gameObject.activeSelf);
            Assert.AreEqual(5, _objectPool.GetAvailableObjectsCount());
            yield return null;
        }

        private bool IsSceneInBuildSettings(string sceneName)
        {
            return SceneUtility.GetBuildIndexByScenePath(sceneName) != -1;
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Pool;
using UnityObject = UnityEngine.Object;

namespace Slothsoft.UnityExtensions {
    public sealed class GameObjectPool : IDisposable {
        public event Action<GameObject> onInstantiate;

        readonly Transform parent;
        readonly GameObject prefab;
        public readonly int capacity;

        readonly IObjectPool<GameObject> pool;

        public GameObjectPool(Transform parent, int capacity) {
            Assert.IsTrue(parent);

            this.parent = parent;
            this.capacity = capacity;

            pool = new LinkedPool<GameObject>(
                 createFunc: CreateInstance,
                 actionOnGet: EnableInstance,
                 actionOnRelease: DisableInstance,
                 actionOnDestroy: DestroyInstance,
                 collectionCheck: false,
                 maxSize: capacity
             );
        }
        public GameObjectPool(Transform parent, GameObject prefab, int capacity) {
            Assert.IsTrue(parent);
            Assert.IsTrue(prefab);

            this.parent = parent;
            this.prefab = prefab;
            this.capacity = capacity;

            pool = new LinkedPool<GameObject>(
                 createFunc: InstantiateInstance,
                 actionOnGet: EnableInstance,
                 actionOnRelease: DisableInstance,
                 actionOnDestroy: DestroyInstance,
                 collectionCheck: false,
                 maxSize: capacity
             );
        }
        GameObject InstantiateInstance() {
            var obj = UnityObject.Instantiate(prefab, parent);
            onInstantiate?.Invoke(obj);
            return obj;
        }
        GameObject CreateInstance() {
            var obj = new GameObject();
            obj.transform.parent = parent;
            onInstantiate?.Invoke(obj);
            return obj;
        }
        void EnableInstance(GameObject instance) {
            instance.SetActive(true);
        }
        void DisableInstance(GameObject instance) {
            instance.SetActive(false);
        }
        void DestroyInstance(GameObject instance) {
            UnityObject.Destroy(instance);
        }

        public GameObject RequestInstance() {
            return pool.Get();
        }

        public void ReturnInstance(GameObject instance) {
            pool.Release(instance);
        }

        public void Dispose() {
            pool?.Clear();
        }
    }
}

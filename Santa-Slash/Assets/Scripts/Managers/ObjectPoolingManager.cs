using System;
using System.Collections;
using System.Collections.Generic;
using TranscendenceStudio.Character;
using TranscendenceStudio.VFX;
using UnityEngine;
using UnityEngine.Pool;

namespace TranscendenceStudio.Pooling
{
    public class ObjectPoolingManager : MonoBehaviour
    {
        [SerializeField] GameObject objectPrefab;
        private ObjectPool<GameObject> pool;

        private void Start()
        {
            pool = new ObjectPool<GameObject>(CreateObject, OnGetFromPool, OnReturnToPool, OnDestroyGameObject, false, 10, 40);
        }

        private GameObject CreateObject()
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.transform.SetParent(transform, false); // Configura o parent aqui

            if (obj.TryGetComponent(out VFXController vfxController))
            {
                vfxController.SetReleaseCallback(ReleaseObject);
            }

            if (obj.TryGetComponent(out ThrowableWeaponDamageCollider throwableWeaponDamageCollider))
            {
                throwableWeaponDamageCollider.SetReleaseCallback(ReleaseObject);
            }

            return obj;
        }

        private void OnGetFromPool(GameObject @object)
        {
            @object.SetActive(true);
        }

        private void OnReturnToPool(GameObject @object)
        {
            @object.SetActive(false);
        }

        private void OnDestroyGameObject(GameObject @object)
        {
            Destroy(@object);
        }

        public GameObject GetObject()
        {
            GameObject vfx = pool.Get();
            // Configurações adicionais do VFX, se necessário
            return vfx;
        }

        public void ReleaseObject(GameObject vfx)
        {
            pool.Release(vfx);
        }
    }
}

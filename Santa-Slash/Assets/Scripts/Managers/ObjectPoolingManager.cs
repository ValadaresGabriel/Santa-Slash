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
        [SerializeField] int spawnAmount;
        private ObjectPool<GameObject> pool;

        private void Start()
        {
            pool = new ObjectPool<GameObject>(() =>
            {
                GameObject obj = Instantiate(objectPrefab);
                obj.transform.SetParent(transform, false); // Configura o parent aqui
                obj.SetActive(false); // Inicialmente desativa

                if (obj.TryGetComponent(out VFXController vfxController))
                {
                    vfxController.SetReleaseCallback(ReleaseObject);
                }

                if (obj.TryGetComponent(out ThrowableWeaponController throwableWeaponController))
                {
                    throwableWeaponController.SetReleaseCallback(ReleaseObject);
                }

                return obj;
            }, vfx =>
            {
                vfx.SetActive(true);
            }, vfx =>
            {
                vfx.SetActive(false);
            }, vfx =>
            {
                Destroy(vfx);
            },
            false, 10, 20);

            PreSpawnObject();
        }

        private void PreSpawnObject()
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                GameObject vfx = pool.Get();

                vfx.SetActive(false);
            }
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

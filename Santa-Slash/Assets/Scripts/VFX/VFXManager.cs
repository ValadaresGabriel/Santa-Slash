using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace TranscendenceStudio.VFX
{
    public class VFXManager : MonoBehaviour
    {
        [SerializeField] GameObject vfxPrefab;
        [SerializeField] int spawnAmount;
        private ObjectPool<GameObject> pool;

        private void Start()
        {
            pool = new ObjectPool<GameObject>(() =>
            {
                GameObject obj = Instantiate(vfxPrefab);
                obj.transform.SetParent(transform, false); // Configura o parent aqui
                obj.SetActive(false); // Inicialmente desativa

                VFXController vfxController = obj.GetComponent<VFXController>();
                if (vfxController != null)
                {
                    vfxController.SetReleaseCallback(ReleaseVFX);
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

            PreSpawnVFX();
        }

        private void PreSpawnVFX()
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                GameObject vfx = pool.Get();
                // Configura o VFX conforme necessário aqui
                pool.Release(vfx); // Devolve imediatamente para o pool
            }
        }

        public GameObject GetVFX()
        {
            GameObject vfx = pool.Get();
            // Configurações adicionais do VFX, se necessário
            return vfx;
        }

        public void ReleaseVFX(GameObject vfx)
        {
            pool.Release(vfx);
        }
    }
}

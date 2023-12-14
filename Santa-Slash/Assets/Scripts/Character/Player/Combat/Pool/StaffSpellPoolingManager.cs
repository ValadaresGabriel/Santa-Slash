using TranscendenceStudio.Pooling;

namespace TranscendenceStudio.Character
{
    public class StaffSpellPoolingManager : ObjectPoolingManager
    {
        public static StaffSpellPoolingManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

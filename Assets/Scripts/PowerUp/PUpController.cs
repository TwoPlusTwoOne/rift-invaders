using Assets.Scripts.Spawn;
using UnityEngine;

namespace Assets.Scripts.PowerUp
{
    public class PUpController : MonoBehaviour {

        private static PUpController pUpController;
        [SerializeField] private float spawnTimer;
        [SerializeField] private GameObject[] popUps;


        public static PUpController GetController()
        {
            return pUpController;
        }

        void Awake()
        {
            if (pUpController == null)
                pUpController = this;
            else if (pUpController != this)
                Destroy(this);
        }

        void Update()
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer > 1)
            {
                spawnTimer = 0;
                SpawnController.GetController().Spawn(GridController.GetController().GetPUpGrid(), GetPopUp());
            }
        }

        private GameObject GetPopUp()
        {
            return popUps[Random.Range(0, popUps.Length)];
        }
    }

    
}
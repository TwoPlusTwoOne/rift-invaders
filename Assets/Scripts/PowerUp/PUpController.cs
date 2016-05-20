using Assets.Scripts.Spawn;
using UnityEngine;

namespace Assets.Scripts.PowerUp
{
    public class PUpController : MonoBehaviour {

        private static PUpController pUpController;
        [SerializeField] private float spawnTimer;
        [SerializeField] private float turretTimer;
        [SerializeField] private PowerUp[] popUps;
        [SerializeField] private PowerUp[] turretPUps;


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
            turretTimer += Time.deltaTime;
            spawnTimer += Time.deltaTime;
            if (spawnTimer > 10)
            {
                spawnTimer = 0;
                SpawnController.GetController().Spawn(GridController.GetController().GetPUpGrid(), GetPowerUp().gameObject);
            }

            if (turretTimer >= 20)
            {
                turretTimer = 0;
                Player.PlayerController.GetController().PUpObtained(GetTurretPowerUp().GetType());
            }

        }

        private PowerUp GetPowerUp()
        {
            return popUps[Random.Range(0, popUps.Length)];
        }

        private PowerUp GetTurretPowerUp()
        {
            return turretPUps[Random.Range(0, turretPUps.Length)];
        }
    }

    
}
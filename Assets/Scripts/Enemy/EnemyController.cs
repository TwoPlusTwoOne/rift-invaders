using Assets.Scripts.Controllers;
using Assets.Scripts.Spawn;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour
    {

        private static EnemyController enemyController;

        [SerializeField] private Enemy[] enemyShips;
        private float spawnTimer;

        public static EnemyController GetController()
        {
            return enemyController;
        }

        void Awake()
        {
            if (enemyController == null)
                enemyController = this;
            else if (enemyController != this)
                Destroy(this);
        }

        void Update()
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer > 1)
            {
                spawnTimer = 0;
                SpawnController.GetController().Spawn(GridController.GetController().GetSpawnGrid(), GetEnemyShip().gameObject);
            }
        }


        private Enemy GetEnemyShip()
        {
            return enemyShips[Random.Range(0, enemyShips.Length)];
        }

        internal void OnShipTriggerShield()
        {
            GameController.GetController().ReduceShield();
        }
    }
}

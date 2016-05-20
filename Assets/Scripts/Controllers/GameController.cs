using Assets.Scripts.Spawn;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {

        int score;
        int shield;

       /* [SerializeField]
        private GameObject bigShip;*/

/*
        private double spawnTimer = 0;
*/

        private static GameController gameController;

        public static GameController GetController()
        {
            return gameController;
        }

        void Start()
        {
            shield = 100;
        }

        void Update()
        {
           /* spawnTimer += Time.deltaTime;
            if (spawnTimer > 1)
            {
                spawnTimer = 0;
                SpawnController.GetController().Spawn(GridController.GetController().GetSpawnGrid(), bigShip);
            }*/
        }

        void Awake()
        {
            if (gameController == null)
                gameController = this;
            else if (gameController != this)
                Destroy(this);
        }


        public void ReduceShield()
        {
            shield -= 5;
        }

        public void Spawn(GridType grid, GameObject gameObject, Tuple<int, int> pos)
        {
            Grid g;
            g = GetGridByType(grid);
            SpawnController.GetController().Spawn(g, gameObject, pos);
        }

        public void Spawn(GridType grid, GameObject gameObject)
        {
            Grid g;
            g = GetGridByType(grid);
            SpawnController.GetController().Spawn(g, gameObject);
        }

        private Grid GetGridByType(GridType type)
        {
            switch (type)
            {
                case GridType.PUp:
                    return GridController.GetController().GetPUpGrid();
                case GridType.Shield:
                    return GridController.GetController().GetShieldGrid();
                case GridType.Spawn:
                    return GridController.GetController().GetSpawnGrid();
                default:
                    return null;
            }
        }
     

        private void EndGame()
        {
            // todo
        }

    }
}

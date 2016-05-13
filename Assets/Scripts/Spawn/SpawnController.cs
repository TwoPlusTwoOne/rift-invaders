using Assets.Scripts.Enemy;
using Assets.Scripts.Player;
using Assets.Scripts.PowerUp;
using UnityEngine;

namespace Assets.Scripts.Spawn
{
    public class SpawnController : MonoBehaviour
    {


        private static SpawnController spawnController;

        public static SpawnController GetController()
        {
            return spawnController;
        }

        void Awake()
        {
            if (spawnController == null)
                spawnController = this;
            else if (spawnController != this)
                Destroy(this);
        }

        public void Spawn(Grid g, GameObject gameObject)
        {
            Tile tile = g.GetTile(GetRandomCoordinates(g));
            GameObject instance = GameObject.Instantiate(gameObject, tile.transform.position, tile.transform.rotation) as GameObject;
            AssignParent(instance, g);
        }

        public void Spawn(Grid g, GameObject gameObject, Tuple<int, int> pos)
        {
        }

        public Tuple<int, int> GetRandomCoordinates(Grid g)
        {
            System.Random r = new System.Random();
            return new Tuple<int, int>(r.Next(g.Dim()), r.Next(g.Dim()));
        }

        private void AssignParent(GameObject gameObject, Grid g)
        {
            GridType gridType = g.GetGridType();
            switch (gridType)
            {
                case GridType.PUp:
                    gameObject.gameObject.transform.parent = PUpController.GetController().transform;
                    break;
                case GridType.Shield:
                    gameObject.gameObject.transform.parent = PlayerController.GetController().transform;
                    break;
                case GridType.Spawn:
                    gameObject.gameObject.transform.parent = EnemyController.GetController().transform;
                    break;
            }
        }

    }
}

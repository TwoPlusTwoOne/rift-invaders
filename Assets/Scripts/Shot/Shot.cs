using Assets.Scripts.Controllers;
using UnityEngine;

namespace Assets.Scripts.Shot
{
    public class Shot : MonoBehaviour
    {

        public int maxX;
        public int minX;
        public int maxY;
        public int minY;
        public int maxZ;

        private static float speed = 20;

        public GameObject target;

        private Vector3 direction;
        [SerializeField] private ShotSource source;
        [SerializeField] private ShotType type;

        void Update ()
        {
          /*  if (transform.position.x > maxX || transform.position.x < minX || transform.position.y > maxY || transform.position.y < minY
                || transform.position.z > maxZ)
                Destroy(this.gameObject);*/
            if (target != null)
            {
                direction = transform.position - target.transform.position;
                transform.Translate(Vector3.Normalize(direction)*Time.deltaTime*speed);
            }
            else
            {
                direction = new Vector3(direction.x, direction.y, direction.z - (Time.deltaTime*speed));
                transform.position = direction;
            }

        }

        void OnTriggerEnter (Collider c)
        {
            string currentTag = c.gameObject.tag;
            if(currentTag.Equals("PUpTile") || currentTag.Equals("SpawnTile")) return;
            switch (source)
            {
                    case ShotSource.Player:
                        if (currentTag.Equals("shield") || currentTag.Equals("Shot") || currentTag.Equals("Turret")) return;
                        if (currentTag.Equals("Enemy")) c.GetComponent<Enemy.Enemy>().ReduceLife();
                        Destroy(this.gameObject);
                        break;
                    case ShotSource.Turret:
                        if (currentTag.Equals("shield") || currentTag.Equals("Shot")) return;
                        Destroy(this.gameObject);
                        break;
                    case ShotSource.Enemy:
                        if (currentTag.Equals("Enemy") || currentTag.Equals("Shot") || currentTag.Equals("PUpTile")) return;
                        if(currentTag.Equals("ShieldTile")) GameController.GetController().ReduceShield();
                        else if(currentTag.Equals("Player")) GameController.GetController().ReduceShield();
                        Destroy(this.gameObject);
                        break;
                default:
                    break;
            }
            /*if ((c.gameObject.tag.Equals("EnemyShot") || (c.gameObject.tag.Equals("Enemy") || (c.gameObject.tag.Equals("EnemyShot")) || )
                return;
            else
                Destroy (this.gameObject);*/
        }

        public void SetTarget(GameObject target)
        {
            this.target = target;
        }

        public void SetDirection(Vector3 direction)
        {
            this.direction = direction;
        }

        public ShotSource GetSource()
        {
            return source;
        }
    }
}

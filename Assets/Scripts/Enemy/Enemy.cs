using Assets.Scripts.Controllers;
using UnityEngine;
using Assets.Scripts.Shot;
using Assets.Scripts.Spawn;

namespace Assets.Scripts.Enemy
{
    public class Enemy : MonoBehaviour {


        [SerializeField] private float speed;
        [SerializeField] private bool canShoot;
        [SerializeField] private int lifes;

        [SerializeField] private Transform shotSpawn;
        [SerializeField] private Shot.Shot shot;

        private float shootTime;

        void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
            if (canShoot)
            {
                shootTime += Time.deltaTime;
                if (shootTime > 1.5)
                {
                    Shoot();
                    shootTime = 0;
                }
            }
        }

        private void Shoot()
        {
            Shot.Shot currentShot = Instantiate(shot.gameObject).GetComponent<Shot.Shot>();
            currentShot.SetDirection(transform.position);
        }

        void OnTriggerEnter(Collider c)
        {
            if (c.gameObject.tag.Equals("ShieldTile"))
            {
                EnemyController.GetController().OnShipTriggerShield();
                Destroy(this.gameObject);
            }
        }

        public void ReduceLife()
        {
            lifes--;
            if (lifes == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

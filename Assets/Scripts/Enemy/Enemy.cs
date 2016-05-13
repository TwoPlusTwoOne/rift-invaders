using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Enemy : MonoBehaviour {


        [SerializeField] private float speed;
        [SerializeField] private bool canShoot;
        [SerializeField] private int lifes;

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
            
        }

        void OnTriggerEnter(Collider c)
        {
            if (c.gameObject.tag.Equals("ShieldTile"))
            {
                EnemyController.GetController().OnShipTriggerShield();
                Destroy(this.gameObject);
            }
        }
    }
}

using Assets.Scripts.Controllers;
using Assets.Scripts.Shot;
using UnityEngine;

namespace Assets.Scripts.PowerUp
{
    public class PowerUp : MonoBehaviour
    {

        [SerializeField] private PowerUpType type;

        void Update()
        {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }

        void OnTriggerEnter(Collider c)
        {
            Shot.Shot shot = c.GetComponent<Shot.Shot>();
            if (shot == null) return;
            string currentTag = c.gameObject.tag;
            if (currentTag.Equals("PUpTile") || currentTag.Equals("SpawnTile")) return;
            switch (shot.GetSource())
            {
                // todo
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
                    if (currentTag.Equals("ShieldTile")) GameController.GetController().ReduceShield();
                    else if (currentTag.Equals("Player")) GameController.GetController().ReduceLife();
                    Destroy(this.gameObject);
                    break;
                default:
                    break;
            }
        
        }

        public PowerUpType Type()
        {
            return type;
        }
    }
}

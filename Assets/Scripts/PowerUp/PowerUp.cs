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
            switch (shot.GetSource())
            {
                case ShotSource.Player:
                    Player.PlayerController.GetController().PUpObtained(type);
                    Destroy(this.gameObject);
                    break;
                case ShotSource.Turret:
                    return;
                case ShotSource.Enemy:
                    return;
                default:
                    break;
            }
        
        }

        internal PowerUpType GetType()
        {
            return type;

        }
    }
}

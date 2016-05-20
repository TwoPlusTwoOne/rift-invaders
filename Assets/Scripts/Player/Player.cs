using Assets.Scripts.Shot;
using Assets.Scripts.PowerUp;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Player : MonoBehaviour
    {


        [SerializeField]
        private float speed;
        [SerializeField]
        private FirstPersonController fpc;

        private ShotType shotType;
        private Turret turret;


        void Update()
        {
            if (Input.GetKey("turret"))
            {
                PlaceTurret();
            }
        }


        public void PowerUp(PowerUp.PowerUp pup)
        {
            if (pup.Type() == PowerUpType.BlazeShot)
            {
                shotType = ShotType.Blast;
            }
        }

        public void ReceiveTurrent(Turret turret)
        {
            this.turret = turret;
        }

        public void PlaceTurret()
        {
            if (turret == null)
                return;
            PlayerController.GetController().PlaceTurret(turret);
            turret = null;
        }
    }
}


using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {

        private Player player;

        private static PlayerController playerController;

        public static PlayerController GetController ()
        {
            return playerController;
        }

        void Awake ()
        {
            if (playerController == null)
                playerController = this;
            else if (playerController != this)
                Destroy (this);
        }

        /*public void PlaceTurret (Turret turret)
	{
		RaycastHit hit;
		if (Physics.Raycast (player.transform.position, player.transform.forward, out hit)) {
			if (hit.collider.tag.Equals ("tile")) {
				//GameController.GetController ().Spawn (GridType.Shield, turret, (hit.collider.gameObject as Tile).GetPos ());
			}
		}
	}*/

        internal void PUpObtained(PowerUpType type)
        {
        }
        public void PlaceTurret(Turret turret)
        {
            RaycastHit hit;
            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit))
            {
                if (hit.collider.tag.Equals("tile"))
                {
                    //GameController.GetController ().Spawn (GridType.Shield, turret, (hit.collider.gameObject as Tile).GetPos ());
                }
            }
        }
    }
}

using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Tank : MonoBehaviour
    {

        [SerializeField]
        private float speed;

        void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
        }

        void OnTriggerEnter(Collider c)
        {
            if (c.gameObject.tag.Equals("ShieldTile"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}


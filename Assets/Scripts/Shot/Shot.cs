using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{

	public int maxX;
	public int minX;
	public int maxY;
	public int minY;
	public int maxZ;


	private static float speed;

	private GameObject target;

	private Vector3 direction;
	private ShotSource source;

	void Update ()
	{
		if (transform.position.x > maxX || transform.position.x < minX || transform.position.y > maxY || transform.position.y < minY
		    || transform.position.z > maxZ)
			Destroy(this.gameObject);
		if (target != null) {
			direction = target.transform.position - transform.position;
		}
		transform.Translate (Vector3.Normalize (direction) * Time.deltaTime * speed);
	}

	void OnTriggerEnter (Collider c)
	{
		if (c.gameObject.tag.Equals ("shield") && (source.Equals (ShotSource.Player) || source.Equals (ShotSource.Turret)))
			return;
		else
			Destroy (this.gameObject);
	}

}

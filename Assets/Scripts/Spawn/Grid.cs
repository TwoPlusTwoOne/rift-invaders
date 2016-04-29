using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{

	public GameObject cube;

	private Tile[,] tiles;
	[SerializeField]
	private int dimensions;
	[SerializeField]
	private int lateralSide;
	private GameObject tilePrefab;

	private static Grid shieldGrid;
	private static Grid powerUpGrid;
	private static Grid spawnGrid;

	void Start ()
	{
		Populate ();
	}

	public static Grid GetShieldGrid ()
	{
		return shieldGrid;
	}

	public static Grid GetPUpGrid ()
	{
		return powerUpGrid;
	}

	public static Grid GetSpawnGrid ()
	{
		return spawnGrid;
	}

	private void Populate ()
	{
		tiles = new Tile[dimensions,dimensions];
		for (int i = 0; i < dimensions; i++) {
			for (int j = 0; j < dimensions; j++) {
				GameObject currentTile = GameObject.Instantiate (cube, new Vector3 (i * (lateralSide / dimensions), j * (lateralSide / dimensions),0), Quaternion.identity) as GameObject;
				currentTile.gameObject.transform.parent = transform;
				currentTile.gameObject.transform.localScale = ((lateralSide / dimensions) * Vector3.one);
				tiles [i,j] = currentTile.GetComponent<Tile>();
			}
		}
	}
}

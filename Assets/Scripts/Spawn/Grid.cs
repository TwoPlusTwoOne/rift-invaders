using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{

    public GameObject cube;

    [SerializeField]
    private GridType gridType;
    private string tileTag;

    private Tile[,] tiles;
    [SerializeField]
    private int dimensions;
    [SerializeField]
    private int lateralSide;
    private GameObject tilePrefab;



    void Start()
    {
        Populate();
    }



    private void Populate()
    {
        switch (gridType)
        {
            case GridType.PUp:
                tileTag = "PUpTile";
                break;
            case GridType.Shield:
                tileTag = "ShieldTile";
                break;
            case GridType.Spawn:
                tileTag = "SpawnTile";
                break;
        }
        tiles = new Tile[dimensions, dimensions];
        for (int i = 0; i < dimensions; i++)
        {
            for (int j = 0; j < dimensions; j++)
            {
                GameObject currentTile = GameObject.Instantiate(cube, new Vector3(i * (lateralSide / dimensions), j * (lateralSide / dimensions), transform.position.z), Quaternion.identity) as GameObject;
                currentTile.gameObject.transform.parent = transform;
                currentTile.gameObject.transform.localScale = ((lateralSide / dimensions) * Vector3.one);
                currentTile.gameObject.transform.localScale = new Vector3(currentTile.gameObject.transform.localScale.x,
                    currentTile.gameObject.transform.localScale.y, 0.05f);
                currentTile.gameObject.tag = tileTag;
                AddTag(currentTile);
                tiles[i, j] = currentTile.GetComponent<Tile>();
            }
        }
    }

    public Tile GetTile(Tuple<int, int> t)
    {
        return tiles[t.Fst(), t.Snd()];
    }

    public int Dim()
    {
        return dimensions;
    }

    public GridType GetGridType()
    {
        return gridType;
    }

    private void AddTag(GameObject tile)
    {
        switch (gridType)
        {
            case GridType.PUp:
                gameObject.gameObject.tag = "PowerUpTile";
                break;
            case GridType.Shield:
                gameObject.gameObject.tag = "ShieldTile";
                break;
            case GridType.Spawn:
                gameObject.gameObject.tag = "SpawnTile";
                break;
        }
    }
}

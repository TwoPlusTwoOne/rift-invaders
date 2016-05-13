using UnityEngine;
using System.Collections;

public class GridController : MonoBehaviour
{
    [SerializeField]
    public Grid shieldGrid;

    [SerializeField]
    public Grid powerUpGrid;

    [SerializeField]
    public Grid spawnGrid;

    private static GridController gridController;

    public static GridController GetController()
    {
        return gridController;
    }

    void Awake()
    {
        if (gridController == null)
            gridController = this;
        else if (gridController != this)
            Destroy(this);
    }

    public Grid GetShieldGrid()
    {
        return shieldGrid;
    }

    public Grid GetPUpGrid()
    {
        return powerUpGrid;
    }

    public Grid GetSpawnGrid()
    {
        return spawnGrid;
    }
}

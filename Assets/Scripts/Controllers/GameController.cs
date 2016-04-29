using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

	int score;
	int shield;

	private static GameController gameController;

	public static GameController GetController ()
	{
		return gameController;
	}

	void Awake ()
	{
		if (gameController == null)
			gameController = this;
		else if (gameController != this)
			Destroy (this);
	}


	public void ReduceShield ()
	{
		shield -= 5;
	}

	public void Spawn (GridType grid, GameObject gameObject, Tuple<int,int> pos)
	{
		Grid g;
		g = GetGridByType (grid);
		SpawnController.GetController ().Spawn (g, gameObject, pos);
	}

	public void Spawn (GridType grid, GameObject gameObject)
	{
		Grid g;
		g = GetGridByType (grid);
		SpawnController.GetController ().Spawn (g, gameObject);
	}

	private Grid GetGridByType (GridType type)
	{
		switch (type) {
		case GridType.PUp:
			return Grid.GetPUpGrid ();
		case GridType.Shield:
			return Grid.GetShieldGrid ();
		case GridType.Spawn:
			return Grid.GetSpawnGrid ();
			defualt:
			return null;
		}
		return null;
	}
}

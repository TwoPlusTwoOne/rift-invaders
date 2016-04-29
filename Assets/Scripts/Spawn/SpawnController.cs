using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {


	private static SpawnController spawnController;

	public static SpawnController GetController() {
		return spawnController;
	}

	void Awake() 
	{
		if (spawnController == null)
			spawnController = this;
		else if (spawnController != this)
			Destroy (this);
	}

	public void Spawn(Grid g, GameObject gameObject)
	{
	}

	public void Spawn(Grid g, GameObject gameObject, Tuple<int,int> pos){
	}

}

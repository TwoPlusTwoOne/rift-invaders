using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{

	private Tuple<int,int> pos;

	public Tile (Tuple<int,int> pos)
	{
		this.pos = pos;
	}

	public Tile (int x, int y)
	{
		this.pos = new Tuple<int,int> (x, y);
	}

	public Tuple<int,int> GetPos ()
	{
		return pos;
	}
}

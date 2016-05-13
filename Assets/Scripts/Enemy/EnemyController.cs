using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    private static EnemyController enemyController;

    public static EnemyController GetController()
    {
        return enemyController;
    }

    void Awake()
    {
        if (enemyController == null)
            enemyController = this;
        else if (enemyController != this)
            Destroy(this);
    }
}

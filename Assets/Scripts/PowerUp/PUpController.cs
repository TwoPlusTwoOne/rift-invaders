using UnityEngine;
using System.Collections;

public class PUpController : MonoBehaviour {

    private static PUpController pUpController;

    public static PUpController GetController()
    {
        return pUpController;
    }

    void Awake()
    {
        if (pUpController == null)
            pUpController = this;
        else if (pUpController != this)
            Destroy(this);
    }
}
using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{


    [SerializeField]
    private GameObject crossHair;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private LineRenderer lr;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Start()
    {
        lr = gameObject.AddComponent<LineRenderer>();
        lr.SetWidth(0.04f, 0.04f);
        Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
        lr.material = whiteDiffuseMat;
    }


    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        Vector3 fwd = transform.forward;
        RaycastHit hit;
        var layerMask = 1 << 8;
        layerMask = ~layerMask;

        if (Physics.Raycast(transform.position, fwd, out hit, Mathf.Infinity, layerMask))
        {
            //Debug.Log("There is something in front of the object!");
            //Debug.Log(hit.collider.gameObject.name);
            DrawCursor(hit.point, hit.normal);
            lr.SetPosition(0, new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z));
            lr.SetPosition(1, crossHair.transform.position);
            //lr.SetPositions(new Vector3[] { transform.position, hit.point });
            lr.SetColors(Color.red, Color.red);
        }
        else {
            DrawCursor(fwd * 10000, new Vector3(0, 0, 0));
            lr.SetPosition(0, new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z));
            lr.SetPosition(1, crossHair.transform.position);
            lr.SetColors(Color.blue, Color.red);
        }
    }



    private void DrawCursor(Vector3 position, Vector3 normal)
    {
        //GameObject reticle = GameObject.Instantiate(crossHair, position - gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        //Debug.Log("Hit position: " + "x: " + position.x + "y: " + position.y + "z: " + position.z);
        //Debug.Log("GameObject position: " + "x: " + transform.position.x + "y: " + transform.position.y + "z: " + transform.position.z);
        //crossHair.transform.position = new Vector3(transform.forward.x, transform.forward.y, position.z);
        crossHair.transform.position = position - new Vector3(0, 0, 1f);
        crossHair.transform.rotation = gameObject.transform.rotation;
        //crossHair.transform.eulerAngles = normal;
    }
}

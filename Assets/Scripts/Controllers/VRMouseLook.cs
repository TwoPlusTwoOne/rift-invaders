using UnityEngine;
using System.Collections;

using UnityEngine;
using UnityEngine.VR;

public class VRMouseLook : MonoBehaviour
{

#if UNITY_EDITOR

    [SerializeField]
    private GameObject crossHair;

    private LineRenderer lr;

    public bool enableYaw = true;
    public bool autoRecenterPitch = true;
    public bool autoRecenterRoll = true;
    public KeyCode HorizontalAndVerticalKey = KeyCode.LeftAlt;
    public KeyCode RollKey = KeyCode.LeftControl;

    Transform vrCameraTransform;
    Transform rotationTransform;
    Transform forwardTransform;

    private float mouseX = 0;
    private float mouseY = 0;
    private float mouseZ = 0;

    void Start()
    {
        lr = gameObject.AddComponent<LineRenderer>();
        lr.useWorldSpace = true;
    }

    void Awake()
    {
        // get the vr camera so we can align our forward with it
        Camera vrCamera = gameObject.GetComponentInChildren<Camera>();
        vrCameraTransform = vrCamera.transform;

        // create a hierarchy to enable us to additionally rotate the vr camera
        rotationTransform = new GameObject("VR Mouse Look (Rotation)").GetComponent<Transform>();
        forwardTransform = new GameObject("VR Mouse Look (Forward)").GetComponent<Transform>();
        rotationTransform.SetParent(transform.parent, false);
        forwardTransform.SetParent(rotationTransform, false);
        transform.SetParent(forwardTransform, false);
    }

    void Update()
    {
        bool rolled = false;
        bool pitched = false;
        if (Input.GetKey(HorizontalAndVerticalKey))
        {
            pitched = true;
            if (enableYaw)
            {
                mouseX += Input.GetAxis("Mouse X") * 5;
                if (mouseX <= -180)
                {
                    mouseX += 360;
                }
                else if (mouseX > 180)
                {
                    mouseX -= 360;
                }
            }
            mouseY -= Input.GetAxis("Mouse Y") * 2.4f;
            mouseY = Mathf.Clamp(mouseY, -85, 85);
        }
        else if (Input.GetKey(RollKey))
        {
            rolled = true;
            mouseZ += Input.GetAxis("Mouse X") * 5;
            mouseZ = Mathf.Clamp(mouseZ, -85, 85);
        }
        if (!rolled && autoRecenterRoll)
        {
            // People don't usually leave their heads tilted to one side for long.
            mouseZ = Mathf.Lerp(mouseZ, 0, Time.deltaTime / (Time.deltaTime + 0.1f));
        }
        if (!pitched && autoRecenterPitch)
        {
            // People don't usually leave their heads tilted to one side for long.
            mouseY = Mathf.Lerp(mouseY, 0, Time.deltaTime / (Time.deltaTime + 0.1f));
        }

        forwardTransform.localRotation = Quaternion.Inverse(Quaternion.Euler(0.0f, vrCameraTransform.localRotation.eulerAngles.y, 0.0f));
        rotationTransform.localRotation = Quaternion.Euler(0, vrCameraTransform.localRotation.eulerAngles.y, 0.0f) * Quaternion.Euler(mouseY, mouseX, mouseZ);


        // Raycast for making cursor
        Vector3 fwd = transform.forward;
        RaycastHit hit;
        var layerMask = 1 << 8;
        layerMask = ~layerMask;

        if (Physics.Raycast(transform.position, fwd, out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("There is something in front of the object!");
            Debug.Log(hit.collider.gameObject.name);
            DrawCursor(hit.point, hit.normal);
            lr.SetPositions(new Vector3[] { transform.position, hit.point });
            lr.SetColors(Color.red, Color.red);
        }
        else {
            DrawCursor(fwd * 10000, new Vector3(0, 0, 0));
            lr.SetPositions(new Vector3[] { transform.position, fwd * 10000 });
            lr.SetColors(Color.blue, Color.red);
        }


        Debug.DrawLine(transform.position, fwd * 20, Color.red);

    }

    private void DrawCursor(Vector3 position, Vector3 normal)
    {
        //GameObject reticle = GameObject.Instantiate(crossHair, position - gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        Debug.Log("Hit position: " + "x: " + position.x + "y: " + position.y + "z: " + position.z);
        Debug.Log("GameObject position: " + "x: " + transform.position.x + "y: " + transform.position.y + "z: " + transform.position.z);
        //crossHair.transform.position = new Vector3(transform.forward.x, transform.forward.y, position.z);
        crossHair.transform.position = position - new Vector3(0, 0, 1f);
        crossHair.transform.rotation = gameObject.transform.rotation;
        //crossHair.transform.eulerAngles = normal;
    }


#endif
}

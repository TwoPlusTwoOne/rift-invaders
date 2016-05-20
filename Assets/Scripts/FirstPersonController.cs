using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{

    public class FirstPersonController : MonoBehaviour
    {

        [SerializeField]
        private float m_WalkSpeed;

        [SerializeField]
        private float tilt;

        private Quaternion originalXRotation;
        bool goingRight;
        bool goingLeft;
        bool goingUp;
        bool goingDown;

        

        private void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            transform.position = new Vector3(transform.position.x + horizontal * Time.deltaTime * m_WalkSpeed, transform.position.y,
                    transform.position.z);
            transform.position = new Vector3(transform.position.x,
                transform.position.y + vertical * Time.deltaTime * m_WalkSpeed, transform.position.z);

            /*if (horizontal > 0)
            {
                goingRight = true;
                goingLeft = false;
                TiltRight();
            }
            else if (horizontal < 0)
            {
                goingRight = false;
                goingLeft = true;
                TiltLeft();
            }
            else
            {
                goingRight = false;
                goingLeft = false;
                ResetHorizontalTilt();
            }
            if (vertical > 0)
            {
                goingUp = true;
                goingDown = false;
                TiltUp();
            }
            else if (vertical < 0)
            {
                goingUp = false;
                goingDown = true;
                TiltDown();
            }
            else
            {
                goingUp = false;
                goingDown = false;
                ResetVerticalTilt();
            }*/




            //m_MouseLook.UpdateCursorLock();
        }

        private void ResetHorizontalTilt()
        {
            gameObject.transform.Rotate(Vector3.forward * tilt);
        }

        private void TiltLeft()
        {
            gameObject.transform.Rotate(Vector3.forward * -tilt);
        }

        private void TiltRight()
        {
            gameObject.transform.Rotate(Vector3.forward * tilt);
        }
    }
}
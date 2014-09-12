using UnityEngine;
using System.Collections;


public class SmoothCamera2D : MonoBehaviour {

    public float dampTime = 0.15f;
    private Vector3 initialPosition;
    private Vector3 velocity = Vector3.zero;
    public bool follow = false;
    public Transform target;
    private float cameraSizeDefault = 18f;
    public float cameraSizeFocus = 8f;
    private bool isOn = false;

	void Start()
    {
        initialPosition = transform.position;
    }
    

	// Update is called once per frame
	void FixedUpdate () {

        if (target && follow)
        {
            //camera.orthographicSize = cameraSizeFocus;
            //Vector3 point = camera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.65f, 10f)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            isOn = true;

			if(target.transform.rigidbody2D.velocity.x > 70)
				camera.orthographicSize = cameraSizeFocus + 4;
			else
			{
				camera.orthographicSize = cameraSizeFocus + ((target.transform.rigidbody2D.velocity.x * 4) / 70);
			}
        }
        else
        {
            resetCamera();
        }
	}

    public void resetCamera()
    {
        if (isOn)
        {
            transform.position = Vector3.SmoothDamp(transform.position, initialPosition, ref velocity, dampTime);
            camera.orthographicSize = cameraSizeDefault;
           if(velocity.x + velocity.y == 0)
           {
               isOn = false;
           }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rig;
    private float speed = 4f;
    public new Transform camera = null;
    public GameObject arrowPrefab;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;
        float diagspeed = Mathf.Sqrt(2f * speed * speed) / 2f;

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.A))
            {
                //forward
                movement += transform.forward * diagspeed * Time.deltaTime;
                //left
                movement += Quaternion.Euler(0, -90, 0) * (transform.forward * diagspeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //forward
                movement += transform.forward * diagspeed * Time.deltaTime;
                //right
                movement += Quaternion.Euler(0, 90, 0) * (transform.forward * diagspeed * Time.deltaTime);
            }
            else
            {
                movement += transform.forward * speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A))
            {
                //backward
                movement += Quaternion.Euler(0, 180, 0) * transform.forward * diagspeed * Time.deltaTime;
                //left
                movement += Quaternion.Euler(0, -90, 0) * (transform.forward * diagspeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //backward
                movement += Quaternion.Euler(0, 180, 0) *transform.forward * diagspeed * Time.deltaTime;
                //right
                movement += Quaternion.Euler(0, 90, 0) * (transform.forward * diagspeed * Time.deltaTime);
            }
            else
            {
                movement += Quaternion.Euler(0, 180, 0) * transform.forward * speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movement += Quaternion.Euler(0, -90, 0) * (transform.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement += Quaternion.Euler(0, 90, 0) * (transform.forward * speed * Time.deltaTime);
        }

        rig.MovePosition(transform.position + movement);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, camera.eulerAngles.y, transform.eulerAngles.z);

        if(Input.GetMouseButtonDown(0))
        {

            GameObject arrow = Instantiate(arrowPrefab, transform.position + new Vector3(0, 0.5f, 0) + transform.forward, transform.rotation);
            Rigidbody arrowRig = arrow.GetComponent<Rigidbody>();
            arrow.transform.eulerAngles = new Vector3(transform.eulerAngles.x, camera.eulerAngles.y, transform.eulerAngles.z);
            arrowRig.velocity = transform.forward * 20f;
        }
    }

}

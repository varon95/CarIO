using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public new Camera camera;

    private void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        transform.LookAt(hit.point);
    }
}    

/*
    void Update()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = camera.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)camera.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, angle+49f, 0f));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(b.x - a.x, b.y - a.y) * Mathf.Rad2Deg;
    }
}

        /*
        public InputManager Im;
        public int rotationSpeed;
        // Start is called before the first frame update
        void Start()
        {      
             Im = GetComponent<InputManager>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime * Im.turretSteer, 0);
        }
    }
    */

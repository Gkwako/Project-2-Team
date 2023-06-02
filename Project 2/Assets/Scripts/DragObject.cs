using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public bool isDragging = false;
    private Vector3 offset;

    void Update()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    // Check if the touch hits the draggable object
                    //if (CheckIfObjectTouched(touchPosition))

                    if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        //Debug.Log(touchPosition);
                        isDragging = true;
                        offset = touchPosition - transform.position;
                    }
                    break;

                case TouchPhase.Moved:

                    // Only move the object if it's being dragged
                    if (isDragging)
                    {
                        transform.position = new Vector3(transform.position.x, touchPosition.y - offset.y, transform.position.z);
                    }
                    break;

                case TouchPhase.Ended:

                    isDragging = false;
                    break;
            }
        }
    }

    bool CheckIfObjectTouched(Vector3 touchPosition)
    {
        Collider2D collider = GetComponent<Collider2D>();
        return collider.bounds.Contains(touchPosition);
    }
}

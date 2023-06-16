using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public bool isDragging = false;
    private Vector3 offset;
    public float maxYPosition = 5f; // Maximum transform position on the y-axis
    public float followSpeed = 5f; // Speed at which the object follows the input

    public float followSpeedUp = 5f; // Speed at which the object follows the input when moving up
    public float followSpeedDown = 2f; // Speed at which the object follows the input when moving down

    public bool speedUp;
    public float speedUpTimer;
    public float speedBoostAmount;

    private GameObject selectedObject; // Reference to the selected object

    private void Update()
    {

        // Mouse Controls

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            selectedObject = null; // Reset the selected object when the mouse button is released
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            isDragging = true;


            // Check if the mouse hits the draggable object
            if ( /*CheckIfObjectClicked(mousePosition) && */ hit.collider != null && hit.collider.gameObject == gameObject)
            {
                offset = mousePosition - transform.position;
                selectedObject = gameObject; // Set the selected object to the current object
            }
        }

        // Only move the object if it's being dragged
        if (isDragging && selectedObject == gameObject)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float targetY = mousePosition.y - offset.y;
            float clampedY = Mathf.Clamp(targetY, -maxYPosition, maxYPosition);
            Vector3 targetPosition = new Vector3(transform.position.x, clampedY, transform.position.z);

            // Adjust the follow speed based on the direction of movement
            float currentFollowSpeed = targetY > transform.position.y ? followSpeedUp : followSpeedDown;

            transform.position = Vector3.Lerp(transform.position, targetPosition, currentFollowSpeed * Time.deltaTime);
        }
    

        bool CheckIfObjectClicked(Vector3 mousePosition)
        {
            Collider2D collider = GetComponent<Collider2D>();
            return collider.bounds.Contains(mousePosition);
        }
    
        // Touch Controls
        /*
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    // Check if the touch hits the draggable object
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
                        float targetY = touchPosition.y - offset.y;
                        float clampedY = Mathf.Clamp(targetY, -maxYPosition, maxYPosition);
                        Vector3 targetPosition = new Vector3(transform.position.x, clampedY, transform.position.z);

                        // Adjust the follow speed based on the direction of movement
                        float currentFollowSpeed = targetY > transform.position.y ? followSpeedUp : followSpeedDown;

                        transform.position = Vector3.Lerp(transform.position, targetPosition, currentFollowSpeed * Time.deltaTime);
                    }
                    break;

                case TouchPhase.Ended:

                    isDragging = false;
                    break;
            }

        } */

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            GameManager.instance.fastSpeedPlayer();
        }

    }

    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            GameManager.instance.fastSpeedPlayer();
        }

    }

}

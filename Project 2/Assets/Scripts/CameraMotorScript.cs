using UnityEngine;

public class CameraMotorScript : MonoBehaviour
{
    public Transform lookAt;
    public Transform lookAt2;
    public Transform lookAt3;
    public Transform currentPosition;
    public Camera cam;
    public PlayerMovement player;

    public float boundX = 0f;
    public float boundY = 0f;
    public float boundZ = 0f;

    public bool zoomOut;

    public Transform childObject;
    public Transform childObject2;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        lookAt = GameObject.Find("Player").transform;
        cam = Camera.main;
        SoundManager.PlaySound("BGsea");

        // Create the child object and attach SpriteRenderer
        //GameObject childGO = new GameObject("CameraChild");
        //childObject = childGO.transform;
        //childObject.parent = transform;
        //childObject.localPosition = Vector3.zero;
        //spriteRenderer = childGO.AddComponent<SpriteRenderer>();
    }

    public void LateUpdate()
    {
        Vector3 targetPosition = lookAt.position;

        // Adjust target position based on bounds
        targetPosition.x = Mathf.Clamp(targetPosition.x, lookAt.position.x - boundX, lookAt.position.x + boundX);
        targetPosition.z = Mathf.Clamp(targetPosition.z, lookAt.position.z - boundZ - 10, lookAt.position.z + boundZ - 10);

            targetPosition.y = Mathf.Clamp(targetPosition.y, lookAt.position.y - boundY, lookAt.position.y + boundY);
            Vector3 currentPosition = targetPosition;

            transform.position = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * 0.15f);


        //transform.position = targetPosition;


        // Update the sprite size to match the camera size
        float cameraHeight = 1f * cam.orthographicSize;
        float cameraWidth = cameraHeight * cam.aspect;

        // Adjust the child object's scale based on the camera size
        Vector3 childScale = new Vector3(cameraWidth, cameraHeight, 1f);
        childObject.localScale = childScale;
        childObject2.localScale = childScale;

        // Adjust the sprite size and position based on the child object's scale
        //spriteRenderer.drawMode = SpriteDrawMode.Sliced;
        //spriteRenderer.size = new Vector2(cameraWidth, cameraHeight);
        //spriteRenderer.transform.localPosition = Vector3.zero;
    }
}
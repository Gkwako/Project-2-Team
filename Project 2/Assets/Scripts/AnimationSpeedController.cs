using UnityEngine;

public class AnimationSpeedController : MonoBehaviour
{
    public float speedMultiplier = 1f; // Adjust this to change the animation speed
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Adjust the animation speed based on the speedMultiplier
        animator.speed = speedMultiplier;
    }
}
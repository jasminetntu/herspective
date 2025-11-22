using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private SpriteRenderer sr;
    private Vector2 movement;
    private Animator animator;
    public bool isActive = true;
    public float turnDelay = 1f;

    [Header("ControlLocks")]
    public bool onlyLeft = false;
    public bool onlyRight = false;

    [Header("Very cool settings part")]
    [SerializeField] GameObject settingsPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponentInChildren<SpriteRenderer>(); // sprite on child object
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsPanel.activeSelf)
            {
                CloseSettings();
            }
            else
            {
                OpenSettings();
            }
        }

        if (settingsPanel.activeSelf)
        {
            animator.SetBool("isWalking", false);
            return;
        }
        ;

        // Raw input (what the player is trying to do)
        float rawX = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right

        // Effective input (what they're actually allowed to do)
        float effectiveX = rawX;

        if (onlyLeft && effectiveX > 0)
            effectiveX = 0;
        if (onlyRight && effectiveX < 0)
            effectiveX = 0;

        // This is what physics will use
        movement = new Vector2(effectiveX, 0f).normalized;

        if (isActive)
        {
            // isMoving is based on allowed movement, NOT raw input
            bool isMoving = Mathf.Abs(effectiveX) > 0.01f;
            animator.SetBool("isWalking", isMoving);

            // Facing is based on raw input so you can still "turn in place"
            if (Mathf.Abs(rawX) > 0.01f)
            {
                sr.flipX = rawX < 0f;  // left if negative, right if positive
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 pos3D = rb.position;
        Vector3 move3D = new Vector3(movement.x, movement.y, 0f);

        if (isActive && !settingsPanel.activeSelf)
        {
            // Movement already respects onlyLeft / onlyRight
            rb.MovePosition(pos3D + move3D * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void TriggerTurn()
    {
        StartCoroutine(DisableMovementTemporarily(turnDelay));
    }

    void FlipHorizontally()
    {
        sr.flipX = !sr.flipX;
    }

    IEnumerator DisableMovementTemporarily(float delay)
    {
        isActive = false;
        FlipHorizontally();
        animator.SetBool("isWalking", false);

        yield return new WaitForSeconds(delay);
        FlipHorizontally();
        isActive = true;
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}

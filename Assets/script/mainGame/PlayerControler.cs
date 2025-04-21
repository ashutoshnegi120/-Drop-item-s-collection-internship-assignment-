using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputSystem inputActions;
    [SerializeField] private float movementValue;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private new Rigidbody2D rigidbody2D;
    [SerializeField] private GameObject masterNode;
    private bool preMove;
    private MasterNode script;

    /*---------------------------------UI-------------------------------------*/
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI healthUI;
    [SerializeField] private GameObject gameTime;
    [SerializeField] private GameObject gameOver;

    //-----------------------------------public var ------------------------------
    public int score = 0;

    //--------------------------------------audio---------------------------------
    [SerializeField] private AudioSource gameOverAudio;
    [SerializeField] private AudioSource bgAudio;
    private Animator animator;


    private void Awake()
    {
        gameTime.SetActive(true);
        gameOver.SetActive(false);
        script = masterNode.GetComponent<MasterNode>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        inputActions = new InputSystem();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Movement.performed += OnMovementHappened;
        inputActions.Player.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Player.Movement.performed -= OnMovementHappened;
        inputActions.Player.Movement.canceled -= OnMovementCancelled;

    }

    private void FixedUpdate()
    {
        scoreUI.text = string.Format(": " + score);
        healthUI.text = string.Format(": " + script.health);

        if (script.health <= 0)
        {
            bgAudio.Stop();
            gameOver.GetComponent<GameOver>().setVar(score);
            gameOver.SetActive(true);
            gameTime.SetActive(false);
            gameOverAudio.Play();
            Destroy(gameObject);
        }
        else
        {
            if (movementValue < 0)
            {
                animator.SetBool("isWalk", true);
                preMove = true;
            }
            else if (movementValue > 0)
            {
                animator.SetBool("isWalk", true);
                preMove = false;

            }
            else
            {
                animator.SetBool("isWalk", false);
            }
            gameObject.GetComponent<SpriteRenderer>().flipX = preMove;
            Vector2 velocity = new Vector2(movementValue, 0f) * movementSpeed;
            rigidbody2D.velocity = new Vector2(velocity.x, rigidbody2D.velocity.y);
        }
    }

    private void OnMovementHappened(InputAction.CallbackContext context)
    {
        movementValue = context.ReadValue<float>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext context)
    {
        movementValue = 0f;
    }

}

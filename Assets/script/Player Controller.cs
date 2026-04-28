using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    public float gravityModifier = 1f;
    public float jumpForce = 10f;
    public bool IsOnGround = true;

    //animação
    private Animator playerAnim;

    public bool gameOver = false;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }
    public void OnJump(InputValue Value)
    {

        if (Value.isPressed && IsOnGround)
        {
            playerRb.AddForce(
                Vector3.up * jumpForce, ForceMode.Impulse);

            IsOnGround = false;

            //animaçao
            playerAnim.SetTrigger("jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
        //Morte do Jogador
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }

    }
    private void FixedUpdate()
    {
        playerRb.AddForce(
            Vector3.down * (gravityModifier -1)
            * Physics.gravity.magnitude, ForceMode.Acceleration);
    }

}

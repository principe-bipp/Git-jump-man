using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;//Metodo Singleton
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private ParticleSystem explosionParticle;

    [SerializeField] private ParticleSystem particulaD;
    [SerializeField] private ParticleSystem particulaE;
    [SerializeField] private AudioSource music;

    //Audio
    private AudioSource playerAudio;

    private Rigidbody playerRb;

    public float gravityModifier = 1f;
    public float jumpForce = 10f;
    public bool IsOnGround = true;

    //animação
    private Animator playerAnim;

    public bool gameOver = false;

    private void Awake()
    {
        //Singleton
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }
    public void OnJump(InputValue Value)
    {

        if (Value.isPressed && IsOnGround)
        {
            playerAudio.PlayOneShot(playerAudio.clip, 1.0f);

            //parar as particulas de poeira
            particulaD.Stop();
            particulaE.Stop();

            playerRb.AddForce(
                Vector3.up * jumpForce, ForceMode.Impulse);


            IsOnGround = false;

            //animaçao
            playerAnim.SetTrigger("jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")&& !gameOver)
        {
            //ativar as particulas de poeira
            particulaD.Play();
            particulaE.Play();
            IsOnGround = true;
        }

  

        //Morte do Jogador
        if (collision.gameObject.CompareTag("Obstaculo"))
        {

            //parar as particulas de poeira
            particulaD.Stop();
            particulaE.Stop();
            music.Stop();
            gameOver = true;
            gameOverText.gameObject.SetActive(true);
            explosionParticle.Play();
            Destroy(collision.gameObject);
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

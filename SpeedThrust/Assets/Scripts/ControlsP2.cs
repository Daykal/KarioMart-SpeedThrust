using UnityEngine;

public class ControlsP2 : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private float forwardMoveSpeed = 180f;
    [SerializeField] private float backwardMoveSpeed = 100f;
    [SerializeField] private float steerSpeed = 40f;
    [SerializeField] private bool cp1 = false;
    [SerializeField] private bool cp2 = false;
    private Rigidbody2D _rb2D;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float tf = Mathf.Lerp(0, steerSpeed, _rb2D.velocity.magnitude / 10);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _rb2D.AddForce(transform.up * (forwardMoveSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _rb2D.AddForce(transform.up * (-backwardMoveSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb2D.AddTorque(tf * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb2D.AddTorque(-1 * tf * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CpTag1"))
        {
            Debug.Log("Trigger1");
            cp1 = true;
        }

        if (other.CompareTag("CpTag2"))
        {
            Debug.Log("triger2");
            cp2 = true;
        }

        if (other.CompareTag("Finish"))
        {
            if (cp1 == true && cp2 == true)
            {
                Debug.Log("YES");
                gameManager.currentLapP2++;
                gameManager.theLapText.text = ("LAP " + gameManager.currentLapP2.ToString() + "/3");
                cp1 = false;
                cp2 = false;
                if (gameManager.currentLapP2 == 4)
                {
                    gameManager.gameOverUI.SetActive(true);
                    Time.timeScale = 0f;
                }
            }

        }
        
    }
}

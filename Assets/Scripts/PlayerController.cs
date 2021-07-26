using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public Text countText;
    public Text healthText;
    public GameObject winTextObject;
    public GameObject gameOverTextObject;
    public GameObject resetButtonObject;
    public GameObject nextButtonObject;
    public GameObject[] pickUpObject;
    public GameObject eS;
    public EnemySpawner enemySpawner;
    public GameObject pS;
    public PickUpSpawner pickUpSpawner;
    
    public AudioClip hit;
    public AudioSource hitSound;
    public AudioClip pickUp;
    public AudioSource pickUpSound;
    public AudioClip gameOver;
    public AudioSource gameOverSound;
    public AudioClip nLevel;
    public AudioSource nLevelSound;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private int health;
    private int damage=10;
    private Vector3 initPos;
    
    void Start()
    {        
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        initPos = this.transform.position;
        nextLevel();
        enemySpawner = eS.GetComponent<EnemySpawner>();
        pickUpSpawner = pS.GetComponent<PickUpSpawner>();
    }

    void nextLevel()
	{
        count = GameObject.FindGameObjectsWithTag("PickUp").Length;
        health = 100;
        SetCountText();
        SetHealthText();
        this.transform.position = initPos;
        winTextObject.SetActive(false);
        gameOverTextObject.SetActive(false);
        nextButtonObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
	{
        // in this function, the computer will read the value
        // of the input
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
	}

    void SetCountText()
	{
        
        countText.text = count.ToString();
        if (count == 0)
		{
            nLevelSound.PlayOneShot(nLevel);
            winTextObject.SetActive(true);
            nextButtonObject.SetActive(true);
            Time.timeScale = 0;
        }
	}
    void SetHealthText()
	{

        healthText.text = health.ToString();
		if (health <= 0)
		{
            gameOverSound.PlayOneShot(gameOver);
            gameOverTextObject.SetActive(true);
            Time.timeScale = 0;
        }
	}

    public void NextButton()
	{
        pickUpSpawner.pickUps();
        damage += 1;
        enemySpawner.secondsBetweenSpawn -= 0.1f;
        nextLevel();
        Time.timeScale = 1;
    }

	void FixedUpdate()
	{
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement*speed);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickUp"))
		{
            pickUpSound.PlayOneShot(pickUp);
            other.gameObject.SetActive(false);
            count-=1;
            SetCountText();
		}
		if(other.gameObject.CompareTag("Enemy"))
		{
            hitSound.PlayOneShot(hit);
            other.gameObject.SetActive(false);
            health -= damage;
            SetHealthText();
		}
	}
}
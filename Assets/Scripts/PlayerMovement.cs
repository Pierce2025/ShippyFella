using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float thrust;
    public Rigidbody2D rb;
    public GameObject player;
    public float maxSpeed;
    private bool isGameActive;
    private TextMeshProUGUI timeText;
    public float timer;
    public GameObject levelCompleteText;
    public GameObject gameOverText;
    public int levelNumber;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGameActive = true;
        timeText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        levelNumber = 1;
    }
 

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        if (Input.GetKey(KeyCode.A) & isGameActive)
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) & isGameActive)
        {
            transform.Rotate(Vector3.forward * -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W) & isGameActive) 
        {
            rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime, ForceMode2D.Impulse);
        }
        Scene scene = SceneManager.GetActiveScene();
        if (isGameActive)
            timer = Time.timeSinceLevelLoad;
            timeText.text = timer.ToString("#.00");
        if (scene.name == "Level 1")
        {

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("border"))
        {
            levelNumber = 0;
            SceneManager.LoadScene(0);
            timer = 0.0f;
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            isGameActive = false;
            levelCompleteText.SetActive(true);
            SceneManager.LoadScene(levelNumber);
            levelNumber += 1;
        }
    }
}

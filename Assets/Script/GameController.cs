using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private int rightScore = 0;
    private int leftScore = 0;
    private bool started = false;

    public Starter starter;
    public Text scoreRightTXT;
    public Text scoreLeftTXT;

    public GameObject ball;
    private BallController ball_controller;

    private Vector3 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        this.ball_controller = this.ball.GetComponent<BallController>();
        this.startingPos = this.ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.started)
            return;
        
        if(Input.GetKey(KeyCode.Space)) {
            this.started = true;
            this.starter.StartCountdown();
        }
    }

    public void StartGame() {
        this.ball_controller.Go();
    }

    public void rightGoal() {
        Debug.Log("rightGoal");
        this.rightScore++;
        updateUI();
        resetBallPosition();
    }

    public void leftGoal() {
        Debug.Log("leftGoal");
        this.leftScore++;
        updateUI();
        resetBallPosition();
    }

    private void updateUI() {
        this.scoreRightTXT.text = this.rightScore.ToString();
        this.scoreLeftTXT.text = this.leftScore.ToString();
    }

    private void resetBallPosition() {
        this.ball_controller.Stop();
        this.ball.transform.position = this.startingPos;
        this.starter.StartCountdown();
    }
}

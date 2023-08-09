using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{

    private Animator animator;
    private GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<GameController>();
        animator = GetComponent<Animator>();
    }

    public void StartGame() {
        controller.StartGame();
    }

    public void StartCountdown() {
        animator.SetTrigger("StartCountdown");
    }


}

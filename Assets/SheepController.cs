﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    private State state;
    private float timer = 0.0f;

    private Vector3 target;
    private float wayPassed;
    public float speed;
    private float timeToReachTarget;
    private Animator animator;

    private MovementController movementController;

    public enum State
    {
        Walk,
        Eat
    }

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        movementController = GetComponent<MovementController>();
        SetStateEat(5.0f);
    }

    void Update()
    {
        TimerCount();
        Debug.Log(timer);

        switch (state)
        {
            case State.Walk:
                Debug.Log("Walk");
                Walk();
                break;

            case State.Eat:
                Debug.Log("Eat");
                Eat();
                break;
        }
    }

    private void Walk()
    {
        if (target == transform.position)
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isEat", true);
            SetStateEat(2.0f);
        }
        else
        {
            wayPassed += Time.deltaTime/timeToReachTarget;
            transform.position = Vector3.Lerp(transform.position, target, wayPassed);
        }
    }

    private void Eat()
    {
        animator.SetBool("isEat", true);
        if (timer < 0.1f)
        {
            animator.SetBool("isEat", false);
            animator.SetBool("isWalk", true);
        }

        if (timer <= 0.0f)
        {

            SetStateWalk();
        }
    }

    private void TimerCount()
    {

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void SetStateEat(float seconds)
    {
        state = State.Eat;
        timer = seconds;
    }

    private void SetStateWalk()
    {
        // выбираем направление
        Vector3 dir = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 0.0f);
        target = transform.position + dir;

        // прошли еще нисколько
        wayPassed = 0;
        timeToReachTarget = Vector3.Distance(target, transform.position)/speed;
        state = State.Walk;
        animator.SetBool("isWalk", true);
    }
}

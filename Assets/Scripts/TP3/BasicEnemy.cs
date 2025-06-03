using System;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    private GameManager GameManager;
    private Transform player;
    private float speed = 0.75f;
    
    
    
    
    
    void Start()
    {
        GameManager = FindAnyObjectByType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        transform.LookAt(player);
        Vector3 targetPos = player.position;
        targetPos.y = 0;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player")) GameManager.UIManager.ResultCanvasShow();
    }
}

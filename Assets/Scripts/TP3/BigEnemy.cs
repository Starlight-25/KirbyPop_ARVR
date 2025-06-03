using UnityEngine;
using UnityEngine.UI;

public class BigEnemy : MonoBehaviour
{
    private GameManager GameManager;
    private Transform player;
    private Transform Camera;
    private float speed = 0.5f;

    public Slider HPBar;
    public Transform Canvas;
    
    
    
    
    
    void Start()
    {
        GameManager = FindAnyObjectByType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Camera = player.parent;
    }


    void Update()
    {
        transform.LookAt(player);
        Canvas.LookAt(Camera);
        
        Vector3 targetPos = player.position;
        targetPos.y = 0;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player")) GameManager.UIManager.ResultCanvasShow();
    }
}

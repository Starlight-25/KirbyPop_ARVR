using UnityEngine;
using UnityEngine.InputSystem;

public class KillingCamTP3 : MonoBehaviour
{
    public GameObject ParticleEffect;
    private Vector2 touchPos;
    private RaycastHit hit;
    private Camera cam;
    
    public PlayerInput playerInput;
    private InputAction touchPressAction;
    private InputAction touchPosAction;

    public GameManager GameManager;
    public AudioManager AudioManager;
    void Start()
    {
        cam = GetComponent<Camera>();
        touchPressAction = playerInput.actions["TouchPress"];
        touchPosAction = playerInput.actions["TouchPos"];
    }
    
    void Update()
    {
        if (!touchPressAction.WasPerformedThisFrame())
        {
            return;
        }

        AudioManager.TriggerPopSound();
        Debug.Log("screen touched");
        touchPos = touchPosAction.ReadValue<Vector2>();
        Ray ray = cam.ScreenPointToRay(touchPos);
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObj = hit.collider.gameObject;
            Debug.Log($"Collided with object {hitObj.name} {hitObj.tag}");
            if (hitObj.CompareTag("Enemy"))
            {
                if (hitObj.GetComponent<BigEnemy>() != null)
                {
                    BigEnemy bigEnemy = hitObj.GetComponent<BigEnemy>();
                    bigEnemy.HPBar.value -= 1;
                    if (bigEnemy.HPBar.value <= 0) KillEnemy(hitObj);
                    
                }
                else KillEnemy(hitObj);
            }
        }
    }


    private void KillEnemy(GameObject Enemy)
    {
        var clone = Instantiate(ParticleEffect, Enemy.transform.position, Quaternion.identity);
        //clone.transform.localScale = Enemy.transform.localScale;
        Destroy(Enemy);
        GameManager.UpdateScore();
    }
}

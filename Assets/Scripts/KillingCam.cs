using UnityEngine;
using UnityEngine.InputSystem;

public class KillingCam : MonoBehaviour
{
    public GameObject ParticleEffect;
    private Vector2 touchPos;
    private RaycastHit hit;
    private Camera cam;
    
    public PlayerInput playerInput;
    private InputAction touchPressAction;
    private InputAction touchPosAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();
        touchPressAction = playerInput.actions["TouchPress"];
        touchPosAction = playerInput.actions["TouchPos"];
    }

    // Update is called once per frame
    void Update()
    {
        if (!touchPressAction.WasPerformedThisFrame())
        {
            return;
        }
        Debug.Log("screen touched");
        touchPos = touchPosAction.ReadValue<Vector2>();
        Ray ray = cam.ScreenPointToRay(touchPos);
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObj = hit.collider.gameObject;
            Debug.Log($"Collided with object {hitObj.name} {hitObj.tag}");
            if (hitObj.CompareTag("Enemy"))
            {
                Debug.Log("Object is an Enemy");
                var clone = Instantiate(ParticleEffect, hitObj.transform.position, Quaternion.identity);
                clone.transform.localScale = hitObj.transform.localScale;
                Destroy(hitObj);
            }
        }

    }
}

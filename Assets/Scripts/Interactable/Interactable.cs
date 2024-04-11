using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Interactable : MonoBehaviour
{
    public float moveSpeed = 1f;

    private bool isGrabbed;
    private new Rigidbody rigidbody;
    private Transform target;
    private Transform myTransform;
    private Vector3 currentPosition;
    public abstract void OnRelease();

    public abstract void OnGrab();

    public abstract void OnInteract();

    public void Grab(Transform parent)
    {
        if (!isGrabbed)
        {
            isGrabbed = true;

            if (rigidbody != null)
            {
                rigidbody.isKinematic = true;
            }

            target = parent;

            transform.SetParent(parent, true);
            transform.position = parent.position;

            Debug.Log("object grabbed");
        }
    }

    public void Release()
    {
        if (isGrabbed)
        {
            isGrabbed = false;

            if (rigidbody != null)
            {
                rigidbody.isKinematic = false;
            }

            transform.SetParent(null, true);
            transform.position = currentPosition;

            Debug.Log("object released");
        }
    }

    public void Interact()
    {

    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        isGrabbed = false;
        myTransform = transform;
    }

    private void FixedUpdate()
    {
        if (isGrabbed)
        {
            // Track controller position. The value will be used to set objects position when deparenting to avoid
            // unpredictible jumps in position.
            currentPosition = Vector3.MoveTowards(myTransform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

}


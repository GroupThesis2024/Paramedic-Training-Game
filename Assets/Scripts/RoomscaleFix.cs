using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent (typeof(XROrigin))]
public class RoomscaleFix : MonoBehaviour
{
    private CharacterController _character;
    private XROrigin _xrOrigin;

    // Start is called before the first frame update
    void Start()
    {
        _character = GetComponent<CharacterController>();
        _xrOrigin = GetComponent<XROrigin>();
    }

    private void FixedUpdate()
    {
        // Adjust characters height to allow grouching
        _character.height = _xrOrigin.CameraInOriginSpaceHeight + 0.15f;

        // Convert XROrigins camera transform position from world space to local space
        var centerPoint = transform.InverseTransformPoint(_xrOrigin.Camera.transform.position);
        _character.center = new Vector3(centerPoint.x, _character.height / 2 + _character.skinWidth, centerPoint.z);

        // Move character slighly in every frame to update physics for preventing going through objects
        _character.Move(new Vector3(0.001f, -0.001f, 0.001f));
        _character.Move(new Vector3(-0.001f, 0.001f, -0.001f));
    }
}

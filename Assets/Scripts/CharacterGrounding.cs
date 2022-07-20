using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] Transform _leftFoot;
    [SerializeField] Transform _rightFoot;
    [SerializeField] float _maxDistance;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] bool isGrounded;

    void Update()
    {
        CheckFoodForGrounding(_leftFoot);
        if(isGrounded == false)
            CheckFoodForGrounding(_rightFoot);

    }

    void CheckFoodForGrounding(Transform foot)
    {
        var rayCastHit = Physics2D.Raycast(foot.position, Vector2.down, _maxDistance, _layerMask);
        Debug.DrawRay(foot.position, Vector3.down * _maxDistance, Color.red);
        if (rayCastHit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}

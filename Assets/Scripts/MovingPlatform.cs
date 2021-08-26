using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _targetA, _targetB;
    private float _speed = 3;
    [SerializeField]private List<Transform> _wayPoints;
    [SerializeField]private int _currentTarget;
    private bool _targetReached;
    private bool _switching;
    private Player _player;
    [SerializeField] private Transform _newParent;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {     
        if (_switching==false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
        }
        
        if (transform.position==_targetB.position)
        {
            _switching = true;
        }
        if (_switching==true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
        }
        if (transform.position==_targetA.position)
        {
            _switching = false;
        }   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            other.transform.SetParent(transform);
            Debug.Log("moving platform");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
        {
            other.transform.SetParent(null);
        }
    }
}
//
// float distance = Vector3.Distance(transform.position, _wayPoints[_currentTarget].position);
// if(distance<1 &&_targetReached==false)
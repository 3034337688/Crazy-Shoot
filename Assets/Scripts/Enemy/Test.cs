using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform player;
    public GameObject beetle;
    private void Start()
    {
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Éú³ÉµÐÈË");
            Instantiate(beetle, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private float xAixsInput;
    private float zAxisInput;
    public float speed = 10;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //playermovement
      xAixsInput = Input.GetAxis("Horizontal");
      transform.Translate(Vector3.right* xAixsInput * Time.deltaTime* speed);
      
      if(Input.GetKeyDown(KeyCode.Space))
      {
        //launch
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
      }
    }
}

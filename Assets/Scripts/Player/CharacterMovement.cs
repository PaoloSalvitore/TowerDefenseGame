using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //one data type
    public float speed = 5;
    //struct container of data types
    //two data types
    public Vector2 example;
    //three data types
    public Vector3 direction;
    //int    means integer          (Whole Number)               1
    //int    means floating number   (Decimal Number)             1.0f
    //string means a collection of characters "aetg!"£%126:@"?./ zx"#
    //bool   means boolean           (True or False/ o or 1)
    //enum is like a type
    //comma seperated list of identifiers
    public enum ItemType
    {
        Dagger,
        Sword,
        Axe

    }
    public ItemType itemType;
    //Component References
    public Transform myTransform;

    private void Awake()//return type
    {
        Debug.Log("Awake");
    }

    /*
    void Start()
    {
        Debug.Log("Start");
    }

    */



    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }


    private void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }

    private void FixedUpdate()
    {

    }

}//THE END


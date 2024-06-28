using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class charactercontroller : MonoBehaviour
{
    public charactercontroller _character;
    private Animator _animator;
    private int speed = 2;
    private Rigidbody rb;
    public Transform cameraParentPos;

    void Start()
    {
        _character = GetComponent<charactercontroller>();
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();


        _animator.SetBool("isRun", false);
        _animator.SetBool("isWalk", false);
    }

    void Update()
    {
        speed = 2;

        //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        //{
        //    Vector3 rotateDict = cameraParentPos.rotation.eulerAngles;
        //    rotateDict.x = rotateDict.z = 0;
        //    transform.rotation = Quaternion.Euler(rotateDict);
        //} 


        float ho = Input.GetAxis("Horizontal");
        float ve = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(ho, 0, ve);



        if (dir != Vector3.zero)
        {

            _animator.SetBool("isWalk", true);
            //让人物面向方向
            Vector3 lookRotate = Quaternion.LookRotation(dir).eulerAngles;
            lookRotate += cameraParentPos.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(lookRotate);




            //让人物朝前方移动
            setstate();

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        }
        else
        {
            _animator.SetBool("isWalk", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            //transform.Translate(Vector3.up * speed * Time.deltaTime);
            _animator.SetTrigger("isJump");

            rb.AddForce(new Vector3(0, 250f, 0));

        }

        void setstate()
        {
            if (Input.GetKey(KeyCode.H))//跑
            {
                speed = 4;
                _animator.SetBool("isRun", true);

            }
            else
            {
                _animator.SetBool("isRun", false);
            }
        }



    }
}
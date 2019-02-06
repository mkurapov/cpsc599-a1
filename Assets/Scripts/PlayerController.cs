using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using EasyAR;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    public bool isMoving = true;

    List<GameObject> listOfTargets = new List<GameObject>();
    private GameObject currentTarget;
    private int targetIndex = 0;

    void Start()
    {

        //anim = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        //target1 = GameObject.Find("Target1");
        //target2 = GameObject.Find("Target2");
        //target3 = GameObject.Find("Target3");

        isMoving = true;

        //gameObject.SetActive(false);
        // only start if all are ready
        ////listOfTargets.Add(GameObject.Find("TargetTree").transform.Find("Palm_Tree").gameObject);
        listOfTargets.Add(GameObject.Find("Target1"));
        listOfTargets.Add(GameObject.Find("Target2"));
        listOfTargets.Add(GameObject.Find("Target3"));


        currentTarget = listOfTargets[targetIndex];
        //anim.SetTrigger("StartWalking");

    }

    void Update()
    {
        if (currentTarget && isMoving)
        {
            Vector3 direction = currentTarget.transform.position - transform.position;
            rb.AddForce(direction);
        }

        //if (listOfTargets.TrueForAll(obj => obj.activeSelf))
        //{
        //    gameObject.SetActive(true);
        //    //Vector3 direction = currentTarget.transform.position - transform.position;
        //    //rb.AddForce(direction);
        //    //Debug.Log("active");
        //}

        //if (currentTarget)
        //{
        //    Debug.Log("current Target");
        //}

        //if (listOfTargets.TrueForAll(obj => obj.activeInHierarchy))
        //{
        //    gameObject.SetActive(true);
        //}
        //Vector3 direction = currentTarget.transform.position - transform.position;
        //rb.AddForce(direction);
        //The code for moving up/down and left/right
        //if (currentTarget)
        //{
        //anim.SetTrigger("StartWalking");
        //    var target = GameObject.Find("Target");
        //Vector3 relativePos = new Vector3(1, 1, 1);
        ////    transform.LookAt(target.transform);
        ////    //rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
        //rb.velocity = relativePos;
        //rb.AddForce(Vector3.forward * speed, ForceMode.Force);
        //    Debug.Log(relativePos);
        //    //transform.position = Vector3.Lerp(transform.position, currentTarget.transform.position, Time.deltaTime);
        //}

    }

    void OnCollisionEnter(Collision collision)
    {
        if (isMoving && listOfTargets[targetIndex].Equals(collision.gameObject))
        {
            targetIndex++;
            Debug.Log(listOfTargets.Count);

            if (targetIndex < listOfTargets.Count)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                currentTarget = listOfTargets[targetIndex];
            }
            else
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                isMoving = false;
            }
        }
    }
}
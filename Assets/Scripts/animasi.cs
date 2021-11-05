using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animasi : MonoBehaviour
{
    // Variabel
    private float cepat;
    private float nilai_x;
    private float nilai_z;
    private bool status_ground;

    // Reference
    private Animator anim;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        nilai_x = player.GetComponent<playermovement>().x;      
        nilai_z = player.GetComponent<playermovement>().z;
        cepat = player.GetComponent<playermovement>().kecepatan;
        status_ground = player.GetComponent<playermovement>().isGrounded;
        anim.SetFloat("x", nilai_x);
        anim.SetFloat("z", nilai_z);
        anim.SetFloat("cepat", cepat);
        anim.SetBool("isGrounded", status_ground);
    }
}

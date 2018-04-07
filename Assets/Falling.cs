using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour {
    public GameObject tile;
    public GameObject cube;
    private Animator anim;
    public Rigidbody rb;
    public Color begColor;
    public Color endColor;
    public float duration = 1.0f;
    private Renderer rend;
    public bool isFlipped;
    private void Start()
    {
        tile = this.gameObject;
        anim = GetComponent<Animator>();
        rb = this.GetComponentInChildren<Rigidbody>();
        rend = tile.GetComponent<Renderer>();
        isFlipped = anim.GetBool("Flipped");
        
        
    }

    private void Update()
    {
        if (isFlipped)
        {
            MaterialSelect(); 
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {

            anim.SetBool("Flipped", true);
            
        }
        else
        {
            return;
            
        }
    }

    private void DropCube()
    {
        rb.isKinematic = false;
    }

    private void MaterialSelect()
    {
        if (tile.tag == "FireTile")
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;

            GetComponent<Renderer>().material.color = Color.Lerp(begColor, endColor, lerp);
        }
        else {
            return;
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleDrop : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private AudioSource sfxAuido;
    private PlayerController playerController;
    private MasterNode masterNode;
    

 
    private void Start()
    {
        
        masterNode = FindObjectOfType<MasterNode>();
        playerController = FindObjectOfType<PlayerController>();
        if(playerController != null)
        {
            sfxAuido = playerController.GetComponent<AudioSource>();
        }
        
    }

    private void Update()
    {
       transform.Translate(Vector2.down *Time.deltaTime*moveSpeed);
        Destroy(gameObject,10f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            if(playerController != null && sfxAuido !=null) {
                playerController.score++;
                sfxAuido.Play();
                Destroy(gameObject);
            
            }
        }
        else
        {
            if(masterNode.health > 0)
            {
                masterNode.health--;
                Destroy(gameObject);
            }
            
        }
    }
}

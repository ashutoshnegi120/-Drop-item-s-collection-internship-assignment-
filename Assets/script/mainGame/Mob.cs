using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private GameObject appleDropPrefab;
    private MasterNode masterNode;
    private float dropPointX;
    private bool hasDropped = false; 

    private void Start()
    {
        masterNode = FindObjectOfType<MasterNode>();
        appleDropPrefab = masterNode.drop;
        dropPointX = Random.Range(-7f, 6f);
        moveSpeed = Random.Range(3f, 5f);
    }

    private void Update()
    {
        
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);

        
        if (!hasDropped && Mathf.Abs(transform.position.x - dropPointX) < 0.1f)
        {
            DropApple();
            hasDropped = true;
        }

        
        Destroy(gameObject, 8f);
    }

    private void DropApple()
    {
        if (appleDropPrefab != null)
        {
            Instantiate(appleDropPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("AppleDrop prefab is not assigned.");
        }
    }
}

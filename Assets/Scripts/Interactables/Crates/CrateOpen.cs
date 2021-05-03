using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateOpen : Interactable
{
    [Header("Objects")]
    [SerializeField]
    private GameObject openedCrate;
    [SerializeField]
    private GameObject crateTop;

    [Header("Positions")]
    [SerializeField]
    private float deltaXTop;
    [SerializeField]
    private float deltaYTop;
    [SerializeField]
    private float deltaZTop;

    protected override void HandleAnimation()
    {
        
    }

    protected override void HandleUse()
    {
        if (activated)
        {
            Instantiate(openedCrate, transform.position, transform.rotation);
            Instantiate(crateTop, new Vector3(transform.position.x + deltaXTop, transform.position.y + deltaYTop, transform.position.z + deltaZTop), transform.rotation);
            Destroy(this.gameObject);
        }
    }

    protected override void Init()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

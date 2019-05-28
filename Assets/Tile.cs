using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    private int x, y;
    public List<Tile> neighbours = new List<Tile>(0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public void OnMouseEnter()
    {
    }

    public void OnMouseDown()
    {
        foreach(Tile t in neighbours)
            t.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
    }
}

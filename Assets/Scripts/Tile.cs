using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    private int x, y;
    private Color color;
    public List<Tile> neighbours = new List<Tile>(0);

    public void setPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void setColor(Color color)
    {
        this.color = color;
    }

    public void OnMouseEnter()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
    }

    public void OnMouseExit()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = this.color;
    }

}

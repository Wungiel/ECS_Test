using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public GameObject tile;
    public int width, height;
    Dictionary<Vector2, Tile> tiles = new Dictionary<Vector2, Tile>();

    // Start is called before the first frame update
    void Start()
    {
        generateMap();
        setNeighbours();
    }


    private void generateMap()
    {
        float heightHex = 0.5f * Mathf.Sqrt(3);
        GameObject go;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                float positionX = i * 0.75f;
                float positionY = j * heightHex;
                float offsetY = 0.5f * heightHex;

                if (i % 2 == 0)
                    go = Instantiate(tile, new Vector2(positionX, positionY), tile.transform.rotation, this.transform);
                else
                    go = Instantiate(tile, new Vector2(positionX, positionY - (offsetY)), tile.transform.rotation, this.transform);
                go.GetComponent<SpriteRenderer>().color = getColor();
                go.name = $"Tile_{i}_{j}";
                go.GetComponent<Tile>().setPosition(i, j);
                go.GetComponent<Tile>().setColor(go.GetComponent<SpriteRenderer>().color);
                tiles.Add(new Vector2(i, j), go.GetComponent<Tile>());

            }
        }
    }

    private void setNeighbours()
    {
            List<Vector2> directionsOdd = new List<Vector2>(){new Vector2(1,0), new Vector2(1,-1), new Vector2(0,-1),
                                        new Vector2(-1,-1), new Vector2(-1,0), new Vector2(0,1)};
            List<Vector2> directionsEven = new List<Vector2>(){new Vector2(1,1), new Vector2(1,0), new Vector2(0,-1),
                                        new Vector2(-1,0), new Vector2(-1,1), new Vector2(0,1)};


        foreach (KeyValuePair<Vector2, Tile> kvp in tiles)
        {
            List<Vector2> directions;
            if (kvp.Key.x % 2 == 0)
                directions = directionsEven;
            else
                directions = directionsOdd;

            foreach (Vector2 direction in directions)
            {
                Vector3 tmp = kvp.Key + direction;
                Tile tmpTile = new Tile();
                if (tiles.ContainsKey(tmp))
                {
                    tiles.TryGetValue(tmp, out tmpTile);
                    kvp.Value.neighbours.Add(tmpTile);
                }
            }
        }
    }

    private Color getColor()
    {
        float r = UnityEngine.Random.Range(0, 255)/255f;
        float g = UnityEngine.Random.Range(0, 255)/255f;
        float b = UnityEngine.Random.Range(0, 255/255f);
        return new Color(r, g, b); 
    }

}

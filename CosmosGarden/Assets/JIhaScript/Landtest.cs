using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Landtest : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tiles;
    public Grid _Grid;

    public List<Vector3Int> LandTile;

    Vector3Int ClickPos;

    private void Start()
    {
        ClickPos = new Vector3Int(4, 5, -10);//_Grid.WorldToCell(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y)));
        Debug.Log(ClickPos);
        //tileSet(tiles);
        tilemap.SetTile(new Vector3Int(4, 5, -10), tiles);
        //tilemap.SetTile(ClickPos, tiles);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickPos = _Grid.WorldToCell(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y)));
            tileSet(tiles);
        }
    }
    
    public void tileSet(TileBase tile)
    {
        tilemap.SetTile(ClickPos, tile);
    }
}

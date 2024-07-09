using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePlacer : MonoBehaviour
{
    [SerializeField] public Tilemap tilemap;
    [SerializeField] public Tile tile;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);

            PlaceTile(cellPosition);
        }
    }

    void PlaceTile(Vector3Int cellPosition)
    {
        tilemap.SetTile(cellPosition, tile);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;

public class MapLoader : MonoBehaviour
{
    public Tilemap[] tilemap;
    // Start is called before the first frame update
    void Start()
    {
        LoadTile(0);
        LoadTile(1);
    }
    [System.Serializable]
    public class TileArray
    {
        public Tiles[] tiles;
    }
    public void SaveTiles()
    {
        for(int index = 0; index < tilemap.Length; index++)
        {
            List<Tiles> savedTiles = new List<Tiles>();
            foreach (Vector3Int pos in tilemap[index].cellBounds.allPositionsWithin)
            {
                TileBase tile = tilemap[index].GetTile(pos);
                
                if (tile != null)
                {
                    Tiles data = new Tiles
                    {
                        x = pos.x,
                        y = pos.y,
                        tileName = tile.name
                    };
                    savedTiles.Add(data);
                }
            }
            TileArray tiles = new TileArray();
            tiles.tiles = savedTiles.ToArray();
            string json = JsonUtility.ToJson(tiles);
            Debug.Log(json);

            File.WriteAllText(Application.persistentDataPath + "/tilemap" + index.ToString() + ".json", json);
        }
    }

    // Update is called once per frame
    public void LoadTile(int index)
    {
        TileArray tiles;
        string filePath = Application.persistentDataPath + "/tilemap" + index.ToString() + ".json";
        //Debug.Log(filePath);

        if (File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            Debug.Log(FromJsonData);
            tiles = JsonUtility.FromJson<TileArray>(FromJsonData);

            for (int i = 0; i < tiles.tiles.Length; i++)
            {
                Vector3Int vector = new Vector3Int(tiles.tiles[i].x, tiles.tiles[i].y, -10);
                TileBase tile = Resources.Load<Tile>(tiles.tiles[i].tileName);
                tilemap[index].SetTile(vector, tile);
            }
        }
        
    }
    
}

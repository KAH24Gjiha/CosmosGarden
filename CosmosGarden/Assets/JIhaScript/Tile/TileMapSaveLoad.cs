using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;
using System.Text;

public class TileMapSaveLoad : MonoBehaviour
{
    public Tilemap tilemap;
    public int index;

    
    [System.Serializable]
    public static class saveTile
    {
        public static List<Tiles> savedTiles = new List<Tiles>();
    }

    private void Start()
    {
        LoadTiles();
    }
    public void SaveTiles()
    {
        saveTile.savedTiles.Clear();
        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            TileBase tile = tilemap.GetTile(pos);
            if (tile != null)
            {
                Tiles data = new Tiles
                {
                    x = pos.x,
                    y = pos.y,
                    tileName = tile.name
                };
                saveTile.savedTiles.Add(data);
            }
        }

        string json = JsonUtility.ToJson(saveTile.savedTiles.ToArray(), true);
        for (int i = 0; i < saveTile.savedTiles.Count; i++)
        {
            Debug.Log(saveTile.savedTiles[i].tileName);
        }
        Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + "/tilemap" + index.ToString() + ".json", json);
    }

    public void LoadTiles()
    {
        string path = Application.persistentDataPath + "/tilemap" + index.ToString() + ".json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            saveTile.savedTiles = JsonUtility.FromJson<List<Tiles>>(json);
            foreach (Tiles data in saveTile.savedTiles)
            {
                Vector3Int pos = new Vector3Int(data.x, data.y, 0);
                TileBase tile = Resources.Load<TileBase>(data.tileName);
                if (tile != null)
                {
                    tilemap.SetTile(pos, tile);
                    Debug.Log("설치중~");
                }
                else Debug.Log("저장이 안됏나본데" );
            }
            Debug.Log("불러옴" + path);
        }
        
    }
}

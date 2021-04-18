using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGen : MonoBehaviour
{
    [SerializeField] GameObject white, stone, silverOre, limitBlock;
    [SerializeField] int width, height, smoothing;


    [Range(38, 48)]
    [SerializeField] int caveDensity;
    [Range(0, 100)]
    [SerializeField] int silverChance;

    GameObject[,] map;


    void Start() {
        genMap();
    }
    void Update() { 
      
    }

    void genMap() {
        map = new GameObject[width, height];
        fillMap();

        for (int i = 0; i < smoothing; i++) {
            evolveMap();
        }
        drawMap();

    }

    void drawMap() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if ((y != (height - 5) && y != (height - 4) && y != (height - 3)) && map[x,y] != white)
                    spawnBlock(map[x, y], x, y);
                if (x > width-5 && map[x, y] != white)
                    spawnBlock(map[x, y], x, y);
                          
            }
        }

         
        for (int x = -1; x < width+1; x++) {
            spawnBlock(limitBlock, x, height);
            spawnBlock(limitBlock, x, -1);
        }
        for (int y = -1; y < height + 1; y++) {
            spawnBlock(limitBlock, -1, y);
            spawnBlock(limitBlock, width, y);
        }



    }

    void fillMap() {

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {

                if (x == 0 || x == width-1 || y == 0 || y == height - 1) {
                    map[x, y] = stone;
                }
                else {

                    if (Random.Range(0, 100) < caveDensity) {
                        map[x, y] = stone;
                    }
                    else {
                    map[x, y] = white;
                    }
                }
            }
        }

    }

    void evolveMap() {
        int nbWallTile = 0;
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                nbWallTile = getNeighboorTile(x, y);
                if(nbWallTile > 4) {
                    if(Random.Range(0, 100) < silverChance) {
                        map[x, y] = silverOre;  

                    }
                    else {
                        map[x, y] = stone;
                    }
                }
                else if (nbWallTile < 4) {
                    map[x, y] = white;     
                }
            }
        }
    }


    int getNeighboorTile(int x, int y) {
        int count = 0;

        for (int nbx = x-1; nbx <= x+1; nbx++) {
            for (int nby = y-1; nby <= y+1; nby++) {
                if(nbx >= 0 && nbx < width && nby >= 0 && nby < height) {
                    if (x != nbx || y != nby) {
                        count += (map[nbx, nby] == stone || map[nbx, nby] == silverOre) ? 1 : 0;
                    }
                }
                else {
                    count++;
                }

                
            }

        }
        return count;

    }
        

    void spawnBlock(GameObject block, int x, int y) {

        block = Instantiate(block, new Vector2(x, y), Quaternion.identity);
        block.transform.parent = this.transform;

    }

}

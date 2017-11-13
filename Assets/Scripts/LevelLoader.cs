using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Runtime.InteropServices;
using Ionic.Zlib;

public class LevelLoader : MonoBehaviour {
	
	// level data
	J2L.Level lvl = new J2L.Level();

	// tileset data
	J2T.Tileset tilesetObj = new J2T.Tileset();

	byte[] TileFrame;
	
	public string level_name;

	[HideInInspector]
	public GameObject player;

	public Texture2D[] tileTextures, tileMasks;


	void loadLevel(string name)
	{
		lvl.LoadLevelData(name);
		
		

		// load tileset data
		tilesetObj.ReadTilesetData(System.Text.Encoding.UTF8.GetString(lvl.GetTileset()).TrimEnd('\0').ToLower().Replace(".j2t", ""));

		// load the J2T data 1 of tileset
		tilesetObj.LoadJ2T_TilesetInfo_1_23();
		tilesetObj.LoadTileImages();
		tilesetObj.LoadTileTransparency();
		tilesetObj.LoadTileClipping();
	}

	// Use this for initialization
	void Start () {
		//player = GameObject.FindWithTag("Player");
		//player.SetActive(false);

		loadLevel(level_name);

		Debug.Log("Level name: " + System.Text.Encoding.Default.GetString(lvl.GetLevelName()));
		Debug.Log("Version: " + lvl.GetVersion());

		Debug.Log("Tileset: " + System.Text.Encoding.Default.GetString(lvl.GetTileset()));
		Debug.Log("Next level: " + System.Text.Encoding.Default.GetString(lvl.GetNextLevel()));
		Debug.Log("Music file: " + System.Text.Encoding.Default.GetString(lvl.GetMusicFile()));

		Debug.Log("Tileset CData1: " + tilesetObj.header.CData1);
		Debug.Log("Tileset UData1: " + tilesetObj.header.UData1);
		Debug.Log("Tileset name: " + System.Text.Encoding.UTF8.GetString(tilesetObj.header.TilesetName).TrimEnd('\0'));

		/*
		if(lvl.IsTileWidthChecked(0))
			Debug.Log("Tile width set (layer0)");

		if(lvl.IsTileWidthChecked(1))
			Debug.Log("Tile width set (layer1)");

		if(lvl.IsTileWidthChecked(2))
			Debug.Log("Tile width set (layer2)");

		if(lvl.IsTileWidthChecked(3))
			Debug.Log("Tile width set (layer3)");

		if(lvl.IsTileWidthChecked(4))
			Debug.Log("Tile width set (layer4)");

		if(lvl.IsTileWidthChecked(5))
			Debug.Log("Tile width set (layer5)");

		if(lvl.IsTileWidthChecked(6))
			Debug.Log("Tile width set (layer6)");

		if(lvl.IsTileWidthChecked(7))
			Debug.Log("Tile width set (layer7)");
		*/

		string tileset = System.Text.Encoding.UTF8.GetString(lvl.GetTileset()).TrimEnd('\0').ToLower().Replace(".j2t", "");	

		GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Music/" + System.Text.Encoding.UTF8.GetString(lvl.GetMusicFile()).TrimEnd('\0').ToLower());
		GetComponent<AudioSource>().PlayDelayed(0f);

		tileTextures = new Texture2D[tilesetObj.TilesetInfo_1_23.TileCount];
		tileMasks = new Texture2D[tilesetObj.TilesetInfo_1_23.TileCount];

		for(int i=0; i<tilesetObj.TilesetInfo_1_23.TileCount; i++)
			tileTextures[i] = new Texture2D(32, 32);

		for(int i=0; i<tilesetObj.TilesetInfo_1_23.TileCount; i++)
			tileMasks[i] = new Texture2D(32, 32);

		//Thread thrd;
		//bool thrdPaused = false;

		//thrd = new Thread(GenerateTileTextures);
		//thrd.Start();

		// DrawPalette();
		GenerateTileTextures();
		// GenerateTileMasks();
		GenerateLevel();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GenerateTileTextures()
	{	
		Debug.Log("Started generating tile textures.");
		// generate the tile textures from the tilset object

		for(int i=0; i<tilesetObj.TilesetInfo_1_23.TileCount; i++)
		{	
			// Debug.Log("Current tile texture " + i);
			uint[] pixels = tilesetObj.GetTile((uint)i, true);

			if(pixels.Length == 1024)
			
			for (int y = 0; y < 32; y++)
	        {
	            for (int x = 0; x < 32; x++)
	            {
	            	//Debug.Log("paletteColor index: " + (32 * y + x));
	            	uint pixel = pixels[32*y + x];
	            	
	            	Color32 c;
     				
     				if(System.BitConverter.IsLittleEndian)
     				{
     					c.r = (byte)((pixel) & 0xFF);
     					c.g = (byte)((pixel>>8) & 0xFF);
     					c.b = (byte)((pixel>>16) & 0xFF);
     					c.a = (byte)((pixel>>24) & 0xFF);
     				}
     				else
     				{
     					c.a = (byte)((pixel) & 0xFF);
     					c.b = (byte)((pixel>>8) & 0xFF);
     					c.g = (byte)((pixel>>16) & 0xFF);
     					c.r = (byte)((pixel>>24) & 0xFF);
     				}

	            	tileTextures[i].SetPixel(32-x, 32-y, c);
	            }
	        }
	        

	        tileTextures[i].Apply();

	        //GameObject tileObj = (GameObject)Instantiate(Resources.Load("Prefabs/Tile/GenericTile"));
			//tileObj.transform.position = new Vector3(i, 0, 0);
			//tileObj.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tileTextures[i], new Rect(0.0f, 0.0f, 32f, 32f), new Vector2(0.5f, 0.5f), 32f);
		}

		//Thread.CurrentThread.Abort();
	}

	void GenerateTileMasks()
	{
		for(uint i=0; i<tilesetObj.TilesetInfo_1_23.TileCount; i++)
		{
			J2T.J2T_TileClip tileClip = tilesetObj.GetTileClip(i);

			int currentByte = 0, row = 0;
			while(currentByte < 128)
			{
				for(int j=0; j<32; j++)
				{
					byte pixel = tileClip.ClippingMask[j];
					
					if(Utils.IsBitSet(pixel, j%8))
						tileMasks[i].SetPixel(row, j, Color.white);
					else tileMasks[i].SetPixel(row, j, new Color(0f, 0f, 0f, 0f));
				}

				if(currentByte % 4 == 0)
					row++;

				currentByte++;
			}
		}
	}

	// for debugging
	public void DrawPalette()
	{
		GameObject tileObj = (GameObject)Instantiate(Resources.Load("Prefabs/Tile/GenericTile"));
		tileObj.transform.position = new Vector3(-10, 0, 0);
		Texture2D paletteTexture = new Texture2D(256, 256);
		for(int i=0; i<256; i++)
			for(int j=0; j<256; j++)
			{
				uint pixel = tilesetObj.TilesetInfo_1_23.PaletteColor[j];
				
				Color32 c;
				
				if(System.BitConverter.IsLittleEndian)
				{
					c.r = (byte)((pixel) & 0xFF);
     				c.g = (byte)((pixel>>8) & 0xFF);
     				c.b = (byte)((pixel>>16) & 0xFF);
     				c.a = (byte)((pixel>>24) & 0xFF);
     			}
     			else
     			{
     				c.a = (byte)((pixel) & 0xFF);
     				c.b = (byte)((pixel>>8) & 0xFF);
     				c.g = (byte)((pixel>>16) & 0xFF);
     				c.r = (byte)((pixel>>24) & 0xFF);
     			}

				paletteTexture.SetPixel(i, j, c);
			}

		paletteTexture.Apply();

		tileObj.GetComponent<SpriteRenderer>().sprite = Sprite.Create(paletteTexture, new Rect(0.0f, 0.0f, 256f, 256f), new Vector2(0.5f, 0.5f), 32f);
	}

	void GenerateLevel()
	{
		for(uint layer=0; layer<8; layer++)
		{
			if(lvl.DoesLayerHaveAnyTiles(layer))
			{
				uint yPos = lvl.GetLayerHeight(layer);
				for(uint i=0; i<lvl.GetLayerHeight(layer); i++)
				{
					for(uint j=0; j<lvl.GetLayerWidth(layer); j++)
					{
						J2L.J2L_Tile tile = lvl.GetTile(layer, j, i, 0f);

						GameObject tileObj = (GameObject)Instantiate(Resources.Load("Prefabs/Tile/GenericTile"));
						tileObj.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tileTextures[tile.index], new Rect(0.0f, 0.0f, 32f, 32f), new Vector2(0.5f, 0.5f), 32f);
						tileObj.transform.position = new Vector3(j, yPos, layer);
						if(layer == 3)tileObj.AddComponent<PolygonCollider2D>();
						tileObj.transform.parent = GameObject.Find("Layer" + layer).transform;

						if(tile.flipped)
							tileObj.GetComponent<SpriteRenderer>().flipX = true;

						//J2L_Event e = Utils.GetTileEvent(d1_lvl, j, i, d1_lvl.LayerRealWidth[3]);

						//if(e != null)
						{
						//	tileObj.AddComponent<GenericEvent>();
						//	tileObj.GetComponent<GenericEvent>().id = e.EventID;
						//	tileObj.GetComponent<GenericEvent>().UpdateData();
						}
					}

					yPos--;
				}
			}
		}

		//TileCoord playerSpawnPos = Utils.GetPlayerStart(d1_lvl, d2_lvl, false);
		//player.SetActive(true);
		// player.transform.position = new Vector3(playerSpawnPos.x, d1_lvl.LayerHeight[3] - playerSpawnPos.y, 2);
		//player.transform.position = new Vector3(25, 50, 2);
	}
}

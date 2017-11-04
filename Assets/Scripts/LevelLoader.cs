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
	LEVL_Header lh = new LEVL_Header();
	J2L_Data1_1_23 d1_lvl = new J2L_Data1_1_23();
	J2L_Data2_1_23 d2_lvl = new J2L_Data2_1_23();
	J2L_Data3 d3_lvl = new J2L_Data3();
	J2L_Data4 d4_lvl = new J2L_Data4();

	// tileset data
	Tileset tilesetObj = new Tileset();

	byte[] TileFrame;
	
	public string level_name;

	[HideInInspector]
	public GameObject player;

	public Texture2D[] tileTextures;


	void loadLevel(string name)
	{
		int offset = 0;

		TextAsset ta = Resources.Load("Jazz2/" + name + "_level", typeof(TextAsset)) as TextAsset;
		byte[] lvl_bytes = ta.bytes;

		Utils.ReadLEVLHeader(ref lh, ref lvl_bytes, ref offset);

		// decompress data1 of level
		byte[] buf = new byte[lh.UData1];
		buf = Ionic.Zlib.ZlibStream.UncompressBuffer(Utils.getBytes(lvl_bytes, ref offset, (int)lh.CData1));

		// read the J2L data 1 of level
		Utils.ReadJ2L_Data_1_23(ref d1_lvl, ref buf);

		// decompress data2 of level
		buf = new byte[lh.UData2];
		buf = Ionic.Zlib.ZlibStream.UncompressBuffer(Utils.getBytes(lvl_bytes, ref offset, (int)lh.CData2));

		// read the J2L data 2 of level
		Utils.ReadJ2L_Data2_1_23(ref d2_lvl, buf, lh.UData2);

		// decompress data3 of level
		buf = new byte[lh.UData3];
		buf = Ionic.Zlib.ZlibStream.UncompressBuffer(Utils.getBytes(lvl_bytes, ref offset, (int)lh.CData3));

		// read the J2L data 3 of level
		Utils.ReadJ2L_Data3(ref d3_lvl, ref buf, lh.UData3);

		// decompress data4 of level
		buf = new byte[lh.UData4];
		buf = Ionic.Zlib.ZlibStream.UncompressBuffer(Utils.getBytes(lvl_bytes, ref offset, (int)lh.CData4));

		// read the J2L data 1 of level
		Utils.ReadJ2L_Data4(ref d4_lvl, d1_lvl, ref buf, lh.UData4);
		
		TileFrame = new byte[d1_lvl.LayerWidth[3] * d1_lvl.LayerHeight[3]];

		for(int i=0; i<d1_lvl.LayerWidth[3] * d1_lvl.LayerHeight[3]; i++)
			TileFrame[i] = 0;


		// load tileset data
		tilesetObj.ReadTilesetData(System.Text.Encoding.UTF8.GetString(d1_lvl.Tileset).TrimEnd('\0').ToLower().Replace(".j2t", ""));

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

		Debug.Log("Level name: " + System.Text.Encoding.Default.GetString(lh.LevelName));
		Debug.Log("Version: " + lh.Version);
		Debug.Log("File size: " + lh.FileSize);
		Debug.Log("Compressed data 1: " + lh.CData1);
		Debug.Log("Compressed data 2: " + lh.CData2);
		Debug.Log("Compressed data 3: " + lh.CData3);
		Debug.Log("Compressed data 4: " + lh.CData4);

		Debug.Log("Level name(data1): " + System.Text.Encoding.Default.GetString(d1_lvl.LevelName));
		Debug.Log("Tileset: " + System.Text.Encoding.Default.GetString(d1_lvl.Tileset));
		Debug.Log("Next level: " + System.Text.Encoding.Default.GetString(d1_lvl.NextLevel));
		Debug.Log("Music file: " + System.Text.Encoding.Default.GetString(d1_lvl.MusicFile));
		

		Debug.Log("Width " + d1_lvl.LayerWidth[3]);
		Debug.Log("Height " + d1_lvl.LayerHeight[3]);

		Debug.Log("Tileset CData1: " + tilesetObj.header.CData1);
		Debug.Log("Tileset UData1: " + tilesetObj.header.UData1);
		Debug.Log("Tileset name: " + System.Text.Encoding.UTF8.GetString(tilesetObj.header.TilesetName).TrimEnd('\0'));

		string tileset = System.Text.Encoding.UTF8.GetString(d1_lvl.Tileset).TrimEnd('\0').ToLower().Replace(".j2t", "");

		/*
		for(uint layer=0; layer<8; layer++)
		{
			if(d1_lvl.DoesLayerHaveAnyTiles[layer])
			{
				uint yPos = d1_lvl.LayerHeight[layer];
				for(uint i=0; i<d1_lvl.LayerHeight[layer]; i++)
				{
					for(uint j=0; j<d1_lvl.LayerWidth[layer]; j++)
					{
						J2L_Tile tile = Utils.GetTile(lh, d1_lvl, d3_lvl, d4_lvl, ref TileFrame, layer, j, i, 0f);
						
						Debug.Log("Prefabs/Tiles/" + tileset + "/" + tileset + "_" + tile.index);

						if(tile.flipped)
							Debug.Log("Tile is flipped");

						
						GameObject tileObj = (GameObject)Instantiate(Resources.Load("Prefabs/Tiles/" + tileset + "/" + tileset + "_" + tile.index));
						tileObj.transform.position = new Vector3(j, yPos, layer);
					}

					yPos--;
				}
			}
		}

		TileCoord playerSpawnPos = Utils.GetPlayerStart(d1_lvl, d2_lvl, false);
		player.SetActive(true);
		// player.transform.position = new Vector3(playerSpawnPos.x, d1_lvl.LayerHeight[3] - playerSpawnPos.y, 2);
		player.transform.position = new Vector3(25, 50, 2);

		GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Music/" + System.Text.Encoding.UTF8.GetString(d1_lvl.MusicFile).TrimEnd('\0').ToLower());
		GetComponent<AudioSource>().PlayDelayed(0f);
		*/

		tileTextures = new Texture2D[tilesetObj.TilesetInfo_1_23.TileCount];

		for(int i=0; i<tilesetObj.TilesetInfo_1_23.TileCount; i++)
			tileTextures[i] = new Texture2D(32, 32);

		//Thread thrd;
		//bool thrdPaused = false;

		//thrd = new Thread(GenerateTileTextures);
		//thrd.Start();

		DrawPalette();
		GenerateTileTextures();

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
			Debug.Log("Current tile texture " + i);
			uint[] pixels = tilesetObj.GetTile((uint)i, true);

			if(pixels.Length == 1024)
			for (int y = 0; y < 32; y++)
	        {
	            for (int x = 0; x < 32; x++)
	            {
	            	//Debug.Log("paletteColor index: " + (32 * y + x));
	            	uint pixel = pixels[32*y + x];
	            	Color32 c = new Color32((byte)Utils.getByteFromNumber(pixel, 1),
	            		(byte)Utils.getByteFromNumber(pixel, 2),
	            		(byte)Utils.getByteFromNumber(pixel, 3),
	            		(byte)Utils.getByteFromNumber(pixel, 4));

	            	tileTextures[i].SetPixel(32-x, 32-y, c);
	            }
	        }

	        tileTextures[i].Apply();

	        GameObject tileObj = (GameObject)Instantiate(Resources.Load("Prefabs/Tile/GenericTile"));
			tileObj.transform.position = new Vector3(i, 0, 0);
			tileObj.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tileTextures[i], new Rect(0.0f, 0.0f, 32f, 32f), new Vector2(0.5f, 0.5f), 32f);
		}

		//Thread.CurrentThread.Abort();
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
				Color32 c = new Color32((byte)Utils.getByteFromNumber(tilesetObj.TilesetInfo_1_23.PaletteColor[j], 1), (byte)Utils.getByteFromNumber(tilesetObj.TilesetInfo_1_23.PaletteColor[j], 2),
	            	(byte)Utils.getByteFromNumber(tilesetObj.TilesetInfo_1_23.PaletteColor[j], 3), (byte)Utils.getByteFromNumber(tilesetObj.TilesetInfo_1_23.PaletteColor[j], 4));
				
				paletteTexture.SetPixel(i, j, c);
			}

		paletteTexture.Apply();

		tileObj.GetComponent<SpriteRenderer>().sprite = Sprite.Create(paletteTexture, new Rect(0.0f, 0.0f, 256f, 256f), new Vector2(0.5f, 0.5f), 32f);
	}
}

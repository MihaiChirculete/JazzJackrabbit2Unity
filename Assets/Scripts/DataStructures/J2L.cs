using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J2L {
public class LEVL_Header
{
	public byte[] Copyright = new byte[180];
	public byte[] Magic = new byte[4]; // Should be 'LEVL'
	public byte[] PasswordHash = new byte[4]; // 0x00BABE00 for no password
	public byte[] LevelName = new byte[32];
	public ushort Version;
	public uint FileSize;
	public uint CRC32;
	public uint CData1;            // compressed size of Data1
	public uint UData1;            // uncompressed size of Data1
	public uint CData2;            // compressed size of Data2
	public uint UData2;            // uncompressed size of Data2
	public uint CData3;            // compressed size of Data3
	public uint UData3;            // uncompressed size of Data3
	public uint CData4;            // compressed size of Data4
	public uint UData4;            // uncompressed size of Data4
}

public class Animated_Tile
{
	public ushort FrameWait;
	public ushort RandomWait;
	public ushort PingPongWait;
	public bool PingPong;
	public byte Speed;
	public byte FrameCount;
	public ushort[] Frame = new ushort[64]; // this can be a flipped tile or another animated tile
}

public class J2L_Data1_1_23
{
	public ushort JCSHorizontalOffset; // In pixels
	public ushort Security1; // 0xBA00 if passworded, 0x0000 otherwise
	public ushort JCSVerticalOffset; // In pixels
	public ushort Security2; // 0xBE00 if passworded, 0x0000 otherwise
	public byte SecAndLayer; // Upper 4 bits are set if passworded, zero otherwise. Lower 4 bits represent the layer number as last saved in JCS.
	public byte MinLight; // Multiply by 1.5625 to get value seen in JCS
	public byte StartLight; // Multiply by 1.5625 to get value seen in JCS
	public ushort AnimCount;
	public bool VerticalSplitscreen;
	public bool IsLevelMultiplayer;
	public uint BufferSize;
	public byte[] LevelName = new byte[32];
	public byte[] Tileset = new byte[32];
	public byte[] BonusLevel = new byte[32];
	public byte[] NextLevel = new byte[32];
	public byte[] SecretLevel = new byte[32];
	public byte[] MusicFile = new byte[32];
	public byte[,] HelpString = new byte[16,512];
	public uint[] LayerMiscProperties = new uint[8]; // Each property is a bit in the following order: Tile Width, Tile Height, Limit Visible Region, Texture Mode, Parallax Stars. This leaves 27 (32-5) unused bits for each layer?
	public byte[] Type = new byte[8]; // name from Michiel; function unknown
	public bool[] DoesLayerHaveAnyTiles = new bool[8]; // must always be set to true for layer 4, or JJ2 will crash
	public uint[] LayerWidth = new uint[8];
	public uint[] LayerRealWidth = new uint[8]; // for when "Tile Width" is checked. The lowest common multiple of LayerWidth and 4.
	public uint[] LayerHeight = new uint[8];
	public int[] LayerZAxis = new int[8]; // Should be { -300, -200, -100, 0, 100, 200, 300, 400 }, but nothing happens when you change these
	public byte[] DetailLevel = new byte[8]; // is set to 02 for layer 5 in Battle1 and Battle3, but is 00 the rest of the time, at least for JJ2 levels. No clear effect of altering. Name from Michiel.
	public int[] WaveX = new int[8]; // name from Michiel; function unknown
	public int[] WaveY = new int[8]; // name from Michiel; function unknown
	public uint[] LayerXSpeed = new uint[8]; // Divide by 65536 to get value seen in JCS
	public uint[] LayerYSpeed = new uint[8]; // Divide by 65536 to get value seen in JCSvalue
	public uint[] LayerAutoXSpeed = new uint[8]; // Divide by 65536 to get value seen in JCS
	public uint[] LayerAutoYSpeed = new uint[8]; // Divide by 65536 to get value seen in JCS
	public byte[] LayerTextureMode = new byte[8];
	public byte[,] LayerTextureParams = new byte[8,3]; // Red, Green, Blue
	public ushort AnimOffset; // MAX_TILES minus AnimCount, also called StaticTiles
	public uint[] TilesetEvents = new uint[Constants.MAX_TILES_1_23]; // same format as in Data2, for tiles
	public bool[] IsEachTileFlipped = new bool[Constants.MAX_TILES_1_23]; // set to 1 if a tile appears flipped anywhere in the level
	public byte[] TileTypes = new byte[Constants.MAX_TILES_1_23]; // translucent=1 or caption=4, basically. Doesn't work on animated tiles.
	public byte[] XMask = new byte[Constants.MAX_TILES_1_23]; // tested to equal all zeroes in almost 4000 different levels, and editing it has no appreciable effect.  // Name from Michiel, who claims it is totally unused.
	public Animated_Tile[] Anim = new Animated_Tile[128]; // or [256] in TSF.
	// only the first [AnimCount] are needed; JCS will save all 128/256, but JJ2 will run your level either way.
	public byte[] Padding = new byte[512]; //all zeroes; only in levels saved with JCS
}

public class J2L_Data1_TSF
{
	public ushort JCSHorizontalOffset; // In pixels
	public ushort Security1; // 0xBA00 if passworded, 0x0000 otherwise
	public ushort JCSVerticalOffset; // In pixels
	public ushort Security2; // 0xBE00 if passworded, 0x0000 otherwise
	public byte SecAndLayer; // Upper 4 bits are set if passworded, zero otherwise. Lower 4 bits represent the layer number as last saved in JCS.
	public byte MinLight; // Multiply by 1.5625 to get value seen in JCS
	public byte StartLight; // Multiply by 1.5625 to get value seen in JCS
	public ushort AnimCount;
	public bool VerticalSplitscreen;
	public bool IsLevelMultiplayer;
	public uint BufferSize;
	public byte[] LevelName = new byte[32];
	public byte[] Tileset = new byte[32];
	public byte[] BonusLevel = new byte[32];
	public byte[] NextLevel = new byte[32];
	public byte[] SecretLevel = new byte[32];
	public byte[] MusicFile = new byte[32];
	public byte[,] HelpString = new byte[16,512];
	public uint[] LayerMiscProperties = new uint[8]; // Each property is a bit in the following order: Tile Width, Tile Height, Limit Visible Region, Texture Mode, Parallax Stars. This leaves 27 (32-5) unused bits for each layer?
	public byte[] Type = new byte[8]; // name from Michiel; function unknown
	public bool[] DoesLayerHaveAnyTiles = new bool[8]; // must always be set to true for layer 4, or JJ2 will crash
	public uint[] LayerWidth = new uint[8];
	public uint[] LayerRealWidth = new uint[8]; // for when "Tile Width" is checked. The lowest common multiple of LayerWidth and 4.
	public uint[] LayerHeight = new uint[8];
	public int[] LayerZAxis = new int[8]; // Should be { -300, -200, -100, 0, 100, 200, 300, 400 }, but nothing happens when you change these
	public byte[] DetailLevel = new byte[8]; // is set to 02 for layer 5 in Battle1 and Battle3, but is 00 the rest of the time, at least for JJ2 levels. No clear effect of altering. Name from Michiel.
	public int[] WaveX = new int[8]; // name from Michiel; function unknown
	public int[] WaveY = new int[8]; // name from Michiel; function unknown
	public uint[] LayerXSpeed = new uint[8]; // Divide by 65536 to get value seen in JCS
	public uint[] LayerYSpeed = new uint[8]; // Divide by 65536 to get value seen in JCSvalue
	public uint[] LayerAutoXSpeed = new uint[8]; // Divide by 65536 to get value seen in JCS
	public uint[] LayerAutoYSpeed = new uint[8]; // Divide by 65536 to get value seen in JCS
	public byte[] LayerTextureMode = new byte[8];
	public byte[,] LayerTextureParams = new byte[8,3]; // Red, Green, Blue
	public ushort AnimOffset; // MAX_TILES minus AnimCount, also called StaticTiles
	public uint[] TilesetEvents = new uint[Constants.MAX_TILES_TSF]; // same format as in Data2, for tiles
	public bool[] IsEachTileFlipped = new bool[Constants.MAX_TILES_TSF]; // set to 1 if a tile appears flipped anywhere in the level
	public byte[] TileTypes = new byte[Constants.MAX_TILES_TSF]; // translucent=1 or caption=4, basically. Doesn't work on animated tiles.
	public byte[] XMask = new byte[Constants.MAX_TILES_TSF]; // tested to equal all zeroes in almost 4000 different levels, and editing it has no appreciable effect.  // Name from Michiel, who claims it is totally unused.
	public Animated_Tile[] Anim = new Animated_Tile[256]; // or [256] in TSF.
	// only the first [AnimCount] are needed; JCS will save all 128/256, but JJ2 will run your level either way.
	public byte[] Padding = new byte[512]; //all zeroes; only in levels saved with JCS
}

public class J2L_Data1_AGA
{
	public ushort JCSHorizontalOffset; // In pixels
	public ushort Security1; // 0xBA00 if passworded, 0x0000 otherwise
	public ushort JCSVerticalOffset; // In pixels
	public ushort Security2; // 0xBE00 if passworded, 0x0000 otherwise
	public byte SecAndLayer; // Upper 4 bits are set if passworded, zero otherwise. Lower 4 bits represent the layer number as last saved in JCS.
	public byte MinLight; // Multiply by 1.5625 to get value seen in JCS
	public byte StartLight; // Multiply by 1.5625 to get value seen in JCS
	public ushort AnimCount;
	public bool VerticalSplitscreen;
	public bool IsLevelMultiplayer;
	public uint BufferSize;
	public byte[] LevelName = new byte[32];
	public byte[] Tileset = new byte[32];
	public byte[] BonusLevel = new byte[32];
	public byte[] NextLevel = new byte[32];
	public byte[] SecretLevel = new byte[32];
	public byte[] MusicFile = new byte[32];
	public byte[,] HelpString = new byte[16,512];
	public byte[,] SoundEffectPointer = new byte[48,64]; // only in version 256 (AGA)
	public uint[] LayerMiscProperties = new uint[8]; // Each property is a bit in the following order: Tile Width, Tile Height, Limit Visible Region, Texture Mode, Parallax Stars. This leaves 27 (32-5) unused bits for each layer?
	public byte[] Type = new byte[8]; // name from Michiel; function unknown
	public bool[] DoesLayerHaveAnyTiles = new bool[8]; // must always be set to true for layer 4, or JJ2 will crash
	public uint[] LayerWidth = new uint[8];
	public uint[] LayerRealWidth = new uint[8]; // for when "Tile Width" is checked. The lowest common multiple of LayerWidth and 4.
	public uint[] LayerHeight = new uint[8];
	public int[] LayerZAxis = new int[8]; // Should be { -300, -200, -100, 0, 100, 200, 300, 400 }, but nothing happens when you change these
	public byte[] DetailLevel = new byte[8]; // is set to 02 for layer 5 in Battle1 and Battle3, but is 00 the rest of the time, at least for JJ2 levels. No clear effect of altering. Name from Michiel.
	public int[] WaveX = new int[8]; // name from Michiel; function unknown
	public int[] WaveY = new int[8]; // name from Michiel; function unknown
	public uint[] LayerXSpeed = new uint[8]; // Divide by 65536 to get value seen in JCS
	public uint[] LayerYSpeed = new uint[8]; // Divide by 65536 to get value seen in JCSvalue
	public uint[] LayerAutoXSpeed  = new uint[8]; // Divide by 65536 to get value seen in JCS
	public uint[] LayerAutoYSpeed = new uint[8]; // Divide by 65536 to get value seen in JCS
	public byte[] LayerTextureMode = new byte[8];
	public byte[,] LayerTextureParams = new byte[8,3]; // Red, Green, Blue
	public ushort AnimOffset; // MAX_TILES minus AnimCount, also called StaticTiles
	public uint[] TilesetEvents = new uint[Constants.MAX_TILES_TSF]; // same format as in Data2, for tiles
	public bool[] IsEachTileFlipped = new bool[Constants.MAX_TILES_TSF]; // set to 1 if a tile appears flipped anywhere in the level
	public byte[] TileTypes = new byte[Constants.MAX_TILES_TSF]; // translucent=1 or caption=4, basically. Doesn't work on animated tiles.
	public byte[] XMask = new byte[Constants.MAX_TILES_TSF]; // tested to equal all zeroes in almost 4000 different levels, and editing it has no appreciable effect.  // Name from Michiel, who claims it is totally unused.
	public byte[] UnknownAGA = new byte[32768]; // only in version 256 (AGA)
	public Animated_Tile[] Anim = new Animated_Tile[256]; // or [256] in TSF.
	// only the first [AnimCount] are needed; JCS will save all 128/256, but JJ2 will run your level either way.
	public byte[] Padding = new byte[512]; //all zeroes; only in levels saved with JCS
}

public class J2L_Event
{
	public byte EventID;
	public byte[] EventData = new byte[3];
}

public class TileCoord
{
	public int x;
	public int y;
}

public class J2L_Tile
{
	public int index;
	public bool flipped;
}

public class J2L_Data2_1_23
{
	public List<J2L_Event> Events = new List<J2L_Event>();

	public J2L_Data2_1_23() {}
	/*
	public J2L_Data2_1_23(J2L_Data2_1_23 other)
	{
		for (int i = 0; i < other.Events.size(); i++)
		{
			Events.push_back(other.Events[i]);
		}
	}
	*/
}

// typedef char EventName[64];

public class Data2AGAPart1
{
	public ushort NumberOfDistinctEvents;
	public byte[,] Events;	// should have been EventName *Events but C# doesnt allow typedefs
}

public class AGAString
{
	private uint StringLength; //including null byte
	private byte[] String; //ends with a null byte

	public AGAString(byte[] bytes, uint length)
	{
		for(int i=0; i<length; i++)
			String[i] = bytes[i];
	}
}

public class AGAEvent
{
	ushort XPos;
	ushort YPos;
	ushort EventID;
	uint Marker;
	//the rest of the structure is only included if the highest bit of Marker is set.
	uint LengthOfParameterSection; //including its own four bytes
	ushort AreThereStrings; //02 if yes, 00 otherwise?
	ushort NumberOfLongs;
	uint[] Parameter;
	AGAString[] parameters; //I guess it just keeps looking for strings until it hits the LengthOfParameterSection length?
}

public class J2L_Data2_AGA
{
	public Data2AGAPart1 part1;
	public List<AGAEvent> Events;
}

public class Word
{
	public ushort[] Tiles = new ushort[4];
}

public class J2L_Data3
{
	public List<Word> Dictionary = new List<Word>();
}

public class J2L_Data4
{
	public List<ushort>[] Layers = new List<ushort>[8];
}

public class Level {
	public LEVL_Header header = new LEVL_Header();

	public J2L_Data1_1_23 Data1_1_23 = null;
	public J2L_Data1_TSF Data1_TSF = null;
	public J2L_Data1_AGA Data1_AGA = null;
	public J2L_Data2_1_23 Data2_1_23 = null;
	public J2L_Data2_AGA Data2_AGA = null;
	public J2L_Data3 Data3_1_23 = new J2L_Data3();
	public J2L_Data4 Data4_1_23 = new J2L_Data4();

	public byte[] TileFrame;

	//public uint8_t *TileFrame;

	public void LoadLevelData(string LevelName)
	{
		int offset = 0;

		TextAsset ta = Resources.Load("Jazz2/" + LevelName + "_level", typeof(TextAsset)) as TextAsset;
		byte[] bytes = ta.bytes;

		// parse the level header
		header.Copyright = Utils.getBytes(bytes, ref offset, 180);
		header.Magic = Utils.getBytes(bytes, ref offset, 4);
		header.PasswordHash = Utils.getBytes(bytes, ref offset, 4);
		header.LevelName = Utils.getBytes(bytes, ref offset, 32);
		header.Version = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2));
		header.FileSize = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		header.CRC32 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		header.CData1 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		header.UData1 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		header.CData2 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		header.UData2 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		header.CData3 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		header.UData3 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		header.CData4 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		header.UData4 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));

		// decompress data1 of level
		byte[] buf = new byte[header.UData1];
		buf = Ionic.Zlib.ZlibStream.UncompressBuffer(Utils.getBytes(bytes, ref offset, (int)header.CData1));

		// load data 1
		LoadData1(buf);

		// decompress data2 of level
		buf = new byte[header.UData2];
		buf = Ionic.Zlib.ZlibStream.UncompressBuffer(Utils.getBytes(bytes, ref offset, (int)header.CData2));

		// read the J2L data 2 of level
		LoadData2(buf);

		// decompress data3 of level
		buf = new byte[header.UData3];
		buf = Ionic.Zlib.ZlibStream.UncompressBuffer(Utils.getBytes(bytes, ref offset, (int)header.CData3));

		// read the J2L data 3 of level
		LoadData3(ref buf, header.UData3);

		// decompress data4 of level
		buf = new byte[header.UData4];
		buf = Ionic.Zlib.ZlibStream.UncompressBuffer(Utils.getBytes(bytes, ref offset, (int)header.CData4));

		// read the J2L data 4 of level
		LoadData4(ref buf, header.UData4);

		// init the TileFrame
		TileFrame = new byte[GetLayerWidth(3) * GetLayerHeight(3)];
		for(int i=0; i<GetLayerWidth(3) * GetLayerHeight(3); i++)
			TileFrame[i] = 0;
	}

	private void LoadData1(byte[] Data1)
	{
		if (Data1 != null)
		{
			if(header.Version == Constants.VERSION_1_23)
			{
				Data1_1_23 = new J2L_Data1_1_23();
				ReadJ2L_Data_1_23(ref Data1_1_23, ref Data1);
			}
			else if(header.Version == Constants.VERSION_TSF)
			{
				Data1_TSF = new J2L_Data1_TSF();
				ReadJ2L_Data_TSF(ref Data1_TSF, ref Data1);
			}
			else if(header.Version == Constants.VERSION_GIGANTIC)
			{
				Data1_AGA = new J2L_Data1_AGA();
				ReadJ2L_Data_AGA(ref Data1_AGA, ref Data1);
			}
		}
	}

	private void LoadData2(byte[] Data2)
	{
		if (Data2 != null)
		{
			if(header.Version == Constants.VERSION_1_23 || header.Version == Constants.VERSION_TSF)
			{
				Data2_1_23 = new J2L_Data2_1_23();
				ReadJ2L_Data2_1_23(ref Data2_1_23, Data2, header.UData2);
			}
			else if(header.Version == Constants.VERSION_GIGANTIC)
			{
				Data2_AGA = new J2L_Data2_AGA();
				ReadJ2L_Data2_1_23(ref Data2_1_23, Data2, header.UData2);
			}
		}
	}

	private static void ReadJ2L_Data_1_23(ref J2L_Data1_1_23 Data1, ref byte[] bytes)
	{
		Data1 = new J2L_Data1_1_23();

		int offset = 0;
		Data1.JCSHorizontalOffset = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2)); // In pixels
		Data1.Security1 = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2)); // 0xBA00 if passworded, 0x0000 otherwise
		Data1.JCSVerticalOffset = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2)); // In pixels
		Data1.Security2 = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2)); // 0xBE00 if passworded, 0x0000 otherwise
		Data1.SecAndLayer = Utils.getByte(bytes, ref offset); // Upper 4 bits are set if passworded, zero otherwise. Lower 4 bits represent the layer number as last saved in JCS.
		Data1.MinLight = Utils.getByte(bytes, ref offset); // Multiply by 1.5625 to get value seen in JCS
		Data1.StartLight = Utils.getByte(bytes, ref offset); // Multiply by 1.5625 to get value seen in JCS
		Data1.AnimCount = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2));
		Data1.VerticalSplitscreen = ((int)Utils.getByte(bytes, ref offset) != 0)? true:false ;
		Data1.IsLevelMultiplayer = ((int)Utils.getByte(bytes, ref offset) != 0)? true:false ;
		Data1.BufferSize = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		Data1.LevelName = Utils.getBytes(bytes, ref offset, 32);
		Data1.Tileset = Utils.getBytes(bytes, ref offset, 32);
		Data1.BonusLevel = Utils.getBytes(bytes, ref offset, 32);
		Data1.NextLevel = Utils.getBytes(bytes, ref offset, 32);
		Data1.SecretLevel = Utils.getBytes(bytes, ref offset, 32);
		Data1.MusicFile = Utils.getBytes(bytes, ref offset, 32);


		for(int i=0; i<16; i++)
			for(int j=0; j<512; j++)
				Data1.HelpString[i,j] = Utils.getByte(bytes, ref offset);

		for(int i=0; i<8; i++)
			Data1.LayerMiscProperties[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// Each property is a bit in the following order: Tile Width, Tile Height, Limit Visible Region, Texture Mode, Parallax Stars. This leaves 27 (32-5) unused bits for each layer?
		
		Data1.Type = Utils.getBytes(bytes, ref offset, 8);	// name from Michiel; function unknown
		for(int i=0; i<8; i++)
			Data1.DoesLayerHaveAnyTiles[i] = (Utils.getByte(bytes, ref offset) != 0)? true:false;	// must always be set to true for layer 4, or JJ2 will crash
		
		for(int i=0; i<8; i++)
			Data1.LayerWidth[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));

		for(int i=0; i<8; i++)
			Data1.LayerRealWidth[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// for when "Tile Width" is checked. The lowest common multiple of LayerWidth and 4.
	
		for(int i=0; i<8; i++)
			Data1.LayerHeight[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));

		for(int i=0; i<8; i++)
			Data1.LayerZAxis[i] = Utils.bytesToLong(Utils.getBytes(bytes, ref offset, 4));

		Data1.DetailLevel = Utils.getBytes(bytes, ref offset, 8); // is set to 02 for layer 5 in Battle1 and Battle3, but is 00 the rest of the time, at least for JJ2 levels. No clear effect of altering. Name from Michiel.
		
		for(int i=0; i<8; i++)
			Data1.WaveX[i] = Utils.bytesToLong(Utils.getBytes(bytes, ref offset, 4));	// name from Michiel; function unknown

		for(int i=0; i<8; i++)
			Data1.WaveY[i] = Utils.bytesToLong(Utils.getBytes(bytes, ref offset, 4));	// name from Michiel; function unknown

		for(int i=0; i<8; i++)
			Data1.LayerXSpeed[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// Divide by 65536 to get value seen in JCS
		
		for(int i=0; i<8; i++)
			Data1.LayerYSpeed[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// Divide by 65536 to get value seen in JCS

		for(int i=0; i<8; i++)
			Data1.LayerAutoXSpeed[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// Divide by 65536 to get value seen in JCS

		for(int i=0; i<8; i++)
			Data1.LayerAutoYSpeed[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// Divide by 65536 to get value seen in JCS
		
		Data1.LayerTextureMode = Utils.getBytes(bytes, ref offset, 8);
		
		for(int i=0; i<8; i++)
			for(int j=0; j<3; j++)
				Data1.LayerTextureParams[i,j] = Utils.getByte(bytes, ref offset);	// Red, Green, Blue

		Data1.AnimOffset = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2)); // MAX_TILES minus AnimCount, also called StaticTiles

		for(int i=0; i<Constants.MAX_TILES_1_23; i++)
			Data1.TilesetEvents[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// same format as in Data2, for tiles

		for(int i=0; i<Constants.MAX_TILES_1_23; i++)
			Data1.IsEachTileFlipped[i] = (Utils.getByte(bytes, ref offset) != 0)? true:false;	// set to 1 if a tile appears flipped anywhere in the level
		
		Data1.TileTypes = Utils.getBytes(bytes, ref offset, Constants.MAX_TILES_1_23);	// translucent=1 or caption=4, basically. Doesn't work on animated tiles.
		Data1.XMask = Utils.getBytes(bytes, ref offset, Constants.MAX_TILES_1_23);	// tested to equal all zeroes in almost 4000 different levels, and editing it has no appreciable effect.  // Name from Michiel, who claims it is totally unused.
		
		for (int i = 0; i < 128; i++)
		{
			Data1.Anim[i] = new Animated_Tile();
			ReadAnimatedTile(ref Data1.Anim[i], bytes, ref offset); // or [256] in TSF.
		}
	}

	private static void ReadJ2L_Data_TSF(ref J2L_Data1_TSF Data1, ref byte[] bytes)
	{
		Data1 = new J2L_Data1_TSF();

		int offset = 0;
		Data1.JCSHorizontalOffset = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2)); // In pixels
		Data1.Security1 = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2)); // 0xBA00 if passworded, 0x0000 otherwise
		Data1.JCSVerticalOffset = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2)); // In pixels
		Data1.Security2 = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2)); // 0xBE00 if passworded, 0x0000 otherwise
		Data1.SecAndLayer = Utils.getByte(bytes, ref offset); // Upper 4 bits are set if passworded, zero otherwise. Lower 4 bits represent the layer number as last saved in JCS.
		Data1.MinLight = Utils.getByte(bytes, ref offset); // Multiply by 1.5625 to get value seen in JCS
		Data1.StartLight = Utils.getByte(bytes, ref offset); // Multiply by 1.5625 to get value seen in JCS
		Data1.AnimCount = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2));
		Data1.VerticalSplitscreen = ((int)Utils.getByte(bytes, ref offset) != 0)? true:false ;
		Data1.IsLevelMultiplayer = ((int)Utils.getByte(bytes, ref offset) != 0)? true:false ;
		Data1.BufferSize = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		Data1.LevelName = Utils.getBytes(bytes, ref offset, 32);
		Data1.Tileset = Utils.getBytes(bytes, ref offset, 32);
		Data1.BonusLevel = Utils.getBytes(bytes, ref offset, 32);
		Data1.NextLevel = Utils.getBytes(bytes, ref offset, 32);
		Data1.SecretLevel = Utils.getBytes(bytes, ref offset, 32);
		Data1.MusicFile = Utils.getBytes(bytes, ref offset, 32);


		for(int i=0; i<16; i++)
			for(int j=0; j<512; j++)
				Data1.HelpString[i,j] = Utils.getByte(bytes, ref offset);

		for(int i=0; i<8; i++)
			Data1.LayerMiscProperties[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// Each property is a bit in the following order: Tile Width, Tile Height, Limit Visible Region, Texture Mode, Parallax Stars. This leaves 27 (32-5) unused bits for each layer?
		
		Data1.Type = Utils.getBytes(bytes, ref offset, 8);	// name from Michiel; function unknown

		for(int i=0; i<8; i++)
			Data1.DoesLayerHaveAnyTiles[i] = (Utils.getByte(bytes, ref offset) != 0)? true:false;	// must always be set to true for layer 4, or JJ2 will crash
		
		for(int i=0; i<8; i++)
			Data1.LayerWidth[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));

		for(int i=0; i<8; i++)
			Data1.LayerRealWidth[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// for when "Tile Width" is checked. The lowest common multiple of LayerWidth and 4.
	
		for(int i=0; i<8; i++)
			Data1.LayerHeight[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));

		for(int i=0; i<8; i++)
			Data1.LayerZAxis[i] = Utils.bytesToLong(Utils.getBytes(bytes, ref offset, 4));

		Data1.DetailLevel = Utils.getBytes(bytes, ref offset, 8); // is set to 02 for layer 5 in Battle1 and Battle3, but is 00 the rest of the time, at least for JJ2 levels. No clear effect of altering. Name from Michiel.
		
		for(int i=0; i<8; i++)
			Data1.WaveX[i] = Utils.bytesToLong(Utils.getBytes(bytes, ref offset, 4));	// name from Michiel; function unknown

		for(int i=0; i<8; i++)
			Data1.WaveY[i] = Utils.bytesToLong(Utils.getBytes(bytes, ref offset, 4));	// name from Michiel; function unknown

		for(int i=0; i<8; i++)
			Data1.LayerXSpeed[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// Divide by 65536 to get value seen in JCS
		
		for(int i=0; i<8; i++)
			Data1.LayerYSpeed[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// Divide by 65536 to get value seen in JCS

		for(int i=0; i<8; i++)
			Data1.LayerAutoXSpeed[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// Divide by 65536 to get value seen in JCS

		for(int i=0; i<8; i++)
			Data1.LayerAutoYSpeed[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// Divide by 65536 to get value seen in JCS
		
		Data1.LayerTextureMode = Utils.getBytes(bytes, ref offset, 8);
		
		for(int i=0; i<8; i++)
			for(int j=0; j<3; j++)
				Data1.LayerTextureParams[i,j] = Utils.getByte(bytes, ref offset);	// Red, Green, Blue

		Data1.AnimOffset = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2)); // MAX_TILES minus AnimCount, also called StaticTiles

		for(int i=0; i<Constants.MAX_TILES_TSF; i++)
			Data1.TilesetEvents[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// same format as in Data2, for tiles

		for(int i=0; i<Constants.MAX_TILES_TSF; i++)
			Data1.IsEachTileFlipped[i] = (Utils.getByte(bytes, ref offset) != 0)? true:false;	// set to 1 if a tile appears flipped anywhere in the level
		
		Data1.TileTypes = Utils.getBytes(bytes, ref offset, Constants.MAX_TILES_TSF);	// translucent=1 or caption=4, basically. Doesn't work on animated tiles.
		Data1.XMask = Utils.getBytes(bytes, ref offset, Constants.MAX_TILES_TSF);	// tested to equal all zeroes in almost 4000 different levels, and editing it has no appreciable effect.  // Name from Michiel, who claims it is totally unused.
		
		for (int i = 0; i < 256; i++)
		{
			Data1.Anim[i] = new Animated_Tile();
			ReadAnimatedTile(ref Data1.Anim[i], bytes, ref offset); // or [256] in TSF.
		}
	}

	private static void ReadJ2L_Data_AGA(ref J2L_Data1_AGA Data1, ref byte[] bytes)
	{
		Data1 = new J2L_Data1_AGA();

		int offset = 0;
		Data1.JCSHorizontalOffset = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2)); // In pixels
		Data1.Security1 = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2)); // 0xBA00 if passworded, 0x0000 otherwise
		Data1.JCSVerticalOffset = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2)); // In pixels
		Data1.Security2 = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2)); // 0xBE00 if passworded, 0x0000 otherwise
		Data1.SecAndLayer = Utils.getByte(bytes, ref offset); // Upper 4 bits are set if passworded, zero otherwise. Lower 4 bits represent the layer number as last saved in JCS.
		Data1.MinLight = Utils.getByte(bytes, ref offset); // Multiply by 1.5625 to get value seen in JCS
		Data1.StartLight = Utils.getByte(bytes, ref offset); // Multiply by 1.5625 to get value seen in JCS
		Data1.AnimCount = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2));
		Data1.VerticalSplitscreen = ((int)Utils.getByte(bytes, ref offset) != 0)? true:false ;
		Data1.IsLevelMultiplayer = ((int)Utils.getByte(bytes, ref offset) != 0)? true:false ;
		Data1.BufferSize = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		Data1.LevelName = Utils.getBytes(bytes, ref offset, 32);
		Data1.Tileset = Utils.getBytes(bytes, ref offset, 32);
		Data1.BonusLevel = Utils.getBytes(bytes, ref offset, 32);
		Data1.NextLevel = Utils.getBytes(bytes, ref offset, 32);
		Data1.SecretLevel = Utils.getBytes(bytes, ref offset, 32);
		Data1.MusicFile = Utils.getBytes(bytes, ref offset, 32);


		for(int i=0; i<16; i++)
			for(int j=0; j<512; j++)
				Data1.HelpString[i,j] = Utils.getByte(bytes, ref offset);

		// SoundEffectPointer only in version 256 (AGA)
		for(int i=0; i<48; i++)
			for(int j=0; j<64; j++)
				Data1.SoundEffectPointer[i,j] = Utils.getByte(bytes, ref offset);

		for(int i=0; i<8; i++)
			Data1.LayerMiscProperties[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// Each property is a bit in the following order: Tile Width, Tile Height, Limit Visible Region, Texture Mode, Parallax Stars. This leaves 27 (32-5) unused bits for each layer?
		
		Data1.Type = Utils.getBytes(bytes, ref offset, 8);	// name from Michiel; function unknown

		for(int i=0; i<8; i++)
			Data1.DoesLayerHaveAnyTiles[i] = (Utils.getByte(bytes, ref offset) != 0)? true:false;	// must always be set to true for layer 4, or JJ2 will crash
		
		for(int i=0; i<8; i++)
			Data1.LayerWidth[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));

		for(int i=0; i<8; i++)
			Data1.LayerRealWidth[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// for when "Tile Width" is checked. The lowest common multiple of LayerWidth and 4.
	
		for(int i=0; i<8; i++)
			Data1.LayerHeight[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));

		for(int i=0; i<8; i++)
			Data1.LayerZAxis[i] = Utils.bytesToLong(Utils.getBytes(bytes, ref offset, 4));

		Data1.DetailLevel = Utils.getBytes(bytes, ref offset, 8); // is set to 02 for layer 5 in Battle1 and Battle3, but is 00 the rest of the time, at least for JJ2 levels. No clear effect of altering. Name from Michiel.
		
		for(int i=0; i<8; i++)
			Data1.WaveX[i] = Utils.bytesToLong(Utils.getBytes(bytes, ref offset, 4));	// name from Michiel; function unknown

		for(int i=0; i<8; i++)
			Data1.WaveY[i] = Utils.bytesToLong(Utils.getBytes(bytes, ref offset, 4));	// name from Michiel; function unknown

		for(int i=0; i<8; i++)
			Data1.LayerXSpeed[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// Divide by 65536 to get value seen in JCS
		
		for(int i=0; i<8; i++)
			Data1.LayerYSpeed[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// Divide by 65536 to get value seen in JCS

		for(int i=0; i<8; i++)
			Data1.LayerAutoXSpeed[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// Divide by 65536 to get value seen in JCS

		for(int i=0; i<8; i++)
			Data1.LayerAutoYSpeed[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// Divide by 65536 to get value seen in JCS
		
		Data1.LayerTextureMode = Utils.getBytes(bytes, ref offset, 8);
		
		for(int i=0; i<8; i++)
			for(int j=0; j<3; j++)
				Data1.LayerTextureParams[i,j] = Utils.getByte(bytes, ref offset);	// Red, Green, Blue

		Data1.AnimOffset = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2)); // MAX_TILES minus AnimCount, also called StaticTiles

		for(int i=0; i<Constants.MAX_TILES_TSF; i++)
			Data1.TilesetEvents[i] = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));	// same format as in Data2, for tiles

		for(int i=0; i<Constants.MAX_TILES_TSF; i++)
			Data1.IsEachTileFlipped[i] = (Utils.getByte(bytes, ref offset) != 0)? true:false;	// set to 1 if a tile appears flipped anywhere in the level
		
		Data1.TileTypes = Utils.getBytes(bytes, ref offset, Constants.MAX_TILES_TSF);	// translucent=1 or caption=4, basically. Doesn't work on animated tiles.
		Data1.XMask = Utils.getBytes(bytes, ref offset, Constants.MAX_TILES_TSF);	// tested to equal all zeroes in almost 4000 different levels, and editing it has no appreciable effect.  // Name from Michiel, who claims it is totally unused.
		
		// UnknownAGA only in version 256 (AGA)
		Data1.UnknownAGA = Utils.getBytes(bytes, ref offset, 32768);

		for (int i = 0; i < 256; i++)
		{
			Data1.Anim[i] = new Animated_Tile();
			ReadAnimatedTile(ref Data1.Anim[i], bytes, ref offset); // or [256] in TSF.
		}
	}

	private static void ReadAnimatedTile(ref Animated_Tile Anim, byte[] bytes, ref int offset)
	{
		Anim.FrameWait = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2));
		Anim.RandomWait = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2));
		Anim.PingPongWait = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2));
		Anim.PingPong = ((int)Utils.getByte(bytes, ref offset) != 0)? true:false ;
		Anim.Speed = Utils.getByte(bytes, ref offset);
		Anim.FrameCount = Utils.getByte(bytes, ref offset);

		for(int i=0; i<64; i++)
			Anim.Frame[i] = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2));
	}

	private static void ReadJ2L_Data2_1_23(ref J2L_Data2_1_23 Data2, byte[] bytes, uint length)
	{
		for (uint i = 0; i < length; i += 4)
		{
			J2L_Event e = new J2L_Event();
			e.EventID = bytes[i];
			e.EventData[0] = bytes[i+1];
			e.EventData[1] = bytes[i+2];
			e.EventData[2] = bytes[i+3];
			
			//if (e.EventID == 0x1F)
			//	printf("MP Start at %d, %d\n", (i / 4) % 128, (i / 4) / 128);

			Data2.Events.Add(e);
		}
	}

	private static void ReadData2AGAPart1(ref Data2AGAPart1 part1, byte[] bytes, ref int offset)
	{
		offset = 2;	// was offset = sizeof(uint16_t)
		int x=0;

		part1.NumberOfDistinctEvents = Utils.bytesToShort(Utils.getBytes(bytes, ref x, 2));
		part1.Events = new byte[part1.NumberOfDistinctEvents, 64];

		for (int i = 0; i < part1.NumberOfDistinctEvents; i++)
			for(int j=0; j<64; j++)
				part1.Events[i,j] = Utils.getByte(bytes, ref offset);
	}


	private void LoadData3(ref byte[] bytes, uint size)
	{
		if(Data3_1_23 != null)
		{
			int offset = 0;

			for(uint i = 0; i < size; i += 8)
			{
				Word w = new Word();

				for(int j=0; j<4; j++)
					w.Tiles[j] = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2));

				Data3_1_23.Dictionary.Add(w);
			}
		}
	}

	private void LoadData4(ref byte[] bytes, uint size)
	{
		int offset = 0;

		for (int i = 0; i < 8; i++)
		{
			Data4_1_23.Layers[i] = new List<ushort>();

			bool TilesDefinedForLayer = false;
			uint LayerWidth = 0;
			uint LayerHeight = 0;

			if(Data1_1_23 != null)
			{
				TilesDefinedForLayer = Data1_1_23.DoesLayerHaveAnyTiles[i];
				LayerWidth = Data1_1_23.LayerRealWidth[i];
				LayerHeight = Data1_1_23.LayerHeight[i];
			}
			else if (Data1_TSF != null)
			{
				TilesDefinedForLayer = Data1_TSF.DoesLayerHaveAnyTiles[i];
				LayerWidth = Data1_TSF.LayerRealWidth[i];
				LayerHeight = Data1_TSF.LayerHeight[i];
			}
			else if (Data1_AGA != null)
			{
				TilesDefinedForLayer = Data1_AGA.DoesLayerHaveAnyTiles[i];
				LayerWidth = Data1_AGA.LayerRealWidth[i];
				LayerHeight = Data1_AGA.LayerHeight[i];
			}

			if (TilesDefinedForLayer)
			{
				uint wordWidth = LayerWidth / 4;
				if ((LayerWidth % 4) > 0)
					wordWidth += 1;
				for (uint s = 0; s < LayerHeight; s++)
				{
					for (uint t = 0; t < wordWidth; t++)
					{
						ushort word;
						word = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2));
						//ReadAndAdvance(word, Data4, offset);
						Data4_1_23.Layers[i].Add(word);
					}
				}
			}
		}
	}

	public uint GetLayerWidth(uint layer)
	{
		if (layer < 8)
		{
			if (Data1_1_23 != null)
				return (Data1_1_23.LayerRealWidth[layer]);
			else if (Data1_TSF != null)
				return (Data1_TSF.LayerRealWidth[layer]);
			else if (Data1_AGA != null)
				return (Data1_AGA.LayerRealWidth[layer]);
		}
		return 0;
	}

	public uint GetLayerHeight(uint layer)
	{
		if (layer < 8)
		{
			if (Data1_1_23 != null)
				return (Data1_1_23.LayerHeight[layer]);
			else if (Data1_TSF != null)
				return (Data1_TSF.LayerHeight[layer]);
			else if (Data1_AGA != null)
				return (Data1_AGA.LayerHeight[layer]);
		}
		return 0;
	}

	public float GetLayerXSpeed(uint layer)
	{
		if (layer < 7)
		{
			if (Data1_1_23 != null)
			{
				return (float)Data1_1_23.LayerXSpeed[layer] / (float)Data1_1_23.LayerXSpeed[3];
			}
		}
		return 0;
	}

	public float GetLayerYSpeed(uint layer)
	{
		if (layer < 7)
		{
			if (Data1_1_23 != null)
			{
				return (float)Data1_1_23.LayerYSpeed[layer] / (float)Data1_1_23.LayerYSpeed[3];
			}
		}
		return 0;
	}

	public byte[] GetTileset()
	{
		if(Data1_1_23 != null)
			return Data1_1_23.Tileset;
		if(Data1_AGA != null)
			return Data1_AGA.Tileset;
		if(Data1_TSF != null)
			return Data1_TSF.Tileset;

		return null;
	}

	public byte[] GetLevelName()
	{
		if(Data1_1_23 != null)
			return Data1_1_23.LevelName;
		if(Data1_AGA != null)
			return Data1_AGA.LevelName;
		if(Data1_TSF != null)
			return Data1_TSF.LevelName;

		return null;
	}

	public byte[] GetNextLevel()
	{
		if(Data1_1_23 != null)
			return Data1_1_23.NextLevel;
		if(Data1_AGA != null)
			return Data1_AGA.NextLevel;
		if(Data1_TSF != null)
			return Data1_TSF.NextLevel;

		return null;
	}

	public byte[] GetMusicFile()
	{
		if(Data1_1_23 != null)
			return Data1_1_23.MusicFile;
		if(Data1_AGA != null)
			return Data1_AGA.MusicFile;
		if(Data1_TSF != null)
			return Data1_TSF.MusicFile;

		return null;
	}

	public ushort GetVersion()
	{
		return header.Version;
	}

	public bool DoesLayerHaveAnyTiles(uint layer)
	{
		if(layer > 7)
			return false;

		if(Data1_1_23 != null)
			return Data1_1_23.DoesLayerHaveAnyTiles[layer];
		if(Data1_AGA != null)
			return Data1_AGA.DoesLayerHaveAnyTiles[layer];
		if(Data1_TSF != null)
			return Data1_TSF.DoesLayerHaveAnyTiles[layer];

		return false;
	}

	public uint GetTileCount(uint layer)
	{
		if (layer < 8)
		{
			if (Data1_1_23 != null)
				return (Data1_1_23.DoesLayerHaveAnyTiles[layer] != false) ? Data1_1_23.LayerRealWidth[layer] * Data1_1_23.LayerHeight[layer] : 0;
			else if (Data1_AGA != null)
				return (Data1_AGA.DoesLayerHaveAnyTiles[layer] != false) ? Data1_AGA.LayerRealWidth[layer] * Data1_AGA.LayerHeight[layer] : 0;
			else if (Data1_TSF != null)
				return (Data1_TSF.DoesLayerHaveAnyTiles[layer] != false) ? Data1_TSF.LayerRealWidth[layer] * Data1_TSF.LayerHeight[layer] : 0;
		}
		return 0;
	}

	public J2L_Tile GetTile(uint layer, uint tileXCoord, uint tileYCoord, float timeElapsed)
	{
		uint stride = GetLayerWidth(layer);
		stride += (((stride % 4) > 0) ? (4 - (stride % 4)) : 0);
		int ind = (int)((tileYCoord * stride) + tileXCoord);

		J2L_Tile tile = new J2L_Tile();
		tile.flipped = false;
		tile.index = -1;

		if (layer > 7)
			return tile;
		if (Data4_1_23 != null)
		{
			ushort bitmask = (ushort)~((header.Version == Constants.VERSION_1_23) ? Constants.FLIPPED_1_23 : Constants.FLIPPED_TSF);
			int DictionaryIndex = Data4_1_23.Layers[layer][ind/4];
			tile.index = Data3_1_23.Dictionary[DictionaryIndex].Tiles[ind % 4];

			if ((tile.index & ~bitmask) != 0)
			{
				tile.index &= bitmask;
				tile.flipped = true;
			}

			if (tile.index >= Data1_1_23.AnimOffset)
			{
				Animated_Tile anim = Data1_1_23.Anim[tile.index - Data1_1_23.AnimOffset];
				if (anim.PingPong)
				{
					int frame = (int)(Math.Round(anim.Speed * Utils.max(timeElapsed, 0.0f))) % (2*anim.FrameCount - 2);
					if (frame >= anim.FrameCount)
					{
						frame = (2 * anim.FrameCount) - frame - 1;
					}
					tile.index = anim.Frame[frame];
				}
				else
				{
					int frame = (int)(Math.Round(anim.Speed * Utils.max(timeElapsed, 0.0f))) % anim.FrameCount;
					if((anim.Speed == 0) && (layer == 3))
					{
						frame = TileFrame[ind];
					}
					tile.index = anim.Frame[frame];
				}
				if ((tile.index & ~bitmask) != 0)
				{
					tile.index &= bitmask;
					tile.flipped = !tile.flipped;
				}
			}
		}
		return tile;
	}

	/*
	public static J2L_Event GetEvent(J2L_Data2_1_23 Data2_1_23, uint tileXCoord, uint tileYCoord, uint layer3Width)
	{
		uint tileCoord = layer3Width * tileYCoord + tileXCoord;
		if(Data2_1_23.Events.Count > tileCoord)
			return Data2_1_23.Events[(int)tileCoord];
		return null;
	}

	public static J2L_Event GetTileEvent(J2L_Data1_1_23 Data1_1_23, uint tileXCoord, uint tileYCoord, uint layer3Width)
	{
		uint tileCoord = layer3Width * tileYCoord + tileXCoord;
		if(Constants.MAX_TILES_1_23 > tileCoord)
		{
			J2L_Event e = new J2L_Event();
				e.EventID = (byte)((Data1_1_23.TilesetEvents[(int)tileCoord]>>24) & 0xFF);
			return e;
		}
		return null;
	}

	
	public static TileCoord GetPlayerStart(J2L_Data1_1_23 Data1_1_23, J2L_Data2_1_23 Data2_1_23, bool Multiplayer)
	{
		TileCoord coord = new TileCoord();
		coord.x = 0;
		coord.y = 0;
		for (int i = 0; i < (Data1_1_23.LayerRealWidth[3] * Data1_1_23.LayerHeight[3]); i++)
		{
			
			if (Multiplayer)
			{
				if (Data2_1_23.Events[i].EventID == (byte)EventID.MultiplayerLevelStart)
				{
					coord.x = (int)(i % Data1_1_23.LayerRealWidth[3]);
					coord.y = (int)(i / Data1_1_23.LayerRealWidth[3]);
				}
			}
			else
			{
				if ((Data2_1_23.Events[i].EventID == (byte)EventID.JazzLevelStart) || (Data2_1_23.Events[i].EventID == (byte)EventID.SpazLevelStart))
				{
					coord.x = (int)(i % Data1_1_23.LayerRealWidth[3]);
					coord.y = (int)(i / Data1_1_23.LayerRealWidth[3]);
					break;
				}
			}
		}
		return coord;
	}
	*/

	public bool IsTileWidthChecked(uint layer)
	{
		if(layer > 7)
			return false;

		if(Data1_1_23 != null)
		{
			if((Data1_1_23.LayerMiscProperties[0] & 0x10000000) != 0)
				return true;
			return false;
		}

		if(Data1_AGA != null)
		{
			if((Data1_AGA.LayerMiscProperties[0] & 0x10000000) != 0)
				return true;
			return false;
		}

		if(Data1_TSF != null)
		{
			if((Data1_TSF.LayerMiscProperties[0] & 0x10000000) != 0)
				return true;
			return false;
		}

		return false;
	}
}
}

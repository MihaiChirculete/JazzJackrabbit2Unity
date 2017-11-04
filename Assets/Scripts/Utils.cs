using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class Utils {

	public static float max(float x, float y)
	{
		if(x > y)
			return x;

		return y;
	}

	public static object ByteArrayToObject(byte[] arrBytes)
    {
        MemoryStream memStream = new MemoryStream();
        BinaryFormatter binForm = new BinaryFormatter();

        memStream.Write(arrBytes, 0, arrBytes.Length);
        memStream.Seek(0, SeekOrigin.Begin);

        object obj = (object)binForm.Deserialize(memStream);

        return obj;
    }

    public static uint getByteFromNumber(uint x, int n) {
  		return (x >> 8*n) & 0xFF;
	}

    public static byte getByte(byte[] bytes, ref int offset)
    {
    	offset++;
    	
    	return bytes[offset];
    }

    public static byte[] getBytesNonRef(byte[] bytes, int offset, int count)
	{
		byte[] temp = new byte[count];

		for(int i=0; i<count; i++)
			temp[i] = bytes[offset+i];

		return temp;
	}

    public static byte[] getBytes(byte[] bytes, ref int offset, int count)
	{
		byte[] temp = new byte[count];

		for(int i=0; i<count; i++)
			temp[i] = bytes[offset+i];

		offset += count;
		return temp;
	}

	// starts from START and ends when NULL is found 
	public static string getString(byte[] bytes, int start, byte terminator = 0x00)
	{
		string s = "";

		while(bytes[start] != terminator)
		{
			s += (char)bytes[start];
			start++;
		}

		return s;
	}

	// returns a string that has COUNT characters in it
	public static string getString(byte[] bytes, int start, int count)
	{
		string s = "";
		for(int i=start; i<start+count; i++)
			s+= (char)bytes[i];

		return s;
	}

	public static uint bytesToULong(byte[] bytes)		// a 32 bit long (aka int in C#)
	{
		if(System.BitConverter.IsLittleEndian)
		{
			//Debug.Log("Is little endian");
		    System.Array.Reverse(bytes);
		}

		uint val = 0;
		val += (uint)(bytes[0] << 24);
		val += (uint)(bytes[1] << 16);
		val += (uint)(bytes[2] << 8);
		val += (uint)bytes[3];

		return val;
	}

	public static int bytesToLong(byte[] bytes)		// a 32 bit long (aka int in C#)
	{
		if(System.BitConverter.IsLittleEndian)
		{
			//Debug.Log("Is little endian");
		    System.Array.Reverse(bytes);
		}

		int val = 0;
		val += (int)(bytes[0] << 24);
		val += (int)(bytes[1] << 16);
		val += (int)(bytes[2] << 8);
		val += (int)bytes[3];

		return val;
	}

	public static ushort bytesToShort(byte[] bytes)
	{
		if(System.BitConverter.IsLittleEndian)
		{
			//Debug.Log("Is little endian");
		    System.Array.Reverse(bytes);
		}

		return (ushort)((bytes[0] << 8) | (bytes[1]));
	}

	public static int searchByte(byte[] bytes, byte x)
	{
		for(int i=0; i<bytes.Length; i++)
			if(bytes[i] == x)
			return i;

		return -1;
	}


	public static void ReadAnimatedTile(ref Animated_Tile Anim, byte[] bytes, ref int offset)
	{
		Anim.FrameWait = bytesToShort(getBytes(bytes, ref offset, 2));
		Anim.RandomWait = bytesToShort(getBytes(bytes, ref offset, 2));
		Anim.PingPongWait = bytesToShort(getBytes(bytes, ref offset, 2));
		Anim.PingPong = ((int)getByte(bytes, ref offset) != 0)? true:false ;
		Anim.Speed = getByte(bytes, ref offset);
		Anim.FrameCount = getByte(bytes, ref offset);

		for(int i=0; i<64; i++)
			Anim.Frame[i] = bytesToShort(getBytes(bytes, ref offset, 2));
	}

	public static void ReadLEVLHeader(ref LEVL_Header lh, ref byte[] bytes, ref int offset)
	{	
		lh.Copyright = Utils.getBytes(bytes, ref offset, 180);
		lh.Magic = Utils.getBytes(bytes, ref offset, 4);
		lh.PasswordHash = Utils.getBytes(bytes, ref offset, 4);
		lh.LevelName = Utils.getBytes(bytes, ref offset, 32);
		lh.Version = Utils.bytesToShort(Utils.getBytes(bytes, ref offset, 2));
		lh.FileSize = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		lh.CRC32 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		lh.CData1 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		lh.UData1 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		lh.CData2 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		lh.UData2 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		lh.CData3 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		lh.UData3 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		lh.CData4 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
		lh.UData4 = Utils.bytesToULong(Utils.getBytes(bytes, ref offset, 4));
	}

	public static void ReadJ2L_Data_1_23(ref J2L_Data1_1_23 Data1, ref byte[] bytes)
	{
		int offset = 0;
		Data1.JCSHorizontalOffset = bytesToShort(getBytes(bytes, ref offset, 2)); // In pixels
		Data1.Security1 = bytesToShort(getBytes(bytes, ref offset, 2)); // 0xBA00 if passworded, 0x0000 otherwise
		Data1.JCSVerticalOffset = bytesToShort(getBytes(bytes, ref offset, 2)); // In pixels
		Data1.Security2 = bytesToShort(getBytes(bytes, ref offset, 2)); // 0xBE00 if passworded, 0x0000 otherwise
		Data1.SecAndLayer = getByte(bytes, ref offset); // Upper 4 bits are set if passworded, zero otherwise. Lower 4 bits represent the layer number as last saved in JCS.
		Data1.MinLight = getByte(bytes, ref offset); // Multiply by 1.5625 to get value seen in JCS
		Data1.StartLight = getByte(bytes, ref offset); // Multiply by 1.5625 to get value seen in JCS
		Data1.AnimCount = bytesToShort(getBytes(bytes, ref offset, 2));
		Data1.VerticalSplitscreen = ((int)getByte(bytes, ref offset) != 0)? true:false ;
		Data1.IsLevelMultiplayer = ((int)getByte(bytes, ref offset) != 0)? true:false ;
		Data1.BufferSize = bytesToULong(getBytes(bytes, ref offset, 4));
		Data1.LevelName = getBytes(bytes, ref offset, 32);
		Data1.Tileset = getBytes(bytes, ref offset, 32);
		Data1.BonusLevel = getBytes(bytes, ref offset, 32);
		Data1.NextLevel = getBytes(bytes, ref offset, 32);
		Data1.SecretLevel = getBytes(bytes, ref offset, 32);
		Data1.MusicFile = getBytes(bytes, ref offset, 32);


		for(int i=0; i<16; i++)
			for(int j=0; j<512; j++)
				Data1.HelpString[i,j] = getByte(bytes, ref offset);

		for(int i=0; i<8; i++)
			Data1.LayerMiscProperties[i] = bytesToULong(getBytes(bytes, ref offset, 4));	// Each property is a bit in the following order: Tile Width, Tile Height, Limit Visible Region, Texture Mode, Parallax Stars. This leaves 27 (32-5) unused bits for each layer?
		
		Data1.Type = getBytes(bytes, ref offset, 8);	// name from Michiel; function unknown
		for(int i=0; i<8; i++)
			Data1.DoesLayerHaveAnyTiles[i] = (getByte(bytes, ref offset) != 0)? true:false;	// must always be set to true for layer 4, or JJ2 will crash
		
		for(int i=0; i<8; i++)
			Data1.LayerWidth[i] = bytesToULong(getBytes(bytes, ref offset, 4));

		for(int i=0; i<8; i++)
			Data1.LayerRealWidth[i] = bytesToULong(getBytes(bytes, ref offset, 4));	// for when "Tile Width" is checked. The lowest common multiple of LayerWidth and 4.
	
		for(int i=0; i<8; i++)
			Data1.LayerHeight[i] = bytesToULong(getBytes(bytes, ref offset, 4));

		for(int i=0; i<8; i++)
			Data1.LayerZAxis[i] = bytesToLong(getBytes(bytes, ref offset, 4));

		Data1.DetailLevel = getBytes(bytes, ref offset, 8); // is set to 02 for layer 5 in Battle1 and Battle3, but is 00 the rest of the time, at least for JJ2 levels. No clear effect of altering. Name from Michiel.
		
		for(int i=0; i<8; i++)
			Data1.WaveX[i] = bytesToLong(getBytes(bytes, ref offset, 4));	// name from Michiel; function unknown

		for(int i=0; i<8; i++)
			Data1.WaveY[i] = bytesToLong(getBytes(bytes, ref offset, 4));	// name from Michiel; function unknown

		for(int i=0; i<8; i++)
			Data1.LayerXSpeed[i] = bytesToULong(getBytes(bytes, ref offset, 4));	// Divide by 65536 to get value seen in JCS
		
		for(int i=0; i<8; i++)
			Data1.LayerYSpeed[i] = bytesToULong(getBytes(bytes, ref offset, 4));	// Divide by 65536 to get value seen in JCS

		for(int i=0; i<8; i++)
			Data1.LayerAutoXSpeed[i] = bytesToULong(getBytes(bytes, ref offset, 4));	// Divide by 65536 to get value seen in JCS

		for(int i=0; i<8; i++)
			Data1.LayerAutoYSpeed[i] = bytesToULong(getBytes(bytes, ref offset, 4));	// Divide by 65536 to get value seen in JCS
		
		Data1.LayerTextureMode = getBytes(bytes, ref offset, 8);
		
		for(int i=0; i<8; i++)
			for(int j=0; j<3; j++)
				Data1.LayerTextureParams[i,j] = getByte(bytes, ref offset);	// Red, Green, Blue

		Data1.AnimOffset = bytesToShort(getBytes(bytes, ref offset, 2)); // MAX_TILES minus AnimCount, also called StaticTiles

		for(int i=0; i<Constants.MAX_TILES_1_23; i++)
			Data1.TilesetEvents[i] = bytesToULong(getBytes(bytes, ref offset, 4));	// same format as in Data2, for tiles

		for(int i=0; i<Constants.MAX_TILES_1_23; i++)
			Data1.IsEachTileFlipped[i] = (getByte(bytes, ref offset) != 0)? true:false;	// set to 1 if a tile appears flipped anywhere in the level
		
		Data1.TileTypes = getBytes(bytes, ref offset, Constants.MAX_TILES_1_23);	// translucent=1 or caption=4, basically. Doesn't work on animated tiles.
		Data1.XMask = getBytes(bytes, ref offset, Constants.MAX_TILES_1_23);	// tested to equal all zeroes in almost 4000 different levels, and editing it has no appreciable effect.  // Name from Michiel, who claims it is totally unused.
		
		for (int i = 0; i < 128; i++)
		{
			Data1.Anim[i] = new Animated_Tile();
			ReadAnimatedTile(ref Data1.Anim[i], bytes, ref offset); // or [256] in TSF.
		}
	}

	public static void ReadJ2L_Data2_1_23(ref J2L_Data2_1_23 Data2, byte[] bytes, uint length)
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

	public static void ReadData2AGAPart1(ref Data2AGAPart1 part1, byte[] bytes, ref int offset)
	{
		offset = 2;	// was offset = sizeof(uint16_t)
		int x=0;

		part1.NumberOfDistinctEvents = bytesToShort(getBytes(bytes, ref x, 2));
		part1.Events = new byte[part1.NumberOfDistinctEvents, 64];

		for (int i = 0; i < part1.NumberOfDistinctEvents; i++)
			for(int j=0; j<64; j++)
				part1.Events[i,j] = getByte(bytes, ref offset);
	}


	public static void ReadJ2L_Data3(ref J2L_Data3 Data3, ref byte[] bytes, uint size)
	{
		int offset = 0;

		for(uint i = 0; i < size; i += 8)
		{
			Word w = new Word();

			for(int j=0; j<4; j++)
				w.Tiles[j] = bytesToShort(getBytes(bytes, ref offset, 2));

			Data3.Dictionary.Add(w);
		}
	}

	public static void ReadJ2L_Data4(ref J2L_Data4 Data4, J2L_Data1_1_23 Data1, ref byte[] bytes, uint size)
	{
		int offset = 0;

		for (int i = 0; i < 8; i++)
		{
			Data4.Layers[i] = new List<ushort>();

			bool TilesDefinedForLayer = false;
			uint LayerWidth = 0;
			uint LayerHeight = 0;

			TilesDefinedForLayer = Data1.DoesLayerHaveAnyTiles[i];
			LayerWidth = Data1.LayerRealWidth[i];
			LayerHeight = Data1.LayerHeight[i];

			/*
			else if (Data1_TSF != nullptr)
			{
				TilesDefinedForLayer = Data1_TSF->DoesLayerHaveAnyTiles[i];
				LayerWidth = Data1_TSF->LayerRealWidth[i];
				LayerHeight = Data1_TSF->LayerHeight[i];
			}
			else if (Data1_AGA != nullptr)
			{
				TilesDefinedForLayer = Data1_AGA->DoesLayerHaveAnyTiles[i];
				LayerWidth = Data1_AGA->LayerRealWidth[i];
				LayerHeight = Data1_AGA->LayerHeight[i];
			}
			*/

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
						word = bytesToShort(getBytes(bytes, ref offset, 2));
						//ReadAndAdvance(word, Data4, offset);
						Data4.Layers[i].Add(word);
					}
				}
			}
		}
	}

	public static J2L_Tile GetTile(LEVL_Header header, J2L_Data1_1_23 Data1, J2L_Data3 Data3, J2L_Data4 Data4, ref byte[] tileFrame, uint layer, uint tileXCoord, uint tileYCoord, float timeElapsed)
	{
		uint stride = Data1.LayerWidth[layer];
		stride += (((stride % 4) > 0) ? (4 - (stride % 4)) : 0);
		int ind = (int)((tileYCoord * stride) + tileXCoord);

		J2L_Tile tile = new J2L_Tile();
		tile.flipped = false;
		tile.index = -1;

		if (layer > 7)
			return tile;

		ushort bitmask = (ushort)~((header.Version == Constants.VERSION_1_23) ? Constants.FLIPPED_1_23 : Constants.FLIPPED_TSF);
		int DictionaryIndex = Data4.Layers[layer][ind/4];
		tile.index = Data3.Dictionary[DictionaryIndex].Tiles[ind % 4];
		if ((tile.index & ~bitmask) != 0)
		{
			tile.index &= bitmask;
			tile.flipped = true;
		}
		if (tile.index >= Data1.AnimOffset)
		{
			Animated_Tile anim = Data1.Anim[tile.index - Data1.AnimOffset];
			if (anim.PingPong)
			{
				int frame = (int)(Math.Round(anim.Speed * max(timeElapsed, 0.0f))) % (2*anim.FrameCount - 2);
				if (frame >= anim.FrameCount)
				{
					frame = (2 * anim.FrameCount) - frame - 1;
				}
				tile.index = anim.Frame[frame];
			}
			else
			{
				int frame = (int)(Math.Round(anim.Speed * max(timeElapsed, 0.0f))) % anim.FrameCount;
				if((anim.Speed == 0) && (layer == 3))
				{
					frame = tileFrame[ind];
				}
				tile.index = anim.Frame[frame];
			}
			if ((tile.index & ~bitmask) != 0)
			{
				tile.index &= bitmask;
				tile.flipped = !tile.flipped;
			}
		}
	
		return tile;
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
}

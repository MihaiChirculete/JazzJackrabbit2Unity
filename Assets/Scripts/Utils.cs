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

	public static bool IsBitSet(byte b, int pos)
	{
	   return (b & (1 << pos)) != 0;
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

	public static J2L_Tile GetTile(LEVL_Header header, J2L_Data1_1_23 Data1, J2L_Data3 Data3, J2L_Data4 Data4, ref byte[] tileFrame, uint layer, uint tileXCoord, uint tileYCoord, float timeElapsed)
	{
		uint stride = Data1.LayerRealWidth[layer];
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
}

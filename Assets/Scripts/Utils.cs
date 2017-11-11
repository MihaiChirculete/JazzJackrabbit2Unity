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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J2T {
public class TILE_Header
{
	public byte[] Copyright = new byte[180];
	public byte[] Magic = new byte[4]; // Should be 'TILE'
	public byte[] Signature = new byte[4]; // 0xDEADBEAF
	public byte[] TilesetName = new byte[32];
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

public class J2T_TilesetInfo_1_23 {
	public uint[] PaletteColor = new uint[256];        //arranged RGBA
	public uint TileCount;                 //number of tiles, always a multiple of 10
	public byte[] FullyOpaque = new byte[Constants.MAX_TILES_1_23];    //1 if no transparency at all, otherwise 0
	public byte[] Unknown1 = new byte[Constants.MAX_TILES_1_23];       //appears to be all zeros
	public uint[] ImageAddress = new uint[Constants.MAX_TILES_1_23];
	public uint[] Unknown2 = new uint[Constants.MAX_TILES_1_23];       //appears to be all zeros
	public uint[] TMaskAddress = new uint[Constants.MAX_TILES_1_23];   //Transparency masking, for bitblt
	public uint[] Unknown3 = new uint[Constants.MAX_TILES_1_23];       //appears to be all zeros
	public uint[] MaskAddress = new uint[Constants.MAX_TILES_1_23];    //Clipping or tile mask
	public uint[] FMaskAddress = new uint[Constants.MAX_TILES_1_23];   //flipped version of the above
}

public class J2T_TilesetInfo_1_24 {
	public uint[] PaletteColor = new uint[256];        //arranged RGBA
	public uint TileCount;                 //number of tiles, always a multiple of 10
	public byte[] FullyOpaque = new byte[Constants.MAX_TILES_TSF];    //1 if no transparency at all, otherwise 0
	public byte[] Unknown1 = new byte[Constants.MAX_TILES_TSF];       //appears to be all zeros
	public uint[] ImageAddress = new uint[Constants.MAX_TILES_TSF];
	public uint[] Unknown2 = new uint[Constants.MAX_TILES_TSF];       //appears to be all zeros
	public uint[] TMaskAddress = new uint[Constants.MAX_TILES_TSF];   //Transparency masking, for bitblt
	public uint[] Unknown3 = new uint[Constants.MAX_TILES_TSF];       //appears to be all zeros
	public uint[] MaskAddress = new uint[Constants.MAX_TILES_TSF];    //Clipping or tile mask
	public uint[] FMaskAddress = new uint[Constants.MAX_TILES_TSF];   //flipped version of the above
}

public class J2T_TileImage {
	public byte[] ImageData = new byte[1024];	// Stores the palette color index for each pixel for a 32x32 image
}

public class J2T_TileTransparency {
	public byte[] TransparencyMask = new byte[128];
}

public class J2T_TileClip {
	public byte[] ClippingMask = new byte[128];
}

public class Tileset
{
	public byte[] Data1;
	public byte[] Data2;
	public byte[] Data3;
	public byte[] Data4;

	public TILE_Header header = new TILE_Header();

	public J2T_TilesetInfo_1_23 TilesetInfo_1_23;
	public J2T_TilesetInfo_1_24 TilesetInfo_1_24;

	public List<J2T_TileImage> TileImages = new List<J2T_TileImage>();
	public List<J2T_TileTransparency> TileTransparencyMasks = new List<J2T_TileTransparency>();
	public List<J2T_TileClip> TileClippingMasks = new List<J2T_TileClip>();

	public Dictionary<uint, byte[]> ExpandedClipMasks = new Dictionary<uint, byte[]>();

	public void ReadTilesetData(string tilesetName)
	{
		TextAsset ta = Resources.Load("Jazz2/" + tilesetName + "_tileset", typeof(TextAsset)) as TextAsset;
		byte[] bytesBuf = ta.bytes;

		int offset = 0;

		header.Copyright = Utils.getBytes(bytesBuf, ref offset, 180);
		header.Magic = Utils.getBytes(bytesBuf, ref offset, 4);
		header.Signature = Utils.getBytes(bytesBuf, ref offset, 4);
		header.TilesetName = Utils.getBytes(bytesBuf, ref offset, 32);
		header.Version = Utils.bytesToShort(Utils.getBytes(bytesBuf, ref offset, 2));
		header.FileSize = Utils.bytesToULong(Utils.getBytes(bytesBuf, ref offset, 4));
		header.CRC32 = Utils.bytesToULong(Utils.getBytes(bytesBuf, ref offset, 4));
		header.CData1 = Utils.bytesToULong(Utils.getBytes(bytesBuf, ref offset, 4));
		header.UData1 = Utils.bytesToULong(Utils.getBytes(bytesBuf, ref offset, 4));
		header.CData2 = Utils.bytesToULong(Utils.getBytes(bytesBuf, ref offset, 4));
		header.UData2 = Utils.bytesToULong(Utils.getBytes(bytesBuf, ref offset, 4));
		header.CData3 = Utils.bytesToULong(Utils.getBytes(bytesBuf, ref offset, 4));
		header.UData3 = Utils.bytesToULong(Utils.getBytes(bytesBuf, ref offset, 4));
		header.CData4 = Utils.bytesToULong(Utils.getBytes(bytesBuf, ref offset, 4));
		header.UData4 = Utils.bytesToULong(Utils.getBytes(bytesBuf, ref offset, 4));

		// decompress data1 of tileset
		Data1 = new byte[header.UData1];
		Data1 = Ionic.Zlib.ZlibStream.UncompressBuffer(Utils.getBytes(bytesBuf, ref offset, (int)header.CData1));

		// decompress data2 of tileset
		Data2 = new byte[header.UData2];
		Data2 = Ionic.Zlib.ZlibStream.UncompressBuffer(Utils.getBytes(bytesBuf, ref offset, (int)header.CData2));

		// decompress data3 of tileset
		Data3 = new byte[header.UData3];
		Data3 = Ionic.Zlib.ZlibStream.UncompressBuffer(Utils.getBytes(bytesBuf, ref offset, (int)header.CData3));

		// decompress data4 of tileset
		Data4 = new byte[header.UData4];
		Data4 = Ionic.Zlib.ZlibStream.UncompressBuffer(Utils.getBytes(bytesBuf, ref offset, (int)header.CData4));
	}

	public void LoadJ2T_TilesetInfo_1_23()
	{
		TilesetInfo_1_23 = new J2T_TilesetInfo_1_23();

		int offset = 0;

		for(int i=0; i<256; i++)
			TilesetInfo_1_23.PaletteColor[i] = Utils.bytesToULong(Utils.getBytes(Data1, ref offset, 4));

		TilesetInfo_1_23.TileCount = Utils.bytesToULong(Utils.getBytes(Data1, ref offset, 4));
		TilesetInfo_1_23.FullyOpaque = Utils.getBytes(Data1, ref offset, Constants.MAX_TILES_1_23);
		TilesetInfo_1_23.Unknown1 = Utils.getBytes(Data1, ref offset, Constants.MAX_TILES_1_23);

		for(int i=0; i<Constants.MAX_TILES_1_23; i++)
			TilesetInfo_1_23.ImageAddress[i] = Utils.bytesToULong(Utils.getBytes(Data1, ref offset, 4));

		for(int i=0; i<Constants.MAX_TILES_1_23; i++)
			TilesetInfo_1_23.Unknown2[i] = Utils.bytesToULong(Utils.getBytes(Data1, ref offset, 4));

		for(int i=0; i<Constants.MAX_TILES_1_23; i++)
			TilesetInfo_1_23.TMaskAddress[i] = Utils.bytesToULong(Utils.getBytes(Data1, ref offset, 4));

		for(int i=0; i<Constants.MAX_TILES_1_23; i++)
			TilesetInfo_1_23.Unknown3[i] = Utils.bytesToULong(Utils.getBytes(Data1, ref offset, 4));

		for(int i=0; i<Constants.MAX_TILES_1_23; i++)
			TilesetInfo_1_23.MaskAddress[i] = Utils.bytesToULong(Utils.getBytes(Data1, ref offset, 4));

		for(int i=0; i<Constants.MAX_TILES_1_23; i++)
			TilesetInfo_1_23.FMaskAddress[i] = Utils.bytesToULong(Utils.getBytes(Data1, ref offset, 4));
	}

	
	public void LoadTileImages()
	{
		Dictionary<uint, uint> ImageIndexMap = new Dictionary<uint, uint>();

		for (uint i = 0; i < Constants.MAX_TILES_1_23; i++)
		{
			if (ImageIndexMap.ContainsKey(TilesetInfo_1_23.ImageAddress[i]))
			{
				TilesetInfo_1_23.ImageAddress[i] = ImageIndexMap[TilesetInfo_1_23.ImageAddress[i]];
			}
			else
			{
				J2T_TileImage image = new J2T_TileImage();
				image.ImageData = Utils.getBytesNonRef(Data2, (int)TilesetInfo_1_23.ImageAddress[i], 1024);	// memcpy(image.ImageData, &Data2[TilesetInfo_1_23->ImageAddress[i]], 1024);
				uint newIndex = (uint)TileImages.Count;
				ImageIndexMap[TilesetInfo_1_23.ImageAddress[i]] = newIndex;
				TilesetInfo_1_23.ImageAddress[i] = newIndex;
				TileImages.Add(image);
			}
		}
	}

	public void LoadTileTransparency()
	{
		Dictionary<uint, uint> ImageIndexMap = new Dictionary<uint, uint>();
		for (uint i = 0; i < Constants.MAX_TILES_1_23; i++)
		{
			if (ImageIndexMap.ContainsKey(TilesetInfo_1_23.TMaskAddress[i]))
			{
				TilesetInfo_1_23.TMaskAddress[i] = ImageIndexMap[TilesetInfo_1_23.TMaskAddress[i]];
			}
			else
			{
				J2T_TileTransparency image = new J2T_TileTransparency();
				image.TransparencyMask = Utils.getBytesNonRef(Data3, (int)TilesetInfo_1_23.TMaskAddress[i], 128); // memcpy(image.TransparencyMask, &Data3[TilesetInfo_1_23->TMaskAddress[i]], 128);
				uint newIndex = (uint)TileTransparencyMasks.Count;
				ImageIndexMap[TilesetInfo_1_23.TMaskAddress[i]] = newIndex;
				TilesetInfo_1_23.TMaskAddress[i] = newIndex;
				TileTransparencyMasks.Add(image);
			}
		}
	}

	public void LoadTileClipping()
	{
		Dictionary<uint, uint> ImageIndexMap = new Dictionary<uint, uint>();
		for (uint i = 0; i < Constants.MAX_TILES_1_23; i++)
		{
			if (ImageIndexMap.ContainsKey(TilesetInfo_1_23.MaskAddress[i]))
			{
				TilesetInfo_1_23.MaskAddress[i] = ImageIndexMap[TilesetInfo_1_23.MaskAddress[i]];
			}
			else
			{
				J2T_TileClip image = new J2T_TileClip();
				image.ClippingMask = Utils.getBytesNonRef(Data4, (int)TilesetInfo_1_23.MaskAddress[i], 128); // memcpy(image.ClippingMask, &Data4[TilesetInfo_1_23->MaskAddress[i]], 128);
				uint newIndex = (uint)TileClippingMasks.Count;
				ImageIndexMap[TilesetInfo_1_23.MaskAddress[i]] = newIndex;
				TilesetInfo_1_23.MaskAddress[i] = newIndex;
				TileClippingMasks.Add(image);
			}
		}
		for (uint i = 0; i < Constants.MAX_TILES_1_23; i++)
		{
			if (ImageIndexMap.ContainsKey(TilesetInfo_1_23.FMaskAddress[i]))
			{
				TilesetInfo_1_23.FMaskAddress[i] = ImageIndexMap[TilesetInfo_1_23.FMaskAddress[i]];
			}
			else
			{
				J2T_TileClip image = new J2T_TileClip();
				image.ClippingMask = Utils.getBytesNonRef(Data4, (int)TilesetInfo_1_23.FMaskAddress[i], 128); // memcpy(image.ClippingMask, &Data4[TilesetInfo_1_23->FMaskAddress[i]], 128);
				uint newIndex = (uint)TileClippingMasks.Count;
				ImageIndexMap[TilesetInfo_1_23.FMaskAddress[i]] = newIndex;
				TilesetInfo_1_23.FMaskAddress[i] = newIndex;
				TileClippingMasks.Add(image);
			}
		}
	}

	public uint NumTiles()
	{
		/*
		if (TilesetInfo_1_23 != nullptr)
			return TilesetInfo_1_23->TileCount;
		else if (TilesetInfo_1_24 != nullptr)
			return TilesetInfo_1_24->TileCount;
			*/

		return TilesetInfo_1_23.TileCount;
	}

	public uint[] GetTile(uint index, bool flipped)
	{
		byte[] bitmap = { 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80 };
		uint CHANNEL_ALPHA, CHANNEL_RED, CHANNEL_GREEN, CHANNEL_BLUE;

		if(System.BitConverter.IsLittleEndian)
		{
			CHANNEL_RED = (uint)0x000000FF;
			CHANNEL_GREEN = (uint)0x0000FF00;
			CHANNEL_BLUE = (uint)0x00FF0000;
			CHANNEL_ALPHA = (uint)0xFF000000;
		}
		else
		{
			CHANNEL_RED = (uint)0xFF000000;
			CHANNEL_GREEN = (uint)0x00FF0000;
			CHANNEL_BLUE = (uint)0x0000FF00;
			CHANNEL_ALPHA = (uint)0x000000FF;
		}

		if (index >= NumTiles())
			return null;

		int ImageIndex = 0;
		int TransparencyIndex = 0;

		ImageIndex = (int)TilesetInfo_1_23.ImageAddress[index];
		TransparencyIndex = (int)TilesetInfo_1_23.TMaskAddress[index];

		J2T_TileImage image = TileImages[ImageIndex];
		J2T_TileTransparency transparency = TileTransparencyMasks[TransparencyIndex];

		uint[] Pixels = new uint[1024];
		for (int i = 0; i < 1024; i++)
		{
			Pixels[i] = TilesetInfo_1_23.PaletteColor[image.ImageData[i]];
		}

		for (int i = 0; i < 1024; i++)
		{
			Pixels[i] |= ((transparency.TransparencyMask[i / 8] & bitmap[i % 8]) != 0) ? CHANNEL_ALPHA : (uint)0x00000000;
			//Pixels[i] |= CHANNEL_RED;
			//Pixels[i] |= CHANNEL_GREEN;
			//Pixels[i] |= CHANNEL_BLUE;
		}

		if(flipped)
		{
			for (int i = 0; i < 32; i++)
			{
				for (int j = 0; j < 16; j++)
				{
					uint temp = Pixels[32 * i + j];
					Pixels[32 * i + j] = Pixels[32 * i + (31 - j)];
					Pixels[32 * i + (31 - j)] = temp;
				}
			}
		}
		return Pixels;
	}

	public J2T_TileClip GetTileClip(uint index)
	{
		return TileClippingMasks[(int)index];
	}



	//uint8_t *GetClipMask(const uint32_t &index, const bool &flipped) const;
	//uint32_t *GetPalette() const;
}
}

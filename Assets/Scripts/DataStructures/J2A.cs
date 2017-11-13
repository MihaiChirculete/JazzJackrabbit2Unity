using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J2A {
public class ALIB_Header
{
	public byte[] Magic = new byte[4];						// Magic number, should be 'ALIB'
	public uint Signature = 0x00BABE00;	// Signature
	public uint HeaderSize;				// Equals 464 bytes for v1.23 Anims.j2a
	public ushort Version = 0x0200;			// Probably means v2.0
	public ushort Unknown2 = 0x1808;			// Unknown purpose
	public uint FileSize;					// Equals 8182764 bytes for v1.23 anims.j2a
	public uint CRC32;						// Note: CRC buffer starts after the end of header
	
	// Number of sets in the Anims.j2a (109 in v1.23)
	public uint SetCount;
	public uint[] SetAddress = new uint[Constants.ANIM_COUNT];	// Each set's starting address within the file
}

public class ANIM_Header
{
	public byte[] Magic = new byte[4];						// Magic number, should be 'ANIM'
	public byte AnimationCount;				// Number of animations in set
	public byte SampleCount;				// Number of sound samples in set
	public ushort FrameCount;				// Total number of frames in set
	public uint PriorSampleCount;          // Total number of sound sample across all sets preceding this one
	public uint CData1;                    // Compressed size of Data1
	public uint UData1;                    // Uncompressed size of Data1
	public uint CData2;                    // Compressed size of Data2
	public uint UData2;                    // Uncompressed size of Data2
	public uint CData3;                    // Compressed size of Data3
	public uint UData3;                    // Uncompressed size of Data3
	public uint CData4;                    // Compressed size of Data4
	public uint UData4;                    // Uncompressed size of Data4
}

public class AnimInfo
{
	public ushort FrameCount;
	public ushort FrameRate;
	public uint Reserved;
}

public class FrameInfo
{
	public ushort Width;
	public ushort Height;
	public short ColdspotX;    // Relative to hotspot
	public short ColdspotY;    // Relative to hotspot
	public short HotspotX;
	public short HotspotY;
	public short GunspotX;     // Relative to hotspot
	public short GunspotY;     // Relative to hotspot
	public uint ImageAddress;  // Address in Data3 where image starts
	public uint MaskAddress;   // Address in Data3 where mask starts
}
}

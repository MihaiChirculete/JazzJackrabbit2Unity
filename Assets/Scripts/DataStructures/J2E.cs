using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J2E {
public class J2E_Header
{
	public uint HeaderSize;
	public uint Position;
	public uint IsRegistered;
	public uint Unknown;
	public byte[] EpisodeName = new byte[128];
	public byte[] FirstLevel = new byte[32];
	public uint Width;
	public uint Height;
	public uint Unknown2;
	public uint Unknown3;
	public uint TitleWidth;
	public uint TitleHeight;
	public uint Unknown4;
	public uint Unknown5;
}
}

using UnityEngine;
using System.Collections;

public class LINF {

	/* LINF section (starts at 4328)*/
    public long SectionLength;	// starts at 4332
    public short ChunkVersion = 258; // JJ2 gives error otherwise;    starts at 4336
    public string LevelName;	// starts at 4338 and ends with 0x00
    public string BonusLevel;	// not sure about this one but seems to have only 1 byte
    public string MusicFile;	// starts at 4338 + length of filename + 1 byte from BonusLevel
    public string NextLevel; // minus the file extension
    public string SecretLevel;
    public long MinLight; // multiply by 1.5625 to get Set Light-compatible value
    public long StartLight; // same
    public long[] unknown3 = new long[8];
	public byte[] Padding; // pad the section length out to a multiple of four
}

public class HSTR {
	/* HSTR section (starts at 4328 + LINF length) */
	public long SectionLength;	// starts at 4328 + LINF length + 12
    public short MaxLength = 256; // maybe?
    public string[] HelpString = new string[16]; // starts at 4328 + LINF length + 12 + 2
    public byte[] Padding; // pad the section length out to a multiple of four
}

public class TILE
{
    public long SectionLength;
    public long ChunkVersion = 263; // JJ2 gives error otherwise
    /*
    public section INFO;
    public section DATA;
    public section EMSK;
    public section MASK;
    public section ANIM;
    public section FLIP;
    */

    public class INFO
	{
		public long SectionLength;
	    public long NumberOfTiles;
	    // public byte[] TileType = new byte[NumberOfTiles-1]; // starts at tile 1, not 0
	    public byte[] Padding; // pad the section length out to a multiple of four
	}

	public class DATA
	{
		public long SectionLength;
	    // public TILE[] TileType = new TILE[NumberOfTiles-1]; //tile 0 is always blank
	                                    //and therefore is not recorded
	}

	public class EMSK
	{
		public long SectionLength;
	}

	public class MASK
	{
		public long SectionLength;
	}

	public class ANIM
	{
		public long SectionLength;
	}

	public class FLIP
	{
		public long SectionLength;
	}
}


public class LAYR
{
	public long SectionLength;
	public long ChunkVersion = 263; // JJ2 gives error otherwise

	public class INFO
	{
		public long SectionLength;
	    public LayerInfo[] LayerProperties = new LayerInfo[8];
	}

	public class LayerInfo
	{
		public long LayerFlags; // bit0: Tile Width
                     // bit1: Tile Height
                     // bit2: Layer has tiles
                     // bit3: Limit Visible Region
                     // bit4: Texture mode
	    public short LayerWidth;
	    public short LayerHeight;
	    public short ZAxis; // nothing happens when you change these
	    public byte Type; // No known effect. Name from Michiel.
	    public long SpeedSettings; // bit0: include unknown byte
	                        // bit1: include X/Y Speeds
	                        // bit2: include Auto X/Y Speeds
	    public byte DetailLevel; //if SpeedSettings bit0.
	                      //Only appears in battle1 and battle3, for
	                      //layer 5 only, where it is 02 both times.
	                      //No known effect. Name from Michiel.
	    public long LayerXSpeed; //if SpeedSettings bit1
	    public long LayerYSpeed; //if SpeedSettings bit1
	    public long LayerAutoXSpeed; //if SpeedSettings bit2
	    public long LayerAutoYSpeed; //if SpeedSettings bit2
	}

	/* List of offsets for data start in different levels */
	/* CASTLE1: 556944                                    */
	public class DATA
	{
	    public long SectionLength;
	    // short AnimOffset = 1024 - NumberOfAnimations;
	    public static short NumberOfWords;
	    public short unknown = 0; // always zero?
	    public short[,] Word = new short[NumberOfWords, 16];
	    // short[,] LayerLayout = new short[8, System.Math.Ceiling(LayerInfo.LayerWidth/16)*LayerInfo.LayerHeight];
	}
}
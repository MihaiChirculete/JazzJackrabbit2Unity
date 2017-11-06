using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
	public static int VERSION_1_23 = 514;
	public static int VERSION_TSF = 515;
	public static int VERSION_GIGANTIC = 256;

	public static int TILE_VERSION_1_23 = 0x200;
	public static int TILE_VERSION_1_24 = 0x201;

	public static int MAX_TILES_1_23 = 1024;
	public static int MAX_TILES_TSF = 4096;

	public static int FLIPPED_1_23 = 0x0400;
	public static int FLIPPED_TSF = 0x1000;

	public static int ANIM_COUNT = 109;
}

public class SpriteCoords
{
	public int TextureIndex;
	public float x;
	public float y;
	public float width;
	public float height;
}

enum GemType
{
	GT_None,
	GT_Red,
	GT_Blue,
	GT_Green,
	GT_Purple
}

public enum EventID : byte
{
	None = 0,
	OneWay = 1,
	Hurt = 2,
	Vine = 3,
	Hook = 4,
	Slide = 5,
	HPole = 6,
	VPole = 7,
	AreaFlyOff = 8,
	Ricochet = 9,
	BeltRight = 10,
	BeltLeft = 11,
	AccBeltR = 12,
	AccBeltL = 13,
	StopEnemy = 14,
	WindLeft = 15,
	WindRight = 16,
	AreaEndOfLevel = 17,
	AreaWarpEOL = 18,
	AreaRevertMorph = 19,
	AreaFloatUp = 20,
	TriggerRock = 21,
	DimLight = 22,
	SetLight = 23,
	LimitXScroll = 24,
	ResetLight = 25,
	AreaWarpSecret = 26,
	Echo = 27,
	ActivateBoss = 28,
	JazzLevelStart = 29,
	SpazLevelStart = 30,
	MultiplayerLevelStart = 31,
	FreezerAmmoPlus3 = 33,
	BouncerAmmoPlus3 = 34,
	SeekerAmmoPlus3 = 35,
	ThreeWayAmmoPlus3 = 36,
	ToasterAmmoPlus3 = 37,
	TNTAmmoPlus3 = 38,
	Gun8AmmoPlus3 = 39,
	Gun9AmmoPlus3 = 40,
	StillTurtleshell = 41,
	SwingingVine = 42,
	Bomb = 43,
	SilverCoin = 44,
	GoldCoin = 45,
	Guncrate = 46,
	Carrotcrate = 47,
	OneUpcrate = 48,
	Gembarrel = 49,
	Carrotbarrel = 50,
	OneUpBarrel = 51,
	BombCrate = 52,
	FreezerAmmoPlus15 = 53,
	BouncerAmmoPlus15 = 54,
	SeekerAmmoPlus15 = 55,
	ThreeWayAmmoPlus15 = 56,
	ToasterAmmoPlus15 = 57,
	TNT = 58,
	Airboard = 59,
	FrozenGreenSpring = 60,
	GunFastFire = 61,
	SpringCrate = 62,
	RedGemPlus1 = 63,
	GreenGemPlus1 = 64,
	BlueGemPlus1 = 65,
	PurpleGemPlus1 = 66,
	SuperRedGem = 67,
	Birdy = 68,
	GunBarrel = 69,
	GemCrate = 70,
	JazzSpaz = 71,
	CarrotEnergyPlus1 = 72,
	FullEnergy = 73,
	FireShield = 74,
	WaterShield = 75,
	LightningShield = 76,
	MaxWeapon = 77,
	Autofire = 78,
	FastFeet = 79,
	ExtraLive = 80,
	EndofLevelsignpost = 81,
	Sparkle = 82,
	Savepointsignpost = 83,
	BonusLevelsignpost = 84,
	RedSpring = 85,
	GreenSpring = 86,
	BlueSpring = 87,
	Invincibility = 88,
	ExtraTime = 89,
	FreezeEnemies = 90,
	HorRedSpring = 91,
	HorGreenSpring = 92,
	HorBlueSpring = 93,
	MorphIntoBird = 94,
	SceneryTriggerCrate = 95,
	Flycarrot = 96,
	RectGemRed = 97,
	RectGemGreen = 98,
	RectGemBlue = 99,
	TufTurt = 100,
	TufBoss = 101,
	LabRat = 102,
	Dragon = 103,
	Lizard = 104,
	Bee = 105,
	Rapier = 106,
	Sparks = 107,
	Bat = 108,
	Sucker = 109,
	Caterpillar = 110,
	Cheshire1 = 111,
	Cheshire2 = 112,
	Hatter = 113,
	BilsyBoss = 114,
	Skeleton = 115,
	DoggyDogg = 116,
	NormTurtle = 117,
	Helmut = 118,
	Leaf = 119,
	Demon = 120,
	Fire = 121,
	Lava = 122,
	DragonFly = 123,
	Monkey = 124,
	FatChick = 125,
	Fencer = 126,
	Fish = 127,
	Moth = 128,
	Steam = 129,
	RotatingRock = 130,
	BlasterPowerUp = 131,
	BouncyPowerUp = 132,
	IcegunPowerUp = 133,
	SeekPowerUp = 134,
	RFPowerUp = 135,
	ToasterPowerUP = 136,
	PINLeftPaddle = 137,
	PINRightPaddle = 138,
	PIN500Bump = 139,
	PINCarrotBump = 140,
	Apple = 141,
	Banana = 142,
	Cherry = 143,
	Orange = 144,
	Pear = 145,
	Pretzel = 146,
	Strawberry = 147,
	SteadyLight = 148,
	PulzeLight = 149,
	FlickerLight = 150,
	QueenBoss = 151,
	FloatingSucker = 152,
	Bridge = 153,
	Lemon = 154,
	Lime = 155,
	Thing = 156,
	Watermelon = 157,
	Peach = 158,
	Grapes = 159,
	Lettuce = 160,
	Eggplant = 161,
	Cucumb = 162,
	SoftDrink = 163,
	SodaPop = 164,
	Milk = 165,
	Pie = 166,
	Cake = 167,
	Donut = 168,
	Cupcake = 169,
	Chips = 170,
	Candy = 171,
	Chocbar = 172,
	Icecream = 173,
	Burger = 174,
	Pizza = 175,
	Fries = 176,
	ChickenLeg = 177,
	Sandwich = 178,
	Taco = 179,
	Weenie = 180,
	Ham = 181,
	Cheese = 182,
	FloatLizard = 183,
	StandMonkey = 184,
	DestructScenery = 185,
	DestructSceneryBOMB = 186,
	CollapsingScenery = 187,
	ButtStompScenery = 188,
	InvisibleGemStomp = 189,
	Raven = 190,
	TubeTurtle = 191,
	GemRing = 192,
	SmallTree = 193,
	AmbientSound = 194,
	Uterus = 195,
	Crab = 196,
	Witch = 197,
	RocketTurtle = 198,
	Bubba = 199,
	Devildevanboss = 200,
	Devan = 201,
	Robot = 202,
	Carrotuspole = 203,
	Psychpole = 204,
	Diamonduspole = 205,
	SuckerTube = 206,
	Text = 207,
	WaterLevel = 208,
	FruitPlatform = 209,
	BollPlatform = 210,
	GrassPlatform = 211,
	PinkPlatform = 212,
	SonicPlatform = 213,
	SpikePlatform = 214,
	SpikeBoll = 215,
	Generator = 216,
	Eva = 217,
	Bubbler = 218,
	TNTPowerup = 219,
	Gun8Powerup = 220,
	Gun9Powerup = 221,
	MorphFrog = 222,
	ThreeDSpikeBoll = 223,
	Springcord = 224,
	Bees = 225,
	Copter = 226,
	LaserShield = 227,
	Stopwatch = 228,
	JunglePole = 229,
	Warp = 230,
	BigRock = 231,
	BigBox = 232,
	WaterBlock = 233,
	TriggerScenery = 234,
	BollyBoss = 235,
	Butterfly = 236,
	BeeBoy = 237,
	Snow = 238,
	WarpTarget = 240,
	TweedleBoss = 241,
	AreaId = 242,
	CTFBasePlusFlag = 244,
	NoFireZone = 245
}

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

public class J2L_Tile
{
	public int index;
	public bool flipped;
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



	//uint8_t *GetClipMask(const uint32_t &index, const bool &flipped) const;
	//uint32_t *GetPalette() const;
}

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
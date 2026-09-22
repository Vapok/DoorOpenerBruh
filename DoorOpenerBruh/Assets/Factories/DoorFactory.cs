using System.Collections.Generic;
using DoorOpenerBruh.Assets.Pieces;
using DoorOpenerBruh.Assets.Pieces.Doors;
using Vapok.Common.Abstractions;
using Vapok.Common.Managers.Configuration;

namespace DoorOpenerBruh.Assets.Factories;

public class DoorFactory : FactoryBase
{
    private static Dictionary<string, IDoorPiece> _doorPieces = new();

    public static Dictionary<string, IDoorPiece> DoorPieces => _doorPieces;
    
    public DoorFactory(ILogIt logger, ConfigSyncBase configs) : base(logger, configs)
    {
        _doorPieces.Clear();
        _doorPieces.Add("dungeon_forestcrypt_door", new DungeonForestCryptDoor("dungeon_forestcrypt_door", "$piece_wooddoor", "Dungeon: Burial Chamber Door"));
        _doorPieces.Add("dungeon_queen_door", new DungeonQueenDoor("dungeon_queen_door", "$piece_queendoor", "World: Mistlands Queen Door"));
        _doorPieces.Add("dvergrtown_secretdoor", new DvergrTownSecretDoor("dvergrtown_secretdoor", "$piece_secretdoor", "Dungeon: Dvergr Town Secret Door"));
        _doorPieces.Add("dvergrtown_slidingdoor", new DvergrTownSlidingDoor("dvergrtown_slidingdoor", "$piece_dv_gate", "Dungeon: Dvergr Town Sliding Door"));
        _doorPieces.Add("piece_dvergr_wood_door", new DvergrWoodDoor("piece_dvergr_wood_door", "$piece_dvergr_door", "World: Dvergr Wood Door"));
        _doorPieces.Add("piece_hexagonal_door", new HexagonalGate("piece_hexagonal_door", "$piece_hexagonalgate", "Buildable: Hexagonal Gate"));
        _doorPieces.Add("wood_door", new WoodDoor("wood_door", "$piece_wooddoor", "Buildable: Wood Door"));
        _doorPieces.Add("iron_grate", new IronGrate("iron_grate", "$piece_irongate", "Buildable: Iron Gate"));
        _doorPieces.Add("darkwood_gate", new DarkwoodGate("darkwood_gate", "$piece_darkwoodgate", "Buildable: Darkwood Gate"));
        _doorPieces.Add("ashwood_door", new AshwoodDoor("ashwood_door", "$piece_ashwood_door", "Buildable: Ashwood Door"));
        _doorPieces.Add("flametal_gate", new FlametalGate("flametal_gate", "$piece_flametal_gate", "Buildable: Flametal Gate"));
        _doorPieces.Add("piece_grausten_door", new GraustenDoor("piece_grausten_door", "$piece_grausten_door", "Buildable: Grausten Door"));
        _doorPieces.Add("piece_grausten_gate", new GraustenGate("piece_grausten_gate", "$piece_grausten_gate", "Buildable: Grausten Gate"));
        _doorPieces.Add("piece_drawbridge", new Drawbridge("piece_drawbridge", "$piece_drawbridge", "Buildable: Drawbridge"));
        _doorPieces.Add("piece_drawbridge_log", new RusticDrawbridge("piece_drawbridge_log", "$piece_drawbridge_log", "Buildable: Rustic Drawbridge"));
        _doorPieces.Add("dungeon_sunkencrypt_irongate", new DungeonSunkenCryptIronGate("dungeon_sunkencrypt_irongate", "$piece_irongate", "Dungeon: Sunken Crypt Iron Gate"));
        _doorPieces.Add("MountainKit_wood_gate", new MountainWoodGate("MountainKit_wood_gate", "$piece_woodgate", "World: Mountain Wood Gate"));
        _doorPieces.Add("sunken_crypt_gate", new SunkenCryptIronGate("sunken_crypt_gate", "$piece_irongate", "World: Sunken Crypt Gate"));
        _doorPieces.Add("wood_gate", new WoodGate("wood_gate", "$piece_woodgate", "Buildable: Wood Gate"));
        _doorPieces.Add("wood_window", new WindowShutter("wood_window", "$piece_woodwindowshutter", "Buildable: Wood Shutter"));
        _doorPieces.Add("wood_fence_gate", new WoodFenceGate("wood_fence_gate", "$piece_woodfencegate", "Buildable: Wood Fence Gate"));
        _doorPieces.Add("stave_gate", new StaveGate("stave_gate", "$piece_stavegate", "Buildable: Stave Gate"));
        _doorPieces.Add("other", new OtherDoors("other", "other", "Other: Other and Custom Doors"));
    }
}

<div align="center">

# 🚪 DoorOpenerBruh

### *Automated door opening and closing mechanics for Valheim.*

[![Survival Servers](https://ibin.co/5RCcxHBNFp)](https://www.survivalservers.com/services/game_servers/valheim/?ref=vapok)

[![GitHub Release](https://img.shields.io/github/v/release/Vapok/DoorOpenerBruh?include_prereleases&logo=github&style=for-the-badge)](https://github.com/Vapok/DoorOpenerBruh/releases)
[![Thunderstore Version](https://img.shields.io/thunderstore/v/Vapok/DoorOpenerBruh?logo=thunderstore&style=for-the-badge)](https://thunderstore.io/c/valheim/p/Vapok/DoorOpenerBruh/)
[![Nexus Mods](https://img.shields.io/badge/Nexus_Mods-Available-da8e35?logo=nexusmods&style=for-the-badge)](https://www.nexusmods.com/valheim/mods/2506)
<br>
[![Discord](https://img.shields.io/badge/Discord-Join%20Community-7289da?logo=discord&logoColor=white&style=for-the-badge)](https://discord.gg/5YAJkRFBXt)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](https://opensource.org/licenses/MIT)

---

</div>

Never get snagged on your castle gates, longhouse doors, or dungeon entrances again! **DoorOpenerBruh** automatically swings open doors, gates, and drawbridges as you approach, and gently closes them behind you once you depart.

---

## 🚪 How It Works

* 🚶 **Automatic Approach & Departure**: Walk up to any supported door, gate, or drawbridge and it will seamlessly open for you. Walk away and it securely closes behind you.
* 🏰 **Full Biome & Structure Support**: Works with standard Wood and Iron doors, Darkwood gates, Ashlands doors and gates, and massive Timberwood and Rustic drawbridges!
* 🗝️ **Key & Crypt Recognition**: Automatically opens locked crypt and dungeon doors if the player carries the matching key in their inventory or equipped backpack.
* 🛡️ **Ward & Private Area Respect**: Safely respects player wards—doors inside private protected zones will only open for authorized Vikings.

---

## 📦 Supported Door & Gate Types

| Structure | Biome / Tier | Key Features |
| :--- | :--- | :--- |
| **Wood & Log Doors** | 🌸 Meadows / 🌲 Black Forest | Basic residential doors and gates. |
| **Iron Doors & Gates** | 🐸 Swamp | Sturdy iron fortification gates. |
| **Darkwood Gates** | 🌾 Plains | Decorative and high-durability double gates. |
| **Ashwood & Flametal Gates** | 🔥 Ashlands | Heavy molten fortification gates and Ashwood doors. |
| **Grausten Doors & Gates** | 🔥 Ashlands | Ancient volcanic stone doors and portcullises. |
| **Timberwood & Rustic Drawbridges** | 🏰 Fortress / Base | Massive multi-panel drawbridges with collision bounds awareness. |
| **Crypt & Burial Chamber Doors** | ⚔️ Dungeons | Key-validated dungeon and crypt entryways. |

---

## ⚙️ Configuration & Settings

Fine-tune global toggles and per-door behavior in the in-game [BepInEx Configuration Manager](https://github.com/BepInEx/BepInEx.ConfigurationManager) (<kbd>F1</kbd>):

| Setting | Default | Description |
| :--- | :--- | :--- |
| **Enable Mod** | `true` | Globally toggles automatic door opening and closing. |
| **Open Distance** | `3.0m` | Proximity distance in meters required to trigger door opening. |
| **Close Distance** | `5.0m` | Departure distance in meters required to trigger door closing. |
| **Respect Wards** | `true` | Prevents unauthorized doors in active ward areas from opening. |
| **Auto Open Crypts** | `true` | Allows dungeon/crypt doors to open automatically if the player carries the key. |
| **Per-Door Toggles** | `true` *(All)* | Individual enable/disable toggles for every door type in the game. |

---

## 🛡️ Advanced Mechanics & Safeguards

* 🌉 **Drawbridge Bounds Detection**: Utilizes collider-aware bounding box checks across large drawbridges to guarantee the bridge never auto-closes while you are actively traversing it.
* 🔄 **Multiplayer Synchronization**: Fully synchronizes open/close states across dedicated server clients with zero door desynchronization.
* ⚡ **Zero Lag Overhead**: Replaced legacy continuous polling with proximity distance triggers for instant, smooth response.

---

## 🤝 Verified Mod Compatibility

<div align="center">

| Mod | Compatibility Status |
| :--- | :--- |
| **AdventureBackpacks** | 🟢 Fully Supported (Keys in backpacks are recognized by doors) |
| **FastItemTransfer** | 🟢 Fully Supported |
| **Buildable Nature / PieceManager Mods** | 🟢 Fully Supported |
| **WardIsLove / Better Wards** | 🟢 Fully Supported |

</div>

---

## 🌐 Available Translations

<div align="center">

🇺🇸 **English** (Default)

</div>

*Want to help translate Door Opener Bruh? Community translations are welcome! Please submit a PR on [GitHub](https://github.com/Vapok/DoorOpenerBruh) or stop by our [Discord](https://discord.gg/5YAJkRFBXt).*

---

## 📥 Installation & Server Setup

### Mod Manager (Recommended)
1. Install via **R2ModMan** or **Thunderstore Mod Manager**.
2. Dependencies (`BepInExPack`, `Jotunn (JVL)`) are installed automatically.

### Dedicated Servers
* **Client & Server Compatible**: Can run as a client-side quality-of-life mod or installed on dedicated servers for centralized configuration enforcement.

---

<div align="center">

### 👨‍💻 Created by Vapok Gaming

[![Vapok Gaming](https://avatars.githubusercontent.com/u/1264136?s=120&v=4)](https://github.com/Vapok)

**Author**: [Vapok](https://github.com/Vapok)  
**Source Code**: [GitHub Repository](https://github.com/Vapok/DoorOpenerBruh)  
**Community & Support**: [Discord Server](https://discord.gg/5YAJkRFBXt)  
**Changelog**: [Release Notes](https://github.com/Vapok/DoorOpenerBruh/blob/main/CHANGELOG.md)

</div>

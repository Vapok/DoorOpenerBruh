# DoorOpenerBruh Patch Notes

## 1.2.2 - Changing Default Enable
* Automatically turns on Auto Door when mod is first installed.
  * This was giving the appearance that the mod didn't do anything when installed.
  * Original value required the player to enable the mod before doors would open.
* Updating Dependencies

## 1.2.1 - Fixing Dedicated Server Config Syncing
* A regression issue was introduced when switching to Jotunn preventing servers from dictating configs to clients.
  * This has been resolved.
* Appropriately added the BepInDependency Flags for graceful mod exit if missing dependencies.

## v1.2.0 - Removes ServerSync, adds JotunnVL  
* Updating for Valheim 0.221.4

## v1.1.4 - Updates for 0.217.28
* Updating for Valheim 0.217.28
* Fixed issue where doors don't open after death.

## v1.1.3 - Updates for 0.217.24
* Updating for Valheim 0.217.24

## v1.1.2 - Bug Fixes and Error Management
* Fixing Death and Spawn Error Messaages.
  * They didn't affect or prevent correct operation.

## v1.1.1 - Door Management and Config
* Introducing Config Settings for Everydoor in the Game.
  * Auto Close/Open settings based on type of Door
  * Auto Close/Open Methods based on Self-made Door, or Player Only made Doors.
  * Auto Close/Open Doors with Keys (if player has them)
  * Configuration is ServerSync-able
  * Respects Wards and Private Access Areas
* Improved the detection and increased the check speed to attempt to prevent non-closures.
* Removed artifact translations
* Cleaned up additional bugs 

## v1.0.1 - Updating to work without other mods now.
* Fixing startup errors when the mod is ran by itself.

## v1.0.0 - Initial Version of DoorOpenerBruh
* Initial Release of Automatic Door Opener
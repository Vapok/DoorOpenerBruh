# 2.0.3 - Unified Splash Screen & Telemetry Controls
* **Unified Startup Splash Screen & Telemetry**:
  * Updated `Vapok.Valheim.Common` dependency reference to `v3.5.1012`.
  * Registered mod metadata with centralized `ModSplashManager`.
  * Added `ShowSplashOnStartup` and `Enable Anonymous Telemetry` configuration bindings to `ConfigRegistry`.

# 2.0.1 - Dependency & Compatibility Maintenance
* **Runtime & Dependency Updates**:
  * Synchronized package manifest and project references with Jotunn `2.30.0` and BepInEx `5.4.2350`.
  * Verified build pipeline and ILRepack bundling with `Vapok.Valheim.Common` `3.2.1012`.
* **Compatibility & Documentation**:
  * Validated door collider detection and player proximity trigger hooks against current Valheim 1.0 builds.
  * Standardized mod documentation, changelog tiers, and release staging.

# 2.0.0 - Valheim 1.0, Ashlands Doors and Deep North Drawbridges
* **Valheim 1.0 Compatibility & Core Updates**:
  * Updated references and dependencies for Valheim 1.0 (`1.0.12`), BepInEx 5.4.2350, and Jotunn 2.30.0.
  * Rebuilt on .NET Framework 4.8.
  * Bundled `Vapok.Valheim.Common` 3.2.1012 via ILRepack.
* **Networking & Multiplayer RPC Synchronization**:
  * Resolved critical networking and RPC synchronization issues for remote multiplayer clients when doors auto-close.
  * Fixed live ZDO state inspection on door entities and resolved local player reference caching issues across character respawn and world reconnect events.
* **New Biome Doors & Drawbridge Support**:
  * Added prefab detection and dedicated configuration settings for Timberwood Drawbridge (`piece_drawbridge`) and Rustic Drawbridge (`piece_drawbridge_log`).
  * Added support for Ashwood Door (`ashwood_door`), Flametal Gate (`flametal_gate`), Grausten Door (`piece_grausten_door`), and Grausten Gate (`piece_grausten_gate`).
* **Collider-Aware Bounds Detection & Distance Config**:
  * Implemented structure bounds proximity checking across large entities (such as drawbridges) to prevent structures from auto-closing while players are actively traversing them.
  * Added per-door configurable `Open Distance` and `Close Distance` settings with hysteresis thresholds to eliminate edge jitter.
  * Eliminated stale state polling intervals in favor of direct proximity triggers for instantaneous approach/departure response.

# 1.2.4 - PieceManager and Buildable Nature Compatibility
* Added initialization ordering guardrails to ensure `DoorStatus` components are not attached before `DoorOpener` is fully initialized.
* Updated Jotunn to 2.29.0.

# 1.2.3 - Local Configuration Change & Dependency Maintenance
* Shifted to client-side local configuration architecture, allowing individual client customization without forcing server-wide door rules.
* Updated to Valheim 0.221.12 references and `Vapok.Valheim.Common` 2.11.22112.
* Updated Jotunn to 2.27.1.

# 1.2.2 - Default Setting Updates
* Enabled automatic door opening by default on initial installation.
* Updated dependencies.

# 1.2.1 - Dedicated Server Config Syncing Fix
* Resolved regression preventing server configuration synchronization from enforcing client settings on dedicated servers.
* Added `BepInDependency` flags for graceful handling when dependencies are missing.

# 1.2.0 - Jotunn Migration & ServerSync Transition
* Migrated configuration sync from standalone ServerSync to Jotunn JVL framework.
* Updated for Valheim 0.221.4.

# 1.1.4 - Valheim 0.217.28 Maintenance
* Updated for Valheim 0.217.28.
* Fixed issue where doors failed to open following player death and respawn.

# 1.1.3 - Valheim 0.217.24 Maintenance
* Updated for Valheim 0.217.24.

# 1.1.2 - Spawn & Death Error Handling
* Fixed error logs generated during player death and respawn events.

# 1.1.1 - Per-Door Configuration & Ward Respect
* Introduced per-door configuration settings for all door prefabs in the game.
* Implemented ward check validation and private area permission verification before triggering door open actions.
* Added key check validation allowing doors to open automatically if the player carries the required crypt/dungeon key.

# 1.0.0 - Initial Release of DoorOpenerBruh
* Initial release of automatic door opening and closing mechanics for Valheim.

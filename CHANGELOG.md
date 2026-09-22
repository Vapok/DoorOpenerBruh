# 2.0.8 - Expanded Door Support, Dedicated Server Support & Stability
* **Expanded Door Support**: Added dedicated configuration settings for Wood Shutters, Wood Fence Gates, and Stave Gates.
* **Dedicated Server Support**: Enabled full configuration loading on headless dedicated servers while bypassing client-only door checks.
* **Door Interaction Safety**: Fixed an issue where third-party mod wards could cause errors when doors open.
* **Dependency Updates**: Updated Jotunn to 2.30.2 and internal dependencies for stability.

<details>
<summary><b>2.0 Changelog History (Valheim Release)</b> (<i>click to expand</i>)</summary>

### 2.0.7 - Valheim 1.0.15 Alignment & Internalized Dependency Updates
* **Valheim 1.0.15 Alignment**: Updated game assembly references and internalized `Vapok.Valheim.Common` 3.13.1015.
* **Localization & Stability**: Re-synchronized 35-language splash localizations and verified patch compatibility.

### 2.0.6 - Splash Window Updates & Valheim 1.0.14 Alignment
* **Splash Window Updates**:
  * Telemetry is now unchecked when first loaded (Opt-In visibility)
  * Added Send Error Logs (Opt-Out)
  * Privacy Policy is now available directly in-game
  * Added Data Disclaimers on hover over checkboxes for transparency on what data is sent
* **Valheim 1.0.14 Alignment**: Updated game assembly references and internalized `Vapok.Valheim.Common` 3.12.1014.


### 2.0.5 - Jewelcrafting Font Compatibility
* Fixed: Jewelcrafting packages it's own font which was overriding part of a vanilla font, causing the Splash screen to appear blank.
### 2.0.4 - Updated README with Telemetry Information
* Updated the README.md with Anonymous Telemetry information per request of mod stores.

### 2.0.3 - Unified Splash Screen & Telemetry Controls
* **Unified Startup Splash Screen**: Integrated with a centralized startup splash screen.
  * Added configurable `Show on Game Startup` which can be enabled or disabled in the configuration file.
* **Anonymous Telemetry**: 
  * Added configurable `Enable Anonymous Telemetry` configuration which can be enabled or disabled in the configuration file.
    * Defaults to enabled with auto-opt-in on launch. Uncheck to Opt-Out
    * ANONYMOUS DATA ONLY - I track version number and usage data. No personal data is ever collected. For more information, see the [Privacy Policy](https://vapok.io/privacy-policy/).

### 2.0.1 - Dependency & Compatibility Maintenance
* **Dependency Updates**: Updated Jotunn and BepInEx runtime package bindings.
* **Compatibility Maintenance**: Verified compatibility against the latest Valheim 1.0 release.
* **Documentation Improvements**: Standardized README, user guides, and technical patch documentation.

### 2.0.0 - Valheim 1.0, Ashlands Doors and Deep North Drawbridges
* **Valheim 1.0 Compatibility**:
  * Updated references and dependencies for Valheim 1.0 and Jotunn 2.30.0.
  * Resolved network synchronization issues for remote multiplayer clients when doors auto-close.
  * Fixed character reference handling on player respawn and server reconnect.
* **New Doors & Drawbridge Support**:
  * Added support and dedicated configuration settings for Timberwood Drawbridge, Rustic Drawbridge, Ashwood Door, Flametal Gate, Grausten Door, and Grausten Gate.
* **Bounds Detection & Distance Config**:
  * Implemented structure bounds proximity checking across large structures (such as drawbridges) to prevent doors/bridges from closing while walking across them.
  * Added per-door configurable Open Distance and Close Distance settings.
  * Improved proximity responsiveness upon approach and departure.

</details>

<details>
<summary><b>1.0 Changelog History (Valheim Early Access)</b> (<i>click to expand</i>)</summary>

### 1.2.4 - PieceManager and Buildable Nature Compatibility
* Added initialization guardrails to ensure door status components initialize reliably.
* Updated Jotunn to 2.29.0.

### 1.2.3 - Local Configuration Change & Dependency Maintenance
* Changed to client-side local configuration, allowing individual player customization.
* Updated to Valheim 0.221.12 references, `Vapok.Valheim.Common` 2.11.22112, and Jotunn 2.27.1.

### 1.2.2 - Default Settings Update
* Enabled automatic door opening by default on fresh mod installations.
* Updated dependencies.

### 1.2.1 - Dedicated Server Config Syncing Fix
* Resolved an issue preventing dedicated servers from properly enforcing configuration settings on connected clients.
* Added graceful dependency handling and notifications.

### 1.2.0 - Jotunn Migration
* Transitioned to Jotunn library and updated for Valheim 0.221.4.

### 1.1.4 - Valheim 0.217.28 Maintenance
* Updated for Valheim 0.217.28.
* Fixed issue where doors failed to open following character death.

### 1.1.3 - Valheim 0.217.24 Maintenance
* Updated for Valheim 0.217.24.

### 1.1.2 - Spawn & Death Error Handling
* Fixed error logs generated during player death and respawn events.

### 1.1.1 - Per-Door Configuration & Ward Respect
* Added configuration settings for every door in the game.
* Implemented automatic door open/close checks based on door type and player ownership.
* Added automatic opening for locked doors when carrying required keys.
* Added respect for player wards and private access zones.

### 1.0.1 - Standalone Compatibility
* Fixed startup errors when running without other companion mods installed.

### 1.0.0 - Initial Release of DoorOpenerBruh
* Initial release of automatic door opening and closing mechanics.

</details>

# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]


## [4.1.0] - 2025-07-12

### Added
- Added GameObjectPool.


## [4.0.1] - 2025-06-18

### Fixed
- Fixed README.

### Removed
- Removed internal devops files.


## [4.0.0] - 2025-04-22

### Removed
- Removed Render Pipeline Converter.

### Added
- Added BoundsInt.Contains2D(Vector2Int position).
- Added BoundsInt.Contains2D(Vector3Int position).
- Added IReadOnlyList<T>.GetXY(int x, int y, int width).
- Added Span<T>.GetXY(int x, int y, int width).
- Added Color32.IsEqualTo(Color32 second).
- Added Color32[].CreateTexture(int width, int height).
- Added Color32[].CreateTexture(int width, int height).
- Added Sprite.GetRect(bool subtractBorder = false).
- Added Sprite.GetPixels32(in Color32 clearColor = default).
- Added Sprite.GetPixelsWithPosition().
- Added Sprite.IsFullyTransparent().
- Added Texture2D.GetPixels32(in RectInt rect, in Color32 clearColor = default).
- Added Texture2D.GetPixels32(in Rect rect, in Color32 clearColor = default).
- Added Texture2D.SetPixels32(in RectInt rect, Color32[] pixels).
- Added Texture2D.GetPixels(in RectInt rect).
- Added Texture2D.GetPixels(in Rect rect).
- Added Texture2D.SetPixels(in RectInt rect, Color[] pixels).
- Added Texture2D.IsFullyTransparent().
- Added Texture2D.AsReadable().
- Added Texture2D.GetSpritesRow(int rowIndex).
- Added Texture2D.GetSpritesMatrix().
- Added Texture2D.GetSprites().
- Added Type.FindImplementations().
- Added UnityObject.SmartDestroy().
- Added UnityObject.RenameTo(string newName).
- Added AnimationClip.GetSettings().
- Added AnimationClip.SetSettings(AnimationClipSettings settings).
- Added AnimationClip.GetSpriteKeyframes().
- Added AnimationClip.SetSpriteKeyframes(ObjectReferenceKeyframe[] frames).
- Added AssetImportContext.TryDependOnArtifact<T>(string path, out T artifact).
- Added Implementation, ImplementationForAttribute, ImplementationLocator.

### Changed
- Changed required test-framework from v2 to v1.


## [3.1.0] - 2023-11-28

### Added
- Added option to NOT use the folder hierarchy when fixing C# namespaces.


## [3.0.0] - 2023-08-15

### Changed
- Increased the minimum Unity version 2021.3.0.
- Increased the minimum Visual Studio package to 2.0.20.


## [2.6.0] - 2023-08-01

### Added
- Added ToDictionary for enumerables of tuples.


## [2.5.5] - 2023-07-08

### Fixed
- Fixed WebGL build failure with the message "'' is an incorrect path for a scene file.".


## [2.5.4] - 2023-05-21

### Fixed
- Made `SerializableKeyValuePairsDrawer` public.


## [2.5.3] - 2023-05-21

### Changed
- Unsealed `SerializableKeyValuePairs`.


## [2.5.2] - 2023-04-24

### Fixed
- Fixed Build.Solution command creating .csproj files with `<LangVersion>latest</LangVersion>` when Visual Studio is not installed.
- The option fixBurstCompilerPathForAndroid is only processed when the build target is Android, preventing irrelevant error messages when the Android SDK is not installed.


## [2.5.1] - 2023-04-04

### Added
- Added support for Unity 2019.3.


## [2.5.0] - 2023-03-07

### Added
- Added CLI method Slothsoft.UnityExtensions.Editor.Build.Solution.


## [2.3.0] - 2023-01-02

### Added
- Added AssetUtils.


## [2.2.0] - 2023-01-02

### Added
- Added support for Unity 2022.2.


## [2.0.0] - 2022-10-13

### Added
- Added a C# template with namespace support.


## [1.5.0] - 2022-03-11

### Added
- Added Tilemap and ITilemap extensions.
- Added more IEnumerable extensions.
- Added more Vector2, Vector2Int, Vector3, Vector3Int extensions.
- Added more Transform extensions.
- Added missing documentation.
- Added missing tests.

### Removed
- Removed SerializableDictionary.


## [1.4.0] - 2021-07-12

### Added
- Added a WebGL template to use in iframes.


## [1.3.0] - 2021-06-17

### Changed
- Replaced settings asset with com.unity.settings-manager.


## [1.2.6] - 2021-03-28

### Fixed
- Minor code cleanup.


## [1.2.5] - 2021-03-28

### Added
- Made SerializableKeyValuePairs thread-safe(ish).


## [1.2.4] - 2021-03-07

### Fixed
- Fixed drawer inheritance.


## [1.2.3] - 2021-03-07

### Added
- Improved RuntimeEditorTools.
- Added Wait.forSeconds[float].


## [1.2.2] - 2021-03-01

### Fixed
- Fixed dictionary index label.


## [1.2.1] - 2021-03-01

### Added
- Added PropertyDrawer for SerializableKeyValuePairs.


## [1.2.0] - 2021-02-28

### Changed
- Moved settings to Plugins/Slothsoft/.

### Added
- Added Vector2, Vector3, Color extensions.
- Added SerializableKeyValuePairs.


## [1.1.0] - 2021-02-02

### Changed
- Made RuntimeEditorTools compatible with any UnityEngine.Object.


## [1.0.0] - 2021-01-13
First release on OpenUPM.
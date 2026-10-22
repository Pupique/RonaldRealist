# Ronald Realist

A RimWorld mod that introduces a storyteller whose event frequency is driven by geographical, environmental, and colonial (wealth and population) factors.

**Package ID:** `Pupique.RonaldRealist`  
**Author:** Pupique  
**License:** [GPL-3.0](LICENSE)

Supported game versions and the player-facing description live in [`Mod/About/About.xml`](Mod/About/About.xml)—treat that as the source of truth when they change.

## Premise

Vanilla storytellers largely ignore where you settle and how your colony is shaped. This mod focuses on making event cadence respond to geography, environment, and colony state (wealth and population), rather than overhauling storyteller design as a whole.

Exact gameplay effects may expand or shift as the mod develops; context-specific event definitions live under [`doc/`](doc/).

## How the repository is organized

Only the [`Mod/`](Mod/) directory is what RimWorld (and Steam Workshop) should load. Everything else is development metadata and source.

| Path | Role |
|------|------|
| `Mod/` | Loadable mod root (`About/`, `LoadFolders.xml`, versioned content) |
| `Mod/About/` | Mod metadata and preview |
| `Mod/<version>/` | Assemblies and other assets for that game version |
| `<version>/Source/` | C# project and Harmony patches (not shipped inside `Mod/`) |

`LoadFolders.xml` wires each supported RimWorld release to its folder under `Mod/` (for example `Mod/1.7/`).

Adding another game version means mirroring the version tree under `Mod/`, adding a matching `Source/` project when needed, then updating `Mod/LoadFolders.xml` and the supported-versions list in `Mod/About/About.xml`.

## Requirements

### To play

- A supported RimWorld version (see `Mod/About/About.xml`)
- [Harmony](https://steamcommunity.com/sharedfiles/filedetails/?id=2009463077) (`brrainz.harmony`)

Enable this mod after Harmony. Restart RimWorld or reload mods after updating assemblies.

### To build from source

- A [.NET SDK](https://dotnet.microsoft.com/download) compatible with the version project’s `TargetFramework`
- A matching RimWorld install (managed game assemblies for compile references)

Machine-specific paths are not committed. Each version’s project uses a gitignored `Local.props` beside the `.csproj` (see below).

## Building

Commands below use the current `1.7` tree as an example; substitute the version folder you are building.

1. Clone this repository somewhere convenient (not necessarily inside RimWorld’s `Mods` folder).

2. Configure local paths:

   ```bash
   cp 1.7/Source/Local.props.example 1.7/Source/Local.props
   ```

   Edit `Local.props` and set `RimWorldManagedDir` to the directory that contains `Assembly-CSharp.dll`. Optionally set `RimWorldModsDir` or `RimWorldModInstallDir` if the default live-install path derived from `RimWorldManagedDir` is wrong for your install. The example file has typical Steam path hints.

   For a full install of loadable content, also configure `paths.env` (from `paths.env.example`) and run `./deploy.sh` once so `Mods/RonaldRealist` exists.

3. Restore and build:

   ```bash
   dotnet restore 1.7/Source/RonaldRealist.csproj
   dotnet build 1.7/Source/RonaldRealist.csproj -c Release
   ```

   Output lands under `Mod/1.7/Assemblies/`. After a successful build, the project also copies those assemblies into `Mods/RonaldRealist/1.7/Assemblies/` (it does not rewrite the rest of the install). Use `./deploy.sh` when About, `LoadFolders.xml`, defs, or other non-assembly content under `Mod/` changes.

4. Load the mod in-game with Harmony enabled, then restart or reload mods so the new assembly is picked up.

Do not commit `Local.props`, `paths.env`, `bin/`, `obj/`, or built `*.dll` files (already covered by `.gitignore`).

## Contributing

Issues and forks are welcome. Keep changes coherent with the core idea: event frequency shaped by geography, environment, and colony factors—not a wholesale storyteller redesign.

For agent/tooling conventions used in this repo, see [AGENTS.md](AGENTS.md).

## License

This project is licensed under the [GNU General Public License v3.0](LICENSE).

# Mod overview — Ronald Realist

Canonical agent knowledge base for this repository’s mod. Prefer this file over sifting `Mod/About/` XML when you need identity, purpose, or conventions.

General RimWorld agent rules live in [`AGENTS.md`](../AGENTS.md). Keep this overview in sync when you deliberately change the corresponding fields in `Mod/About/` (or related conventions in code).

## Purpose

A different type of Rimworld storyteller whose main premise is an event frequency revamp based on geographical, environmental, and colonial (wealth and population) factors.

Context-specific definitions of events lie on the [documents](../doc) folder. Check relevant documentation in order to have a better understanding of the task at hand.

> [!NOTE]
> An overall revamp of storytellers is not the mod's purpose and is not included in its scope.

## Identity

| Item | Value |
|------|--------|
| Display name | Ronald Realist |
| Author | Pupique |
| Package id | `Pupique.RonaldRealist` |
| Harmony id | `Pupique.RonaldRealist` |
| Deploy folder under RimWorld `Mods/` | `RonaldRealist` |
| Player-facing log prefix | `[Ronald Realist]` |
| Supported game versions | 1.7 |
| Required dependency | Harmony (`brrainz.harmony`) |

Keep package id, Harmony id, deploy folder, and log prefix stable unless the user changes them deliberately.

## Done criteria (mod-specific)

Storyteller applies events based on the specifications provided in the documentation.

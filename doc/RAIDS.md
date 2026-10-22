# Raids

Vanilla raids are one of the biggest contention points. Their frequency under standard storytellers are evidently artificial and often clockwork.

Given that Storytellers manage events based on arbitrarily chosen parameters, either fixed or variable, they don't match the colony's geography and climate, taking only its wealth and recent events as relevant factors which mostly deal with their intensity rather than frequency.

Therefore, as a proposal to make them more realistic and adequate to a colony's environment, each type (or group) of raids will have its own frequency rather than being fired based on abstract Storyteller parameters.

## Humanoid Raids

Humanoid raids are raids conducted by humanoid factions. Entry method is not taken into consideration and is grouped together, with it being decided randomly.

The frequency formula is:

\[
ERh = (7\% \times Ag \times (0.25 + (0.75 \times Ac)) \times (0.1 + (0.9 \times Ap)) + (2\% \times (\log_{10}(W) - 4))) \times (1 + Ash)
\]

where:

- \( ERh \) is the frequency of humanoid raids;
- \( A* \) are attractiveness modifiers from Variables;
- \( W \) is the settlement's wealth.

From it we can conclude:

- Raid chance is composite:
  - Base/terrain chance is 7%:
    - Geography has 100% impact;
    - Climate has 75% impact;
    - Pollution has 90% impact.
  - Wealth separately affects chance:
    - 2% extra chance for every 10x wealth over 1,000:
      - Wealth of 10,000 has 2% chance;
      - Wealth of 100,000 has 4% chance;
      - Wealth of 1,000,000 has 6% chance;
      - etc.
  - Nearby hostile settlements increase overall chance with 100% impact.
- Rationale is that:
  - Terrain attractiveness is the main factor;
  - Wealth further manipulates chance since:
    - It makes sense to make remote albeit wealthy settlements interesting targets;
    - They will likely be less interesting targets than poorer albeit easy targets, however, which is intended.

## Manhunter Packs

The formula for the likelihood of a manhunter pack appearing is:

\[
ERm = \frac{5\% \times \frac{TR}{1500} \times \frac{1}{\sqrt{Ap}}}{1+As}
\]

where:

- \( ERm \) is the frequency of manhunter packs;
- \( A* \) are attractiveness modifiers from Variables;
- \( TR \) is the terrain's yearly rainfall.

From it we can conclude:

- Manhunter chance is simple:
  - Base chance is 5%:
    - Reaches 100% at 1500mm of rainfall and extends beyond it;
    - Is inversely proportional to the settlement's pollution attractiveness.
  - Nearby settlements decrease chance with 100% impact.
- Rationale is that:
  - Rainfall is a crude albeit reasonable proxy for wildlife density;
  - Pollution theoretically increases the likelihood of disease spread, which in turn results in Scaria (Manhunter pack) attacks:
    - Has little effect on barren regions, therefore a heavily polluted extreme desert is unlikely to be a target.
    - Whereas non-polluted but wet regions still are relatively likely targets.
  - Nearby settlements serve as deterrents, therefore decreasing overall manhunter population;
  - Geographical isolation and wealth are irrelevant factors.

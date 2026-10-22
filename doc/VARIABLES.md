# Variables

Variables are, as the name suggests, variables that can be used to determine the frequency of events. Since they are common to multiple types of events, they are listed here for easy reference.

## Base Game Variables

Base game variables are those that are directly accessible from the game's data.

## Calculated Variables

Calculated variables are custom variables, specified here in this document, to compose events' frequencies.

### Geography

The sole variable for geography is the colony terrain's Movement Difficulty.

It alone considers:
- Hilliness;
- Vegetation;
- Road access.

All of these are sufficient to determine the colony's accessibility except for cases in which are reliant on its surroundings like islands or desolate valleys.

Surrounding terrain can be included at a later date.

Therefore, the formula for the colony's geographical attractiveness is:
\[ Ag = \frac{1}{TMd} \]
where:
- \( Ag \) is the colony's geographical attractiveness;
- \( TMd \) is the colony's terrain movement difficulty.

The following can be concluded from the formula:
- Its output value will always be greater than 0;
- The value is multiplicatively inverted since the lower the movement difficulty, the more accessible the colony is.

### Climate

Even though using the climate type (Temperate Forest, Desert, etc.) is a good indicator of the colony's climate, it will likely be incompatible with mods that add climate types, thus warranting extensive patches to integrate with them.

Therefore, as a compromise, climate considers two terrain variables in the colony's location:
- Average temperature;
- Rainfall.

Since most climates are defined by these two variables, they are sufficient to determine the colony's climate with reasonable accuracy.

As the climate attractiveness level based on these two variables should form a parabola, their union is based on both input variables interacting against each other:
\[ Ac = \sqrt{(1-(\frac{clamp(TTa,-10,40)-15}{25})^2)^2 \times (1-(\frac{clamp(TR,0,3000)-1500}{1500})^2)^2} \]
where:
- \( Ac \) is the colony's climate attractiveness;
- \( TTa \) is the colony's average temperature;
- \( TR \) is the colony's rainfall.

The formula is as such since it reaches its maximum point halfway through its clamped range, with smoothened plateaus at the middle and the edges.

Therefore, using the aforementioned formula:
- Output value will fluctuate between 0 and 1 (inclusive);
- Regarding Temperature:
  - Maximum attractiveness is at 15°C;
  - Attractiveness is 0 at -10°C and 40°C.
- Regarding Rainfall:
  - Maximum attractiveness is at 1500mm;
  - Attractiveness is 0 at 0mm and 3000mm.
- After all calculations, the value is normalized with a cube root:
  - This widens the acceptable range whilst keeping the extremes unattractive.

#### Additional Considerations

Using the immediate temperature instead of the yearly average is a possibility but it would require repeated calculations which may compound to performance loss and an unreliable frequency over time.

Therefore, the average temperature is used instead.

### Pollution

Pollution, both in the colony and its surroundings, imposes a pontentially significant impact on the colony and to whomever decides to visit it for whatever reason.

Therefore, both factors are taken into consideration to assemble the severity of the region's pollution and how much of a deterrent it is supposed to be.

The formula for the pollution attractiveness level is:
\[ Ap = (\sqrt{\frac{1}{1+TPn}} \times 0.5) + ((1-TP) \times 0.5) \]
where:
- \( Ap \) is the pollution attractiveness level;
- \( TPn \) is the nearby pollution;
- \( TP \) is the colony's pollution.

Therefore, by observing the formula, the following can be concluded:
- Output value will fluctuate between 0 and 1 but always greater than 0;
- Both variables compose the final attractiveness level equally:
  - Even though it seems that the colony's pollution is relatively underrrepresented, it is worth noting that heavily polluted areas will likewise have a higher nearby pollution;
  - Therefore, this equal distribution ends up being a reasonable representation of the overall pollution level.

### Proximity

Proximity is a composite variable which counts every settlement within the radius of 20 tiles. The farther the settlement, less its impact will be.

Nearby settlements can also be filtered by their relation to the colony:
- Allied (relations > 50);
- Neutral (relations > 0):
  - Includes allied settlements.
- Hostile (relations < 0).

The formula for the proximity attractiveness impact is:
\[ As = \sum_{x \in S} \frac{20-distance(x,c)}{20} \]
where:
- \( As \) is the proximity attractiveness impact with variants:
  - \( Asa \) is the allied proximity attractiveness impact;
  - \( Asn \) is the neutral proximity attractiveness impact;
  - \( Ash \) is the hostile proximity attractiveness impact;
  - \( As \) is the total proximity attractiveness impact from all nearby settlements.
- \( S \) is the set of settlements;
- \( c \) is the colony;
- \( distance(x,c) \) is the distance between the settlement \( x \) and the colony \( c \).

The formula is as such since the impact is inversely proportional to the distance.

Therefore, using the aforementioned formula:
- Output value can be greater or equal to 0:
  - Each individual settlement can contribute from 0 to 1 (inclusive) to the total impact.
- The output value will be the sum of the inverse distances of all settlements within the radius.

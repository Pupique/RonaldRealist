# Events

Events are the core of any Storyteller. It's the storyteller's responsibility to manage events according to their specifications.

Given that Ronald Realist is a storyteller that aims to make the game more realistic as his own name implies, his event system is based on actual calculations and estimations rather than arbitrary parameters and near-clockwork sequences.

## Event Natures

Event natures refer to the frequency calculation method of an event:
1. Variable, where its formula is composed of at least one variable;
2. Constant, where its formula is a constant value.

An event's nature can be inferred from its frequency formula.

### Variables

Variable events are largely dependent on variables. Said variables have a constant formula which is dependent on the colony's data but each event manages each variable according to its own settings.

See [VARIABLES.md](VARIABLES.md) for more information on the variables and their formulas.

### Frequency

Event variables and their probabilities are calculated once per ingame day at a randomly picked hour.

> [!TODO]
> Decide on the frequency of daily event checks: dynamic as 1 or more in the case of high frequency events?

### Examples

Consult [examples](examples/) for real and simulated colony examples to see how the variables are calculated and how they affect the frequency of events.

Contains both `.ods` and `.csv` files.

## Event Types

Below is a table of event types and their respective specification files. Any event that is not included in the list and the files therein are assumed to follow Vanilla settings.

| Event Type | Specification File |
|------------|--------------------|
| Raids | [RAIDS.md](RAIDS.md) |

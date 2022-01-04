# Celluloze

Cellular automaton framework that allows user to define own set of rules.

![Game Of Life glider](https://upload.wikimedia.org/wikipedia/commons/f/f2/Game_of_life_animated_glider.gif)

## Summary

Project is a part of 2022 [#csharpchallenge](https://twitter.com/hashtag/csharpchallenge?f=live) initiative. It gives user possibility to recreate well-known cellular automatons like `Game Of Life`, `Seeds` or `Langton's ant`, add own rules within automaton engine and render state of grid in each generation.

## Technologies

* .NET 6

## Roadmap

1. Create and render static patterns in console application
1. Add `Game Of Life` rules support
1. Add mechanism to define own rulesets
1. Add GUI
1. Performance improvements

## Possible ideas

* allow non-2D grids
* allow custom cell shapes and neighborhood definition
* add human-friendly serialization for easy sharing of rules and initial states
* add stale-state check mechansim to stop simulation when it reaches final form
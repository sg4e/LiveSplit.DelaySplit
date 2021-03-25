# DelaySplit

A LiveSplit Component to automatically split after a set delay. Useful for multi-game races that require cart-swap delays, like the NES Big 20 and SNES Super 16.

## Installation

Download the latest DLL file from the [Releases page](https://github.com/sg4e/LiveSplit.DelaySplit/releases) and place it in the "Components" folder of the LiveSplit directory.

## Configuration

Open LiveSplit and right-click on your splits -> "Edit Layout..." -> click the "+" icon -> "Control" -> "DelaySplit".

Click the "Layout Settings" button to adjust DelaySplit's default settings. Please note that these settings are saved to your LiveSplit layout file and not your splits file.

![DelaySplit default settings](/DelaySplit_settings.png)

## Precision

DelaySplit aims to split within 15 milliseconds after the set delay, which is less than 1 frame in a 60 FPS game. If you have your LiveSplit layout configured to show hundredths of seconds, you may notice an additional 0.01-second delay on the automatic splits. This is normal, and while DelaySplit may split a few milliseconds late, it will never split early and offer you an unfair advantage in the "Swap Game" period of a race. If you experience longer delays, your CPU may be under heavy load and unable to schedule DelaySplit's threads in a timely manner.

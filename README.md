# CODEQUEST: Console Wizard RPG 🧙‍♂️

CodeQuest is a RPG game developed in C# and ready for use on its console. It consists of a menu with 7 options (Plus the exit game option!) with several mechanics and features to choose from.

In this README.md, I will be explaining and ellaborating on its features.

# Table of contents
0. [Setup and Initialization](#intro)
1. [Chapter 1: Train your Wizard](#chapter1)
2. [Chapter 1: Increase Wizard's Level](#chapter2)
3. [Chapter 2: ](#chapter2)
4. [Chapter 3: ](#chapter2)
5. [Chapter 4: ](#chapter2)
6. [Chapter 5: ](#chapter2)
3. [Chapter 6: ](#chapter2)
7. [Chapter 6: ](#chapter2)


-----

## 0\. Setup and Initialization <a name="intro"></a>

The `Main` method prepares the console environment and sets up core game utilities.

```csharp
public static void Main()
{
    // Enables Unicode/UTF8 encoding for emojis (like 💀, 🪙, 🔥) to display correctly.
    Console.OutputEncoding = System.Text.Encoding.UTF8; 
    Console.InputEncoding = System.Text.Encoding.UTF8;
    
    // Core game utility for randomness (combat dice, mine contents, training hours).
    Random rand = new Random();
    
    // Defines the size of the mining grid.
    const int ROWS = 5, COLS = 5; 
    
    // ... (Constant and variable declarations)
}
```

-----
## 1\. Chapter 1: Train Your Wizard <a name="chapter1"></a>

## 2\. Chapter 2: Increase Wizard's Level <a name="chapter2"></a>

The program uses extensive **`const`** fields for all static game text, monster names, prices, and ASCII art, centralizing all game data.

### Key Data Structures

| Data Structure | Type | Purpose |
| :--- | :--- | :--- |
| `wizardLevel`, `power`, `totalBits` | `int` | Player stats and currency. |
| `inventory` | `string[]` | Stores purchased/looted items. **(Note: Array is dynamically resized, which is generally inefficient; converting to `List<string>` is recommended for future scalability.)** |
| `healthpoints` | `int[]` | Stores the initial health of all monsters. |
| `levels` | `string[][]` | A **jagged array** defining spells available at each wizard level. |
| `dices` | `string[]` | ASCII art representations of the d6 roll. |

-----

## 3\. Game Flow and Main Menu (The `do-while` Loop)

The game's primary execution loop runs until the player selects **Option 0 (Exit game)**.

### A. Wizard Name Input

The initial `do-while` loop ensures the user enters a non-empty name (`string.IsNullOrWhiteSpace` check) and capitalizes it correctly for display.

### B. Main Menu Loop and Robust Input Validation 🛡️

This section uses a nested `do-while` structure to guarantee the user's input is both **non-empty** and a **valid integer within the accepted range (0-7)** before proceeding to the game logic.

1.  **Outer Loop (`do { ... } while (op != 0);`)**: Keeps the main menu cycling until the player exits.
2.  **Inner Loop (`do { ... } while (!isValidSelection);`)**: Handles all input validation:
      * It first checks if the input is empty (`string.IsNullOrWhiteSpace(opString)`).
      * If not empty, it attempts conversion using `Int32.TryParse`.
      * It checks the range (`op >= 0 && op < 8`).
      * If conversion fails (e.g., user enters a letter) or the number is out of range, the inner loop displays `MsgError` and repeats the prompt, **preventing program termination**.

-----

## 4\. Menu Option Breakdown (The Main `switch` Statement)

### Case 1: Train Your Wizard (Training) 🏋️

  * Simulates 5 days of training, accumulating `totalHours` and increasing the player's `power` stat.
  * Assigns a rank/title (`wizardTitle`) based on specific `power` point thresholds.

### Case 2: Increase LVL (Combat) ⚔️

  * A random monster is selected.
  * A `while` loop simulates combat: the player rolls a d6, dealing damage equal to the dice result.
  * Upon the monster's defeat, the wizard levels up (`wizardLevel++`, capped implicitly by the highest level in `levels`).
  * The monster's HP is reset using the `tempHP` variable, restoring its original health for the next encounter.

### Case 3: Loot the Mine (Grid Minigame) ⛏️

  * Initializes a $5 \times 5$ grid (`mineFilled`) with random treasures (coins or empty slots).
  * The player has 5 mining attempts (`attempts`).
  * **Input Handling:** This section uses nested `Console.ReadLine()` calls for the X and Y coordinates. **Note:** This structure is susceptible to losing an attempt if the user provides invalid input (non-numeric, out-of-bounds) for either coordinate, as the overall logic does not immediately repeat the coordinate prompt on failure.
  * Finding a coin adds random `bits` to `totalBits`.

### Case 4: Show Inventory 🎒

  * Displays all items currently stored in the `inventory` array.
  * Shows a message if the inventory is empty.

### Case 5: Buy Items (Shop) 🛍️

  * Allows the player to purchase items if they have sufficient `totalBits`.
  * If an item is purchased, the `inventory` array is **resized manually** using a temporary array and a loop to copy elements, which is a key area for performance improvement (by using `List<string>`).
  * Updates `totalBits` upon a successful purchase.

### Case 6: Show Attacks by LVL ✨

  * Displays the spells available to the wizard from the `levels` jagged array, corresponding to the current `wizardLevel`.
  * Includes a check to cap the attack display at the maximum defined level.

### Case 7: Decode Ancient Scroll (Logic Puzzle) 📜

  * A mini-game requiring three separate string manipulation tasks (Actions 1, 2, 3):
      * **Action 1:** Removes spaces from a scroll text.
      * **Action 2:** Counts the number of vowels (`vowels`) in a scroll text.
      * **Action 3:** Extracts all numeric digits (`numbers`) from a scroll text.
  * Success is tracked via `stepOne`, `stepTwo`, and `stepThree` flags. **Note:** These flags should be reset when re-entering Case 7 to allow for multiple puzzle attempts in one session.

### Case 0: Exit Game 👋

  * Terminates the program gracefully.

*Content initially generated with Google's Gemini 3 Pro AI, but completely reforged.

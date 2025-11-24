# CODEQUEST: Console Wizard RPG 🧙‍♂️

CodeQuest is a RPG game developed in C# and ready for use on its console. It consists of a menu with 7 options (Plus the exit game option!) with several mechanics and features to choose from.

In this README.md, I will be explaining and ellaborating on its features.

# Table of contents
[Setup and Initialization](#intro)

0. [Test Cases for Main Menu](#testcases)
1. [Chapter 1: Train your Wizard](#chapter1)
2. [Chapter 2: Increase Wizard's Level](#chapter2)
3. [Chapter 3: Loot the Mine](#chapter3)
4. [Chapter 4: Show Inventory](#chapter4)
5. [Chapter 5: Buy Items](#chapter5)
6. [Chapter 6: Show Attacks ](#chapter6)
7. [Chapter 7: ](#chapter7)


-----

## Setup and Initialization <a name="intro"></a>

The `Main` method prepares the console environment and sets up core game utilities.

```csharp
public static void Main()
{
    // Enables Unicode/UTF8 encoding for emojis (like 💀, 🪙, 🔥) to display correctly.
    Console.OutputEncoding = System.Text.Encoding.UTF8; 
    Console.InputEncoding = System.Text.Encoding.UTF8;
    
    // Core game utility for randomness (combat dice, mine contents, training hours).
    Random rand = new Random();

    //...every constant and variable declared to help with the program's features.

}
```

-----

The program uses extensive **`const`** fields for all static game text, monster names, prices, and ASCII art, centralizing all game data.

#### Key Data Structures

| Data Structure | Type | Purpose |
| :--- | :--- | :--- |
| `wizardLevel`, `power`, `totalBits` | `int` | Player stats and currency. |
| `inventory` | `string[]` | Stores purchased/looted items. **(Note: Array is dynamically resized, which is generally inefficient; converting to `List<string>` is recommended for future scalability.)** |
| `healthpoints` | `int[]` | Stores the initial health of all monsters. |
| `levels` | `string[][]` | A **jagged array** defining spells available at each wizard level. |
| `dices` | `string[]` | ASCII art representations of the d6 roll. |

-----

#### A. Wizard Name Input

The initial `do-while` loop ensures the user enters a non-empty name (`string.IsNullOrWhiteSpace` check) and capitalizes it correctly for display.

#### B. Main Menu Loop and Robust Input Validation 🛡️

This section uses a nested `do-while` structure to guarantee the user's input is both **non-empty** and a **valid integer within the accepted range (0-7)** before proceeding to the game logic.

1.  **Outer Loop (`do { ... } while (op != 0);`)**: Keeps the main menu cycling until the player exits.
2.  **Inner Loop (`do { ... } while (!isValidSelection);`)**: Handles all input validation:
      * It first checks if the input is empty (`string.IsNullOrWhiteSpace(opString)`).
      * If not empty, it attempts conversion using `Int32.TryParse`.
      * It checks the range (`op >= 0 && op < 8`).
      * If conversion fails (e.g., user enters a letter) or the number is out of range, the inner loop displays `MsgError` and repeats the prompt, **preventing program termination**.

-----

## 0. Test Cases for Main Menu <a name ="testcases"></a>


### **Test Case 1: Error Case (Input = "A")** ❌

This case verifies what happens whan user inputs a non-valid option that leads to an error.

| # Instruction | # Iteration | Variables | Condition / Output |
| :--- | :--- | :--- | :--- |
| **1** (ReadLine) | - | `opString`="A" | - |
| **2** (Null Check) | - | `opString`="A" | IsNullOrWhiteSpace? $\rightarrow$ **FALSE** |
| **3** (TryParse) | - | `op`=0, `isOp`=False | Conversion Successful? $\rightarrow$ **FALSE** |
| **4** (Range Check) | 1 | `isValidSelection`=False | `isOp` && Range? $\rightarrow$ **FALSE** |
| **5** (Else Block) | - | - | **Output:** "Invalid option. Try again!" |
| **6** (While Loop) | - | `isValidSelection`=False | !isValidSelection $\rightarrow$ **TRUE** (Repeat Loop) |

---

### **Test Case 2: Limit Case (Input = "7")** 🚧

This case verifies the upper limit of the allowed range (0-7). The number is 7, just making it into the menu's valid options.

| # Instruction | # Iteration | Variables | Condition / Output |
| :--- | :--- | :--- | :--- |
| **1** (ReadLine) | - | `opString`="7" | - |
| **2** (Null Check) | - | `opString`="7" | IsNullOrWhiteSpace? $\rightarrow$ **FALSE** |
| **3** (TryParse) | - | `op`=7, `isOp`=True | Conversion Successful? $\rightarrow$ **TRUE** |
| **4** (Range Check) | 1 | `isValidSelection`=True | `op` >= 0 && `op` < 8? $\rightarrow$ **TRUE** |
| **5** (While Loop) | - | `isValidSelection`=True | !isValidSelection $\rightarrow$ **FALSE** (Exit Loop) |
| **6** (Switch) | - | `op`=7 | **Action:** Enter "Case 1: Train your wizard" |
---

### **Test Case 3: Normal Case (Input = "1")** ✅
Este caso verifica una entrada correcta que permite entrar al juego.

| # Instruction | # Iteration | Variables | Condition / Output |
| :--- | :--- | :--- | :--- |
| **1** (ReadLine) | - | `opString`="1" | - |
| **2** (Null Check) | - | `opString`="1" | IsNullOrWhiteSpace? $\rightarrow$ **FALSE** |
| **3** (TryParse) | - | `op`=1, `isOp`=True | Conversion Successful? $\rightarrow$ **TRUE** |
| **4** (Range Check) | 1 | `isValidSelection`=True | `op` >= 0 && `op` < 8? $\rightarrow$ **TRUE** |
| **5** (While Loop) | - | `isValidSelection`=True | !isValidSelection $\rightarrow$ **FALSE** (Exit Loop) |
| **6** (Switch) | - | `op`=1 | **Action:** Enter "Case 1: Train your wizard" |

## Chapter 1: Train Your Wizard <a name="chapter1"></a> 

  * Simulates 5 days of training, accumulating `totalHours` and increasing the player's `power` stat.
  * Assigns a rank/title (`wizardTitle`) based on specific `power` point thresholds.

## Chapter 2: Increase LVL <a name="chapter2"></a>

  * A random monster is selected.
  * A `while` loop simulates combat: the player rolls a d6, dealing damage equal to the dice result.
  * Upon the monster's defeat, the wizard levels up (`wizardLevel++`, capped implicitly by the highest level in `levels`).
  * The monster's HP is reset using the `tempHP` variable, restoring its original health for the next encounter.

## Chapter 3: Loot the Mine <a name="chapter3"></a>

  * Initializes a $5 \times 5$ grid (`mineFilled`) with random treasures (coins or empty slots).
  * The player has 5 mining attempts (`attempts`).
  * **Input Handling:** This section uses nested `Console.ReadLine()` calls for the X and Y coordinates.
  * Finding a coin adds random `bits` to `totalBits`.

## Chapter 4: Show Inventory <a name="chapter4"></a>

  * Displays all items currently stored in the `inventory` array.
  * Shows a message if the inventory is empty.

## Chapter 5: Buy Items <a name="chapter5"></a>

  * Allows the player to purchase items if they have sufficient `totalBits`.
  * If an item is purchased, the `inventory` array is **resized manually** using a temporary array and a loop to copy elements, which is a key area for performance improvement (by using `List<string>`).
  * Updates `totalBits` upon a successful purchase.

## Chapter 6: Show Attacks by LVL <a name="chapter6"></a>

  * Displays the spells available to the wizard from the `levels` jagged array, corresponding to the current `wizardLevel`.
  * Includes a check to cap the attack display at the maximum defined level.

## Chapter 7: Decode Ancient Scroll <a name="chapter7"></a>

  * A mini-game requiring three separate string manipulation tasks (Actions 1, 2, 3):
      * **Action 1:** Removes spaces from a scroll text.
      * **Action 2:** Counts the number of vowels (`vowels`) in a scroll text.
      * **Action 3:** Extracts all numeric digits (`numbers`) from a scroll text.
  * Success is tracked via `stepOne`, `stepTwo`, and `stepThree` flags. **Note:** These flags should be reset when re-entering Case 7 to allow for multiple puzzle attempts in one session.

### Case 0: Exit Game 👋

  * Terminates the program gracefully.

*Content initially generated with Google's Gemini 3 Pro AI, but completely reforged.

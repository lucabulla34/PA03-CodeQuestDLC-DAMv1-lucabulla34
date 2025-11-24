# Chapter 3: Loot the Mine (Grid Minigame) - Logic Breakdown ⛏️

This section initializes a 5x5 grid (`ROWS`=5, `COLS`=5) and randomly places treasures (Coins) or empty spaces using a nested `for` loop. The player interacts with this grid by inputting X and Y coordinates to uncover what is hidden.

## A. Grid Initialization and Input Loop

| Instruction | Purpose | Key Variables Affected | Detailed Logic |
| :--- | :--- | :--- | :--- |
| **`attempts = 5`** | **State Reset** | `attempts` | Sets the player's lives for this minigame session. |
| **`string[,] mineFilled...`** | **Grid Setup** | `mineFilled` | Creates a 2D array to hold the "hidden" values (Coin/Empty). |
| **`for (int i...)`** | **Populate Grid** | `mineFilled` | Iterates through [0,0] to [4,4]. RNG places either `Coin` or `Empty` tokens. |
| **`do-while (attempts > 0)`** | **Game Loop** | `attempts` | Grants the player strictly 5 tries. Loop repeats until attempts run out. |
| **`TryParse` (X & Y)** | **Input Validation** | `xAxis`, `yAxis` | Attempts to parse string inputs into integers. |
| **`if (isAxis && ...)`** | **Range Check** | N/A | Checks if input is valid AND within bounds (0 to 4). |
| **`if (mineFilled[x,y] == treasures[1])`** | **Hit Logic (Coin)** | `totalBits` | If a coin is found, adds `bits` to total and marks the spot on `mineUser` map. |
| **`mineFilled[x,y] = treasures[0]`** | **Exploit Prevention** | `mineFilled` | **Crucial:** If a coin is found, the slot is changed to `Empty` in the hidden grid to prevent farming the same coordinate. |
| **`else if (... == treasures[0])`** | **Miss Logic (Empty)** | `attempts` | If empty, marks the spot with an 'X' (`userOutput[2]`) on the user map. |

---

## B. Test Cases

### **Test Case 1: Error Case (Invalid Type Input)** ❌
**Scenario:** The user introduces a letter ("A") instead of a number for the X-axis.
*Initial State: `attempts` = 5, `totalBits` = 0.*

| # Instruction | Variables | Condition / Output |
| :--- | :--- | :--- |
| **1** (Input X) | `opString`="A" | - |
| **2** (TryParse) | `xAxis`=0, `isAxis`=**False** | Conversion Failed. |
| **3** (If Check) | `isAxis`=False | `isAxis` && ... $\rightarrow$ **FALSE** |
| **4** (Else Block) | - | **Output:** "Invalid option. Try again!" |
| **5** (Loop Check) | `attempts`=5 | 5 > 0 $\rightarrow$ **TRUE** (Loop repeats, attempt NOT lost) |

### **Test Case 2: Limit Case (Out of Bounds Input)** 🚧
**Scenario:** The user introduces a number that is valid as an integer but outside the grid array limits (e.g., 5, when max index is 4).
*Initial State: `attempts` = 5, `totalBits` = 0.*

| # Instruction | Variables | Condition / Output |
| :--- | :--- | :--- |
| **1** (Input X) | `opString`="5" | - |
| **2** (TryParse) | `xAxis`=5, `isAxis`=**True** | Conversion Success. |
| **3** (If Check) | `xAxis`=5 | 5 < `ROWS` (5)? $\rightarrow$ **FALSE** (Strict inequality fail) |
| **4** (Else Block) | - | **Output:** "Invalid option. Try again!" |
| **5** (Loop Check) | `attempts`=5 | Attempts remain 5. Loop repeats. |

### **Test Case 3: Normal Case (Coin Found)** ✅
**Scenario:** The user introduces valid coordinates [0,0] where a coin is hidden.
*Initial State: `attempts` = 5, `totalBits` = 0, `mineFilled[0,0]` = "Coin".*

| # Instruction | Variables | Condition / Output |
| :--- | :--- | :--- |
| **1** (Input X/Y) | `x`=0, `y`=0 | Inputs Valid & In Range $\rightarrow$ **TRUE** |
| **2** (Logic Check) | `mineFilled[0,0]`="Coin" | Object == Coin $\rightarrow$ **TRUE** |
| **3** (RNG) | `bits`=25 | Random bits generated. |
| **4** (Update) | `totalBits`=25 | **Action:** `totalBits` increased. |
| **5** (Update Map) | `mineUser[0,0]`="🪙" | User map updated. |
| **6** (Update Hidden)| `mineFilled[0,0]`="Empty" | Hidden map updated (Exploit prevention). |
| **7** (Decrement) | `attempts`=4 | **Action:** `attempts` decreases by 1. |
| **8** (Loop Check) | `attempts`=4 | 4 > 0 $\rightarrow$ **TRUE** (Continue with 4 tries left) |

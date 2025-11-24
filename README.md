# Chapter 2: Increase LVL (Combat) - Logic Breakdown ⚔️

This section handles the core combat loop. It is an automated, turn-based system where the wizard fights a randomly selected monster to gain experience (Levels).

## A. The Combat & State Management Loop

The logic relies on Random Number Generation (RNG) to determine enemies and damage, while ensuring the global game state remains consistent after the battle.

| Instruction | Purpose | Key Variables Affected | Detailed Logic |
| :--- | :--- | :--- | :--- |
| **`randomMonster = rand.Next(...)`** | **Enemy Selection** | `randomMonster` | Randomly selects an index to pick a monster from the arrays. |
| **`int tempHP = healthpoints[...]`** | **State Preservation** | `tempHP` | **Crucial:** Stores the monster's *max health* in a local variable before the fight begins. |
| **`while (healthpoints[...] > 0)`** | **Combat Loop** | N/A | The battle continues as long as the monster is alive (HP > 0). |
| **`dice = rand.Next(1, 7)`** | **Damage RNG** | `dice` | Simulates a standard D6 die roll (Values 1 to 6). |
| **`healthpoints[...] -= dice`** | **Damage Logic** | `healthpoints` | Subtracts the dice roll from the global health array. |
| **`if (healthpoints[...] > 0)`** | **Combat Continuation** | N/A | If the monster survives the hit, it pauses (`ReadKey`) to let the player read the log. |
| **`else if (... <= 0)`** | **Victory Logic** | `wizardLevel` | If HP drops to 0 or negative (overkill), the monster is defeated. Triggers level up. |
| **`if (wizardLevel < 5)`** | **Error Prevention** | `wizardLevel` | **Safety Check:** Prevents the level from exceeding the game's designed limit (Level 5). |
| **`healthpoints[...] = tempHP`** | **State Restoration** | `healthpoints` | **Crucial:** Resets the monster's HP in the global array to `tempHP` so it is fully healed for the next encounter. |

---

## B. Test Cases

### **Test Case 1: Normal Case (Standard Victory)** ✅
**Scenario:** The player fights a **Forest Goblin (5 HP)** starting at **Level 1**. The damage deals "Overkill" (HP goes below 0).

| # Instruction | # Iteration | Variables | Condition / Output |
| :--- | :--- | :--- | :--- |
| **1** (Start) | - | `randMonster`="Goblin", `HP`=5 | - |
| **2** (While) | 1 | `HP`=5 | 5 > 0 $\rightarrow$ **TRUE** |
| **3** (Roll) | 1 | `dice`=2 | Output: "You rolled a 2" |
| **4** (Calc) | 1 | `HP` (5 - 2) = 3 | `HP` > 0 $\rightarrow$ **TRUE** (Wait for Key) |
| **5** (While) | 2 | `HP`=3 | 3 > 0 $\rightarrow$ **TRUE** |
| **6** (Roll) | 2 | `dice`=4 | Output: "You rolled a 4" |
| **7** (Calc) | 2 | `HP` (3 - 4) = -1 | `HP` <= 0 $\rightarrow$ **TRUE** (Defeated) |
| **8** (Level Up)| - | `wizardLevel`=1 | **Action:** Level increases to **2**. |
| **9** (Restore)| - | `HP` becomes 5 | Global array restored. |

### **Test Case 2: Limit Case (Exact Zero HP)** 🚧
**Scenario:** The player fights a **Wandering Skeleton (3 HP)**. The die roll matches the HP exactly. This tests the logic boundary of `<= 0`.

| # Instruction | # Iteration | Variables | Condition / Output |
| :--- | :--- | :--- | :--- |
| **1** (Start) | - | `randMonster`="Skeleton", `HP`=3 | - |
| **2** (While) | 1 | `HP`=3 | 3 > 0 $\rightarrow$ **TRUE** |
| **3** (Roll) | 1 | `dice`=3 | Output: "You rolled a 3" |
| **4** (Calc) | 1 | `HP` (3 - 3) = 0 | `HP`=0 |
| **5** (Check) | 1 | `HP`=0 | `HP` > 0 $\rightarrow$ **FALSE** |
| **6** (Check) | 1 | `HP`=0 | `HP` <= 0 $\rightarrow$ **TRUE** (Defeated) |
| **7** (Level Up)| - | `wizardLevel`=2 | **Action:** Level increases to **3**. |

### **Test Case 3: Error Prevention Case (Level Cap Overflow)** ❌
**Scenario:** The player is already at **Level 5** (Max). They defeat a monster. This tests if the code prevents the "Error" of leveling up to 6 (which implies accessing undefined array indexes in Chapter 6).

| # Instruction | Variables | Condition / Output |
| :--- | :--- | :--- |
| **1** (Start) | `wizardLevel`=5, `HP`=10 | Wizard is Max Level. |
| **2** (Combat) | `dice`=6, `dice`=5 | Monster defeated (`HP` <= 0). |
| **3** (Logic) | `wizardLevel`=5 | Code enters Victory Block. |
| **4** (Check) | `wizardLevel` < 5 | 5 < 5 $\rightarrow$ **FALSE** |
| **5** (Action) | `wizardLevel`=5 | **Result:** Level does **NOT** increase. (Overflow prevented). |

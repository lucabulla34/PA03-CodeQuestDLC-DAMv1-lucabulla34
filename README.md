# Chapter 1: Train Your Wizard - Logic Breakdown

This section handles the character progression simulation. It uses a deterministic loop combined with random number generation (RNG) to simulate a 5-day training camp, calculating the wizard's growth in "power" and "hours played."

## A. The Training Simulation Loop

The core mechanic is a `for` loop that iterates exactly 5 times (representing 5 days). In each iteration, RNG determines the daily gains.

| Instruction | Purpose | Key Variables Affected | Detailed Logic |
| :--- | :--- | :--- | :--- |
| **`for (int day = 1; day <= 5; day++)`** | **Time Progression**. | `day` | Guarantees exactly 5 iterations. No user input is required; the process is automatic. |
| **`randomHours = rand.Next(0, 25)`** | **RNG: Time Spent**. | `randomHours` | Generates a random integer between **0 and 24** (inclusive). Note: `Next` upper bound is exclusive. |
| **`power += rand.Next(1, 11)`** | **RNG: Stat Growth**. | `power` | Generates a random power increase between **1 and 10**. This is added to the existing `power` variable (which starts at 1). |
| **`totalHours += randomHours`** | **Accumulation**. | `totalHours` | Keeps a running total of all hours trained across the 5 days. |
| **`Console.Write(MsgDays...)`** | **Daily Feedback**. | N/A | interpolation displays the current day, hours trained *so far*, and current power using the `MsgDays` format string. |

---

## B. Title Assignment (Threshold Logic)

Once the loop finishes, the code evaluates the final `power` score to assign a "Wizard Title" and display a specific rank message. This uses an `if-else-if` ladder.

* **Min Possible Power:** $1 \text{ (Base)} + (5 \text{ days} \times 1) = 6$.
* **Max Possible Power:** $1 \text{ (Base)} + (5 \text{ days} \times 10) = 51$.

| Condition | Threshold (Power) | Resulting Title (`wizardTitle`) | Description |
| :--- | :--- | :--- | :--- |
| **`if (power < 20)`** | **6 - 19** | `TitleOne` ("Raoden el Elantrí") | Lowest tier. The wizard failed to gain significant power. |
| **`else if (power < 30)`** | **20 - 29** | `TitleTwo` ("Zyn el buguejat") | Low-Mid tier. Novice wizard status. |
| **`else if (power < 35)`** | **30 - 34** | `TitleThree` ("Arka Nullpointer") | Middle tier. Competent spellcaster. |
| **`else if (power < 40)`** | **35 - 39** | `TitleFour` ("Elarion de les Brases") | High tier. Powerful wizard. |
| **`else if (power >= 40)`** | **40 - 51** | `TitleFive` ("ITB-Wizard el Gris") | Max tier. Shows a special `TrainingComplete` message. |

### Logic Note on `else if`
Because the checks are sequential, we do not need to check the lower bound in every step.
* *Example:* If the check reaches `power < 30`, we implicitly know `power` is already `>= 20`, because the previous `if (power < 20)` returned `false`.

### **Test Case 1: Limit Case (Lower Bound - Min Luck)** 📉
*Initial State: `power` = 1, `totalHours` = 0*

| # Instruction | # Iteration | Variables | Condition / Output |
| :--- | :--- | :--- | :--- |
| **1** (For Loop Start) | - | `day`=1 | `day` <= 5 $\rightarrow$ **TRUE** |
| **2** (Randoms & Add) | 1 | `randHours`=0, `randPower`=1 | `power` (1+1) = **2** |
| **3** (Write) | 1 | - | **Output:** "Day 1... total 0h... 2 pts" |
| **4** (Loop Continue) | 2..5 | `power` increases by 1 each time | `power` ends at **6** |
| **5** (Loop End) | - | `day`=6 | `day` <= 5 $\rightarrow$ **FALSE** |
| **6** (If < 20) | - | `power`=6 | 6 < 20 $\rightarrow$ **TRUE** |
| **7** (Assign Title) | - | `wizardTitle`="Raoden..." | **Action:** Assign Level 1 Title |

---

### **Test Case 2: Limit Case (Upper Bound - Max Luck)** 📈
*Initial State: `power` = 1, `totalHours` = 0*

| # Instruction | # Iteration | Variables | Condition / Output |
| :--- | :--- | :--- | :--- |
| **1** (For Loop Start) | - | `day`=1 | `day` <= 5 $\rightarrow$ **TRUE** |
| **2** (Randoms & Add) | 1 | `randHours`=24, `randPower`=10 | `power` (1+10) = **11** |
| **3** (Write) | 1 | - | **Output:** "Day 1... total 24h... 11 pts" |
| **4** (Loop Continue) | 2..5 | `power` increases by 10 each time | `power` ends at **51** |
| **5** (Loop End) | - | `day`=6 | `day` <= 5 $\rightarrow$ **FALSE** |
| **6** (If < 20) | - | `power`=51 | 51 < 20 $\rightarrow$ **FALSE** |
| **7** (Else Ifs...) | - | `power`=51 | ...checks fail until >= 40 |
| **8** (Else If >= 40) | - | `power`=51 | 51 >= 40 $\rightarrow$ **TRUE** |
| **9** (Assign Title) | - | `wizardTitle`="ITB-Wizard..." | **Action:** Assign Level 5 Title |

---

### **Test Case 3: Normal Case (Average Luck)** ✅
*Initial State: `power` = 1, `totalHours` = 0*

| # Instruction | # Iteration | Variables | Condition / Output |
| :--- | :--- | :--- | :--- |
| **1** (For Loop Start) | - | `day`=1 | `day` <= 5 $\rightarrow$ **TRUE** |
| **2** (Randoms & Add) | 1 | `randPower`=5 | `power` (1+5) = **6** |
| **3** (Loop Continue) | 2..5 | `power` increases by ~5 each time | `power` ends at **26** |
| **4** (Loop End) | - | `day`=6 | `day` <= 5 $\rightarrow$ **FALSE** |
| **5** (If < 20) | - | `power`=26 | 26 < 20 $\rightarrow$ **FALSE** |
| **6** (If >= 20 && < 30) | - | `power`=26 | 26 >= 20 && 26 < 30 $\rightarrow$ **TRUE** |
| **7** (Assign Title) | - | `wizardTitle`="Zyn..." | **Action:** Assign Level 2 Title |

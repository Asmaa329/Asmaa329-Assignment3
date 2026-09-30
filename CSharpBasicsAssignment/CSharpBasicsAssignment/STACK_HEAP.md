
## Line 1: `Order o1 = new Order { OrderId = 1, CustomerName = "Ali" };`
+------------------------+                  +-----------------------------------+
|         STACK          |                  |               HEAP                |
+------------------------+                  +-----------------------------------+
| o1 ------> [0x00A110]  | ---------------> | Order Object (0x00A110)           |
+------------------------+                  |  - OrderId: 1                     |
                                            |  - CustomerName: "Ali"            |
                                            |  - Quantity: 0                    |
                                            |  - UnitPrice: 0.0                 |
                                            |  - TotalPrice: 0.0                |
                                            |  - IsPaid: false                  |
                                            |  - DiscountPercent: 0.0           |
                                            |  - ShippingCity: null             |
                                            |  - Priority: '\0'                 |
                                            |  - ItemCode: 0                    |
                                            +-----------------------------------+

Explanation: Line 1 creates a new Order object instance on the Heap at address 0x00A110 with initialized field values
while storing its reference address in o1 on the Stack.

## Line 2: `Order o2 = o1;`
+------------------------+                  +-----------------------------------+
|         STACK          |                  |               HEAP                |
+------------------------+                  +-----------------------------------+
| o1 ------> [0x00A110]  | ---------------> | Order Object (0x00A110)           |
| o2 ------> [0x00A110]  | ----------------/|  - OrderId: 1                     |
+------------------------+                  |  - CustomerName: "Ali"            |
                                            |  - Quantity: 0                    |
                                            |  - UnitPrice: 0.0                 |
                                            |  - TotalPrice: 0.0                |
                                            |  - IsPaid: false                  |
                                            |  - DiscountPercent: 0.0           |
                                            |  - ShippingCity: null             |
                                            |  - Priority: '\0'                 |
                                            |  - ItemCode: 0                    |
                                            +-----------------------------------+
Explanation: Line 2 copies the memory reference 0x00A110 from o1 to o2 on the Stack
so both variables point to the same single Order object on the Heap without creating a new object.
## Line 3: `o2.IsPaid = true;`
+------------------------+                  +-----------------------------------+
|         STACK          |                  |               HEAP                |
+------------------------+                  +-----------------------------------+
| o1 ------> [0x00A110]  | ---------------> | Order Object (0x00A110)           |
| o2 ------> [0x00A110]  | ----------------/|  - OrderId: 1                     |
+------------------------+                  |  - CustomerName: "Ali"            |
                                            |  - Quantity: 0                    |
                                            |  - UnitPrice: 0.0                 |
                                            |  - TotalPrice: 0.0                |
                                            |  - IsPaid: true  <-- UPDATED      |
                                            |  - DiscountPercent: 0.0           |
                                            |  - ShippingCity: null             |
                                            |  - Priority: '\0'                 |
                                            |  - ItemCode: 0                    |
                                            +-----------------------------------+
Explanation: Line 3 modifies the IsPaid field of the single Heap object from false to true
which reflects through both o1 and o2 because they share the exact same Heap memory address.



## What would be different with structs?

If `Order` were defined as a `struct` (Value Type) instead of a `class` (Reference Type), using `Point` from Part C as an example:

1. **No Heap Allocation:** The entire `Point` data (`X` and `Y`) would be stored directly inside the Stack variable `p1`, leaving the Heap completely empty.
2. **Value Copying:** Executing `Point p2 = p1;` would copy the actual values of `X` and `Y` into a brand-new, independent memory block on the Stack for `p2`.
3. **Independent Modification:** Changing `p2.X = 99;` would update only `p2`'s Stack slot, while `p1.X` remains completely unchanged at `1`.
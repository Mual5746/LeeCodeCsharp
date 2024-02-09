# Intuition
<!-- Describe your first thoughts on how to solve this problem. -->

# Approach
<!-- Describe your approach to solving the problem. -->

1. **Negative Asteroids Handling**:
   - When encountering a negative asteroid in the array, indicating a potential collision, the code enters the block for handling negative asteroids.

2. **Collision with Positive Asteroids**:
   - It checks if the stack is not empty (`stacksChar.Count > 0`) and if the top asteroid on the stack is positive (`stacksChar.Peek() > 0`).
   - If the condition is met and the magnitude of the current negative asteroid is greater than the positive asteroid on top of the stack (`stacksChar.Peek() < Math.Abs(asteroids[i])`), it removes the positive asteroid from the stack since it will be destroyed in the collision.

3. **Handling Same Size Collisions**:
   - If the magnitude of the current negative asteroid is equal to the positive asteroid on top of the stack (`stacksChar.Peek() == Math.Abs(asteroids[i])`), it removes both asteroids from the stack, effectively destroying both in the collision.
   - The `continue` statement is used to move to the next iteration of the loop without executing any further code for the current iteration.

4. **Handling Empty Stack or Negative Asteroids**:
   - If the stack is empty (`stacksChar.Count == 0`) or the top asteroid on the stack is negative (`stacksChar.Peek() < 0`), it simply adds the current negative asteroid to the stack, as there are no positive asteroids to collide with it.

5. **Positive Asteroids Handling**:
   - For positive asteroids encountered in the array, they are directly pushed onto the stack without any further processing.

6. **Return Result**:
   - Finally, the stack is converted to an array, reversed to maintain the order of asteroids, and returned as the result.

This approach ensures proper handling of asteroid collisions and maintains the integrity of the stack throughout the process.

# Complexity
- Time complexity:
<!-- Add your time complexity here, e.g. $$O(n)$$ -->
# Runtime 128 ms Beats 56.63% of users with C#

- Space complexity:
<!-- Add your space complexity here, e.g. $$O(n)$$ -->
# 49.94 MB Beats 5.47% of users with C#

# Code
```
public class Solution {
   public int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> stacksChar = new Stack<int>();
            int n = asteroids.Count() ;
            //stacksChar.Push(asteroids[0]);
            for (int i = 0; i <n ; i++)
            {
                //if the valus in array is negative
                if (asteroids[i] < 0 )
                {
                  
                    // as far stack not empty and the peek is greater than 0 the peek is lee than the absolut value of array remove it from stack
                    while (stacksChar.Count >0 && stacksChar.Peek() > 0 && stacksChar.Peek() < Math.Abs(asteroids[i]))
                    {
                        stacksChar.Pop();

                    }
                        //for the case like {8 ,-8}
                    if (stacksChar.Count > 0 && stacksChar.Peek() == Math.Abs(asteroids[i]))
                    {
                        stacksChar.Pop();
                        continue;
                    }
                    //the case of empty stack and negative number in array
                    if (stacksChar.Count == 0 || stacksChar.Peek() < 0)
                    {
                        stacksChar.Push(asteroids[i]); // Lägg till den negativa asteroiden på stacken
                    }

                }
                else
                {
                    stacksChar.Push(asteroids[i]);
                }

            }
            return stacksChar.Reverse().ToArray();
             

        }


}
```

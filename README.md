This project is a simple Number Memory Game using C# and Windows Forms. 
The objective of the game is to test the player's memory by showing a sequence of random numbers, and then prompting the player to input the numbers they remember.

How it Works:
  - Start Game: When the player clicks the "Start" button, the game begins by generating a random sequence of 5 numbers.
  - Number Display: These numbers are shown to the player one by one for a second each.
  - Player Input: The player enters their guessed sequence in the provided textbox and submits their answer by clicking the "Submit" button.
  - Validation: The game checks if the player's input matches the generated sequence and gives feedback accordingly.

Code Structure:
  - Form1.cs: Contains the core logic of the game, including event handlers for button clicks (Start and Submit), number generation, and input validation.
  - Timer Events: Utilized to control the timing of number display and hide the number after a brief interval to challenge the player's memory.

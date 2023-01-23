# Asteroid Game Manager Tool

## Location
This tool can be found under the tab Tools in the upper right corner. It will open a window which is the tools.

## Usage
This tool was made to collect and place every aspect of the game in a single window so it would be easier to find and modify core values. It is designed in particular for game designer with limited knowledge with programming.

## VG Requirments

- #### Utilize advanced features of Unity editor tools, such as custom inspectors or editors, to enhance the user experience and make the tool more powerful and efficient. 

When making this tool i used myself of custom editors to make horizontal groups and group together variables that are of the same aspects such as (min, max) values. This can be seen in [ControlPanel.cs](Assets/Editor/ControlPanel.cs) on line 108 where a horizontal scope is used to group together those values.


- #### Incorporate error handling, undo/redo functionality, and other best practices to improve the robustness and reliability of the tool.

This tool is using serialized property which will add Undo/Redo functionality and multi object editing. The scriptable objects the tools are using to store the values also have checks for variables that should not be able to be negative and controls that max values dont go below the corresponding min value. [Asteroid Scriptable Object](https://github.com/ChristianBackstrom/asteroids-scriptable-objects/blob/main/Assets/2.%20Scripts/1.%20Scriptable%20Objects/AsteroidSpawningValues.cs) uses a OnValidate method which checks the vulnerable values before it stores it and otherwise sets them to the closest valid value.


- #### Create additional functionality or expand on the existing functionality to make the tool more useful and versatile.

This tool uses itself of a custom class called [BreakPoints.cs](https://github.com/ChristianBackstrom/asteroids-scriptable-objects/blob/main/Assets/2.%20Scripts/1.%20Scriptable%20Objects/1.%20Subclasses/SpawningBreakpoints.cs) which is used to make the game more difficult after a certain amount of asteroids have been destroyed. This can be customised in the tool under breakpoints where these breakpoints can be added or removed.


- #### Create a well-organized and easy-to-user interface, making sure that all functionalities are intuitive and easy to find

This was completed by using myself of different layout groups in the tool to make it easy to understand what variables are used in sync. I also thought of this when making the window tool and where to be able to find it. I thought that the most obvious place for the tool would be under a tab called "Tools/Control Panel". 

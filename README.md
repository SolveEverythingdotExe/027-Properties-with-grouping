Properties with Grouping

This project shows how to create a property which has a grouping or has a parent and child property in the Properties Window of Visual Studio.

Example:
Size - "Size" property serves as the parent or grouping which has child properties "Width" and "Height".
Size originalSize = new Size(100, 200);
originalSize.Width = 20;
originalSize.Height = 10;

Another one is "Location" with child properties "X" and "Y".
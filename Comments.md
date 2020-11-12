1. Many classes have interfaces which does anything but duplicating code. There is no sense for using them. 
2. Product interface can be and abstract class, it is more "intuitive"
3. Constants like VAT should be a const instead of static. Same for default value of AdvancePercentage - this should be a const in some class with constant values.
4. Company request class and load request should have private setters. I think it would be better to pass parameters via constructor to be sure all properties are set.
5. Reorganize ProductApplication structure to be more "readable".
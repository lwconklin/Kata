# kataKalibrate


Friday, November 24, 2017

Good day everyone.

I finished the tata given to me by Kalibrate. There is lots
of code already on the internet concerning this. I decided to just use the
rules and go with my own solution. All the code is mine.

I did used nugget to bring down closedXML. I used this
package to read the excel worksheet. I also put a simple winform over the code
so it can be better visualized.

Simple operations.

Use file menu file dialog option to find your
xslt data worksheet and load inventory into program.Use Inventory option to update loaded inventory.



A simple data grid view will show the initial inventory
loaded and show the results after the inventory has been uploaded.

Design considerations.

I used to two design principals. separation of
concerns (SoC) and single responsibility principle.Inventory items are defined with a base class
called Product, and each inventory item has its own class. i.e. Normal Item,
Aged Brie, BackStage Passes, etc.



Each inventory class uses the base class (Product) for
common class properties and common implementation. Any item specific rules are
in the actual item classes. One note I am not a fan of derived classes because
it creates high cohesion and high coupling instead of high cohesion and low coupling.
However, like most things in computer programming don’t throw something out if
it does what you’re looking for.  

The Inventory class loads the inventory from Excel using
ClosedXml. A friend of mine turned me onto ClosedXml a while back. Each inventory
item is loaded into a generic list. I use enumeration types to determine item
type. I use the base class to determine item type then cast it to actual item
type to update inventory.  I did this so
the application could grow in complexity with inventory items having different
rule sets.

Update is a virtual method from base class. Some common
methods have been implemented in the base class Product such as “CheckQualityLevel”.


 

I also use NUnit and created some tests.

Larry Conklin

 


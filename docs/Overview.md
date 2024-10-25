# Overview of the Rules Utility concept

This repository presents a data model that describes a configurable Rule that can be constructed in memory, at Run-Time, from a simple Definition object.  

I'm not specifying a storage technology to hold these Rule Definitions, that's up to you when you use this concept.  

## History
I've been writing Validation Logic for years in my day-to-day work as a .Net Software Maker.  A few years back, it started to bug me that I was continually needing to adjust the code whenever a needed to alter that logic for whatever Object was being validated.  (Validation code is usally BOOOO-RING, and Boring Code attracts bugs.)  

I also began to see potential patterns emerge when validating Data, such as:
 * Every "rule" could be boiled down to one (or sometimes a few) True-or-False statements.
 * Rules should be applied based on the Activity that is being performed on the Entity we're validating. (Not all rules apply to all activities!)
 * Rules usually have a defined "consequence" when they evaluate to False.
 * Frequently, we want to run ALL of the Validation Rules for a given Activity, and present all broken rules to the end user at once, rather than playing ping-pong between the user and the system.  (I've filled in forms that show me one problem at a time, and it's a PAIN IN THE NECK!)

You'll notice that the points I raise are centered around and scoped to Business Entity Validation.  This is on-purpose.

**But imagine for a moment...**
*"What if we could inject the Action to Take when a rule evaluates to False and have that Action execute Automatically?"*
*"What if... we could also inject the Action to Take when a rule evaluates to TRUE, and run THAT Automatically as well?"*

I'm not gonna go THERE for awhile yet.  I may not, ever.  But it sure is tempting...

*-That Developer Dad*

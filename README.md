# GNUClay
##Overview
I develop just for fun a small expert system based on the principles of Prolog.

Pure Prolog has a very minimalistic syntax.
As a result, the writing on it complicated programs generates large amounts of code.
As the result of it, many people are working on the improvement of the Prolog.
For example, Reiter's default logic or Stanford certainty factor.
I want to add some of these improvements to my system.

Now the logical programming and expert systems are used by large corporations, serious scientists and geeks enthusiasts-amateurs.
I dream of a greater use of logic programming.
I think, that there is great potential for the use of logic programming in the writing game characters with complex behavior, and chatbots.
I have published the minimal realization of my production system.
In the future, I will add different features to my system and to fix them in the new intermediate versions.
So, my system may be used in the early stages of its development, starting from the very first its version.

##Syntax
Language Gnu clay is based on the predicate calculus.

###Convention about names
The name may contain latin letters (in any case), numbers and underscore.
The name may begin with any of these types of characters.

Examples of valid names:
`Tom, fire3, tom_and_jerry, _Tom, 1X, _1m_X_5`

Names are case sensitive.
So, x and X; Dog and dog - are different names.

###Types of entities
Class. At the moment, it is just some entity of the subject area.
In the future, it will be a class in terms of object-oriented programming.
Standard name. Globally unique.
Examples: 
`Tom, fire3, tom_and_jerry, _Tom, 1X, _1m_X_5`

Variable. Standard name with the symbol $ before its. It is unique within its rule.
Examples: 
`$dog, $X, $Z_1`

Relation. Standard name with its parameters, that are followed for it in round brackets.
Separator of these parameters - the comma.
There must be at least one parameter.
The parameter must be a class or a variable.
The first parameter must necessarily be a logical subject.
Examples: male(Tom), male($X), parent($X, $Y).

###Logical expression
Logical expression consists of at least one relationship.
Examples: male(Tom), male($X), parent($X, $Y).

Two or more relationships can be combined by operation "AND" (denoted by symbol &).
Examples: parent($X1, $X2) & male($X2).

###Structures of the language
The language consists of facts and rules, like Prolog.

The rule has the structure:

`>: {A($X)} -> {B($X)}`

Which means: A($X) is true if it is true B($X).
So, B($X) is true if it is true A($X).
The logical expressions are enclosed in figure brackets braces in the two parts of the rule.
The part of the rules after >: conventionally called the head of the rule.
The part of the rules after -> conventionally called the body of the rule.
Both parts of the rule can contain two or more relations.
All variables in the rule are quantifier ∀.
While we can not set a different quantifier for a variable.

The fact has the structure:

`>: {A($X)}`

The logical expression is enclosed in figure brackets.
Fact may contain only one relation.
Fact can not contain variables.

###Query language
####Extracting information
Format: SELECT {A($X)}.
The extracted expression is enclosed in figure brackets.
The field Success contains a boolean values: true or false.
If the query contains variables, we return a list of results.
Each result contains the found values of these variables.

####Adding information
Format: INSERT {added a fact or rule}.
Added rule or fact is enclosed in figure brackets.
Acceptable simultaneously adding two or more of the facts or the rules in one expression.
Separator added facts or rules - a comma.

##Examples
INSERT {>: {parent($X1,$X2)} -> {child($X2,$X1)}},{>: {son($X1,$X2)} -> {child($X1,$X2) & male($X1)}},{>: {parent(Tom,Piter)}},{>: {parent(Tom,Mary)}},{>: {male(Piter)}},{>: {female(Mary)}},{>: {male(Bob)}}

? SELECT {son(Piter,$X1)}
yes
$X1 = Tom

? SELECT {son(Piter,Tom)}
yes

? SELECT {son($X1,$X2)}
yes
$X1 = Piter;$X2 = Tom

? SELECT {son(Piter,Mary)}
no
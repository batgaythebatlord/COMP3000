EXTERNAL rollDice()
EXTERNAL showState(character)

=== testKnot ===
This is the dialogue. #portrait: familyGuyAstacus
This is line 2.
* This choice leads to +1 annoyance from Shauna #annoyance: 1!s
    Annoyance updated
    ->choosePerson
-> DONE
* This choice leads to -1 trust from Romello #trust: -1!r
    Trust updated
    ->choosePerson
-> DONE
*This choice leads to -1 annoyance from both characters #annoyance: -1!s #annoyance: -1!r
    Annoyance updated
    ->choosePerson
-> DONE
* This choice leads to a dice roll
    ~ rollDice()
    Dice roll
    ->choosePerson
-> END

==choosePerson==
Choose character
* Shauna
    ~showState("Shauna")
-> DONE
* Romello
    ~showState("Romello")
-> DONE
* Finish dialogue
-> END
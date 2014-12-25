% ?- chdir("/Users/dte/Desktop").
% ?- [yl1].

?- write('Tere, Margus!'), nl.

mother(malle, silvi).
mother(vello, silvi).
mother(margus, malle).
mother(moonika, malle).
mother(elen, irina).
mother(geily, elen).
mother(mihkel, aleksandra).
married(silvi, valter).
married(irina, vello).
married(malle, jyri).
married(elen, mihkel).
male(valter).
male(vello).
male(margus).
male(jyri).
male(mihkel).
female(silvi).
female(malle).
female(irina).
female(moonika).
female(elen).
female(geily).


?- mother(margus, Mother), married(Mother, Father), write(Father), nl.  

father(Child,Father):-
  mother(Child,Mother),
  married(Mother,Father).

?- father(margus, Father), write(Father), nl.

brother(Child, Brother):-
  mother(Child, Mother),
  father(Child, Father),
  (mother(Brother, Mother); father(Brother, Father)),
  male(Brother),
  Brother \= Child.

sister(Child, Sister):-
  mother(Child, Mother),
  father(Child, Father),
  (mother(Sister, Mother); father(Sister, Father)),
  female(Sister),
  Sister \= Child.

?- brother(moonika, Sister), write(Sister), nl.
?- sister(margus, Sister), write(Sister), nl.

?- father(X, Y).
?- father(X, Y), write(X-Y), nl, fail.
?- father(X, Y), write(X-Y), nl, fail ; true.

aunt(Child, Aunt):-
  mother(Child, Mother),
  father(Child, Father),
  (sister(Mother, Aunt); sister(Father, Aunt)).

uncle(Child, Aunt):-
  mother(Child, Mother),
  father(Child, Father),
  (brother(Mother, Aunt); brother(Father, Aunt)).

grandmother(Child, Grandmother):-
  mother(Child, Mother),
  father(Child, Father),
  (mother(Mother, Grandmother); mother(Father, Grandmother)).

grandfather(Child, Grandfather):-
  mother(Child, Mother),
  father(Child, Father),
  (father(Mother, Grandfather); father(Father, Grandfather)).

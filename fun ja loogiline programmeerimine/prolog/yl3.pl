% 1. Kirjeldage predikaat tryki_list/1, mis trükib listi elemendid eraldi ridadesse. Näiteks

tryki_list([]).
tryki_list([X|Xs]):-
  write(X), nl,
  tryki_list(Xs).

?- tryki_list([1,2,3]).  


% 2. Kirjeldage predikaat kopeeri_list/2, mis kopeerib listi elemendid teise listi. Näiteks

kopeeri_list([],[]).
kopeeri_list([X|Xs],[X|Ys]):-
  kopeeri_list(Xs,Ys).

?- kopeeri_list([1,2,3],X), write(X), nl.


% 3. Kirjeldage predikaat suurenda2/2, mis suurendab arvulisti elemente kahe võrra. Näiteks

suurenda2([],[]).
suurenda2([X|Xs],[CreaterX|Ys]):-
  CreaterX is X+2,
  suurenda2(Xs,Ys).

?- suurenda2([1,2,3], X), write(X), nl.


% 4. Moodustage tudengite struktuur.

struktuur([
  tudeng(adele,_,_),
  tudeng(bruno,_,_),
  tudeng(carol,_,_),
  tudeng(david,_,_)
]).



% 5. Kirjeldage predikaadid nimi/2, keel1/2 ja keel2/2, mis maaravad vastavalt tudengi nime, ja tema poolt raagitavate keelte asukohad struktuuris.

nimi(tudeng(A,_,_),A).
keel1(tudeng(_,B,_),B).
keel2(tudeng(_,_,B),B).


% 6. Täitke struktuur ning kontrollige selle korrektsust.

taida_struktuur([A,B,C,D]):-
  nimi(Nimi1),
  nimi(A,Nimi1),
  keeled(A),
  nimi(Nimi2),
  Nimi1 @< Nimi2,
  nimi(B,Nimi2),
  keeled(B),
  nimi(Nimi3),
  Nimi2 @< Nimi3,
  nimi(C,Nimi3),
  keeled(C),
  nimi(Nimi4),
  Nimi3 @< Nimi4,
  nimi(D,Nimi4),
  keeled(D),
  true.

keeled(A):-
   keel(Keel1), keel(Keel2),
   Keel1 @< Keel2,
   keel1(A,Keel1), keel2(A,Keel2).

nimi(adele).
nimi(bruno).
nimi(carol).
nimi(david).

keel(hispaania).
keel(prantsuse).
keel(inglise).
keel(saksa).

lahenda(Tudengid):-
  struktuur(Tudengid),
  taida_struktuur(Tudengid),
  fakt1(Tudengid),
  fakt2(Tudengid),
  fakt3(Tudengid),
  kitsendus1(Tudengid),
  true.

fakt1(T):-
  \+ (
  koneleb(Nimi,saksa,T),
  koneleb(Nimi,prantsuse,T)
  ).

fakt2(T):-
  \+ koneleb(adele, hispaania, T),
  koneleb(adele, Keel, T),
  koneleb(bruno, Keel, T),
  koneleb(adele, Keel2, T),
  koneleb(carol, Keel2, T).

fakt3(T):-
  koneleb(bruno, saksa, T),
  \+ koneleb(david, saksa, T),
  koneleb(bruno, Keel, T),
  koneleb(david, Keel, T).

% 10 Kirjeldage kitsendus 1.

kitsendus1(T):-
  \+ (
  koneleb(adele, Keel, T),
  koneleb(carol, Keel, T),
  koneleb(david, Keel, T)
  ).

koneleb(Nimi,Keel,Struktuur):-
  member(X,Struktuur),
  nimi(X,Nimi),
  (keel1(X,Keel) ; keel2(X,Keel)).
  

% 11. Veenduge, et ülesandel on ühene lahend.

?- setof(X,lahenda(X),Lahendid), length(Lahendid,N).

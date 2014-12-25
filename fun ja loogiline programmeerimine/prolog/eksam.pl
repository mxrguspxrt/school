% 2

seitse(N):-
  N > 0,
  Last is N mod 10,
  write(Last),
  (Last =:= 7 ; seitse((N-Last)/10)).


% 3

paaritud([], []).
paaritud([A], [A]).
paaritud([A,B|C], Vastus):-
  paaritud(C, D),
  append([A], D, Vastus).


% 4 (Alusmaterjalina kasutatud SEND MORE MONEY Näidet: http://clip.dia.fi.upm.es/~vocal/public_info/seminar_notes/node13.html)

lahenda(O) :-
        X = [A,B,C,D,E],
        Digits = [0,1,2,3,4,5,6,7,8,9],
        assign_digits(X, Digits),
        A*B*C < A*D*C, A*D*C < A*E*C,
                  100*A + 10*B + C +
                  100*A + 10*D + C +
                  100*A + 10*E + C =:=
        2014,
        write(X),
        O = X.

select(X, [X|R], R).
select(X, [Y|Xs], [Y|Ys]):- select(X, Xs, Ys).

assign_digits([], _List).
assign_digits([D|Ds], List):-
        select(D, List, NewList),
        assign_digits(Ds, NewList).

% 1

poisse(11).
tydrukuid(8).
lapsi_klassis(Lapsi):-
  Lapsi = poisse(X), tydrukuid(Y),

bussisoit_maksab(Hulk, Summa):-
  Summa is Hulk*1.50.


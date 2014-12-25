% ?- chdir("/Users/dte/Desktop").
% ?- [yl2].

korrutis:-
  write('Sisesta X: '), 
  read(X), 
  write('Sisesta Y: '), 
  read(Y), 
  Z is X*Y,
  write(X * Y = Z).

arvud(N):-
  N>0,
  write(N), tab(1),
  N1 is N-1,
  arvud(N1).

joon(N):-
  N>0,
  write('-'), 
  N1 is N-1,
  joon(N1).

arvud_yles(M,N):-
  M =< N,
  write(M), tab(1),
  M1 is M+1,
  arvud_yles(M1, N).


kell('Esmaspaev', 12, 'Be awsome!').
kell('Teisipaev', 12, 'Be awsome!').
kell('Kolmapaev', 12, 'Be awsome!').
kell('Neljapaev', 12, 'Be awsome!').
kell('Reede',     12, 'Be awsome!').

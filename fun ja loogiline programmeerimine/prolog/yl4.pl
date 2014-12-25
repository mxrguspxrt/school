:-encoding(utf8).

:-dynamic ost/6.

ostud:-
  algus,
  menyy.

menyy:-
  write('Vali: '),
  get_single_char(C),
  atom_codes(Klahv,[C]),
  (exit(Klahv)->write(Klahv), write(' OK!')
  ;
  write(Klahv), nl,
  valik(Klahv),
  menyy).

exit(e).

algus:-help.

help:-
  write('1-lisa ost'), nl,
  write('2-kustuta ost'), nl,
  write('3-näita ostusid'), nl,
  write('4-arvuta summa'), nl,
  write('5-vormista kviitung'), nl,
  write('6-salvesta faili'), nl,
  write('7-loe failist'), nl,
  write('e-exit'), nl,
  write('h-help'), nl,
  menyy.


valik('1'):-!,
  write('Ostu lisamine:'), nl,
  write('nimetus: '), read(A),
  write('hind: '), read(B),
  write('kogus: '), read(C),
  write('pood: '), read(D),
  write('kuupäev: '), read(E),
  write('kaubagrupp: '), read(F),
  assert(ost(A,B,C,D,E,F)),
  write('Lisan ostu '), 
  write(ost(A,B,C,D,E,F)), nl,
  menyy.   

valik('2'):-!,
  ostude_kustutamine,
  menyy.

valik('3'):-!,
  kuva_ostud,
  menyy.

valik('4'):-!,
  arvuta_summa,
  menyy.

valik('5'):-!,
  vormista_kviitung,
  menyy.

valik('6'):-!,
  salvesta_faili,
  menyy.

valik('7'):-!,
  loe_failist,
  menyy.

kuva_ostud:-
  ost(A,B,C,D,E,F), 
  write(ost(A,B,C,D,E,F)),
  nl,
  fail.

arvuta_summa:-
  findall(Hind*Kogus, ost(_,Hind,Kogus,_,_,_),Nimekiri),
  summa(Nimekiri,Summa),
  write(Summa), nl.

summa([],0).
summa([X|Xs],Summa):-
  summa(Xs,SubSumma),
  Summa is SubSumma+X.

vormista_kviitung:-
  write('nimetus\t\t hind\t\t kogus\t\t pood\t\t kuupäev\t\t kaubagrupp'), nl,
  (ost(A,B,C,D,E,F),
  write(A '\t\t' B '\t\t' C '\t\t' D '\t\t' E '\t\t' F), nl,
  fail);
  write('Kokku:'),
  arvuta_summa
  .

loe_failist:-
  write('Fail: '), read(Fail),
  consult(Fail).
  

valik(h):-help.
valik(C):-write(' tundmatu symbol: '), write(C), nl.


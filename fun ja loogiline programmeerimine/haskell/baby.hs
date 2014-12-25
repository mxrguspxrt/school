1 : [2]
-- [1,2]

fuck x = if (x==10) 
            then x
            else x+100

[x*2 | x <- [1..10]]  
-- [2,4,6,8,10,12,14,16,18,20]  


[ x | x <- [50..100], x `mod` 7 == 3]  
-- [52,59,66,73,80,87,94]   

[ x | x <- [10..20], x /= 13, x /= 15, x /= 19]  

length' xs = sum [1 | _ <- xs]   

:t "a"
-- "a" :: [Char]

read "5" + 3
read "5" :: Int
read "(3, 'a')" :: (Int, Char)

let fromIntegral = (Num b, Integral a) => a -> b


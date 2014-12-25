

checkPoly :: Eq a => [a] -> Bool
checkPoly (x) = x == reverse x



--checkSame :: a -> a -> Bool


-- toPoly :: [a] -> [a]
-- toPoly (x) = [x ]


-- String on tegelt [Char]
encodeStr :: [Char] -> [(Char, Int)]
encodeStr [] = []
encodeStr (x:xs) = [(x, 1+length(takeWhile (==x) xs))] ++ encodeStr(dropWhile (==x) xs)

decodeStr :: [(Char, Int)] -> String
decodeStr [] = ""
decodeStr ((x,y):xs) = replicate y x ++ decodeStr xs

--sortByPosition :: [(Char, Integer)] -> [(Char, Integer)]
--sortByPosition [] = []
--sortByPosition (x) =

bin2dec :: [Integer] -> Integer
-- võta iga element ja tema positsioon ja pane see kahe astmeks ja liida kokku
bin2dec [] = 0

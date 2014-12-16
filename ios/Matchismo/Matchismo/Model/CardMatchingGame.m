//
//  CardMatchingGame.m
//  Matchismo
//
//  Created by Margus Pärt on 14/11/14.
//  Copyright (c) 2014 Gravitational Wave OÜ. All rights reserved.
//

#import "CardMatchingGame.h"
#import "PlayingCard.h"

@interface  CardMatchingGame()
@property (nonatomic, readwrite) NSInteger score;
@property (nonatomic, strong) NSMutableArray *cards;
@property (nonatomic, readwrite) NSString *info;
@property (nonatomic, readwrite) NSString *message;
@end

@implementation CardMatchingGame

- (NSMutableArray *)cards
{
    if (!_cards) _cards = [[NSMutableArray alloc] init];
    return _cards;
}

- (instancetype)initWithCardCount:(NSUInteger)count
                        usingDeck:(Deck *)deck
                  matchCardsCount:(NSInteger)matchCardsCount {
    self = [super init];
    
    if (self) {
        for (int i=0; i<count; i++) {
            Card *card = [deck drawRandomCard];
            if (card) {
                NSLog(@"Added card to cards: %@", card.contents);
                [self.cards addObject:card];
                for (Card *card in self.cards) {
                    NSLog(@"Cards contains: %@", card.contents);
                }
                self.matchCardsCount = matchCardsCount;
            } else {
                self = nil;
                break;
            }
        }
    }
    
    return self;
}

- (Card *)cardAtIndex:(NSUInteger)index {
    Card *card = [self.cards objectAtIndex:index];
    NSLog(@"GardMatchingGame#cardAtIndex %@", card.contents);
    return card;
}

static const int MISMATCH_PENALTY = 2;
static const int MATCH_BONUS = 4;
static const int COST_TO_CHOOSE = 1;

- (NSArray *)chosenCards {
    NSMutableArray *chosenCards = [[NSMutableArray alloc]init];
    for (Card *card in self.cards) {
        if (card.isChosen && !card.isMatched) {
            [chosenCards addObject:card];
        }
    }
    return chosenCards;
}

- (void)chooseCardAtIndex:(NSUInteger)index {
    Card *card = [self cardAtIndex:index];
    
    NSLog(@"CardMatchingGame#chooseCardAtIndex %i has contents: %@", index, card.contents);
    
    if (card.isMatched) {
        return;
    }
    
    if (card.isChosen) {
        [self setMessage:[NSString stringWithFormat:@"Unselected card %@", card.contents]];

        card.isChosen = NO;
        return;
    }
    
    self.score -= COST_TO_CHOOSE;
    card.isChosen = YES;

    [self setMessage:[NSString stringWithFormat:@"Selected card %@", card.contents]];
    
    NSArray *chosenCards = [self chosenCards];
    NSInteger matchCardsCount = self.matchCardsCount ? self.matchCardsCount : 2;
    NSInteger chosenCardsCount = [chosenCards count];
    
    if (matchCardsCount == chosenCardsCount) {
        
        NSInteger points = [self matchingPoints:chosenCards] * MATCH_BONUS;
        
        if (points) {
            self.score += points;
            for (Card *chosenCard in chosenCards) {
                chosenCard.isMatched = YES;
            }
            card.isMatched = YES;
            
            // message text
            NSMutableArray *matchedCards = [self matchedCards:chosenCards];
            NSMutableArray *matchedCardsContents = [[NSMutableArray alloc]init];
            for (Card *card in matchedCards) {
                [matchedCardsContents addObject:card.contents];
            }
            NSString *matchedCardTexts = [matchedCardsContents componentsJoinedByString:@", "];
            [self appendMessage:[NSString stringWithFormat:@"matched %@ and got %i points", matchedCardTexts, points]];

        } else {
            self.score -= MISMATCH_PENALTY;
            for (Card *chosenCard in chosenCards) {
                chosenCard.isChosen = NO;
            }
            
            // message text
            [self appendMessage:[NSString stringWithFormat:@"did not match and got %i points penalty", MISMATCH_PENALTY]];
        }
    }
    
    card.isChosen = YES;
}

- (void)appendMessage:message {
    //self.message = [self.message stringByAppendingString:message];
}

- (void)setMessage:message {
    //self.message = message;
}

- (NSInteger)matchingPoints:chosenCards {
    NSInteger points = 0;
    NSMutableArray *checkedCards = [[NSMutableArray alloc]init];
    for(Card *chosenCard in chosenCards) {
        points += [chosenCard match:checkedCards];
        [checkedCards addObject:chosenCard];
    }
    return points;
}

- (NSMutableArray*)matchedCards:chosenCards {
    NSMutableArray *checkedCards = [[NSMutableArray alloc]init];
    NSMutableArray *matchedCards = [[NSMutableArray alloc]init];
    for(Card *chosenCard in chosenCards) {
        if ([chosenCard match:checkedCards]) {
            [matchedCards addObject:chosenCard];
        }
        [checkedCards addObject:chosenCard];
    }
    return matchedCards;
}

@end

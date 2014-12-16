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
        card.isChosen = NO;
        return;
    }
    
    self.score -= COST_TO_CHOOSE;
    
    NSArray *chosenCards = [self chosenCards];
    NSInteger matchCardsCount = self.matchCardsCount ? self.matchCardsCount : 2;
    NSInteger chosenCardsCount = [chosenCards count];
    
    if (matchCardsCount == chosenCardsCount+1) {
        
        NSInteger points = [card match:chosenCards];
        
        if (points) {
            self.score += points * MATCH_BONUS;
            for (Card *card in chosenCards) {
                card.isMatched = YES;
            }
            card.isMatched = YES;
        } else {
            self.score -= MISMATCH_PENALTY;
            for (Card *card in chosenCards) {
                card.isChosen = NO;
            }
        }
    }
    
    card.isChosen = YES;
    
}

@end

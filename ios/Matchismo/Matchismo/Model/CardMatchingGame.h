//
//  CardMatchingGame.h
//  Matchismo
//
//  Created by Margus Pärt on 14/11/14.
//  Copyright (c) 2014 Gravitational Wave OÜ. All rights reserved.
//

#import <Foundation/Foundation.h>

#import "Deck.h"
#import "Card.h"

@interface CardMatchingGame : NSObject

// THIS IS INITIALIZER!
- (instancetype)initWithCardCount:(NSUInteger)count
                        usingDeck:(Deck *)deck
                  matchCardsCount:(NSInteger)matchCardsCount;

- (void)chooseCardAtIndex:(NSUInteger)index;
- (Card *)cardAtIndex:(NSUInteger)index;

@property (nonatomic, readonly) NSInteger score;
@property (nonatomic, readonly) NSString *messageText;
@property (nonatomic) NSInteger matchCardsCount;

@end

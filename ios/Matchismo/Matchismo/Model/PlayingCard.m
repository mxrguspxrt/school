//
//  PlayingCard.m
//  Matchismo
//
//  Created by Margus Pärt on 10/11/14.
//  Copyright (c) 2014 Gravitational Wave OÜ. All rights reserved.
//

#import "PlayingCard.h"

@implementation PlayingCard

- (NSString *) contents {
    return [self.rank stringByAppendingString:self.suit];
}

@synthesize suit = _suit;

+ (NSArray *)validSuits {
    return @[@"♠︎", @"♣︎", @"♥︎", @"♦︎"];
}

+ (NSArray *)rankStrings {
    return @[@"?", @"A", @"2", @"3", @"4", @"5", @"6", @"7", @"8", @"9", @"10", @"J", @"Q", @"K"];
}

- (void)setSuit:(NSString *)suit {
    if ([[PlayingCard validSuits] containsObject:suit]) {
         _suit = suit;
    }
}

- (NSString *)suit {
    return _suit ? _suit : @"?";
}



@end
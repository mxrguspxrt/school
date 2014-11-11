//
//  CardGameViewController.m
//  Matchismo
//
//  Created by Margus Pärt on 10/11/14.
//  Copyright (c) 2014 Gravitational Wave OÜ. All rights reserved.
//

#import "CardGameViewController.h"

#import "PlayingCardDeck.h"
#import "PlayingCard.h"

@interface CardGameViewController ()
@property (weak, nonatomic) IBOutlet UILabel *flipsLabel;
@property (nonatomic) int flipCount;
@property (strong, nonatomic) PlayingCard *playingCard;
@property (strong, nonatomic) PlayingCardDeck *playingCardDeck;
@end

@implementation CardGameViewController

- (IBAction)touchCardButton:(UIButton *)sender {
    if (self.playingCard) {
        self.playingCard = nil;
        [self cardBack:sender];
    } else {
        self.playingCard = [self.playingCardDeck drawRandomCard];
        [self cardFront:sender
                  title:self.playingCard.contents
         ];
    }
    self.flipCount++;
}

- (void)cardFront:(UIButton *)sender title:(NSString *)title {
    UIImage *cardfront = [UIImage imageNamed:@"cardfront"];
    [sender setBackgroundImage:cardfront forState:UIControlStateNormal];
    [sender setTitle:title forState:UIControlStateNormal];
}

- (void)cardBack:(UIButton *)sender {
    UIImage *cardback = [UIImage imageNamed:@"cardback"];
    [sender setBackgroundImage:cardback forState:UIControlStateNormal];
    [sender setTitle:@"" forState:UIControlStateNormal];
}

-(PlayingCardDeck *)playingCardDeck {
    if (!_playingCardDeck) {
        _playingCardDeck = [[PlayingCardDeck alloc] init];
    }
    return _playingCardDeck;
}

-(void)setFlipCount:(int)flipCount {
    _flipCount = flipCount;
    self.flipsLabel.text = [NSString stringWithFormat:@"Flips: %d", self.flipCount];
}

@end

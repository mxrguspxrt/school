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
#import "CardMatchingGame.h"

@interface CardGameViewController ()
@property (strong, nonatomic) CardMatchingGame *game;
@property (strong, nonatomic) IBOutletCollection(UIButton) NSArray *cardButtons;
@property (weak, nonatomic) IBOutlet UILabel *scoreLabel;
@property (nonatomic) NSInteger matchCardsCount;
@end

@implementation CardGameViewController

- (CardMatchingGame *)createNewGame {
    return [[CardMatchingGame alloc] initWithCardCount:[self.cardButtons count]
                                             usingDeck:[self createPlayingCardDeck]
                                       matchCardsCount:[self matchCardsCount]
            ];
}

- (CardMatchingGame *)game {
    if (!_game) {
        _game = [self createNewGame];
    }
    return _game;
}

- (IBAction)touchCardButton:(UIButton *)sender {
    int chosenButtonIndex = [self.cardButtons indexOfObject:sender];
    NSLog(@"Pressed putton at index: %i", chosenButtonIndex);
    [self.game chooseCardAtIndex:chosenButtonIndex];
    [self updateUI];
}

- (void)updateUI {
    for (UIButton *cardButton in self.cardButtons) {
        int cardButtonIndex = [self.cardButtons indexOfObject:cardButton];
        Card *card = [self.game cardAtIndex:cardButtonIndex];
        [cardButton setTitle:[self titleForCard:card] forState:UIControlStateNormal];
        [cardButton setBackgroundImage:[self backgroundImageForCard:card] forState:UIControlStateNormal];
        
        cardButton.enabled = !card.isMatched;
    }
    self.scoreLabel.text = [NSString stringWithFormat:@"Score: %d", self.game.score];
}

- (NSString *)titleForCard:(Card *)card {
    return card.isChosen ? card.contents : @"";
}

- (UIImage *)backgroundImageForCard:(Card *)card {
    NSString *imageName = card.isChosen ? @"cardfront" : @"cardback";
    return [UIImage imageNamed:imageName];
}

-(PlayingCardDeck *)createPlayingCardDeck {
    return [[PlayingCardDeck alloc] init];
}


- (IBAction)redeal:(id)sender {
    _game = [self createNewGame];
    [self updateUI];
}


- (IBAction)changeMode:(UISegmentedControl*)sender {
    if (sender.selectedSegmentIndex==0) {
        self.game.matchCardsCount = self.matchCardsCount = 2;
    } else {
        self.game.matchCardsCount = self.matchCardsCount = 3;
    }
}


@end

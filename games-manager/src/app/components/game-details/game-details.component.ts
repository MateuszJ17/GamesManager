import {Component, OnInit} from '@angular/core';
import {Game} from "../../models/game";
import {ActivatedRoute} from "@angular/router";
import {GameService} from "../../services/game.service";
import {GameViewHistory} from "../../models/game-view-history";

@Component({
  selector: 'app-game-details',
  templateUrl: './game-details.component.html',
  styleUrls: ['./game-details.component.css']
})
export class GameDetailsComponent implements OnInit {

  constructor(private route: ActivatedRoute, private gamesService: GameService) {
  }

  game: Game;
  history: GameViewHistory[] = [];

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      let id = params['id'];
      this.gamesService.getGame(id).subscribe(response => {
        console.log("RESPONSE ", response);
        this.game = response;
        this.gamesService.getGameHistory(id).subscribe(history => {
          console.log("HISTORY", history);
          this.history = history;
          this.history.forEach(e => e.source = 'Web App');
        })
      });
    })
  }

}

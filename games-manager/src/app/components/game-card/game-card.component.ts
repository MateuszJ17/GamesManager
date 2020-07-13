import {Component, EventEmitter, Input, NgZone, OnInit, Output} from '@angular/core';
import {Game} from "../../models/game";
import {GameService} from "../../services/game.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrls: ['./game-card.component.css']
})
export class GameCardComponent implements OnInit {

  @Input()
  game: Game;

  @Output()
  deleted: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor(private zone: NgZone, private gamesService: GameService) { }

  ngOnInit(): void {
  }

  onDelete(id: number) {
    this.gamesService.deleteGame(id).subscribe(response => {
      this.deleted.emit(true);
    });
  }

}

import {Component, NgZone, OnInit} from '@angular/core';
import {GameService} from "../../services/game.service";
import {Game} from "../../models/game";
import {Router} from "@angular/router";

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  games: Game[] = [];

  constructor(private gameService: GameService, private router: Router, private zone: NgZone) { }

  ngOnInit(): void {
    this.fetchGames();
  }

  addClick() {
    this.router.navigateByUrl('/add');
  }

  handleDelete(event: boolean) {
    if (event) {
      this.fetchGames();
    }
  }

  fetchGames() {
    this.gameService.getGames().subscribe(result => {
      this.games = [];
      this.games = result;
    });
  }

}

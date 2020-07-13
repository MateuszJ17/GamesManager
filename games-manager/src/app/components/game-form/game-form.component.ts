import {Component, Input, OnInit} from '@angular/core';
import {GameService} from "../../services/game.service";
import {ActivatedRoute, Router} from "@angular/router";
import {Game} from "../../models/game";

@Component({
  selector: 'app-game-form',
  templateUrl: './game-form.component.html',
  styleUrls: ['./game-form.component.css']
})
export class GameFormComponent implements OnInit {

  isEdit: boolean = false;

  gameToEdit: Game;

  name: string;
  minPlayers: number;
  maxPlayers: number;
  minAge: number;

  constructor(private gameService: GameService, private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      if (params['id']) {
        console.log("EDIT MODE")
        let id = params['id'];
        this.isEdit = true;

        this.gameService.getGame(id).subscribe(response => {
          this.gameToEdit = response;

          this.name = this.gameToEdit.name;
          this.minPlayers = this.gameToEdit.minPlayers;
          this.maxPlayers = this.gameToEdit.maxPlayers;
          this.minAge = this.gameToEdit.minAge;
        });
      }
    })
  }

  onSubmit() {
    console.log("name ", this.name);
    console.log("minPlayers ", this.minPlayers);
    console.log("maxPlayers ", this.maxPlayers);
    console.log("minAge ", this.minAge);

    if (this.isEdit) {
      this.submitEdit()
    } else {
      this.submitAdd();
    }
  }

  submitAdd() {
    this.gameService.createGame({
      name: this.name,
      maxPlayers: this.maxPlayers,
      minPlayers: this.minPlayers,
      minAge: this.minAge
    }).subscribe(response => {
      this.router.navigateByUrl(`/details/${response.id}`);
    });
  }

  submitEdit() {
    this.gameService.updateGame(this.gameToEdit.id, {
      name: this.name,
      maxPlayers: this.maxPlayers,
      minPlayers: this.minPlayers,
      minAge: this.minAge
    }).subscribe(response => {
      this.router.navigateByUrl(`/`);
    });
  }

}

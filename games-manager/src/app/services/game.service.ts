import { Injectable } from '@angular/core';
import { environment } from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Game} from "../models/game";
import {GameViewHistory} from "../models/game-view-history";

@Injectable({
  providedIn: 'root'
})
// @ts-ignore
export class GameService {

  constructor(private httpClient: HttpClient) { }

  getGames(): Observable<Game[]> {
    return this.httpClient.get<Game[]>(`${environment.apiAddress}/games`);
  }

  getGame(id: number): Observable<Game> {
    return this.httpClient.get<Game>(`${environment.apiAddress}/games/${id}`);
  }

  getGameHistory(id: number): Observable<GameViewHistory[]> {
    return this.httpClient.get<GameViewHistory[]>(`${environment.apiAddress}/games/${id}/history`);
  }

  createGame(game: Game): Observable<Game> {
    return this.httpClient.post<Game>(`${environment.apiAddress}/games`, game);
  }

  updateGame(id: number, game: Game): Observable<Game> {
    return this.httpClient.put<Game>(`${environment.apiAddress}/games/${id}`, game);
  }

  deleteGame(id: number): Observable<Game> {
    return this.httpClient.delete<Game>(`${environment.apiAddress}/games/${id}`);
  }
}

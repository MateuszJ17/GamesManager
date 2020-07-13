import {Game} from "./game";

export interface GameViewHistory {
  id?: number;
  date: Date;
  gameId: number;

  game?: Game;
  source?: string;
}

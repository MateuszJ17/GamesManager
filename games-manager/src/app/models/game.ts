import {GameViewHistory} from "./game-view-history";

export interface Game {
  id?: number;
  name: string;
  minPlayers: number;
  maxPlayers: number;
  minAge: number;
  source?: string;

  gameViewHistories?: GameViewHistory[];
}


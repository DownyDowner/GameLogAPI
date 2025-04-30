export class GameCompletedListDTO {
  id = "";
  title = "";
  platform = "";
  releaseDate = "";
  completedOn = "";
}

export class GameCompletedList extends GameCompletedListDTO {
  constructor(data: GameCompletedList | GameCompletedListDTO | null) {
    super();
    if (data) Object.assign(this, data);
  }
}

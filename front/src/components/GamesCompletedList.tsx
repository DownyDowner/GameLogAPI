import { mdiClose, mdiMinus, mdiWindowMaximize } from "@mdi/js";
import Icon from "@mdi/react";
import { getGamesCompleted } from "../apis/GameApi";
import { useEffect, useState } from "react";
import { GameCompletedList } from "../models/GameCompletedList";

function GamesCompletedList() {
  const [games, setGames] = useState<GameCompletedList[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getGamesCompleted();
        setGames(data);
      } catch (err) {
        setError("Une erreur est survenue.");
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  const formatDate = (dateString: string) => {
    const date = new Date(dateString);
    const day = String(date.getDate()).padStart(2, "0"); // Ajoute un 0 si le jour est inférieur à 10
    const month = String(date.getMonth() + 1).padStart(2, "0"); // Mois commence à 0, donc on ajoute 1
    const year = date.getFullYear();

    return `${day}/${month}/${year}`;
  };

  if (loading) return <div>Chargement...</div>;
  if (error) return <div>{error}</div>;

  return (
    <div className="xp-window p-2 mt-2 w-75">
      <div className="xp-title-bar d-flex justify-content-between align-items-center">
        <span>Mes Jeux Complétés</span>
        <div>
          <button className="xp-title-button btn btn-sm p-0 mx-1">
            <Icon path={mdiMinus} size={0.6} />
          </button>
          <button className="xp-title-button btn btn-sm p-0 mx-1">
            <Icon path={mdiWindowMaximize} size={0.6} />
          </button>
          <button className="xp-title-button btn btn-sm p-0 mx-1 xp-close-button">
            <Icon path={mdiClose} size={0.6} />
          </button>
        </div>
      </div>
      <ul className="d-flex flex-column justify-content-center align-items-center gap-2 px-3 mt-2">
        {games.length > 0 ? (
          games.map((game) => (
            <li
              key={game.id}
              className="xp-button w-50"
              onClick={() =>
                console.log(
                  `You clicked : ${game.title} - ${game.platform} - ${game.completedOn}`
                )
              }
            >
              {game.title} - {game.platform} - {formatDate(game.completedOn)}
            </li>
          ))
        ) : (
          <li className="list-unstyled">Pas de Jeux référencés</li>
        )}
      </ul>
    </div>
  );
}

export default GamesCompletedList;

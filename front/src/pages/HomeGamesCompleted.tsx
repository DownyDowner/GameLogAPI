import { getGamesCompleted } from "../apis/GameApi";
import { useEffect, useState } from "react";
import { GameCompletedList } from "../models/GameCompletedList";
import XpWindow from "../components/XpWindow";

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
    const day = String(date.getDate()).padStart(2, "0");
    const month = String(date.getMonth() + 1).padStart(2, "0");
    const year = date.getFullYear();

    return `${day}/${month}/${year}`;
  };

  if (loading) return <div>Chargement...</div>;
  if (error) return <div>{error}</div>;

  return (
    <XpWindow title="Mes Jeux Complétés">
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
    </XpWindow>
  );
}

export default GamesCompletedList;

import { useEffect, useState } from "react";
import { getPlatforms } from "../../apis/PlatformApi";
import { PlatformList } from "../../models/PlatformList";
import { Navigate } from "react-router-dom";
import { ROUTES } from "../../router/Routes";
import Loader from "../../components/Loader";

function Platforms() {
  const [platforms, setPlatforms] = useState<PlatformList[] | null>(null);
  const [isLoading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    getPlatforms()
      .then((platforms) => {
        setPlatforms(platforms);
        setLoading(false);
      })
      .catch((err) => {
        setError(err);
        setLoading(false);
      });
  }, []);

  if (isLoading) return <Loader />;
  if (error) return <Navigate to={ROUTES.HOME} replace />;

  return (
    <div className="container">
      {platforms && platforms.length > 0 ? (
        <ol className="list-group">
          {platforms.map((platform) => (
            <li
              key={platform.id}
              className="list-group-item d-flex justify-content-between align-items-start"
            >
              <div>{platform.name}</div>
            </li>
          ))}
        </ol>
      ) : (
        <p>No platforms found.</p>
      )}
    </div>
  );
}

export default Platforms;

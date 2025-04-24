import { useEffect, useState } from "react";
import { getPlatforms } from "../../apis/PlatformApi";

function Platforms() {
  const [platforms, setPlatforms] = useState(null);
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

  if (isLoading) return <p>Loading...</p>;
  if (error) return <p>Error loading data!</p>;

  return <p>Data Loaded</p>;
}

export default Platforms;

import { useEffect, useState } from "react";
import { getPlatforms } from "../../apis/PlatformApi";
import { PlatformList } from "../../models/PlatformList";
import { Navigate } from "react-router-dom";
import { ROUTES } from "../../router/Routes";
import Loader from "../../components/Loader";
import { motion } from "framer-motion";

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

  const handleClick = (platform: PlatformList) => {
    console.log(`You clicked on ${platform.name}`);
  };

  if (isLoading) return <Loader />;
  if (error) return <Navigate to={ROUTES.HOME} replace />;

  return (
    <div className="container mt-1">
      {platforms && platforms.length > 0 ? (
        <ol className="list-group">
          {platforms.map((platform) => (
            <motion.li
              key={platform.id}
              className="list-group-item d-flex justify-content-center align-items-center text-center mb-2 rounded"
              whileHover={{
                scale: 1.03,
                y: -2,
                transition: { duration: 0.15 },
              }}
              whileTap={{ scale: 0.98, y: 2, transition: { duration: 0.1 } }}
              onClick={() => handleClick(platform)}
            >
              <div>{platform.name}</div>
            </motion.li>
          ))}
        </ol>
      ) : (
        <p>No platforms found.</p>
      )}
    </div>
  );
}

export default Platforms;

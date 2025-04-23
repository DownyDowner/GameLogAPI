import { motion } from "framer-motion";
import { useNavigate } from "react-router-dom";
import { ROUTES } from "../router/Routes";

function Home() {
  const navigate = useNavigate();

  const handleGoToPlatforms = () => {
    navigate(ROUTES.PLATFORMS);
  };

  return (
    <div className="d-lg-flex justify-content-lg-center align-items-lg-center min-vh-100">
      <motion.div
        animate={{ scale: 1 }}
        initial={{ scale: 0 }}
        className="card text-center"
      >
        <div className="card-title h2 text-primary">GameLog</div>
        <div className="card-body">
          <p className="card-text">
            <b>GameLog</b> helps you stay organized with your video game
            collection.
          </p>
          <p className="card-text">
            Keep track of the games you're currently playing, those you've
            finished, paused, or plan to play in the future.
          </p>
          <p className="card-text">
            You can rate and review games, and even save the dates you started
            or completed them — all in one place.
          </p>
          <p className="card-text">
            It's your personal gaming journal, designed to keep things simple
            and fun.
          </p>
          <div className="text-center mt-4">
            <button
              className="btn btn-primary mx-2"
              onClick={handleGoToPlatforms}
            >
              Platforms
            </button>
            <button
              className="btn btn-secondary mx-2"
              onClick={() => console.log("Games")}
            >
              Games
            </button>
          </div>
        </div>
      </motion.div>
    </div>
  );
}

export default Home;

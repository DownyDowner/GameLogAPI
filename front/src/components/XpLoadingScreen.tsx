import XpImage from "../assets/xp-loading.png";

function XpLoadingScreen() {
  const blockCount = 10;
  return (
    <div className="xp-loading-screen d-flex flex-column justify-content-center align-items-center p-3">
      <img src={XpImage} alt="Windows XP Logo" className="xp-logo" />
      <div className="xp-progress-bar d-flex justify-content-center gap-1 mt-3">
        {[...Array(blockCount)].map((_, index) => (
          <div
            key={index}
            className="xp-progress-block"
            style={{ animationDelay: `${index * 0.3}s` }}
          ></div>
        ))}
      </div>
    </div>
  );
}

export default XpLoadingScreen;

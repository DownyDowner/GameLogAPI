import { motion } from "framer-motion";
const loaderVariants = {
  animationOne: {
    x: [-20, 20],
    y: [0, -30],
    transition: {
      x: {
        repeat: Infinity,
        repeatType: "reverse",
        duration: 0.5,
      },
      y: {
        repeat: Infinity,
        repeatType: "reverse",
        duration: 0.25,
        ease: "easeOut",
      },
    },
  },
};

function Loader() {
  return (
    <div className="d-flex justify-content-center align-items-center min-vh-100">
      <motion.div
        className="loader"
        variants={loaderVariants}
        animate="animationOne"
        color="primary"
      />
    </div>
  );
}

export default Loader;

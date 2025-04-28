import { Navigate, RouteObject } from "react-router-dom";
import Home from "../pages/Home";
import Platforms from "../pages/platforms/Platforms";
import Layout from "../layouts/Layout";
import Games from "../pages/games/Games";

export const ROUTES = {
  HOME: "/",
  PLATFORMS: "/platforms",
  GAMES: "/games",
};

const routes: RouteObject[] = [
  {
    path: ROUTES.HOME,
    element: <Home />,
  },
  {
    path: ROUTES.PLATFORMS,
    element: (
      <Layout>
        <Platforms />
      </Layout>
    ),
  },
  {
    path: ROUTES.GAMES,
    element: (
      <Layout>
        <Games />
      </Layout>
    ),
  },
  {
    path: "*",
    element: <Navigate to={ROUTES.HOME} replace />,
  },
];

export default routes;

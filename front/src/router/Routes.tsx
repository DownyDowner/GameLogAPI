import { RouteObject } from "react-router-dom";
import Home from "../pages/Home";
import Platforms from "../pages/platforms/Platforms";

export const ROUTES = {
  HOME: "/",
  PLATFORMS: "/platforms",
};

const routes: RouteObject[] = [
  {
    path: ROUTES.HOME,
    element: <Home />,
  },
  {
    path: ROUTES.PLATFORMS,
    element: <Platforms />,
  },
];

export default routes;

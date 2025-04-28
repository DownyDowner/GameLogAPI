import { Navigate, RouteObject } from "react-router-dom";
import Home from "../pages/Home";

export const ROUTES = {
  HOME: "/DownyDowner",
};

const routes: RouteObject[] = [
  {
    path: ROUTES.HOME,
    element: <Home />,
  },
  {
    path: "*",
    element: <Navigate to={ROUTES.HOME} replace />,
  },
];

export default routes;

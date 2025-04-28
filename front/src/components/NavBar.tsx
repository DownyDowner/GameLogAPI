import { Link } from "react-router-dom";
import { ROUTES } from "../router/Routes";
import Icon from "@mdi/react";
import { mdiHome, mdiGamepadVariant, mdiMonitor } from "@mdi/js";

function NavBar() {
  const navItems = [
    { path: ROUTES.HOME, icon: mdiHome, label: "Home" },
    { path: ROUTES.GAMES, icon: mdiGamepadVariant, label: "Games" },
    { path: ROUTES.PLATFORMS, icon: mdiMonitor, label: "Platforms" },
  ];

  return (
    <>
      {/* Sidebar for md and more */}
      <div className="d-none d-md-flex flex-column bg-primary text-white postion-fixed p-4 vh-100">
        <div className="text-center mb-4 d-none d-lg-block">
          <h5 className="text-white">GameLog</h5>
        </div>
        {navItems.map((item) => (
          <Link
            to={item.path}
            key={item.path}
            className="text-white text-decoration-none d-flex align-items-center mb-3"
          >
            <Icon path={item.icon} size={1} />
            <span className="ms-2 d-none d-lg-inline">{item.label}</span>
          </Link>
        ))}
      </div>

      {/* Bottom nav mobile */}
      <div className="d-flex d-md-none justify-content-around bg-primary text-white py-2 fixed-bottom border-top">
        {navItems.map((item) => (
          <Link
            key={item.path}
            to={item.path}
            className="text-white text-decoration-none d-flex align-items-center"
          >
            <Icon path={item.icon} size={1} />
          </Link>
        ))}
      </div>
    </>
  );
}

export default NavBar;
